import 'dart:convert';
import 'package:http/http.dart' as http;

import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/register.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/base_provider.dart';
import 'package:mobile/utils/authorization.dart';

class UserProvider extends BaseProvider {
  User? user;

  UserProvider() : super('account');

  Future<User> loginAsync(String username, String password) async {
    var url = '$apiUrl/$endpoint/login';
    final response = await http.post(
      Uri.parse(url),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        'username': username,
        'password': password,
      }),
    );
    if (response.statusCode == 200) {
      var data = jsonDecode(response.body);
      user = User.fromJson(data);
      Authorization.token = user!.token;

      notifyListeners();

      return user!;
    } else {
      throw Exception(response.body);
    }
  }

  Future register(Register data) async {
    var url = '$apiUrl/$endpoint/register';

    final response = await http.post(
      Uri.parse(url),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: json.encode(data.toJson()),
    );

    if (response.statusCode == 200) {
      return;
    } else {
      throw Exception('Greška prilikom registracije.');
    }
  }

  Future<bool> checkUsername(String username) async {
    var url = '$apiUrl/$endpoint/check-username';
    final response = await http.post(Uri.parse(url),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(username));

    if (response.statusCode == 200) {
      return json.decode(response.body) as bool;
    }

    return false;
  }
}
