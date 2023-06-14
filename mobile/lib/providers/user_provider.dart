import 'dart:convert';
import 'package:http/http.dart' as http;

import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/register.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/base_provider.dart';
import 'package:mobile/utils/authorization.dart';
import 'dart:io';

class UserProvider extends BaseProvider {
  User? user;

  UserProvider() : super('account');

  refreshUser() async {
    user = await getById(user!.id, null);
  }

  @override
  Future<User> getById(int id, Map<String, String>? params) async {
    var uri = Uri.parse('$apiUrl/users/$id');

    if (params != null) {
      uri = uri.replace(queryParameters: params);
    }
    var headers = Authorization.createHeaders();

    final response = await http.get(uri, headers: headers);

    if (response.statusCode == 200) {
      var data = json.decode(response.body);

      return fromJson(data);
    } else {
      throw Exception('Failed to load data');
    }
  }

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

  Future registerAsync(Register data, File? imageFile) async {
    var uri = Uri.parse('$apiUrl/$endpoint/register');
    http.MultipartRequest request = http.MultipartRequest("POST", uri);

    http.MultipartFile multipartFile;

    if (imageFile != null) {
      multipartFile =
          await http.MultipartFile.fromPath('image', imageFile.path);

      request.files.add(multipartFile);
    }

    request.fields.addAll(<String, String>{
      'username': data.username,
      'password': data.password,
      'firstName': data.firstName,
      'lastName': data.lastName,
      'email': data.email,
      'phoneNumber': data.phoneNumber ?? '',
      'locationId': data.locationId.toString(),
    });

    http.StreamedResponse response = await request.send();

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

  void logout() {
    user = null;

    notifyListeners();
  }

  @override
  fromJson(data) {
    return User.fromJson(data);
  }
}
