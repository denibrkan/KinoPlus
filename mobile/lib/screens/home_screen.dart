import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/movie.dart';
import 'package:http/http.dart' as http;

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key, required this.title});

  final String title;

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  late Future<List<Movie>> futureMovies;

  Future<List<Movie>> fetchMovies() async {
    final response = await http.get(Uri.parse('$apiUrl/movies'));

    if (response.statusCode == 200) {
      var data = jsonDecode(response.body);
      var list = data.map((p) => Movie.fromJson(p)).cast<Movie>().toList();
      return list;
    } else {
      throw Exception('Could not load movies.');
    }
  }

  @override
  void initState() {
    super.initState();
    futureMovies = fetchMovies();
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
      body: Container(
        height: 300,
        padding: const EdgeInsets.fromLTRB(0, 30, 0, 30),
        color: primary.shade700,
        child: FutureBuilder(
          future: futureMovies,
          builder: (context, snapshot) {
            if (snapshot.hasData) {
              return GridView(
                gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
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
    );
  }

  List<Widget> _buildMovieList(List<Movie> movies) {
    return movies
        .map((movie) => Column(
              children: [
                Image.network(
                  '$apiUrl/images/${movie.imageId}',
                  height: 180,
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(0, 12, 0, 0),
                  child: Text(
                    movie.title,
                    style: const TextStyle(fontSize: 15),
                  ),
                ),
              ],
            ))
        .toList();
  }
}
