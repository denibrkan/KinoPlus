import 'package:mobile/models/projection.dart';
import 'package:mobile/providers/base_provider.dart';

class ProjectionProvider extends BaseProvider<Projection> {
  ProjectionProvider() : super('projections');

  @override
  Projection fromJson(data) {
    return Projection.fromJson(data);
  }
}
