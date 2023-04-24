import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/components/movie_details/date_selector.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/models/location.dart';
import 'package:mobile/models/projection.dart';
import 'package:mobile/providers/date_provider.dart';
import 'package:mobile/services/api_service.dart';
import 'package:provider/provider.dart';

class ProjectionsTab extends StatefulWidget {
  const ProjectionsTab({super.key, required this.movieId});

  final int movieId;

  @override
  State<ProjectionsTab> createState() => _ProjectionsTabState();
}

class _ProjectionsTabState extends State<ProjectionsTab> {
  List<Projection> projections = <Projection>[];
  List<Location> locations = <Location>[];

  late DateProvider dateProvider;

  final APIService locationService = APIService('locations');
  final APIService projectionService = APIService('projections');

  Location? selectedLocation;
  DateTime? selectedDate;
  bool loading = false;

  @override
  void initState() {
    super.initState();
    dateProvider = context.read<DateProvider>();
    selectedDate = dateProvider.selectedDate;

    loadData();
  }

  void loadData() async {
    await loadLocations();
    loadProjections();
  }

  void loadProjections() async {
    if (selectedLocation == null || selectedDate == null) return;
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
    var date = context.watch<DateProvider>().selectedDate;
    if (selectedDate != date) {
      selectedDate = date;
      loadProjections();
    }
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
                InkWell(
                  onTap: () => _selectDate(context),
                  child: const Icon(
                    Icons.calendar_today,
                    size: 26,
                    color: Colors.lightBlue,
                  ),
                ),
              ],
            ),
          ),
          const DateSelector(),
          _buildLocationDropdown(),
          _buildProjectionTickets(),
        ],
      ),
    );
  }

  Widget _buildLocationDropdown() {
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
            locations.isNotEmpty
                ? DropdownButton<Location>(
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
                  )
                : Container(),
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

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        initialDate: DateTime.now(),
        firstDate: DateTime(2015, 8),
        lastDate: DateTime(2101));
    if (picked != null && picked != dateProvider.selectedDate) {
      dateProvider.addDate(picked);
    }
  }
}
