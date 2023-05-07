class Register {
  late String username;
  late String password;
  late String firstName;
  late String lastName;
  late String email;
  late String? phoneNumber;

  Register(this.username, this.password, this.firstName, this.lastName,
      this.email, this.phoneNumber);

  Map<String, dynamic> toJson() {
    return <String, dynamic>{
      'username': username,
      'password': password,
      'firstName': firstName,
      'lastName': lastName,
      'email': email,
      'phoneNumber': phoneNumber,
    };
  }
}
