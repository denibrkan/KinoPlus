import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/movie.dart';

class MovieDetailScreen extends StatefulWidget {
  const MovieDetailScreen({super.key, required this.movie});

  static const String routeName = '/movie';

  final Movie movie;

  @override
  State<MovieDetailScreen> createState() => _MovieDetailScreenState();
}

class _MovieDetailScreenState extends State<MovieDetailScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: primary.shade500,
      body: Column(
        children: [
          Stack(
            alignment: Alignment.center,
            children: [
              ShaderMask(
                shaderCallback: (rect) {
                  return const LinearGradient(
                    begin: Alignment.topCenter,
                    end: Alignment.bottomCenter,
                    colors: [Colors.black, Colors.transparent],
                  ).createShader(Rect.fromLTRB(0, 0, rect.width, rect.height));
                },
                blendMode: BlendMode.dstIn,
                child: SizedBox(
                  width: MediaQuery.of(context).size.width,
                  child: Image.network(
                    '$apiUrl/images/${widget.movie.imageId}?original=true',
                    fit: BoxFit.cover,
                    alignment: Alignment.topCenter,
                  ),
                ),
              ),
              Positioned(
                bottom: 10,
                child: Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(16.0),
                      child: Text(
                        widget.movie.title,
                        style: const TextStyle(fontSize: 20),
                      ),
                    ),
                    Text(
                      '${widget.movie.duration} min',
                      style: const TextStyle(color: Colors.grey),
                    ),
                    Text(
                      widget.movie.genres.map((e) => e.name).join(', '),
                      style: const TextStyle(color: Colors.grey),
                    ),
                  ],
                ),
              ),
              const Positioned(
                bottom: 25,
                right: 0,
                child: Padding(
                  padding: EdgeInsets.all(16.0),
                  child: Icon(
                    Icons.play_circle,
                    color: Colors.white,
                    size: 50,
                  ),
                ),
              ),
            ],
          ),
          if (widget.movie.averageRating != 0)
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                  '${widget.movie.averageRating}/5',
                  textScaleFactor: 1.35,
                ),
                const SizedBox(
                  width: 10,
                ),
                RatingBar.builder(
                  ignoreGestures: true,
                  initialRating: widget.movie.averageRating.toDouble(),
                  direction: Axis.horizontal,
                  allowHalfRating: true,
                  itemCount: 5,
                  itemSize: 22,
                  itemPadding: const EdgeInsets.symmetric(horizontal: 2.0),
                  itemBuilder: (context, _) => const Icon(
                    Icons.star,
                    color: Colors.amber,
                  ),
                  onRatingUpdate: (rating) {},
                ),
              ],
            )
        ],
      ),
    );
  }
}
