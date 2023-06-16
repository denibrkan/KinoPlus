import 'package:flutter/material.dart';

InputDecoration getFormInputDecoration(String hintText, IconData? iconData) {
  var prefixIcon = iconData != null
      ? Icon(
          iconData,
          color: Colors.grey,
        )
      : null;
  return InputDecoration(
    prefixIcon: prefixIcon,
    hintText: hintText,
    hintStyle: const TextStyle(color: Colors.grey, fontSize: 15),
    border: const OutlineInputBorder(
        borderRadius: BorderRadius.all(Radius.circular(8))),
    contentPadding: const EdgeInsets.fromLTRB(12, 16, 12, 16),
  );
}
