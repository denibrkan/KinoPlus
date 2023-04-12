import 'dart:io';
import 'package:flutter/material.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/screens/home_screen.dart';
import 'package:mobile/screens/movie_detail_screen.dart';
import 'package:mobile/screens/movies_screen.dart';
import 'package:mobile/screens/profile_screen.dart';
import 'package:mobile/screens/tickets_screen.dart';
import 'helpers/my_http_overrides.dart';
import 'helpers/colors.dart';

void main() async {
  HttpOverrides.global = MyHttpOverrides();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: appTitle,
      theme: ThemeData(
        primarySwatch: primary,
        textTheme: const TextTheme(
          bodyMedium: TextStyle(color: Colors.white),
        ),
      ),
      onGenerateRoute: (settings) {
        if (settings.name == MovieDetailScreen.routeName) {
          return MaterialPageRoute(
              builder: (context) =>
                  MovieDetailScreen(movie: settings.arguments as Movie));
        }
        return null;
      },
      home: const Main(),
    );
  }
}

class Main extends StatefulWidget {
  const Main({super.key});

  @override
  State<Main> createState() => _MainState();
}

class _MainState extends State<Main> {
  final List<Widget> screens = [
    const HomeScreen(title: appTitle),
    const MoviesScreen(),
    const TicketsScreen(),
    const ProfileScreen(),
  ];

  int _selectedIndex = 0;

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: screens.elementAt(_selectedIndex),
        bottomNavigationBar: BottomNavigationBar(
          items: const <BottomNavigationBarItem>[
            BottomNavigationBarItem(
              icon: Icon(
                Icons.home,
              ),
              label: 'Home',
            ),
            BottomNavigationBarItem(
              icon: Icon(
                Icons.theaters,
              ),
              label: 'Movie',
            ),
            BottomNavigationBarItem(
              icon: Icon(
                Icons.local_activity,
              ),
              label: 'Ticket',
            ),
            BottomNavigationBarItem(
              icon: Icon(
                Icons.account_circle,
              ),
              label: 'Profile',
            ),
          ],
          currentIndex: _selectedIndex,
          selectedItemColor: Colors.lightBlue[300],
          unselectedItemColor: Colors.grey,
          onTap: _onItemTapped,
          showSelectedLabels: false,
          showUnselectedLabels: false,
          backgroundColor: primary.shade800,
          type: BottomNavigationBarType.fixed,
        ),
      ),
    );
  }
}
