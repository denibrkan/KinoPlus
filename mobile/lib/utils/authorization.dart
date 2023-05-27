class Authorization {
  static String? token;

  static Map<String, String> createHeaders() {
    String token = Authorization.token ?? '';

    var headers = {
      "Content-Type": "application/json",
      "Authorization": 'Bearer $token'
    };

    return headers;
  }
}
