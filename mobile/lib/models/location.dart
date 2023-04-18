import 'package:mobile/models/city.dart';

class Location {
  late int id;
  late String name;
  late City city;

  Location({required this.id, required this.name});

  Location.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    name = json['name'];
    city = City.fromJson(json['city']);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['name'] = name;
    return data;
  }
}
