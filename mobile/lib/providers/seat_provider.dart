import 'package:mobile/models/seat.dart';
import 'package:mobile/providers/base_provider.dart';

class SeatProvider extends BaseProvider<Seat> {
  SeatProvider() : super('seats');

  var seats = <Seat>[];

  @override
  Future<List<Seat>> get(Map<String, String>? params) async {
    if (seats.isNotEmpty) {
      return seats;
    } else {
      seats = await super.get(params);
    }
    return seats;
  }

  @override
  Seat fromJson(data) {
    return Seat.fromJson(data);
  }
}
