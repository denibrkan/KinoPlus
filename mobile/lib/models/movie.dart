import 'package:mobile/models/actor.dart';
import 'package:mobile/models/genre.dart';
import 'package:mobile/models/reaction.dart';

class Movie {
  int id;
  String title;
  int duration;
  String description;
  String? imageId;
  String? trailerUrl;
  num averageRating;
  String dateCreated;
  List<Actor> actors;
  List<Genre> genres;
  List<Reaction> reactions;

  Movie(
      {required this.title,
      required this.duration,
      required this.description,
      required this.imageId,
      required this.trailerUrl,
      required this.averageRating,
      required this.id,
      required this.dateCreated,
      required this.actors,
      required this.genres,
      required this.reactions});

  factory Movie.fromJson(Map<String, dynamic> json) {
    var actors = <Actor>[];
    var genres = <Genre>[];
    var reactions = <Reaction>[];
    if (json['actors'] != null) {
      json['actors'].forEach((v) {
        actors.add(Actor.fromJson(v));
      });
    }
    if (json['genres'] != null) {
      json['genres'].forEach((v) {
        genres.add(Genre.fromJson(v));
      });
    }
    if (json['reactions'] != null) {
      json['reactions'].forEach((v) {
        reactions.add(Reaction.fromJson(v));
      });
    }

    return Movie(
        id: json['id'],
        title: json['title'],
        duration: json['duration'],
        description: json['description'],
        imageId: json['imageId'],
        trailerUrl: json['trailerUrl'],
        averageRating: json['averageRating'],
        dateCreated: json['dateCreated'],
        actors: actors,
        genres: genres,
        reactions: reactions);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['title'] = title;
    data['duration'] = duration;
    data['description'] = description;
    data['imageId'] = imageId;
    data['trailerUrl'] = trailerUrl;
    data['averageRating'] = averageRating;
    data['dateCreated'] = dateCreated;
    data['actors'] = actors.map((v) => v.toJson()).toList();
    data['genres'] = genres.map((v) => v.toJson()).toList();
    data['reactions'] = reactions.map((v) => v.toJson()).toList();

    return data;
  }
}
