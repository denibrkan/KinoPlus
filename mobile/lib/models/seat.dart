class Seat {
  late int id;
  late int number;
  late String row;
  late bool isTaken = false;
  late bool isSelected = false;

  Seat({required this.id, required this.number, required this.row});

  Seat.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    number = json['number'];
    row = json['row'];
    isTaken = false;
    isSelected = false;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['number'] = number;
    data['row'] = row;
    return data;
  }

  @override
  String toString() {
    return '$row$number';
  }
}
