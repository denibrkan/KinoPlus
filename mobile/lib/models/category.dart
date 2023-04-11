import 'package:mobile/models/movie.dart';

class Category {
  final int id;
  final String name;
  final List<Movie> movies;

  const Category({required this.id, required this.name, required this.movies});

  factory Category.fromJson(Map<String, dynamic> json) {
    return Category(
      id: json['id'],
      name: json['name'],
      movies:
          json['movies'].map((p) => Movie.fromJson(p)).cast<Movie>().toList(),
    );
  }
}
