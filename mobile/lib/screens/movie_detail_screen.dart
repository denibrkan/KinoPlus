import 'dart:async';

import 'package:flutter/material.dart';
import 'package:mobile/common/rating_bar.dart';
import 'package:mobile/common/video_player_modal.dart';
import 'package:mobile/components/movie_details/movie_tabs.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/providers/movie_tab_provider.dart';
import 'package:mobile/utils/authorization.dart';
import 'package:mobile/utils/get_duration.dart';
import 'package:provider/provider.dart';
import 'package:transparent_image/transparent_image.dart';

class MovieDetailScreen extends StatefulWidget {
  const MovieDetailScreen({super.key, required this.movie});

  static const String routeName = '/movie';

  final Movie movie;

  @override
  State<MovieDetailScreen> createState() => _MovieDetailScreenState();
}

class _MovieDetailScreenState extends State<MovieDetailScreen> {
  var scrollController = ScrollController();
  TabOptions? selectedTab;

  @override
  Widget build(BuildContext context) {
    selectedTab = context.watch<MovieTabProvider>().selectedTab;

    return Scaffold(
      backgroundColor: primary.shade500,
      body: SingleChildScrollView(
        controller: scrollController,
        child: Column(
          children: [
            _buildImageStack(),
            const SizedBox(
              height: 12,
            ),
            _buildMovieInfo(),
            const SizedBox(height: 30),
            MovieTabs(movie: widget.movie),
          ],
        ),
      ),
    );
  }

  void handleScroll() async {
    Timer(const Duration(milliseconds: 500), () {
      scrollController.animateTo(scrollController.position.maxScrollExtent,
          duration: const Duration(milliseconds: 500), curve: Curves.easeOut);
    });
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
            child: widget.movie.imageId != null
                ? FadeInImage(
                    placeholder: MemoryImage(kTransparentImage),
                    image: NetworkImage(
                      '$apiUrl/images/${widget.movie.imageId}?original=true',
                      headers: Authorization.createHeaders(),
                    ),
                    fadeInCurve: Curves.linear,
                    fadeInDuration: const Duration(milliseconds: 500),
                  )
                : const Placeholder(),
          ),
        ),
        IconButton(
          onPressed: () {
            if (widget.movie.trailerUrl?.isNotEmpty == true) {
              showDialog(
                context: context,
                builder: (BuildContext context) =>
                    VideoPlayerModal(videoUrl: widget.movie.trailerUrl!),
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
          widget.movie.title,
          style: const TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.center,
        ),
        const SizedBox(
          height: 10,
        ),
        Text(
          getDuration(widget.movie.duration),
          style: const TextStyle(color: Colors.white54),
        ),
        const SizedBox(
          height: 6,
        ),
        Text(
          widget.movie.genres.map((e) => e.name).join(', '),
          style: const TextStyle(color: Colors.white54),
        ),
        if (widget.movie.averageRating != 0)
          Container(
            margin: const EdgeInsets.only(top: 16),
            child: RatingBar(rating: widget.movie.averageRating),
          ),
      ],
    );
  }
}
