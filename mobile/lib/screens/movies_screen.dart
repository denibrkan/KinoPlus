import 'package:flutter/material.dart';
import 'package:mobile/common/rating_stars.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/category.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/movie_provider.dart';
import 'package:mobile/screens/movie_detail_screen.dart';
import 'package:mobile/utils/authorization.dart';
import 'package:mobile/utils/get_duration.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class MoviesScreen extends StatefulWidget {
  const MoviesScreen({super.key});

  @override
  State<MoviesScreen> createState() => _MoviesScreenState();
}

class _MoviesScreenState extends State<MoviesScreen> {
  late MovieProvider _movieProvider;
  late CategoryProvider _categoryProvider;

  bool loading = false;
  List<Movie> movies = <Movie>[];
  List<Category> categories = <Category>[];

  @override
  void initState() {
    super.initState();

    _movieProvider = context.read<MovieProvider>();
    _categoryProvider = context.read<CategoryProvider>();

    loadData();
  }

  void loadData() async {
    loadMovies();
    await loadCategories();
  }

  void loadMovies() async {
    loading = true;
    try {
      var params = <String, String>{};
      if (_movieProvider.category != null) {
        params.addAll({'categoryId': _movieProvider.category!.id.toString()});
      }
      params.addAll({'activeOnly': 'true'});

      var data = await _movieProvider.get(params);

      setState(() {
        movies = data;
      });

      loading = false;
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  Future loadCategories() async {
    try {
      var params = <String, String>{'isDisplayed': 'true'};

      categories = await _categoryProvider.get(params);
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  @override
  void dispose() {
    super.dispose();
    _movieProvider.setCategory(null);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Filmovi'),
        actions: [
          IconButton(
              onPressed: () =>
                  showSearch(context: context, delegate: MySearchDelegate()),
              icon: const Icon(Icons.search))
        ],
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.symmetric(vertical: 20.0, horizontal: 12),
          child: Column(
            children: [
              _buildFilterList(),
              _buildMovieList(),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildMovieList() {
    if (loading) {
      return Column(
        children: const [
          SizedBox(
            height: 130,
          ),
          Center(
            child: CircularProgressIndicator(
              color: Colors.lightBlueAccent,
            ),
          ),
        ],
      );
    } else if (movies.isEmpty) {
      return const Center(child: Text('Prazno :('));
    }

    return Column(
      children: movies
          .map((movie) => GestureDetector(
                onTap: () => Navigator.pushNamed(
                  context,
                  MovieDetailScreen.routeName,
                  arguments: movie,
                ),
                child: Container(
                    margin: const EdgeInsets.only(bottom: 16),
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(8),
                      color: primary[400],
                    ),
                    child: Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        ClipRRect(
                          borderRadius: const BorderRadius.only(
                              topLeft: Radius.circular(8),
                              bottomLeft: Radius.circular(8)),
                          child: FadeInImage(
                            image: NetworkImage(
                              '$apiUrl/images/${movie.imageId}',
                              headers: Authorization.createHeaders(),
                            ),
                            placeholder: MemoryImage(kTransparentImage),
                            fadeInDuration: const Duration(milliseconds: 300),
                            fit: BoxFit.fill,
                            width: 80,
                            height: 105,
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.symmetric(
                              vertical: 8.0, horizontal: 12),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Padding(
                                padding: const EdgeInsets.only(left: 2),
                                child: Text(
                                  movie.title,
                                  style: const TextStyle(fontSize: 15),
                                ),
                              ),
                              const SizedBox(
                                height: 6,
                              ),
                              Padding(
                                padding: const EdgeInsets.only(left: 2.5),
                                child: Text(
                                  getDuration(movie.duration),
                                  style: const TextStyle(color: Colors.white54),
                                ),
                              ),
                              const SizedBox(
                                height: 4,
                              ),
                              Padding(
                                padding: const EdgeInsets.only(left: 2.5),
                                child: Text(
                                  movie.genres.map((e) => e.name).join(', '),
                                  style: const TextStyle(color: Colors.white54),
                                ),
                              ),
                              const SizedBox(
                                height: 6,
                              ),
                              if (movie.averageRating != 0)
                                RatingStars(
                                    rating: movie.averageRating, size: 15),
                            ],
                          ),
                        )
                      ],
                    )),
              ))
          .toList(),
    );
  }

  Widget _buildFilterList() {
    if (_movieProvider.category == null) {
      return Container();
    }

    return Container(
      margin: const EdgeInsets.only(bottom: 20),
      child: Row(
        children: [
          Container(
            padding: const EdgeInsets.all(8),
            decoration: BoxDecoration(
              border: Border.all(color: Colors.grey),
              borderRadius: BorderRadius.circular(15),
            ),
            child: Text(_movieProvider.category!.name),
          )
        ],
      ),
    );
  }
}

class MySearchDelegate extends SearchDelegate {
  MySearchDelegate() : super(searchFieldLabel: 'Pretraži naslove...');
  @override
  ThemeData appBarTheme(BuildContext context) {
    return Theme.of(context).copyWith(
      inputDecorationTheme: const InputDecorationTheme(
        hintStyle: TextStyle(color: Colors.grey, fontSize: 15),
      ),
      textTheme: const TextTheme(
          titleMedium: TextStyle(color: Color.fromRGBO(233, 233, 233, 1))),
    );
  }

  @override
  List<Widget>? buildActions(BuildContext context) => [
        IconButton(
            onPressed: () {
              if (query.isEmpty) {
                close(context, null);
              } else {
                query = '';
              }
            },
            icon: const Icon(Icons.clear))
      ];

  @override
  Widget? buildLeading(BuildContext context) => IconButton(
        onPressed: () => close(context, null),
        icon: const Icon(Icons.arrow_back),
      );

  @override
  Widget buildResults(BuildContext context) {
    return Container();
  }

  @override
  Widget buildSuggestions(BuildContext context) {
    return Container();
  }
}
