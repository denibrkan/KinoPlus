import 'package:flutter/material.dart';
import 'package:mobile/common/rating_stars.dart';

class RatingBar extends StatelessWidget {
  final num rating;
  const RatingBar({super.key, required this.rating});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          '${rating.toStringAsFixed(2)} / 5',
          textScaleFactor: 1.35,
        ),
        const SizedBox(
          width: 10,
        ),
        RatingStars(rating: rating, size: 20),
      ],
    );
  }
}
