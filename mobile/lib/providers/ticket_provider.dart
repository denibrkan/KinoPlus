import 'package:mobile/models/projection.dart';
import 'package:mobile/models/seat.dart';
import 'package:mobile/models/ticket.dart';
import 'base_provider.dart';

class TicketProvider extends BaseProvider<Ticket> {
  TicketProvider() : super('tickets');

  var _selectedSeats = <Seat>[];
  Projection? _projection;

  setSelectedSeats(List<Seat> seats) {
    seats.sort((a, b) => a.number.compareTo(b.number));
    seats.sort((a, b) => a.row.compareTo(b.row));
    _selectedSeats = seats;
  }

  setProjection(Projection projection) {
    _projection = projection;
  }

  get selectedTicketTotalPrice => _projection!.price * _selectedSeats.length;

  List<Seat> get selectedSeats => _selectedSeats;
  Projection? get projection => _projection;

  @override
  Ticket fromJson(dynamic data) {
    return Ticket.fromJson(data);
  }
}
