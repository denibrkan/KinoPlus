import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/components/movie_details/date_selector.dart';
import 'package:mobile/extensions/date_only_compare.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/models/location.dart';
import 'package:mobile/models/projection.dart';
import 'package:mobile/providers/date_provider.dart';
import 'package:mobile/providers/location_provider.dart';
import 'package:mobile/providers/projection_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/seats_screen.dart';
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

  late DateProvider _dateProvider;
  late LocationProvider _locationProvider;
  late ProjectionProvider _projectionProvider;
  late UserProvider _userProvider;

  Location? selectedLocation;
  late DateTime selectedDate;
  Projection? selectedProjection;

  bool loading = false;

  @override
  void initState() {
    super.initState();

    _dateProvider = context.read<DateProvider>();
    _locationProvider = context.read<LocationProvider>();
    _projectionProvider = context.read<ProjectionProvider>();
    _userProvider = context.read<UserProvider>();

    selectedDate = _dateProvider.selectedDate;

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

    var data = await _projectionProvider.get(params);

    if (mounted) {
      setState(() {
        projections = data;
        loading = false;
      });
    }
  }

  Future loadLocations() async {
    var data = await _locationProvider.get(null);

    if (mounted) {
      int? userLocationId = _userProvider.user!.locationId;
      setState(() {
        selectedLocation = userLocationId != null
            ? data.firstWhere((location) => location.id == userLocationId)
            : data.first;
        locations = data;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    var date = context.watch<DateProvider>().selectedDate;
    if (selectedDate != date) {
      selectedDate = date;
      selectedProjection = null;
      loadProjections();
    }
    return Column(
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
        Container(
            constraints: const BoxConstraints(minHeight: 250),
            child: _buildProjectionTickets()),
        if (selectedProjection != null)
          Container(
            margin: const EdgeInsets.symmetric(horizontal: 10, vertical: 16),
            width: double.infinity,
            height: 50,
            child: ElevatedButton(
              onPressed: () {
                Navigator.pushNamed(
                  context,
                  SeatsScreen.routeName,
                  arguments: selectedProjection,
                );
              },
              style: ButtonStyle(
                backgroundColor:
                    MaterialStateProperty.all(const Color(0xFFE51937)),
                shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                  RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(8.0),
                  ),
                ),
              ),
              child: const Text(
                'Potvrdi',
                style: TextStyle(
                  fontSize: 18,
                ),
              ),
            ),
          )
        else
          const SizedBox(height: 80),
      ],
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
                      setState(() {
                        selectedLocation = value;
                        selectedProjection = null;
                      });
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
      return const Center(
        child: CircularProgressIndicator(
          color: Colors.lightBlue,
        ),
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
                  .map((p) => GestureDetector(
                        onTap: () => selectProjection(p),
                        child: Stack(
                          alignment: Alignment.center,
                          children: [
                            Image.asset(
                              'assets/images/ticket120.png',
                              color: selectedProjection == p
                                  ? const Color.fromARGB(255, 68, 85, 107)
                                  : const Color(0xFF2B3543),
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
                        ),
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
        initialDate: selectedDate,
        firstDate: DateTime.now(),
        lastDate: DateTime(2101));
    if (picked != null && !picked.isSameDate(selectedDate)) {
      _dateProvider.addDate(picked);
    }
  }

  void selectProjection(Projection p) {
    setState(() {
      if (selectedProjection == p) {
        selectedProjection = null;
      } else {
        selectedProjection = p;
      }
    });
  }
}
