import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/common/build_rating_stars.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/models/reaction.dart';
import 'package:mobile/utils/get_duration.dart';

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
      body: SingleChildScrollView(
        child: Column(
          children: [
            _buildImageStack(),
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
                child: buildRatingBar(widget.movie.averageRating),
              ),
            const SizedBox(height: 30),
            TabPills(movie: widget.movie),
          ],
        ),
      ),
    );
  }

  Widget _buildImageStack() {
    return Stack(
      alignment: Alignment.center,
      children: [
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
            width: MediaQuery.of(context).size.width,
            child: Image.network(
              '$apiUrl/images/${widget.movie.imageId}?original=true',
              fit: BoxFit.cover,
            ),
          ),
        ),
        Padding(
          padding: const EdgeInsets.all(16.0),
          child: Icon(
            Icons.play_circle,
            color: Colors.white70,
            size: 50,
            shadows: [
              Shadow(
                color: Colors.black.withOpacity(0.5),
                blurRadius: 20,
                offset: const Offset(5, 5),
              ),
            ],
          ),
        ),
      ],
    );
  }
}

enum TabOptions { details, reactions, projections }

Widget buildRatingBar(num averageRating) {
  return Row(
    mainAxisAlignment: MainAxisAlignment.center,
    children: [
      Text(
        '$averageRating/5',
        textScaleFactor: 1.35,
      ),
      const SizedBox(
        width: 10,
      ),
      buildRatingStars(averageRating),
    ],
  );
}

class TabPills extends StatefulWidget {
  const TabPills({super.key, required this.movie});

  final Movie movie;

  @override
  State<TabPills> createState() => _TabPillsState();
}

class _TabPillsState extends State<TabPills> {
  TabOptions selectedTab = TabOptions.details;

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Center(
          child: Container(
            margin: const EdgeInsets.only(left: 6, right: 6),
            height: 40,
            width: double.infinity,
            child: SegmentedButton<TabOptions>(
              segments: <ButtonSegment<TabOptions>>[
                const ButtonSegment<TabOptions>(
                  value: TabOptions.details,
                  label: Text('Detalji'),
                  icon: Icon(Icons.info),
                ),
                ButtonSegment<TabOptions>(
                  value: TabOptions.reactions,
                  label: Text(
                      'Reakcije ${widget.movie.reactions.isNotEmpty ? "(${widget.movie.reactions.length})" : ""}'),
                  icon: const Icon(Icons.reviews),
                ),
                const ButtonSegment<TabOptions>(
                  value: TabOptions.projections,
                  label: Text('Projekcije'),
                  icon: Icon(Icons.theaters),
                ),
              ],
              selected: <TabOptions>{selectedTab},
              onSelectionChanged: (Set<TabOptions> newSelection) {
                setState(() {
                  selectedTab = newSelection.first;
                });
              },
              showSelectedIcon: false,
              style: ButtonStyle(
                visualDensity: const VisualDensity(vertical: -2),
                side: MaterialStateProperty.all(
                    BorderSide(width: 0.2, color: primary.shade100)),
                padding: MaterialStateProperty.all(
                    const EdgeInsets.fromLTRB(0, 0, 0, 0)),
                backgroundColor: MaterialStateProperty.resolveWith<Color?>(
                  (Set<MaterialState> states) {
                    if (states.contains(MaterialState.selected)) {
                      return Colors.red;
                    }
                    return primary.shade500; // Use the component's default.
                  },
                ),
                foregroundColor: MaterialStateProperty.resolveWith<Color?>(
                  (Set<MaterialState> states) {
                    if (states.contains(MaterialState.selected)) {
                      return Colors.white;
                    }
                    return primary.shade100; // Use the component's default.
                  },
                ),
              ),
            ),
          ),
        ),
        _buildTabContent(widget.movie),
      ],
    );
  }

  Widget _buildTabContent(Movie movie) {
    Widget widget;
    switch (selectedTab) {
      case TabOptions.details:
        widget = Container(
          padding: const EdgeInsets.fromLTRB(20, 30, 20, 50),
          child: Column(
            children: [
              Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  const Text(
                    'Opis',
                    style: TextStyle(
                      fontSize: 16,
                    ),
                  ),
                  const SizedBox(
                    height: 16,
                  ),
                  Text(
                    movie.description,
                    style: const TextStyle(
                      color: Colors.white54,
                    ),
                    textAlign: TextAlign.justify,
                  )
                ],
              ),
              const SizedBox(
                height: 25,
              ),
              Column(
                children: [
                  const Text(
                    'Uloge',
                    style: TextStyle(
                      fontSize: 16,
                    ),
                  ),
                  const SizedBox(
                    height: 16,
                  ),
                  Text(
                    movie.actors.map((a) => a.name).join(', '),
                    style: const TextStyle(
                      color: Colors.grey,
                    ),
                  )
                ],
              ),
            ],
          ),
        );
        break;
      case TabOptions.reactions:
        widget = Container(
          margin: const EdgeInsets.only(
            top: 30,
            bottom: 50,
          ),
          child: movie.averageRating != 0
              ? _buildReactionList(movie.reactions)
              : const Text(
                  'Trenutno nema reakcija.',
                  style: TextStyle(color: Colors.white54),
                ),
        );
        break;
      case TabOptions.projections:
        widget = SizedBox(
          height: MediaQuery.of(context).size.height - 42,
          child: const Text(
            'Projekcije',
            style: TextStyle(
              fontSize: 18,
            ),
          ),
        );
        break;
      default:
        widget = Container();
    }

    return widget;
  }

  Widget _buildReactionList(List<Reaction> reactions) {
    var reactionList = reactions
        .map((r) => Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  width: MediaQuery.of(context).size.width,
                  padding: const EdgeInsets.all(15),
                  margin: const EdgeInsets.all(15),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    color: const Color(0xFF2B3543),
                  ),
                  child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        buildRatingStars(r.rating),
                        Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Text(
                            r.comment ?? '',
                            style: const TextStyle(
                              color: Colors.grey,
                            ),
                          ),
                        ),
                      ]),
                ),
                Container(
                  margin: const EdgeInsets.only(left: 20, bottom: 30),
                  child: Row(
                    children: [
                      Container(
                        padding: const EdgeInsets.all(8),
                        decoration: BoxDecoration(
                          border: Border.all(
                            color: Colors.grey[800]!,
                          ),
                          borderRadius: BorderRadius.circular(30),
                        ),
                        child: Image.asset(
                          'assets/images/user.png',
                          color: Colors.grey,
                          width: 22,
                          height: 22,
                        ),
                      ),
                      const SizedBox(
                        width: 12,
                      ),
                      Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(
                            r.user.username,
                            style: const TextStyle(
                              fontWeight: FontWeight.w500,
                              fontSize: 15,
                            ),
                          ),
                          Text(
                            DateFormat.yMMMMd()
                                .format(DateTime.parse(r.dateCreated)),
                            style: const TextStyle(
                              color: Colors.grey,
                            ),
                          ),
                        ],
                      )
                    ],
                  ),
                )
              ],
            ))
        .toList();

    return Column(
      children: reactionList,
    );
  }
}
