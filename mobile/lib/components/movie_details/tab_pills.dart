import 'package:flutter/material.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/reaction.dart';
import 'package:mobile/providers/movie_tab_provider.dart';
import 'package:provider/provider.dart';

class TabPills extends StatefulWidget {
  const TabPills({super.key, required this.reactions});

  final List<Reaction> reactions;

  @override
  State<TabPills> createState() => _TabPillsState();
}

class _TabPillsState extends State<TabPills> {
  TabOptions? selectedTab;

  late MovieTabProvider _movieTabProvider;

  @override
  void initState() {
    super.initState();

    _movieTabProvider = context.read<MovieTabProvider>();
  }

  @override
  Widget build(BuildContext context) {
    selectedTab = context.watch<MovieTabProvider>().selectedTab;

    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Center(
          child: Container(
            margin: const EdgeInsets.only(left: 6, right: 6),
            height: 40,
            width: double.infinity,
            child: SegmentedButton<TabOptions>(
              emptySelectionAllowed: true,
              segments: <ButtonSegment<TabOptions>>[
                const ButtonSegment<TabOptions>(
                  value: TabOptions.details,
                  label: Text('Detalji'),
                  icon: Icon(Icons.info),
                ),
                ButtonSegment<TabOptions>(
                  value: TabOptions.reactions,
                  label: Text(
                      'Reakcije ${widget.reactions.isNotEmpty ? "(${widget.reactions.length})" : ""}'),
                  icon: const Icon(Icons.reviews),
                ),
                const ButtonSegment<TabOptions>(
                  value: TabOptions.projections,
                  label: Text('Projekcije'),
                  icon: Icon(Icons.theaters),
                ),
              ],
              selected: selectedTab != null
                  ? <TabOptions>{selectedTab as TabOptions}
                  : <TabOptions>{},
              onSelectionChanged: (Set<TabOptions> newSelection) {
                setState(() {
                  if (newSelection.isEmpty) {
                    _movieTabProvider.setSelectedTab(null);
                  } else {
                    _movieTabProvider.setSelectedTab(newSelection.first);
                  }
                });
              },
              showSelectedIcon: false,
              style: ButtonStyle(
                visualDensity: const VisualDensity(vertical: -2),
                side: MaterialStateProperty.all(const BorderSide(
                    width: 0.2, color: Color.fromARGB(255, 219, 219, 219))),
                padding: MaterialStateProperty.all(
                    const EdgeInsets.fromLTRB(0, 0, 0, 0)),
              ),
            ),
          ),
        ),
      ],
    );
  }
}
