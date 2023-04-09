class Movie {
  final int id;
  final String title;
  final String imageId;

  const Movie({required this.id, required this.title, required this.imageId});

  factory Movie.fromJson(Map<String, dynamic> json) {
    return Movie(
      id: json['id'],
      title: json['title'],
      imageId: json['imageId'],
    );
  }
}
