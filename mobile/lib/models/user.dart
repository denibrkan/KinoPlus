class User {
  User({
    required this.id,
    required this.firstName,
    required this.lastName,
    this.phone,
    required this.email,
    required this.username,
    this.imageId,
    this.token,
    required this.roles,
  });
  late final int id;
  late final String firstName;
  late final String lastName;
  late final String? phone;
  late final String email;
  late final String username;
  late final String? imageId;
  late final String? token;
  late final List<dynamic> roles;

  User.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    phone = json['phone'];
    email = json['email'];
    username = json['username'];
    imageId = json['imageId'];
    token = json['token'];
    //roles = List.castFrom<dynamic, dynamic>(json['roles']);
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
    return data;
  }
}
