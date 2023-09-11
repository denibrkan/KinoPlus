import 'package:flutter/material.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';

class PasosCreateScreen extends StatefulWidget {
  const PasosCreateScreen({super.key});

  static const String routeName = '/pasos-create';

  @override
  State<PasosCreateScreen> createState() => _PasosCreateScreenState();
}

class _PasosCreateScreenState extends State<PasosCreateScreen> {
  late UserProvider _userProvider;
  List<User> users = <User>[];
  User? selectedUser;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _userProvider = context.read<UserProvider>();

    loadUsers();
  }

  loadUsers() async {
    try {
      users = await _userProvider.get(null);
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Column(
          children: [
            _buildUserDropdown(),
          ],
        ),
      ),
    );
  }

  Widget _buildUserDropdown() {
    return Container(
        margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 25),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Odaberite korisnika',
              style: Theme.of(context).textTheme.titleMedium,
            ),
            const SizedBox(height: 6),
            users.isNotEmpty
                ? DropdownButton<User>(
                    isExpanded: true,
                    value: selectedUser,
                    icon: const Icon(Icons.arrow_drop_down),
                    elevation: 16,
                    onChanged: (User? value) {
                      setState(() {
                        selectedUser = value;
                      });
                    },
                    items: users
                        .map<DropdownMenuItem<User>>(
                            (l) => DropdownMenuItem<User>(
                                  value: l,
                                  child: Text('${l.firstName} - ${l.lastName}'),
                                ))
                        .toList(),
                  )
                : Container(),
          ],
        ));
  }
}
