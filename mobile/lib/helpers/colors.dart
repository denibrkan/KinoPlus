import 'package:flutter/material.dart';

const MaterialColor primary = MaterialColor(_primaryPrimaryValue, <int, Color>{
  50: Color(0xFFE2E4E6),
  100: Color(0xFFB7BBBF),
  200: Color(0xFF878D95),
  300: Color(0xFF575F6B),
  400: Color(0xFF333D4B),
  500: Color(_primaryPrimaryValue),
  600: Color(0xFF0D1826),
  700: Color(0xFF0B1420),
  800: Color(0xFF08101A),
  900: Color(0xFF040810),
});
const int _primaryPrimaryValue = 0xFF0F1B2B;

const MaterialColor primaryAccent =
    MaterialColor(_primaryAccentValue, <int, Color>{
  100: Color(0xFF5284FF),
  200: Color(_primaryAccentValue),
  400: Color(0xFF0043EB),
  700: Color(0xFF003CD2),
});
const int _primaryAccentValue = 0xFF1F5FFF;
