import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/helpers/extensions.dart';
import 'package:mobile/providers/date_provider.dart';
import 'package:provider/provider.dart';

class DateSelector extends StatefulWidget {
  const DateSelector({super.key});

  @override
  State<DateSelector> createState() => _DateSelectorState();
}

class _DateSelectorState extends State<DateSelector> {
  static const num numberOfDays = 10;
  late DateProvider dateProvider;

  void _handleDateSelected(DateTime date) {
    dateProvider.setSelectedDate(date);
  }

  @override
  void initState() {
    super.initState();
    dateProvider = context.read<DateProvider>();
    if (dateProvider.dates.isEmpty) {
      dateProvider.initializeDates(numberOfDays);
    }
  }

  @override
  Widget build(BuildContext context) {
    var state = context.watch<DateProvider>();

    return SizedBox(
      height: 80,
      child: GridView(
        padding: const EdgeInsets.symmetric(horizontal: 20),
        gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
          crossAxisCount: 1,
          childAspectRatio: 8 / 10,
          mainAxisSpacing: 20,
        ),
        scrollDirection: Axis.horizontal,
        children: state.dates
            .map(
              (d) => DateContainer(
                date: d,
                isSelected: state.selectedDate.isSameDate(d),
                onDateSelected: (value) => _handleDateSelected(value),
              ),
            )
            .toList(),
      ),
    );
  }
}

class DateContainer extends StatefulWidget {
  final DateTime date;
  final ValueChanged<DateTime> onDateSelected;
  final bool isSelected;

  const DateContainer(
      {super.key,
      required this.date,
      required this.onDateSelected,
      required this.isSelected});

  @override
  State<DateContainer> createState() => _DateContainerState();
}

class _DateContainerState extends State<DateContainer> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
        onTap: () {
          widget.onDateSelected(widget.date);
        },
        child: Container(
          padding: const EdgeInsets.all(12),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(8),
            border: Border.all(
              color: Colors.grey,
            ),
            color: widget.isSelected ? Colors.amber : null,
          ),
          width: 100,
          height: 80,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                widget.date.isSameDate(DateTime.now())
                    ? 'Danas'
                    : DateFormat.MMMd('bs').format(widget.date),
                style: Theme.of(context).textTheme.titleMedium!.copyWith(
                    fontWeight: FontWeight.w600,
                    color: widget.isSelected ? Colors.black : null),
              ),
              const SizedBox(
                height: 8,
              ),
              Text(
                DateFormat('EEE', 'bs').format(widget.date).toUpperCase(),
                style: Theme.of(context).textTheme.titleMedium!.copyWith(
                      color: widget.isSelected ? Colors.black : Colors.grey,
                    ),
              ),
            ],
          ),
        ));
  }
}
