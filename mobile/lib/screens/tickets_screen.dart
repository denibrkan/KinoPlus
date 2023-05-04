import 'package:barcode_widget/barcode_widget.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/ticket.dart';
import 'package:mobile/providers/ticket_provider.dart';
import 'package:mobile/providers/user_provider.dart';
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
      showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
                title: const Text("Niste prijavljeni"),
                content: Text(e.toString().substring(11)),
                actions: [
                  TextButton(
                    child: const Text("Ok"),
                    onPressed: () => Navigator.pop(context),
                  )
                ],
              ));
    }
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: [
          _buildHeader(),
          Container(
            constraints: const BoxConstraints(minHeight: 300),
            child: _buildTickets(),
          ),
        ],
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
    return Container(
      margin: const EdgeInsets.symmetric(horizontal: 20, vertical: 30),
      child: Column(
        children: tickets
            .map(
              (t) => Container(
                margin: const EdgeInsets.only(bottom: 20),
                child: Column(
                  children: [
                    ClipRRect(
                      borderRadius: const BorderRadius.only(
                        topLeft: Radius.circular(12),
                        topRight: Radius.circular(12),
                      ),
                      child: FadeInImage.memoryNetwork(
                        placeholder: kTransparentImage,
                        image: '$apiUrl/images/${t.movieImageId}?original=true',
                        height: 210,
                        width: MediaQuery.of(context).size.width,
                        fadeInDuration: const Duration(milliseconds: 300),
                        fit: BoxFit.cover,
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
                        height: 80,
                        textPadding: 12,
                        style: TextStyle(color: primary.shade800),
                      ),
                    ),
                  ],
                ),
              ),
            )
            .toList(),
      ),
    );
  }

  Widget _buildHeader() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Container(
          margin: const EdgeInsets.only(left: 16, top: 20, bottom: 8),
          child: const Text(
            'Ulaznice',
            style: TextStyle(
              fontSize: 20,
            ),
          ),
        ),
        const Divider(
          height: 2,
          color: Colors.grey,
        ),
      ],
    );
  }
}
