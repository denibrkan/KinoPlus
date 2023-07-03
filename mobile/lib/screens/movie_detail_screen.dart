import 'dart:async';

import 'package:flutter/material.dart';
import 'package:mobile/common/rating_bar.dart';
import 'package:mobile/common/video_player_modal.dart';
import 'package:mobile/components/movie_details/movie_tabs.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/providers/movie_provider.dart';
import 'package:mobile/providers/movie_tab_provider.dart';
import 'package:mobile/utils/authorization.dart';
import 'package:mobile/utils/get_duration.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class MovieDetailScreen extends StatefulWidget {
  const MovieDetailScreen(
      {super.key, required this.movie, required this.fetchData});

  static const String routeName = '/movie';

  final Movie movie;
  final bool fetchData;

  @override
  State<MovieDetailScreen> createState() => _MovieDetailScreenState();
}

class _MovieDetailScreenState extends State<MovieDetailScreen> {
  TabOptions? selectedTab;

  late MovieProvider _movieProvider;

  late Movie movie;

  @override
  void initState() {
    super.initState();
    movie = widget.movie;

    if (widget.fetchData) {
      _movieProvider = context.read<MovieProvider>();
      loadData();
    }
  }

  void loadData() async {
    var data = await _movieProvider.getById(widget.movie.id, null);
    setState(() {
      movie = data;
    });
  }

  @override
  Widget build(BuildContext context) {
    selectedTab = context.watch<MovieTabProvider>().selectedTab;
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            _buildImageStack(),
            const SizedBox(
              height: 12,
            ),
            _buildMovieInfo(),
            const SizedBox(height: 30),
            MovieTabs(movie: movie),
          ],
        ),
      ),
    );
  }

  Widget _buildImageStack() {
    return Stack(
      alignment: Alignment.center,
      children: [
        const CircularProgressIndicator(
          color: Colors.lightBlueAccent,
        ),
        ShaderMask(
          shaderCallback: (rect) {
            return const LinearGradient(
              begin: Alignment.center,
              end: Alignment.bottomCenter,
              colors: [Colors.black, Colors.transparent],
            ).createShader(Rect.fromLTRB(0, 0, rect.width, rect.height));
          },
          blendMode: BlendMode.dstIn,
          child: SizedBox(
            height: MediaQuery.of(context).size.height * 0.7,
            width: MediaQuery.of(context).size.width,
            child: movie.imageId != null
                ? FadeInImage(
                    placeholder: MemoryImage(kTransparentImage),
                    image: NetworkImage(
                      '$apiUrl/images/${movie.imageId}?original=true',
                      headers: Authorization.createHeaders(),
                    ),
                    fadeInCurve: Curves.linear,
                    fadeInDuration: const Duration(milliseconds: 500),
                    fit: BoxFit.cover,
                  )
                : const Placeholder(),
          ),
        ),
        IconButton(
          onPressed: () {
            if (movie.trailerUrl?.isNotEmpty == true) {
              showDialog(
                context: context,
                builder: (BuildContext context) =>
                    VideoPlayerModal(videoUrl: movie.trailerUrl!),
                useSafeArea: true,
              );
            }
          },
          icon: Icon(
            Icons.play_circle,
            color: Colors.white54,
            size: 50,
            shadows: [
              Shadow(
                color: Colors.black.withOpacity(0.5),
                blurRadius: 20,
                offset: const Offset(5, 5),
              ),
              Shadow(
                color: Colors.black.withOpacity(0.5),
                blurRadius: 20,
                offset: const Offset(-5, -5),
              ),
            ],
          ),
          padding: const EdgeInsets.all(0),
        ),
      ],
    );
  }

  Widget _buildMovieInfo() {
    return Column(
      children: [
        Text(
          movie.title,
          style: const TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.center,
        ),
        const SizedBox(
          height: 10,
        ),
        Text(
          getDuration(movie.duration),
          style: const TextStyle(color: Colors.grey),
        ),
        const SizedBox(
          height: 6,
        ),
        Text(
          movie.genres.map((e) => e.name).join(', '),
          style: const TextStyle(color: Colors.grey),
        ),
        if (movie.averageRating != 0)
          Container(
            margin: const EdgeInsets.only(top: 16),
            child: RatingBar(rating: movie.averageRating),
          ),
      ],
    );
  }
}
