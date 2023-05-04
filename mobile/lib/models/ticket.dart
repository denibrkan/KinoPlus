import 'package:mobile/models/hall.dart';
import 'package:mobile/models/location.dart';
import 'package:mobile/models/seat.dart';

class Ticket {
  late int id;
  late String dateOfPurchase;
  late int seatId;
  late int userId;
  late int projectionId;
  late String movieTitle;
  late String movieImageId;
  late String projectionStart;
  late String projectionEnd;
  late Location location;
  late Hall hall;
  late Seat? seat;

  Ticket(
      {required this.id,
      required this.dateOfPurchase,
      required this.seatId,
      required this.userId,
      required this.projectionId});

  Ticket.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    dateOfPurchase = json['dateOfPurchase'];
    seatId = json['seatId'];
    userId = json['userId'];
    projectionId = json['projectionId'];
    movieTitle = json['movieTitle'];
    movieImageId = json['movieImageId'];
    projectionStart = json['projectionStart'];
    projectionEnd = json['projectionEnd'];
    location = Location.fromJson(json['location']);
    hall = Hall.fromJson(json['hall']);
    seat = json['seat'] != null ? Seat.fromJson(json['seat']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['dateOfPurchase'] = dateOfPurchase;
    data['seatId'] = seatId;
    data['userId'] = userId;
    data['projectionId'] = projectionId;
    return data;
  }
}
