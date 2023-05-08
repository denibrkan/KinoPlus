import 'package:flutter/material.dart';
import 'package:mobile/helpers/enums.dart';

class MovieTabProvider extends ChangeNotifier {
  TabOptions? _selectedTab;

  setSelectedTab(TabOptions? value) {
    _selectedTab = value;

    notifyListeners();
  }

  get selectedTab => _selectedTab;
}
