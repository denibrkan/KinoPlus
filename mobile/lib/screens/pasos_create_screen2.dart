import 'package:flutter/material.dart';
import 'package:mobile/models/fitpasos.dart';
import 'package:mobile/models/fitpasos_insert.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/fitpasos_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';

class PasosCreateScreen2 extends StatefulWidget {
  const PasosCreateScreen2({super.key});

  static const String routeName = '/novi-pasos';

  @override
  State<PasosCreateScreen2> createState() => _PasosCreateScreen2State();
}

class _PasosCreateScreen2State extends State<PasosCreateScreen2> {
  late UserProvider _userProvider;
  late FITPasosProvider _fitPasosProvider;

  List<User> users = <User>[];

  User? selectedUser;
  DateTime? selectedDate;
  bool isValid = true;

  @override
  void initState() {
    super.initState();

    _userProvider = context.read<UserProvider>();
    _fitPasosProvider = context.read<FITPasosProvider>();

    loadUsers();
  }

  loadUsers() async {
    var data = await _userProvider.get(null);

    setState(() {
      users = data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            children: [
              _buildUsersDropdown(),
              _buildDateField(),
              _buildIsValidCheckbox(),
              ElevatedButton(
                  onPressed: () async => savePasos(),
                  child: const Text('Sacuvaj'))
            ],
          ),
        ),
      ),
    );
  }

  savePasos() async {
    if (selectedDate == null || selectedUser == null) return;

    final pasos = FITPasosInsert(
        validUntil: selectedDate!, userId: selectedUser!.id, isValid: isValid);
    try {
      await _fitPasosProvider.insert(pasos);

      if (mounted) {
        Navigator.pushNamed(context, '/', arguments: 3);
      }
    } catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  Widget _buildUsersDropdown() {
    return users.isNotEmpty
        ? DropdownButton<User>(
            hint: Text('User'),
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
                  (user) => DropdownMenuItem<User>(
                    value: user,
                    child: Text(user.username),
                  ),
                )
                .toList(),
          )
        : Container();
  }

  // Future<void> _selectDate(BuildContext context) async {
  //   final DateTime? picked = await showDatePicker(
  //     context: context,
  //     initialDate: DateTime.now(),
  //     firstDate: DateTime.now(),
  //     lastDate: DateTime(2101),
  //   );
  //   if (picked != null) {
  //     selectedDate = picked;
  //   }
  // }

  Widget _buildDateField() {
    return InputDatePickerFormField(
      firstDate: DateTime.now(),
      lastDate: DateTime(3000),
      onDateSubmitted: _selectValidUntilDate,
      keyboardType: TextInputType.datetime,
    );
  }

  _selectValidUntilDate(DateTime? date) {
    selectedDate = date;
  }

  _buildIsValidCheckbox() {
    return Row(
      children: [
        const Text('Validan?'),
        Checkbox(
          value: isValid,
          onChanged: (value) => setState(() {
            isValid = value!;
          }),
        ),
      ],
    );
  }
}
