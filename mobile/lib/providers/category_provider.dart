import 'package:mobile/models/category.dart';
import 'package:mobile/providers/base_provider.dart';

class CategoryProvider extends BaseProvider<Category> {
  CategoryProvider() : super('categories');

  List<Category> categories = <Category>[];

  @override
  Future<List<Category>> get(Map<String, String>? params) async {
    categories = await super.get(params);

    return categories;
  }

  @override
  Category fromJson(data) {
    return Category.fromJson(data);
  }
}
