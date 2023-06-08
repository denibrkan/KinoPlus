import 'dart:io';
import 'package:flutter/material.dart';
import 'package:intl/date_symbol_data_local.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/models/projection.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/genre_provider.dart';
import 'package:mobile/providers/location_provider.dart';
import 'package:mobile/providers/movie_provider.dart';
import 'package:mobile/providers/movie_tab_provider.dart';
import 'package:mobile/providers/projection_provider.dart';
import 'package:mobile/providers/reaction_provider.dart';
import 'package:mobile/providers/seat_provider.dart';
import 'package:mobile/providers/ticket_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/home_screen.dart';
import 'package:mobile/screens/login_screen.dart';
import 'package:mobile/screens/movie_detail_screen.dart';
import 'package:mobile/screens/movies_screen.dart';
import 'package:mobile/screens/profile_screen.dart';
import 'package:mobile/screens/register_screen.dart';
import 'package:mobile/screens/reservation_success.dart';
import 'package:mobile/screens/seats_screen.dart';
import 'package:mobile/screens/tickets_screen.dart';
import 'package:provider/provider.dart';
import 'helpers/my_http_overrides.dart';
import 'helpers/colors.dart';
import 'models/user.dart';
import 'utils/authorization.dart';

void main() async {
  HttpOverrides.global = MyHttpOverrides();
  initializeDateFormatting('fr_FR', null).then((_) => runApp(const MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => SeatProvider()),
        ChangeNotifierProvider(create: (_) => UserProvider()),
        ChangeNotifierProvider(create: (_) => TicketProvider()),
        ChangeNotifierProvider(create: (_) => CategoryProvider()),
        ChangeNotifierProvider(create: (_) => MovieProvider()),
        ChangeNotifierProvider(create: (_) => LocationProvider()),
        ChangeNotifierProvider(create: (_) => ProjectionProvider()),
        ChangeNotifierProvider(create: (_) => MovieTabProvider()),
        ChangeNotifierProvider(create: (_) => ReactionProvider()),
        ChangeNotifierProvider(create: (_) => GenreProvider()),
      ],
      child: MaterialApp(
        title: appTitle,
        theme: ThemeData(
          primarySwatch: primary,
          textTheme: Theme.of(context).textTheme.apply(
                displayColor: const Color.fromRGBO(233, 233, 233, 1),
                bodyColor: const Color.fromRGBO(233, 233, 233, 1),
                fontFamily: 'Albert Sans',
              ),
          scaffoldBackgroundColor: primary.shade500,
        ),
        routes: {
          ReservationSuccessScreen.routeName: (context) =>
              const ReservationSuccessScreen(),
          TicketsScreen.routeName: (context) => const TicketsScreen(),
          RegisterScreen.routeName: (context) => const RegisterScreen(),
          LoginScreen.routeName: (context) => const LoginScreen(),
        },
        onGenerateRoute: (settings) {
          if (settings.name == MovieDetailScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) =>
                    MovieDetailScreen(movie: settings.arguments as Movie));
          }
          if (settings.name == SeatsScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) =>
                    SeatsScreen(projection: settings.arguments as Projection));
          }
          if (settings.name == ProfileScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => const ProfileScreen());
          }
          if (settings.name == '/') {
            return MaterialPageRoute(
                builder: (context) => Main(
                    index: settings.arguments != null
                        ? settings.arguments as int
                        : 0));
          }
          return null;
        },
      ),
    );
  }
}

class Main extends StatefulWidget {
  const Main({super.key, this.index = 0});

  final int index;

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

  late int _selectedIndex;
  late UserProvider userProvider;

  @override
  void initState() {
    super.initState();
    _selectedIndex = widget.index;

    userProvider = context.read<UserProvider>();
  }

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    User? user = userProvider.user;
    if (user == null) {
      return const LoginScreen();
    }
    Widget userIcon = user.imageId != null
        ? SizedBox(
            width: 30,
            height: 30,
            child: CircleAvatar(
              backgroundImage: NetworkImage(
                '$apiUrl/images/${user.imageId}',
                headers: Authorization.createHeaders(),
              ),
            ),
          )
        : const Icon(
            Icons.account_circle,
          );
    return SafeArea(
      child: Scaffold(
        body: screens.elementAt(_selectedIndex),
        bottomNavigationBar: BottomNavigationBar(
          items: <BottomNavigationBarItem>[
            const BottomNavigationBarItem(
              icon: Icon(
                Icons.home_filled,
              ),
              label: 'Home',
            ),
            const BottomNavigationBarItem(
              icon: Icon(
                Icons.theaters,
              ),
              label: 'Movie',
            ),
            const BottomNavigationBarItem(
              icon: Icon(
                Icons.local_activity,
              ),
              label: 'Ticket',
            ),
            BottomNavigationBarItem(
              icon: userIcon,
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
