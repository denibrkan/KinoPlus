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
import 'package:mobile/providers/reaction_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/utils/get_form_input_decoration.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';

class MovieTabs extends StatefulWidget {
  final Movie movie;

  const MovieTabs({super.key, required this.movie});

  @override
  State<MovieTabs> createState() => _MovieTabsState();
}

class _MovieTabsState extends State<MovieTabs> {
  TabOptions? selectedTab;
  int rating = 3;
  List<Reaction> reactions = <Reaction>[];

  late UserProvider _userProvider;
  late ReactionProvider _reactionProvider;

  bool loading = false;

  final _reactionController = TextEditingController();

  @override
  void initState() {
    super.initState();

    _userProvider = context.read<UserProvider>();
    _reactionProvider = context.read<ReactionProvider>();

    loadReactions();
  }

  loadReactions() async {
    try {
      setState(() {
        loading = true;
      });

      final data = await _reactionProvider
          .get(<String, String>{'movieId': widget.movie.id.toString()});

      setState(() {
        reactions = data;
        loading = false;
      });
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  onRatingUpdate(double value) {
    rating = value.toInt();
  }

  insertReaction() async {
    var reaction = ReactionInsert(
      rating: rating,
      comment: _reactionController.text,
      movieId: widget.movie.id,
      userId: _userProvider.user!.id,
    );

    try {
      await _reactionProvider.insert(reaction);

      await loadReactions();
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  @override
  Widget build(BuildContext context) {
    selectedTab = context.watch<MovieTabProvider>().selectedTab;

    return ChangeNotifierProvider(
      create: (context) => DateProvider(),
      child: Column(
        children: [
          TabPills(
            reactions: reactions,
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
            child: Column(
              children: [
                _buildReactionInsertField(),
                _buildReactionList(),
              ],
            ));
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

  Widget _buildReactionList() {
    if (loading) {
      return const Center(
        child: CircularProgressIndicator(
          color: Colors.lightBlueAccent,
        ),
      );
    }
    if (reactions.isEmpty) {
      return const Text(
        'Trenutno nema reakcija.',
        style: TextStyle(color: Colors.grey),
      );
    }
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
                        RatingStars(rating: r.rating, size: 16),
                        SizedBox(height: 12),
                        Container(
                          margin: EdgeInsets.only(left: 4),
                          child: Text(
                            r.comment ?? '',
                            style: const TextStyle(
                              color: Color.fromARGB(255, 201, 201, 201),
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
                            r.user!.username,
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

  Widget _buildReactionInsertField() {
    final user = _userProvider.user!;
    if (user.moviesWatched.any((movie) => movie.id == widget.movie.id) &&
        !reactions.any((r) => r.userId == user.id)) {
      //create insert field
      return Container(
        margin: const EdgeInsets.symmetric(horizontal: 16),
        child: Column(
          children: [
            RatingStars(
                rating: 3,
                canUpdate: true,
                onUpdate: (value) => onRatingUpdate(value),
                allowHalfRating: false,
                size: 20),
            const SizedBox(
              height: 15,
            ),
            TextField(
              controller: _reactionController,
              decoration: getFormInputDecoration('Unesite reakciju...', null),
              minLines: 1,
              maxLines: 5,
            ),
            const SizedBox(
              height: 10,
            ),
            _reactionController.text.isNotEmpty
                ? SizedBox(
                    width: double.infinity,
                    child: ElevatedButton(
                      onPressed: () => insertReaction(),
                      style: ElevatedButton.styleFrom(
                          backgroundColor:
                              const Color.fromARGB(255, 0, 101, 151),
                          padding: const EdgeInsets.symmetric(vertical: 12)),
                      child: const Text('Spremi'),
                    ),
                  )
                : Container(),
            const Divider(thickness: 0.5, color: Colors.grey, height: 30),
          ],
        ),
      );
    }
    return Container();
  }
}
