class Ticket {
  late int id;
  late String dateOfPurchase;
  late int seatId;
  late int userId;
  late int projectionId;

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
