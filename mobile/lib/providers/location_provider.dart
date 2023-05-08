import 'package:mobile/models/location.dart';
import 'package:mobile/providers/base_provider.dart';

class LocationProvider extends BaseProvider<Location> {
  LocationProvider() : super('locations');

  @override
  Location fromJson(data) {
    return Location.fromJson(data);
  }
}
