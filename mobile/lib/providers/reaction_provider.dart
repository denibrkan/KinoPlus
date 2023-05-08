import 'package:mobile/models/reaction.dart';
import 'package:mobile/providers/base_provider.dart';

class ReactionProvider extends BaseProvider<Reaction> {
  ReactionProvider() : super('moviereactions');

  @override
  Reaction fromJson(data) {
    return Reaction.fromJson(data);
  }
}
