import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/utils/authorization.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  String endpoint;

  BaseProvider(this.endpoint);

  Future<List<T>> get(Map<String, String>? params) async {
    var uri = Uri.parse('$apiUrl/$endpoint');

    if (params != null) {
      uri = uri.replace(queryParameters: params);
    }
    var headers = createHeaders();

    final response = await http.get(uri, headers: headers);

    if (response.statusCode == 200) {
      var data = json.decode(response.body);

      return data.map((d) => fromJson(d)).cast<T>().toList();
    } else {
      throw Exception('Failed to load data');
    }
  }

  Future<dynamic> insert(dynamic resource) async {
    var uri = Uri.parse('$apiUrl/$endpoint');
    Map<String, String> headers = createHeaders();

    var jsonRequest = jsonEncode(resource);
    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (response.statusCode == 200) {
      var data = jsonDecode(response.body);
      if (data is List) {
        return data.map((d) => fromJson(d)).cast<T>().toList();
      }

      return fromJson(data);
    } else {
      throw Exception();
    }
  }

  Map<String, String> createHeaders() {
    String token = Authorization.token ?? '';

    var headers = {
      "Content-Type": "application/json",
      "Authorization": 'Bearer $token'
    };

    return headers;
  }

  T fromJson(data) {
    throw Exception("Override method");
  }
}