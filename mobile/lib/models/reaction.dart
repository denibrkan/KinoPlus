class Reaction {
  final int id;
  final int rating;
  final String? comment;
  final int movieId;
  final String dateCreated;

  const Reaction(
      {required this.id,
      required this.rating,
      required this.comment,
      required this.movieId,
      required this.dateCreated});

  factory Reaction.fromJson(Map<String, dynamic> json) {
    return Reaction(
      id: json['id'],
      rating: json['rating'],
      comment: json['comment'],
      movieId: json['movieId'],
      dateCreated: json['dateCreated'],
    );
  }

  Map<String, dynamic> toJson() {
    var data = <String, dynamic>{};
    data['id'] = id;
    data['rating'] = rating;
    data['comment'] = comment;
    data['movieId'] = movieId;
    data['dateCreated'] = dateCreated;
    return data;
  }
}
