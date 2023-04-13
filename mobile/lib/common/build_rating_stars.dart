import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

Widget buildRatingStars(num rating) {
  return RatingBar.builder(
    ignoreGestures: true,
    initialRating: rating.toDouble(),
    direction: Axis.horizontal,
    allowHalfRating: true,
    itemCount: 5,
    itemSize: 22,
    itemPadding: const EdgeInsets.symmetric(horizontal: 2.0),
    itemBuilder: (context, _) => const Icon(
      Icons.star,
      color: Colors.amber,
    ),
    onRatingUpdate: (rating) {},
  );
}
