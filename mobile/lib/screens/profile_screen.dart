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
        ? Center(
            child:
                Text('Hello ${user!.username}', style: TextStyle(fontSize: 18)),
          )
        : const LoginScreen();
  }
}
