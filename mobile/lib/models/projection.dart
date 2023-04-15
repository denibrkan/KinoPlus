import 'package:mobile/models/projection_type.dart';

class Projection {
  late int id;
  late DateTime startsAt;
  late DateTime endsAt;
  late double price;
  late int movieId;
  late int projectionTypeId;
  late ProjectionType? projectionType;

  Projection(
      {required this.id,
      required this.startsAt,
      required this.endsAt,
      required this.price,
      required this.movieId,
      required this.projectionTypeId,
      required this.projectionType});

  Projection.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    startsAt = DateTime.parse(json['startsAt']);
    endsAt = DateTime.parse(json['endsAt']);
    price = json['price'];
    movieId = json['movieId'];
    projectionTypeId = json['projectionTypeId'];
    projectionType = json['projectionType'] != null
        ? ProjectionType.fromJson(json['projectionType'])
        : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = Map<String, dynamic>();
    data['id'] = id;
    data['startsAt'] = startsAt;
    data['endsAt'] = endsAt;
    data['price'] = price;
    data['movieId'] = movieId;
    data['projectionTypeId'] = projectionTypeId;
    if (projectionType != null) {
      data['projectionType'] = projectionType!.toJson();
    }
    return data;
  }
}
