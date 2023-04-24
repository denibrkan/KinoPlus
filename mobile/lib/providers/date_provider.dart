import 'package:flutter/material.dart';

class DateProvider extends ChangeNotifier {
  List<DateTime> dates = <DateTime>[];

  DateTime selectedDate = DateTime.now();

  initializeDates(num numberOfDays) {
    for (var i = 0; i < numberOfDays; i++) {
      dates.add(selectedDate.add(Duration(days: i)));
    }
  }

  addDate(DateTime date) {
    if (!dates.contains(date)) {
      dates.add(date);
    }
    selectedDate = date;

    notifyListeners();
  }

  setSelectedDate(DateTime date) {
    selectedDate = date;
    notifyListeners();
  }
}
