import 'package:mobile/models/movie.dart';
import 'package:mobile/providers/base_provider.dart';

class MovieProvider extends BaseProvider<Movie> {
  MovieProvider() : super('movies');

  @override
  Movie fromJson(data) {
    return Movie.fromJson(data);
  }
}
