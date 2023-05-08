import 'package:mobile/models/category.dart';
import 'package:mobile/providers/base_provider.dart';

class CategoryProvider extends BaseProvider<Category> {
  CategoryProvider() : super('categories');

  @override
  Category fromJson(data) {
    return Category.fromJson(data);
  }
}
