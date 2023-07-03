import 'dart:convert';

import 'package:adaptive_theme/adaptive_theme.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:http/http.dart' as http;
import 'package:intl/intl.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/providers/seat_provider.dart';
import 'package:mobile/providers/ticket_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/profile_screen.dart';
import 'package:mobile/screens/reservation_success.dart';
import 'package:mobile/utils/authorization.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class PaymentScreen extends StatefulWidget {
  static const String routeName = 'payment';

  const PaymentScreen({super.key});

  @override
  State<PaymentScreen> createState() => _PaymentScreenState();
}

class _PaymentScreenState extends State<PaymentScreen> {
  late SeatProvider seatProvider;
  late UserProvider userProvider;
  late TicketProvider ticketProvider;

  @override
  void initState() {
    super.initState();
    seatProvider = context.read<SeatProvider>();
    userProvider = context.read<UserProvider>();
    ticketProvider = context.read<TicketProvider>();
  }

  showPaymentSheet() async {
    var paymentIntentData = await createPaymentIntent(
        (ticketProvider.selectedTicketTotalPrice * 100).round().toString(),
        'BAM');
    await Stripe.instance
        .initPaymentSheet(
            paymentSheetParameters: SetupPaymentSheetParameters(
                paymentIntentClientSecret: paymentIntentData!['client_secret'],
                merchantDisplayName: 'KinoPlus'))
        .then((value) {})
        .onError((error, stackTrace) {
      showDialog(
          context: context,
          builder: (_) => const AlertDialog(
                content: Text("Poništena transakcija"),
              ));
    });

    try {
      await Stripe.instance.presentPaymentSheet();

      await reservate();
    } catch (e) {
      //silent
    }
  }

  createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
          Uri.parse('https://api.stripe.com/v1/payment_intents'),
          body: body,
          headers: {
            'Authorization': 'Bearer $stripeSecretKey',
            'Content-Type': 'application/x-www-form-urlencoded'
          });
      return jsonDecode(response.body);
    } catch (err) {
      print('err charging user: ${err.toString()}');
    }
  }

  Future reservate() async {
    if (userProvider.user == null) {
      Navigator.pushNamed(context, ProfileScreen.routeName);
      return;
    }
    try {
      final tickets = <Map>[];
      for (var seat in ticketProvider.selectedSeats) {
        tickets.add({
          'userId': userProvider.user!.id,
          'projectionId': ticketProvider.projection!.id,
          'seatId': seat.id
        });
      }
      await ticketProvider.insert(tickets);

      userProvider.refreshUser();
      if (mounted) {
        Navigator.pushNamedAndRemoveUntil(
            context, ReservationSuccessScreen.routeName, (route) => false);
      }
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: AppBar(
          title: const Text('Kupovina'),
        ),
        body: Column(
          children: [
            Expanded(
              child: Align(
                alignment: Alignment.topCenter,
                child: Container(
                    padding: const EdgeInsets.all(16),
                    margin: const EdgeInsets.symmetric(
                        vertical: 100, horizontal: 12),
                    decoration: BoxDecoration(
                        color: AdaptiveTheme.of(context).mode ==
                                AdaptiveThemeMode.dark
                            ? darkSecondaryColor
                            : Colors.white,
                        borderRadius:
                            const BorderRadius.all(Radius.circular(6))),
                    child: Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        SizedBox(
                          width: 100,
                          child: ClipRRect(
                            borderRadius: BorderRadius.circular(6),
                            child: FadeInImage(
                              placeholder: MemoryImage(kTransparentImage),
                              image: NetworkImage(
                                '$apiUrl/images/${ticketProvider.projection!.movie.imageId}?original=true',
                                headers: Authorization.createHeaders(),
                              ),
                              fadeInDuration: const Duration(milliseconds: 300),
                              fit: BoxFit.fill,
                            ),
                          ),
                        ),
                        const SizedBox(
                          width: 20,
                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 8),
                          child: Column(
                            mainAxisSize: MainAxisSize.min,
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(
                                ticketProvider.projection!.movie.title,
                                style: const TextStyle(
                                    fontSize: 18, fontWeight: FontWeight.w600),
                              ),
                              const SizedBox(
                                height: 12,
                              ),
                              Text(
                                '${ticketProvider.projection!.location.name} - ${ticketProvider.projection!.hall.name} - ${ticketProvider.projection!.projectionType?.name}',
                                style: const TextStyle(
                                  color: Colors.grey,
                                ),
                              ),
                              const SizedBox(
                                height: 6,
                              ),
                              Text(
                                '${DateFormat.Hm().format(ticketProvider.projection!.startsAt)} - ${DateFormat.Hm().format(ticketProvider.projection!.endsAt)}',
                                style: const TextStyle(
                                  color: Colors.grey,
                                ),
                              ),
                              const SizedBox(
                                height: 6,
                              ),
                              Text(
                                DateFormat.MMMMEEEEd('bs').format(
                                    ticketProvider.projection!.startsAt),
                                style: const TextStyle(
                                  color: Colors.grey,
                                ),
                              ),
                              const SizedBox(
                                height: 6,
                              ),
                              Text(
                                'Sjedište ${ticketProvider.selectedSeats.join(', ').toString()}',
                                style: const TextStyle(
                                  color: Colors.grey,
                                ),
                              ),
                            ],
                          ),
                        ),
                      ],
                    )),
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 10),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const Text(
                    'Ukupno',
                    style: TextStyle(
                      color: Colors.grey,
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  Text(
                    NumberFormat.currency(locale: 'bs')
                        .format(ticketProvider.selectedTicketTotalPrice),
                    style: const TextStyle(
                        color: Colors.amber,
                        fontWeight: FontWeight.bold,
                        fontSize: 18),
                  ),
                ],
              ),
            ),
            Container(
              margin: const EdgeInsets.symmetric(horizontal: 8, vertical: 20),
              width: double.infinity,
              height: 50,
              child: ElevatedButton(
                  onPressed: () async => await showPaymentSheet(),
                  style: ElevatedButton.styleFrom(
                      backgroundColor: const Color(0xFFE51937)),
                  child: const Text(
                    'Plaćanje',
                    style: TextStyle(fontSize: 18),
                  )),
            )
          ],
        ),
      ),
    );
  }
}
