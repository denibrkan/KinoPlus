import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/components/movie_details/date_selector.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/models/location.dart';
import 'package:mobile/models/projection.dart';
import 'package:mobile/services/api_service.dart';

class ProjectionsTab extends StatefulWidget {
  const ProjectionsTab({super.key, required this.movieId});

  final int movieId;

  @override
  State<ProjectionsTab> createState() => _ProjectionsTabState();
}

class _ProjectionsTabState extends State<ProjectionsTab> {
  List<Projection> projections = <Projection>[];
  List<Location> locations = <Location>[];

  final APIService locationService = APIService('locations');
  final APIService projectionService = APIService('projections');

  Location? selectedLocation;
  late DateTime selectedDate;
  bool loading = false;

  @override
  void initState() {
    super.initState();

    loadData();
  }

  void loadData() async {
    await loadLocations();
    loadProjections();
  }

  void loadProjections() async {
    if (selectedLocation == null) return;
    setState(() {
      loading = true;
    });
    var params = <String, String>{};
    params['movieId'] = widget.movieId.toString();
    params['date'] = selectedDate.toString();
    params['locationId'] = selectedLocation!.id.toString();

    var data =
        await projectionService.get<Projection>(params, Projection.fromJson);

    setState(() {
      projections = data;
      loading = false;
    });
  }

  Future loadLocations() async {
    var data = await locationService.get<Location>(null, Location.fromJson);

    setState(() {
      selectedLocation = data.first;
      locations = data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      constraints:
          BoxConstraints(minHeight: MediaQuery.of(context).size.height),
      child: Column(
        children: [
          Container(
            margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 25),
            child: Row(
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
          ),
          DateSelector(onDateSelected: (value) {
            selectedDate = value;
            loadProjections();
          }),
          _buildLocationDropdown(),
          _buildProjectionTickets(),
        ],
      ),
    );
  }

  Widget _buildLocationDropdown() {
    if (locations.isEmpty) {
      return const Center(
        child: CircularProgressIndicator(
          color: Colors.lightBlue,
        ),
      );
    }

    return Container(
        margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 25),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Kino',
              style: Theme.of(context).textTheme.titleMedium,
            ),
            const SizedBox(height: 6),
            DropdownButton<Location>(
              isExpanded: true,
              value: selectedLocation,
              icon: const Icon(Icons.arrow_drop_down),
              elevation: 16,
              style: const TextStyle(
                fontSize: 16,
              ),
              dropdownColor: const Color(0xFF2B3543),
              onChanged: (Location? value) {
                setState(() => selectedLocation = value);
                loadProjections();
              },
              items: locations
                  .map<DropdownMenuItem<Location>>(
                      (l) => DropdownMenuItem<Location>(
                            value: l,
                            child: Text('${l.name} - ${l.city.name}'),
                          ))
                  .toList(),
            ),
          ],
        ));
  }

  Widget _buildProjectionTickets() {
    if (loading) {
      return const CircularProgressIndicator(
        color: Colors.lightBlue,
      );
    }
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
            Container(
              margin: const EdgeInsets.symmetric(horizontal: 16),
              child: Text(
                key.toString(),
                style: Theme.of(context).textTheme.titleMedium!.copyWith(
                      color: Colors.grey,
                      fontWeight: FontWeight.w700,
                    ),
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
                            top: 35,
                            child: Text(
                              DateFormat.Hm('bs').format(p.startsAt),
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
                              bottom: 35,
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
