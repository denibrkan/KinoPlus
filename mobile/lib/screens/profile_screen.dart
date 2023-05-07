import 'package:flutter/material.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_screen.dart';
import 'package:provider/provider.dart';

class ProfileScreen extends StatefulWidget {
  const ProfileScreen({super.key});

  static const routeName = '/profile';

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  User? user;

  @override
  Widget build(BuildContext context) {
    user = context.watch<UserProvider>().user;

    return user != null
        ? Column(
            children: [
              _buildHeader(),
              const SizedBox(
                height: 100,
              ),
              Image.asset(
                'assets/images/user-96.png',
                color: Colors.grey,
              ),
              const SizedBox(height: 20),
              Text(user!.username, style: const TextStyle(fontSize: 22)),
              const SizedBox(
                height: 10,
              ),
              Text(user!.email, style: const TextStyle(color: Colors.grey)),
              const SizedBox(height: 50),
              IntrinsicHeight(
                child: Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 30.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Expanded(
                        child: Column(
                          children: [
                            Text(
                              user!.loyaltyPoints.toString(),
                              style: const TextStyle(
                                  fontSize: 25, fontWeight: FontWeight.bold),
                            ),
                            const SizedBox(
                              height: 10,
                            ),
                            Text(
                              'Loyalty poeni'.toUpperCase(),
                              style: const TextStyle(
                                  color: Colors.grey,
                                  fontWeight: FontWeight.w600),
                            ),
                          ],
                        ),
                      ),
                      const VerticalDivider(
                        width: 0,
                        color: Colors.grey,
                        thickness: 2,
                      ),
                      Expanded(
                        child: Column(
                          children: [
                            Text(
                              user!.movieCount.toString(),
                              style: const TextStyle(
                                  fontSize: 25, fontWeight: FontWeight.bold),
                            ),
                            const SizedBox(
                              height: 10,
                            ),
                            Text(
                              'Filmovi'.toUpperCase(),
                              style: const TextStyle(
                                  color: Colors.grey,
                                  fontWeight: FontWeight.w600),
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              )
            ],
          )
        : const LoginScreen();
  }

  Widget _buildHeader() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Container(
          margin: const EdgeInsets.only(left: 16, top: 20, bottom: 8),
          child: const Text(
            'Profil',
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
