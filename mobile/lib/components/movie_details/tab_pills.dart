import 'package:flutter/material.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/movie.dart';

class TabPills extends StatefulWidget {
  const TabPills(
      {super.key, required this.movie, required this.onSelectedChange});

  final Movie movie;
  final ValueChanged<TabOptions> onSelectedChange;

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
                widget.onSelectedChange(newSelection.first);
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
      ],
    );
  }
}
