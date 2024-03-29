import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/projection.dart';
import 'package:mobile/models/seat.dart';
import 'package:mobile/providers/seat_provider.dart';
import 'package:mobile/providers/ticket_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/payment_screen.dart';
import 'package:mobile/utils/authorization.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class SeatsScreen extends StatefulWidget {
  final Projection projection;

  const SeatsScreen({super.key, required this.projection});

  static const String routeName = '/seats';

  @override
  State<SeatsScreen> createState() => _SeatsScreenState();
}

class _SeatsScreenState extends State<SeatsScreen> {
  var seats = <Seat>[];
  var takenSeatIds = <int>[];
  var selectedSeats = <Seat>[];

  late SeatProvider seatProvider;
  late UserProvider userProvider;
  late TicketProvider ticketProvider;

  @override
  void initState() {
    super.initState();
    seatProvider = context.read<SeatProvider>();
    userProvider = context.read<UserProvider>();
    ticketProvider = context.read<TicketProvider>();

    takenSeatIds = widget.projection.tickets.map((t) => t.seatId).toList();

    load();
  }

  updateTicketProvider() {
    ticketProvider.setSelectedSeats(selectedSeats);
    ticketProvider.setProjection(widget.projection);
  }

  void load() async {
    var data = await seatProvider.get(null);
    var seatsData = data.map<Seat>(
      (s) {
        var seat = Seat(id: s.id, number: s.number, row: s.row);
        if (takenSeatIds.any((id) => id == s.id)) {
          seat.isTaken = true;
        }
        return seat;
      },
    ).toList();
    setState(() {
      seats = seatsData;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: SingleChildScrollView(
          child: Column(
            children: [
              _buildProjectionHeader(),
              const Divider(
                height: 2,
                color: Colors.grey,
              ),
              const SizedBox(
                height: 40,
              ),
              _buildCinemaScreen(),
              Container(
                constraints: const BoxConstraints(minHeight: 300),
                margin:
                    const EdgeInsets.symmetric(horizontal: 40, vertical: 50),
                child: seats.isNotEmpty
                    ? GridView.count(
                        shrinkWrap: true,
                        crossAxisCount: 10,
                        crossAxisSpacing: 15,
                        mainAxisSpacing: 25,
                        primary: false,
                        children: _buildSeats(),
                      )
                    : const Center(
                        child: CircularProgressIndicator(
                          color: Colors.lightBlueAccent,
                        ),
                      ),
              ),
              const Divider(
                height: 2,
                color: Colors.grey,
              ),
              _buildInfoBoxes(),
              _buildBottomBar(),
            ],
          ),
        ),
      ),
    );
  }

  List<Widget> _buildSeats() {
    return seats.map((s) {
      return InkWell(
        onTap: () {
          if (s.isTaken) {
            return;
          }
          if (!selectedSeats.contains(s)) {
            selectedSeats.add(s);
          } else {
            selectedSeats.remove(s);
          }
          setState(() {
            s.isSelected = !s.isSelected;
          });
        },
        child: Container(
          height: 12,
          width: 12,
          decoration: BoxDecoration(
            color: s.isTaken
                ? Colors.grey
                : s.isSelected
                    ? Colors.lightBlueAccent
                    : null,
            border: Border.all(color: Colors.grey),
            borderRadius: BorderRadius.circular(4),
          ),
        ),
      );
    }).toList();
  }

  Widget _buildInfoBoxes() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Container(
          margin: const EdgeInsets.symmetric(horizontal: 20, vertical: 30),
          child: Column(
            children: [
              Container(
                height: 25,
                width: 25,
                decoration: BoxDecoration(
                  border: Border.all(color: Colors.grey),
                  borderRadius: BorderRadius.circular(4),
                ),
              ),
              const SizedBox(
                height: 8,
              ),
              const Text(
                'Slobodno',
              )
            ],
          ),
        ),
        Container(
          margin: const EdgeInsets.symmetric(horizontal: 20, vertical: 30),
          child: Column(
            children: [
              Container(
                height: 25,
                width: 25,
                decoration: BoxDecoration(
                  color: Colors.grey,
                  border: Border.all(color: Colors.grey),
                  borderRadius: BorderRadius.circular(4),
                ),
              ),
              const SizedBox(
                height: 8,
              ),
              const Text(
                'Zauzeto',
              )
            ],
          ),
        ),
        Container(
          margin: const EdgeInsets.symmetric(horizontal: 20, vertical: 30),
          child: Column(
            children: [
              Container(
                height: 25,
                width: 25,
                decoration: BoxDecoration(
                  color: Colors.lightBlueAccent,
                  border: Border.all(color: Colors.grey),
                  borderRadius: BorderRadius.circular(4),
                ),
              ),
              const SizedBox(
                height: 8,
              ),
              const Text(
                'Odabrano',
              )
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildProjectionHeader() {
    return Container(
      margin: const EdgeInsets.symmetric(vertical: 16),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Container(
              margin: const EdgeInsets.only(right: 20),
              width: 40,
              height: 50,
              child: widget.projection.movie.imageId != null
                  ? FadeInImage(
                      placeholder: MemoryImage(kTransparentImage),
                      image: NetworkImage(
                        '$apiUrl/images/${widget.projection.movie.imageId}',
                        headers: Authorization.createHeaders(),
                      ),
                      fadeInDuration: const Duration(milliseconds: 300),
                      fit: BoxFit.fill,
                    )
                  : const Placeholder()),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                widget.projection.movie.title,
                style:
                    const TextStyle(fontSize: 18, fontWeight: FontWeight.w600),
              ),
              Text(
                '${DateFormat.Hm().format(widget.projection.startsAt)} - ${DateFormat.Hm().format(widget.projection.endsAt)}  |  ${DateFormat.MMMMEEEEd('bs').format(widget.projection.startsAt)}',
                style: const TextStyle(
                  color: Colors.grey,
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _buildCinemaScreen() {
    return Container(
      height: 12,
      width: 350,
      decoration: const BoxDecoration(
        color: lightGrayColor,
        borderRadius: BorderRadius.vertical(
          top: Radius.elliptical(400, 100),
        ),
      ),
    );
  }

  Widget _buildBottomBar() {
    if (selectedSeats.isEmpty) return Container();
    return Container(
      height: 100,
      color: darkSecondaryColor,
      padding: const EdgeInsets.all(16),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          SizedBox(
            width: MediaQuery.of(context).size.width * 0.5,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                Text(
                  'Sjedište: ${selectedSeats.join(', ')}'.toUpperCase(),
                  style: const TextStyle(
                    fontSize: 13,
                    fontWeight: FontWeight.w700,
                    color: Colors.grey,
                  ),
                ),
                const SizedBox(
                  height: 8,
                ),
                Text(
                  NumberFormat.currency(locale: 'bs')
                      .format(widget.projection.price * selectedSeats.length),
                  style: const TextStyle(
                      color: Colors.amber,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ],
            ),
          ),
          SizedBox(
            width: 150,
            height: 50,
            child: ElevatedButton(
              onPressed: () {
                updateTicketProvider();
                Navigator.pushNamed(context, PaymentScreen.routeName);
              },
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all(redButtonColor),
                shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                  RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(8.0),
                  ),
                ),
              ),
              child: const Text(
                'Potvrdi',
                style: TextStyle(
                  fontSize: 18,
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
