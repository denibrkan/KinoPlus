import 'package:mobile/models/fitpasos.dart';
import 'package:mobile/providers/base_provider.dart';

class FITPasosProvider extends BaseProvider<FITPasos> {
  FITPasosProvider() : super('fitpasosi');

  @override
  FITPasos fromJson(data) {
    return FITPasos.fromJson(data);
  }
}
