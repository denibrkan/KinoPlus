class Hall {
  final int id;
  final String name;

  const Hall({required this.id, required this.name});

  factory Hall.fromJson(Map<String, dynamic> json) {
    return Hall(
      id: json['id'],
      name: json['name'],
    );
  }

  Map<String, dynamic> toJson() {
    var data = <String, dynamic>{};
    data['id'] = id;
    data['name'] = name;
    return data;
  }
}
