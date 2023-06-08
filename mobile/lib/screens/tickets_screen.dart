import 'package:barcode_widget/barcode_widget.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/ticket.dart';
import 'package:mobile/providers/ticket_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/utils/authorization.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class TicketsScreen extends StatefulWidget {
  const TicketsScreen({super.key});

  static const String routeName = '/tickets';

  @override
  State<TicketsScreen> createState() => _TicketsScreenState();
}

class _TicketsScreenState extends State<TicketsScreen> {
  List<Ticket> tickets = <Ticket>[];

  bool loading = false;

  late TicketProvider ticketProvider;
  late UserProvider userProvider;

  @override
  void initState() {
    super.initState();

    ticketProvider = context.read<TicketProvider>();
    userProvider = context.read<UserProvider>();

    loadData();
  }

  void loadData() async {
    loading = true;
    try {
      if (userProvider.user == null) {
        loading = false;
        return;
      }
      var params = <String, String>{
        'userId': userProvider.user!.id.toString(),
      };
      var data = await ticketProvider.get(params);

      setState(() {
        tickets = data;
      });

      loading = false;
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Ulaznice'),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              constraints: const BoxConstraints(minHeight: 300),
              child: _buildTickets(),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildTickets() {
    if (loading) {
      return const Center(
        child: CircularProgressIndicator(
          color: Colors.lightBlueAccent,
        ),
      );
    } else if (tickets.isEmpty) {
      return const Center(child: Text('Prazno :('));
    }
    return Center(
      child: Container(
        margin: const EdgeInsets.symmetric(
          horizontal: 20,
        ),
        child: CarouselSlider(
          options: CarouselOptions(
            scrollDirection: Axis.vertical,
            enableInfiniteScroll: false,
            viewportFraction: 0.8,
            enlargeCenterPage: true,
            enlargeFactor: 0.3,
            enlargeStrategy: CenterPageEnlargeStrategy.scale,
            height: MediaQuery.of(context).size.height -
                ((kToolbarHeight * 2) + kBottomNavigationBarHeight),
          ),
          items: tickets
              .map(
                (t) => Column(
                  children: [
                    ClipRRect(
                      borderRadius: const BorderRadius.only(
                        topLeft: Radius.circular(12),
                        topRight: Radius.circular(12),
                      ),
                      child: t.movieImageId != null
                          ? FadeInImage(
                              image: NetworkImage(
                                '$apiUrl/images/${t.movieImageId}?original=true',
                                headers: Authorization.createHeaders(),
                              ),
                              placeholder: MemoryImage(kTransparentImage),
                              height: 250,
                              width: MediaQuery.of(context).size.width,
                              fadeInDuration: const Duration(milliseconds: 300),
                              fit: BoxFit.cover,
                            )
                          : const Placeholder(
                              fallbackHeight: 270,
                            ),
                    ),
                    Container(
                      color: const Color(0xFF2B3543),
                      padding: const EdgeInsets.only(
                          top: 12, left: 22, right: 22, bottom: 20),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Center(
                              child: Text(t.movieTitle,
                                  style: const TextStyle(fontSize: 18))),
                          const SizedBox(
                            height: 6,
                          ),
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              const Text(
                                'KINO',
                                style: TextStyle(
                                  color: Colors.grey,
                                  fontSize: 12,
                                ),
                              ),
                              const SizedBox(
                                height: 4,
                              ),
                              Text(
                                '${t.location.name} - ${t.location.city.name}',
                              ),
                            ],
                          ),
                          const SizedBox(
                            height: 8,
                          ),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  const Text(
                                    'DATUM',
                                    style: TextStyle(
                                      color: Colors.grey,
                                      fontSize: 12,
                                    ),
                                  ),
                                  const SizedBox(
                                    height: 4,
                                  ),
                                  Text(
                                    DateFormat.yMMMd('bs').format(
                                        DateTime.parse(t.projectionStart)),
                                  ),
                                ],
                              ),
                              SizedBox(
                                width: 100,
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    const Text(
                                      'VRIJEME',
                                      style: TextStyle(
                                        color: Colors.grey,
                                        fontSize: 12,
                                      ),
                                    ),
                                    const SizedBox(
                                      height: 4,
                                    ),
                                    Text(
                                      '${DateFormat.Hm('bs').format(DateTime.parse(t.projectionStart))} - ${DateFormat.Hm('bs').format(DateTime.parse(t.projectionEnd))}',
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                          const SizedBox(
                            height: 8,
                          ),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  const Text(
                                    'DVORANA',
                                    style: TextStyle(
                                      color: Colors.grey,
                                      fontSize: 12,
                                    ),
                                  ),
                                  const SizedBox(
                                    height: 4,
                                  ),
                                  Text(
                                    t.hall.name,
                                  ),
                                ],
                              ),
                              SizedBox(
                                width: 100,
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    const Text(
                                      'SJEDIŠTE',
                                      style: TextStyle(
                                        color: Colors.grey,
                                        fontSize: 12,
                                      ),
                                    ),
                                    const SizedBox(
                                      height: 4,
                                    ),
                                    Text(
                                      t.seat.toString(),
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ],
                      ),
                    ),
                    Container(
                      padding: const EdgeInsets.symmetric(
                          vertical: 12, horizontal: 20),
                      decoration: const BoxDecoration(
                          color: Colors.white,
                          borderRadius: BorderRadius.only(
                              bottomLeft: Radius.circular(12),
                              bottomRight: Radius.circular(12))),
                      child: BarcodeWidget(
                        barcode: Barcode.code128(escapes: true),
                        data: 'Ticket ${t.id}',
                        height: 100,
                        textPadding: 12,
                        style: TextStyle(color: primary.shade800),
                      ),
                    ),
                  ],
                ),
              )
              .toList(),
        ),
      ),
    );
  }
}
