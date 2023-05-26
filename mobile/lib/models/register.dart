class Register {
  late String username;
  late String password;
  late String firstName;
  late String lastName;
  late String email;
  late String? phoneNumber;
  late String? imageId;

  Register(
      {required this.username,
      required this.password,
      required this.firstName,
      required this.lastName,
      required this.email,
      this.phoneNumber,
      this.imageId});

  Map<String, dynamic> toJson() {
    return <String, dynamic>{
      'username': username,
      'password': password,
      'firstName': firstName,
      'lastName': lastName,
      'email': email,
      'phoneNumber': phoneNumber,
      'imageId': imageId
    };
  }
}
