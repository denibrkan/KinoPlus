import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:http/http.dart' as http;

abstract class BaseProvider<T> with ChangeNotifier {
  String endpoint;

  BaseProvider(this.endpoint);

  Future<List<T>> get(Map<String, String>? params) async {
    var uri = Uri.parse('$apiUrl/$endpoint');

    if (params != null) {
      uri = uri.replace(queryParameters: params);
    }

    final response = await http.get(uri);

    if (response.statusCode == 200) {
      var data = json.decode(response.body);

      return data.map((d) => fromJson(d)).cast<T>().toList();
    } else {
      throw Exception('Failed to load data');
    }
  }

  T fromJson(data) {
    throw Exception("Override method");
  }
}
