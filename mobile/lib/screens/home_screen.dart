import 'package:flutter/material.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/category.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/movie_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/movie_detail_screen.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key, required this.title});

  final String title;

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  late Future<List<Movie>> futureMovies;
  late Future<List<Category>> futureCategories;

  late CategoryProvider _categoryProvider;
  late MovieProvider _movieProvider;
  late UserProvider _userProvider;

  Future<List<Movie>> fetchMovies() async {
    try {
      return await _movieProvider.recommend(_userProvider.user!.id);
    } catch (e) {
      showErrorDialog(context, e.toString().substring(11));

      return <Movie>[];
    }
  }

  Future<List<Category>> fetchByCategories() async {
    try {
      var params = <String, String>{'includeMovies': 'true'};
      return await _categoryProvider.get(params);
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));

      return <Category>[];
    }
  }

  @override
  void initState() {
    super.initState();

    _categoryProvider = context.read<CategoryProvider>();
    _movieProvider = context.read<MovieProvider>();
    _userProvider = context.read<UserProvider>();

    futureMovies = fetchMovies();
    futureCategories = fetchByCategories();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title,
            style: const TextStyle(
              fontSize: 25,
              fontWeight: FontWeight.w400,
            )),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 350,
              padding: const EdgeInsets.fromLTRB(0, 30, 0, 30),
              color: primary.shade700,
              child: FutureBuilder(
                future: futureMovies,
                builder: (context, snapshot) {
                  if (snapshot.hasData) {
                    return GridView(
                      gridDelegate:
                          const SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 1,
                        childAspectRatio: 4 / 3,
                        mainAxisSpacing: 0,
                      ),
                      scrollDirection: Axis.horizontal,
                      children: _buildMovieList(snapshot.data!),
                    );
                  } else if (snapshot.hasError) {
                    return Text('${snapshot.error}');
                  }
                  return Center(
                    child: CircularProgressIndicator(
                      color: Colors.lightBlue[300],
                    ),
                  );
                },
              ),
            ),
            FutureBuilder(
              future: futureCategories,
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  return _buildCategories(snapshot.data!);
                } else if (snapshot.hasError) {
                  return Text('${snapshot.error}');
                }
                return SizedBox(
                  height: 350,
                  child: Center(
                    child: CircularProgressIndicator(
                      color: Colors.lightBlue[300],
                    ),
                  ),
                );
              },
            )
          ],
        ),
      ),
    );
  }

  List<Widget> _buildMovieList(List<Movie> movies) {
    return movies
        .map((movie) => Column(
              children: [
                InkWell(
                  onTap: () => Navigator.pushNamed(
                    context,
                    MovieDetailScreen.routeName,
                    arguments: movie,
                  ),
                  child: movie.imageId != null
                      ? FadeInImage.memoryNetwork(
                          placeholder: kTransparentImage,
                          image: '$apiUrl/images/${movie.imageId}',
                          height: 210,
                          fadeInDuration: const Duration(milliseconds: 300),
                        )
                      : const Placeholder(
                          fallbackHeight: 210,
                        ),
                ),
                const SizedBox(
                  height: 12,
                ),
                Text(
                  movie.title,
                  style: Theme.of(context).textTheme.titleMedium,
                  textAlign: TextAlign.center,
                ),
              ],
            ))
        .toList();
  }

  Widget _buildCategories(List<Category> categories) {
    var categoriesToShow = categories.where((c) => c.movies.isNotEmpty);

    return Column(
      children: categoriesToShow
          .map(
            (c) => Container(
              height: 190,
              padding: const EdgeInsets.fromLTRB(16, 8, 16, 20),
              decoration: const BoxDecoration(
                border: Border(
                  top: BorderSide(
                    color: Colors.blueAccent,
                    width: 0.2,
                  ),
                ),
              ),
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(c.name,
                          style: Theme.of(context)
                              .textTheme
                              .titleMedium!
                              .copyWith(fontSize: 18)),
                      TextButton(
                          style: ButtonStyle(
                              foregroundColor: MaterialStateProperty.all<Color>(
                            Colors.lightBlue[300]!,
                          )),
                          onPressed: () => {},
                          child: const Text('Pogledaj sve'))
                    ],
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(0, 12, 12, 0),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: c.movies.take(4).map((m) {
                        return InkWell(
                            onTap: () => Navigator.pushNamed(
                                  context,
                                  MovieDetailScreen.routeName,
                                  arguments: m,
                                ),
                            child: SizedBox(
                              width: 70,
                              height: 90,
                              child: m.imageId != null
                                  ? FadeInImage.memoryNetwork(
                                      placeholder: kTransparentImage,
                                      image: '$apiUrl/images/${m.imageId}',
                                      fit: BoxFit.fill,
                                      fadeInDuration:
                                          const Duration(milliseconds: 300),
                                    )
                                  : const Placeholder(),
                            ));
                      }).toList(),
                    ),
                  )
                ],
              ),
            ),
          )
          .toList(),
    );
  }
}
