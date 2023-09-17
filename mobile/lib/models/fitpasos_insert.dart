class FITPasosInsert {
  late DateTime validUntil;
  late bool isValid;
  late int userId;

  FITPasosInsert({
    required this.validUntil,
    required this.isValid,
    required this.userId,
  });

  Map<String, dynamic> toJson() {
    var data = <String, dynamic>{};
    data['validUntil'] = validUntil.toIso8601String();
    data['isValid'] = isValid;
    data['userId'] = userId;

    return data;
  }
}
