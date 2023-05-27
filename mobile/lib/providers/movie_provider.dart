import 'dart:convert';

import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/utils/authorization.dart';

class MovieProvider extends BaseProvider<Movie> {
  MovieProvider() : super('movies');

  Future<List<Movie>> recommend(int userId) async {
    var uri = Uri.parse('$apiUrl/recommendation/$userId');

    var headers = Authorization.createHeaders();

    final response = await http.get(uri, headers: headers);

    if (response.statusCode == 200) {
      var data = json.decode(response.body);

      return data.map((d) => fromJson(d)).cast<Movie>().toList();
    } else {
      throw Exception(response.body);
    }
  }

  @override
  Movie fromJson(data) {
    return Movie.fromJson(data);
  }
}
