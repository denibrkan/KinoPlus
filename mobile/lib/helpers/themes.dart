import 'package:flutter/material.dart';
import 'package:mobile/helpers/colors.dart';

class ThemeClass {
  static ThemeData lightTheme = ThemeData(
    scaffoldBackgroundColor: veryLightGrayColor,
    primaryColor: lightPrimaryColor,
    appBarTheme: const AppBarTheme(
      backgroundColor: lightPrimaryColor,
      actionsIconTheme: IconThemeData(color: Colors.black),
      iconTheme: IconThemeData(color: Colors.black),
      titleTextStyle: TextStyle(
        color: darkPrimaryColor,
        fontSize: 20,
        fontWeight: FontWeight.w400,
      ),
    ),
    brightness: Brightness.light,
    bottomNavigationBarTheme:
        const BottomNavigationBarThemeData(backgroundColor: lightPrimaryColor),
    textTheme: ThemeData.light().textTheme.apply(
        bodyColor: darkPrimaryColor,
        displayColor: darkPrimaryColor,
        fontFamily: 'Albert Sans'),
    textButtonTheme: TextButtonThemeData(
      style: TextButton.styleFrom(
        foregroundColor: darkPrimaryColor,
        backgroundColor: veryLightGrayColor,
        iconColor: Colors.lightBlueAccent,
      ),
    ),
    segmentedButtonTheme: SegmentedButtonThemeData(
      style: ButtonStyle(
        backgroundColor: MaterialStateProperty.resolveWith<Color?>(
          (Set<MaterialState> states) {
            if (states.contains(MaterialState.selected)) {
              return const Color(0xFFE51937);
            }
            return lightPrimaryColor; // Use the component's default.
          },
        ),
        foregroundColor: MaterialStateProperty.resolveWith<Color?>(
          (Set<MaterialState> states) {
            if (states.contains(MaterialState.selected)) {
              return Colors.white;
            }
            return Colors.grey; // Use the component's default.
          },
        ),
      ),
    ),
    canvasColor: lightPrimaryColor,
    iconTheme: const IconThemeData(color: blueButtonColor),
  );

  static ThemeData darkTheme = ThemeData(
    scaffoldBackgroundColor: darkPrimaryColor,
    dialogBackgroundColor: Colors.white,
    primaryColor: darkNavigationBarColor,
    appBarTheme: const AppBarTheme(
        color: darkPrimaryColor,
        titleTextStyle: TextStyle(
          color: lightPrimaryColor,
          fontSize: 20,
          fontWeight: FontWeight.w400,
        )),
    bottomNavigationBarTheme: const BottomNavigationBarThemeData(
        backgroundColor: darkNavigationBarColor),
    brightness: Brightness.dark,
    drawerTheme: const DrawerThemeData(
      backgroundColor: Colors.white,
    ),
    textTheme: ThemeData.light().textTheme.apply(
        bodyColor: Colors.white,
        displayColor: Colors.white,
        fontFamily: 'Albert Sans'),
    textButtonTheme: TextButtonThemeData(
        style: TextButton.styleFrom(
      foregroundColor: lightGrayColor,
      backgroundColor: darkPrimaryColor,
      iconColor: Colors.lightBlueAccent,
    )),
    segmentedButtonTheme: SegmentedButtonThemeData(
      style: ButtonStyle(
        backgroundColor: MaterialStateProperty.resolveWith<Color?>(
          (Set<MaterialState> states) {
            if (states.contains(MaterialState.selected)) {
              return const Color(0xFFE51937);
            }
            return darkPrimaryColor; // Use the component's default.
          },
        ),
        foregroundColor: MaterialStateProperty.resolveWith<Color?>(
          (Set<MaterialState> states) {
            if (states.contains(MaterialState.selected)) {
              return Colors.white;
            }
            return lightGrayColor; // Use the component's default.
          },
        ),
      ),
    ),
    canvasColor: darkPrimaryColor,
  );
}
