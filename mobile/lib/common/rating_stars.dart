import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

class RatingStars extends StatefulWidget {
  final num rating;
  final bool canChange;
  const RatingStars({super.key, required this.rating, this.canChange = false});

  @override
  State<RatingStars> createState() => _RatingStarsState();
}

class _RatingStarsState extends State<RatingStars> {
  @override
  Widget build(BuildContext context) {
    return RatingBar.builder(
      ignoreGestures: !widget.canChange,
      initialRating: widget.rating.toDouble(),
      direction: Axis.horizontal,
      allowHalfRating: true,
      itemCount: 5,
      itemSize: 22,
      itemPadding: const EdgeInsets.symmetric(horizontal: 2.0),
      itemBuilder: (context, _) => const Icon(
        Icons.star,
        color: Colors.amber,
      ),
      unratedColor: const Color.fromARGB(50, 192, 137, 35),
      onRatingUpdate: (rating) {},
    );
  }
}
