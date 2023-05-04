import 'package:flutter/material.dart';
import 'package:mobile/screens/tickets_screen.dart';

class ReservationSuccessScreen extends StatelessWidget {
  static const routeName = '/reservation-success';

  const ReservationSuccessScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Center(
          child: Column(
            children: [
              Container(
                margin: const EdgeInsets.only(top: 150),
                padding: const EdgeInsets.all(25),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(8),
                  color: const Color(0xFF2B3543),
                ),
                child: Column(
                  children: const [
                    Icon(Icons.check_circle_outline,
                        color: Colors.green, size: 40),
                    SizedBox(
                      height: 16,
                    ),
                    Text(
                      'Čestitamo!',
                      style: TextStyle(fontSize: 22),
                    ),
                    SizedBox(
                      height: 6,
                    ),
                    Text(
                      'Uspješno ste rezervirali vaše ulaznice.',
                      style: TextStyle(color: Colors.grey),
                    ),
                  ],
                ),
              ),
              ElevatedButton(
                onPressed: () =>
                    Navigator.pushNamed(context, TicketsScreen.routeName),
                child: const Icon(Icons.close_rounded),
              )
            ],
          ),
        ),
      ),
    );
  }
}
