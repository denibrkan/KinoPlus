import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'helpers/constants.dart';
import 'helpers/my_http_overrides.dart';
import 'helpers/colors.dart';
import 'models/movie.dart';

void main() async {
  HttpOverrides.global = MyHttpOverrides();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Kino+',
      theme: ThemeData(
        primarySwatch: primary,
        textTheme: const TextTheme(
          bodyMedium: TextStyle(color: Colors.white),
        ),
      ),
      home: const MyHomePage(title: 'Kino+'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  late Future<List<Movie>> futureMovies;

  Future<List<Movie>> fetchMovies() async {
    var headers = {
      'Authorization':
          'Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJ0ZXN0IiwibmJmIjoxNjgwODU0OTIyLCJleHAiOjE2ODE0NTk3MjIsImlhdCI6MTY4MDg1NDkyMn0.EBjynCQNmRS1PaKWE-9zjHg3blH--Ldj0pSJbfZNRiONl15OhhjQg91ZiB2DxLZvSFrl9lElo5ZJh1z6AaQ6Kg'
    };

    final response =
        await http.get(Uri.parse('$apiUrl/movies'), headers: headers);

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
            style: TextStyle(
              color: primary.shade50,
              fontSize: 25,
              fontWeight: FontWeight.w400,
            )),
        centerTitle: true,
      ),
      body: Container(
        height: 350,
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
                  mainAxisSpacing: 20,
                ),
                scrollDirection: Axis.horizontal,
                children: _buildMovieList(snapshot.data!),
              );
            } else if (snapshot.hasError) {
              return Text('${snapshot.error}');
            }
            return Center(
              child: CircularProgressIndicator(
                color: primaryAccent.shade200,
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
                Image.network('$apiUrl/images/${movie.imageId}'),
                Padding(
                  padding: const EdgeInsets.fromLTRB(8, 16, 8, 16),
                  child: Text(
                    movie.title,
                    style: const TextStyle(fontSize: 18),
                  ),
                ),
              ],
            ))
        .toList();
  }
}
