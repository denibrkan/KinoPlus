import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:mobile/helpers/constants.dart';

class APIService {
  String resource;

  APIService(this.resource);

  Future<List<T>> get<T>(Map<String, String>? params,
      T Function(Map<String, dynamic>) fromJson) async {
    var uri = Uri.parse('$apiUrl/$resource');

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
}
