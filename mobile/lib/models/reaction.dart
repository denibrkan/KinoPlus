import 'package:mobile/models/user.dart';

class Reaction {
  final int id;
  final int rating;
  final String? comment;
  final int movieId;
  final String dateCreated;
  final User? user;
  final int userId;

  const Reaction({
    required this.id,
    required this.rating,
    required this.comment,
    required this.movieId,
    required this.dateCreated,
    required this.user,
    required this.userId,
  });

  factory Reaction.fromJson(Map<String, dynamic> json) {
    return Reaction(
      id: json['id'],
      rating: json['rating'],
      comment: json['comment'],
      movieId: json['movieId'],
      dateCreated: json['dateCreated'],
      user: json['user'] != null ? User.fromJson(json['user']) : null,
      userId: json['userId'],
    );
  }

  Map<String, dynamic> toJson() {
    var data = <String, dynamic>{};
    data['id'] = id;
    data['rating'] = rating;
    data['comment'] = comment;
    data['movieId'] = movieId;
    data['dateCreated'] = dateCreated;
    data['userId'] = userId;
    return data;
  }
}

class ReactionInsert {
  late int rating;
  late String comment;
  late int movieId;
  late int userId;

  ReactionInsert(
      {required this.rating,
      required this.comment,
      required this.movieId,
      required this.userId});

  Map<String, dynamic> toJson() {
    var data = <String, dynamic>{};
    data['rating'] = rating;
    data['comment'] = comment;
    data['movieId'] = movieId;
    data['userId'] = userId;
    return data;
  }
}
