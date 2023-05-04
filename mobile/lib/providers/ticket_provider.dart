import 'package:mobile/models/ticket.dart';
import 'base_provider.dart';

class TicketProvider extends BaseProvider<Ticket> {
  TicketProvider() : super('tickets');

  @override
  Ticket fromJson(dynamic data) {
    return Ticket.fromJson(data);
  }
}
