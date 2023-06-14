class Register {
  late String username;
  late String password;
  late String firstName;
  late String lastName;
  late String email;
  late String? phoneNumber;
  late int locationId;

  Register({
    required this.username,
    required this.password,
    required this.firstName,
    required this.lastName,
    required this.email,
    required this.locationId,
    this.phoneNumber,
  });

  Map<String, dynamic> toJson() {
    return <String, dynamic>{
      'username': username,
      'password': password,
      'firstName': firstName,
      'lastName': lastName,
      'email': email,
      'phoneNumber': phoneNumber,
      'locationId': locationId,
    };
  }
}
