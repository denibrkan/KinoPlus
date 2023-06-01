import 'package:flutter/material.dart';
import 'package:mobile/common/rating_stars.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/category.dart';
import 'package:mobile/models/genre.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/genre_provider.dart';
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
  late GenreProvider _genreProvider;

  bool loading = false;
  List<Movie> movies = <Movie>[];
  List<Category> categories = <Category>[];
  List<Genre> genres = <Genre>[];

  MovieSorting sortBy = MovieSorting.dateCreated;
  late Category? selectedCategory;
  Genre? selectedGenre;

  final GlobalKey<ScaffoldState> _scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  void initState() {
    super.initState();

    _movieProvider = context.read<MovieProvider>();
    _categoryProvider = context.read<CategoryProvider>();
    _genreProvider = context.read<GenreProvider>();

    selectedCategory = _movieProvider.category;
    categories = _categoryProvider.categories;

    loadData();
  }

  void loadData() async {
    loadMovies();
    await loadGenres();
  }

  void loadMovies() async {
    loading = true;
    try {
      var params = <String, String>{
        'activeOnly': 'true',
        'sortBy': sortBy.name
      };
      if (selectedCategory != null) {
        params.addAll({'categoryId': selectedCategory!.id.toString()});
      }
      if (selectedGenre != null) {
        params.addAll({'genreId': selectedGenre!.id.toString()});
      }
      var data = await _movieProvider.get(params);

      setState(() {
        movies = data;
      });

      loading = false;
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  Future loadGenres() async {
    try {
      genres = await _genreProvider.get(null);
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
        child: Container(
          margin: const EdgeInsets.all(8),
          child: Column(
            children: [
              _buildButtons(),
              _buildFilterList(),
              _buildMovieList(),
            ],
          ),
        ),
      ),
      endDrawer: _buildFilterDrawer(),
      key: _scaffoldKey,
    );
  }

  Widget _buildButtons() {
    return Container(
      margin: const EdgeInsets.only(bottom: 25.0),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(6),
        color: Colors.white,
      ),
      child: IntrinsicHeight(
        child: Row(
          children: [
            Expanded(
              child: TextButton.icon(
                  onPressed: () => sortingDialog,
                  icon: const Icon(
                    Icons.sort,
                    color: Color.fromARGB(255, 0, 101, 151),
                  ),
                  label: Text(
                    'Poredaj',
                    style: TextStyle(color: primary[500]),
                  )),
            ),
            const VerticalDivider(
              thickness: 0.5,
              color: Colors.grey,
            ),
            Expanded(
              child: TextButton.icon(
                  onPressed: () {
                    _scaffoldKey.currentState!.openEndDrawer();
                  },
                  icon: const Icon(
                    Icons.filter_alt,
                    color: Color.fromARGB(255, 0, 101, 151),
                  ),
                  label: Text(
                    'Filtriraj',
                    style: TextStyle(color: primary[500]),
                  )),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildFilterList() {
    if (selectedCategory == null && selectedGenre == null) {
      return Container();
    }

    return Container(
      margin: const EdgeInsets.only(bottom: 20),
      child: Row(
        children: [
          if (selectedCategory != null)
            Container(
              padding: const EdgeInsets.all(8),
              margin: const EdgeInsets.only(right: 12),
              decoration: BoxDecoration(
                border: Border.all(color: Colors.grey),
                borderRadius: BorderRadius.circular(15),
              ),
              child: Text(selectedCategory!.name),
            ),
          if (selectedGenre != null)
            Container(
              padding: const EdgeInsets.all(8),
              decoration: BoxDecoration(
                border: Border.all(color: Colors.grey),
                borderRadius: BorderRadius.circular(15),
              ),
              child: Text(selectedGenre!.name),
            )
        ],
      ),
    );
  }

  Widget _buildFilterDrawer() {
    return Drawer(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
              color: primary[500],
              padding: const EdgeInsets.symmetric(vertical: 30, horizontal: 12),
              margin: const EdgeInsets.only(bottom: 20),
              child: Row(
                children: [
                  Text(
                    'Filtriraj rezultate',
                    style: Theme.of(context).textTheme.titleMedium,
                  ),
                ],
              )),
          Expanded(
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    'Kategorija',
                    style: Theme.of(context)
                        .textTheme
                        .titleLarge!
                        .copyWith(color: primary[500]),
                  ),
                  _buildCategoryDropdown(),
                  Text(
                    'Žanr',
                    style: Theme.of(context)
                        .textTheme
                        .titleLarge!
                        .copyWith(color: primary[500]),
                  ),
                  _buildGenreDropdown(),
                ],
              ),
            ),
          ),
          Row(
            children: [
              Expanded(
                child: TextButton(
                    style: TextButton.styleFrom(
                      minimumSize: const Size.fromHeight(50),
                    ),
                    onPressed: () {
                      setState(() {
                        selectedCategory = null;
                        selectedGenre = null;
                      });
                      loadMovies();
                    },
                    child: const Text('Poništi')),
              ),
              Expanded(
                child: TextButton(
                    style: TextButton.styleFrom(
                      minimumSize: const Size.fromHeight(50),
                    ),
                    onPressed: () {
                      _scaffoldKey.currentState!.closeEndDrawer();
                    },
                    child: const Text('Zatvori')),
              ),
            ],
          )
        ],
      ),
    );
  }

  Widget _buildCategoryDropdown() {
    return Container(
        margin: const EdgeInsets.only(top: 6, bottom: 20),
        child: categories.isNotEmpty
            ? DropdownButton<Category>(
                isExpanded: true,
                value: selectedCategory,
                icon: const Icon(Icons.arrow_drop_down),
                elevation: 16,
                hint: const Text('Odaberi kategoriju...'),
                dropdownColor: const Color(0xFF2B3543),
                onChanged: (Category? value) {
                  setState(() {
                    selectedCategory = value;
                  });
                  loadMovies();
                },
                items: categories
                    .map<DropdownMenuItem<Category>>(
                        (c) => DropdownMenuItem<Category>(
                              value: c,
                              child: Text(c.name,
                                  style: const TextStyle(color: Colors.white)),
                            ))
                    .toList(),
                selectedItemBuilder: (_) {
                  return categories
                      .map((c) => Container(
                            alignment: Alignment.centerLeft,
                            child: Text(
                              c.name,
                              style: TextStyle(color: primary[500]),
                            ),
                          ))
                      .toList();
                },
              )
            : Container());
  }

  Widget _buildGenreDropdown() {
    return Container(
        margin: const EdgeInsets.only(top: 6, bottom: 20),
        child: genres.isNotEmpty
            ? DropdownButton<Genre>(
                isExpanded: true,
                value: selectedGenre,
                icon: const Icon(Icons.arrow_drop_down),
                elevation: 16,
                hint: const Text('Odaberi žanr...'),
                dropdownColor: const Color(0xFF2B3543),
                onChanged: (Genre? value) {
                  setState(() {
                    selectedGenre = value;
                  });
                  loadMovies();
                },
                items: genres
                    .map<DropdownMenuItem<Genre>>(
                        (c) => DropdownMenuItem<Genre>(
                              value: c,
                              child: Text(c.name,
                                  style: const TextStyle(color: Colors.white)),
                            ))
                    .toList(),
                selectedItemBuilder: (_) {
                  return genres
                      .map((c) => Container(
                            alignment: Alignment.centerLeft,
                            child: Text(
                              c.name,
                              style: TextStyle(color: primary[500]),
                            ),
                          ))
                      .toList();
                },
              )
            : Container());
  }

  get sortingDialog => showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text(
              'Poredaj rezultate',
              style: TextStyle(color: primary[500]),
            ),
            content: SingleChildScrollView(
              child: ListBody(
                children: MovieSorting.values
                    .map(
                      (sorter) => GestureDetector(
                        behavior: HitTestBehavior.translucent,
                        child: Padding(
                          padding: const EdgeInsets.symmetric(vertical: 12.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            crossAxisAlignment: CrossAxisAlignment.center,
                            children: [
                              Text(
                                _getMovieSorterName(sorter),
                                style: TextStyle(color: primary[500]),
                              ),
                              sortBy == sorter
                                  ? Icon(
                                      Icons.check,
                                      color: primary[500],
                                      size: 20,
                                    )
                                  : Container()
                            ],
                          ),
                        ),
                        onTap: () {
                          sortBy = sorter;
                          loadMovies();
                          Navigator.of(context).pop();
                        },
                      ),
                    )
                    .toList(),
              ),
            ),
          );
        },
      );

  String _getMovieSorterName(MovieSorting sorter) {
    switch (sorter) {
      case MovieSorting.dateCreated:
        return 'Najnovije';
      case MovieSorting.popularity:
        return 'Popularno';
      case MovieSorting.rating:
        return 'Najbolje ocijenjeno';
      default:
        return '';
    }
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
