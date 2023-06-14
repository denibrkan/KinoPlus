import 'package:mobile/models/location.dart';
import 'package:mobile/models/movie.dart';

class User {
  User({
    required this.id,
    required this.firstName,
    required this.lastName,
    required this.email,
    required this.username,
    this.phone,
    this.imageId,
    this.token,
  });
  late int id;
  late String firstName;
  late String lastName;
  late String? phone;
  late String email;
  late String username;
  late String? imageId;
  late String? token;
  late num movieCount;
  late num loyaltyPoints;
  late int? locationId;
  late Location? location;
  late List<dynamic> roles;
  late List<Movie> moviesWatched;

  User.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    phone = json['phone'];
    email = json['email'];
    username = json['username'];
    imageId = json['imageId'];
    token = json['token'];
    movieCount = json['movieCount'];
    loyaltyPoints = json['loyaltyPoints'];
    locationId = json['locationId'];
    location =
        json['location'] != null ? Location.fromJson(json['location']) : null;
    moviesWatched =
        json['moviesWatched'] != null && json['moviesWatched'].isNotEmpty
            ? json['moviesWatched']
                .map((t) => Movie.fromJson(t))
                .cast<Movie>()
                .toList()
            : <Movie>[];
  }

  Map<String, dynamic> toJson() {
    final data = <String, dynamic>{};
    data['id'] = id;
    data['firstName'] = firstName;
    data['lastName'] = lastName;
    data['phone'] = phone;
    data['email'] = email;
    data['username'] = username;
    data['imageId'] = imageId;
    data['token'] = token;
    data['roles'] = roles;
    data['locationId'] = locationId;
    return data;
  }
}
