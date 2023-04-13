import 'package:mobile/models/user.dart';

class Reaction {
  final int id;
  final int rating;
  final String? comment;
  final int movieId;
  final String dateCreated;
  final User user;

  const Reaction({
    required this.id,
    required this.rating,
    required this.comment,
    required this.movieId,
    required this.dateCreated,
    required this.user,
  });

  factory Reaction.fromJson(Map<String, dynamic> json) {
    return Reaction(
      id: json['id'],
      rating: json['rating'],
      comment: json['comment'],
      movieId: json['movieId'],
      dateCreated: json['dateCreated'],
      user: User.fromJson(json['user']),
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
