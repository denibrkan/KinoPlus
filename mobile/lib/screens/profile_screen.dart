import 'package:adaptive_theme/adaptive_theme.dart';
import 'package:flutter/material.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_screen.dart';
import 'package:mobile/utils/authorization.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class ProfileScreen extends StatefulWidget {
  const ProfileScreen({super.key});

  static const routeName = '/profile';

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  late User? user;
  late UserProvider _userProvider;

  @override
  void initState() {
    super.initState();

    _userProvider = context.read<UserProvider>();
  }

  @override
  Widget build(BuildContext context) {
    user = context.watch<UserProvider>().user;
    var themeMode = AdaptiveTheme.of(context).mode;

    if (user == null) {
      WidgetsBinding.instance.addPostFrameCallback((_) {
        Navigator.of(context).pushReplacementNamed(LoginScreen.routeName);
      });
      return Container();
    }

    return Scaffold(
      appBar: AppBar(
        title: const Text('Profil'),
        actions: [
          Switch(
              activeColor: blueButtonColor,
              value: themeMode == AdaptiveThemeMode.dark,
              activeThumbImage: const AssetImage('assets/images/dark-mode.png'),
              inactiveThumbImage:
                  const AssetImage('assets/images/light-mode.png'),
              onChanged: (value) {
                themeMode == AdaptiveThemeMode.dark
                    ? AdaptiveTheme.of(context).setLight()
                    : AdaptiveTheme.of(context).setDark();
              })
        ],
      ),
      body: Column(
        children: [
          const SizedBox(
            height: 50,
          ),
          _buildInfo(),
          const SizedBox(height: 40),
          _buildStats(),
          _buildLinks(),
        ],
      ),
    );
  }

  Widget _buildInfo() {
    return Column(
      children: [
        user!.location != null
            ? Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Icon(
                    Icons.location_on_sharp,
                    color: Colors.red,
                  ),
                  const SizedBox(
                    width: 5,
                  ),
                  Text(
                    '${user!.location!.name} - ${user!.location!.city.name}',
                    style: const TextStyle(fontSize: 16),
                  )
                ],
              )
            : Container(),
        const SizedBox(height: 40),
        user!.imageId != null
            ? ClipRRect(
                borderRadius: BorderRadius.circular(70),
                child: FadeInImage(
                  placeholder: MemoryImage(kTransparentImage),
                  image: NetworkImage(
                    '$apiUrl/images/${user?.imageId}?original=true',
                    headers: Authorization.createHeaders(),
                  ),
                  width: 120,
                  height: 120,
                  fit: BoxFit.cover,
                ),
              )
            : Image.asset(
                'assets/images/user-96.png',
                width: 70,
                color: Colors.grey,
              ),
        const SizedBox(height: 30),
        Text(user!.username, style: const TextStyle(fontSize: 22)),
        const SizedBox(
          height: 10,
        ),
        Text(user!.email, style: const TextStyle(color: Colors.grey)),
      ],
    );
  }

  Widget _buildStats() {
    return IntrinsicHeight(
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 00.0),
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
                        color: Colors.grey, fontWeight: FontWeight.w600),
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
                        color: Colors.grey, fontWeight: FontWeight.w600),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildLinks() {
    return Expanded(
      child: Container(
        margin: const EdgeInsets.symmetric(vertical: 20, horizontal: 16),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                style: ElevatedButton.styleFrom(
                    backgroundColor: const Color.fromARGB(255, 0, 101, 151),
                    padding: const EdgeInsets.all(12)),
                onPressed: _userProvider.logout,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: const [
                    Icon(
                      Icons.logout,
                      color: Colors.white,
                    ),
                    SizedBox(
                      width: 10,
                    ),
                    Text('Odjavi se')
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
