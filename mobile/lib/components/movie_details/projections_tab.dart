import 'dart:convert';
import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/components/movie_details/date_selector.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/constants.dart';
import 'package:mobile/models/projection.dart';
import 'package:http/http.dart' as http;

class ProjectionsTab extends StatefulWidget {
  const ProjectionsTab({super.key, required this.movieId});

  final int movieId;

  @override
  State<ProjectionsTab> createState() => _ProjectionsTabState();
}

class _ProjectionsTabState extends State<ProjectionsTab> {
  List<Projection> projections = <Projection>[];

  Future<List<Projection>> getProjections(DateTime date) async {
    final response = await http.get(
        Uri.parse('$apiUrl/projections?movieId=${widget.movieId}&date=$date'));

    if (response.statusCode == 200) {
      var data = jsonDecode(response.body);
      var list =
          data.map((p) => Projection.fromJson(p)).cast<Projection>().toList();

      return list;
    } else {
      throw Exception('Could not load projections.');
    }
  }

  void loadProjections(value) async {
    var projections = await getProjections(value);

    setState(() {
      this.projections = projections;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 25),
      child: Column(
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                'Datum',
                style: Theme.of(context).textTheme.titleMedium,
              ),
              const Icon(
                Icons.calendar_today,
                size: 26,
                color: Colors.lightBlue,
              ),
            ],
          ),
          const SizedBox(
            height: 20,
          ),
          DateSelector(onDateSelected: (value) => loadProjections(value)),
          const SizedBox(
            height: 30,
          ),
          _buildProjectionTickets(),
        ],
      ),
    );
  }

  Widget _buildProjectionTickets() {
    if (projections.isEmpty) {
      return const Text(
        'Prazno :(',
        style: TextStyle(color: Color.fromRGBO(233, 233, 233, 1), fontSize: 16),
      );
    }
    var groupedProjections =
        groupBy(projections, (Projection obj) => obj.projectionType!.name);

    var groups = <Widget>[];
    groupedProjections.forEach(
      (key, value) {
        groups.add(Column(
          children: [
            Text(
              key.toString(),
              style: Theme.of(context).textTheme.titleMedium!.copyWith(
                    color: Colors.grey,
                    fontWeight: FontWeight.w700,
                  ),
            ),
            GridView.count(
              shrinkWrap: true,
              primary: false,
              padding: EdgeInsets.zero,
              crossAxisCount: 3,
              crossAxisSpacing: 0,
              children: value
                  .map((p) => Stack(
                        alignment: Alignment.center,
                        children: [
                          Image.asset(
                            'assets/images/ticket120.png',
                            color: const Color(0xFF2B3543),
                          ),
                          Positioned(
                            top: 30,
                            child: Text(
                              '${DateFormat.Hm('bs').format(p.startsAt)}h',
                              style: Theme.of(context)
                                  .textTheme
                                  .titleMedium!
                                  .copyWith(
                                    fontWeight: FontWeight.w500,
                                  ),
                            ),
                          ),
                          Icon(Icons.star, color: primary.shade500, size: 20),
                          Positioned(
                              bottom: 30,
                              child: Text(
                                NumberFormat.currency(locale: 'bs')
                                    .format(p.price),
                                style: const TextStyle(
                                  color: Colors.yellow,
                                  fontWeight: FontWeight.w300,
                                ),
                              ))
                        ],
                      ))
                  .toList(),
            ),
          ],
        ));
      },
    );

    return Column(
      children: groups,
    );
  }
}
