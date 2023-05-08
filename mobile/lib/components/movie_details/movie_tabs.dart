import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/common/rating_stars.dart';
import 'package:mobile/components/movie_details/projections_tab.dart';
import 'package:mobile/components/movie_details/tab_pills.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/movie.dart';
import 'package:mobile/models/reaction.dart';
import 'package:mobile/providers/date_provider.dart';
import 'package:mobile/providers/movie_tab_provider.dart';
import 'package:provider/provider.dart';

class MovieTabs extends StatefulWidget {
  final Movie movie;

  const MovieTabs({super.key, required this.movie});

  @override
  State<MovieTabs> createState() => _MovieTabsState();
}

class _MovieTabsState extends State<MovieTabs> {
  TabOptions? selectedTab;

  @override
  Widget build(BuildContext context) {
    selectedTab = context.watch<MovieTabProvider>().selectedTab;

    return ChangeNotifierProvider(
      create: (context) => DateProvider(),
      child: Column(
        children: [
          TabPills(
            movie: widget.movie,
          ),
          _buildTabContent(widget.movie)
        ],
      ),
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
              ? Column(
                  children: [
                    _buildReactionList(movie.reactions),
                  ],
                )
              : const Text(
                  'Trenutno nema reakcija.',
                  style: TextStyle(color: Colors.grey),
                ),
        );
        break;
      case TabOptions.projections:
        widget = ProjectionsTab(movieId: movie.id);
        break;
      default:
        return Container();
    }
    return Container(
      constraints: const BoxConstraints(minHeight: 500),
      child: widget,
    );
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
                        RatingStars(rating: r.rating),
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
