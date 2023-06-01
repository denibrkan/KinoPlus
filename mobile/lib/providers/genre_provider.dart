import 'package:mobile/models/genre.dart';
import 'package:mobile/providers/base_provider.dart';

class GenreProvider extends BaseProvider<Genre> {
  GenreProvider() : super('genres');

  var genres = <Genre>[];

  @override
  Future<List<Genre>> get(Map<String, String>? params) async {
    if (genres.isNotEmpty) {
      return genres;
    } else {
      genres = await super.get(params);
    }
    return genres;
  }

  @override
  Genre fromJson(data) {
    return Genre.fromJson(data);
  }
}
