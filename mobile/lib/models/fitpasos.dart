import 'package:mobile/models/user.dart';

class FITPasos {
  late int id;
  late DateTime validUntil;
  late DateTime dateIssued;
  late bool isValid;
  late User user;

  FITPasos(
      {required this.id,
      required this.validUntil,
      required this.dateIssued,
      required this.user});

  FITPasos.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    isValid = json['isValid'];
    validUntil = DateTime.parse(json['validUntil']);
    dateIssued = DateTime.parse(json['dateIssued']);
    user = User.fromJson(json['user']);
  }
}
