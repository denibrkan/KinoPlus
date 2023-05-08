import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

class RatingStars extends StatefulWidget {
  final num rating;
  final bool canUpdate;
  final Function(double)? onUpdate;
  final bool allowHalfRating;
  final double size;

  const RatingStars(
      {super.key,
      required this.rating,
      this.canUpdate = false,
      this.onUpdate,
      this.allowHalfRating = true,
      this.size = 22});

  @override
  State<RatingStars> createState() => _RatingStarsState();
}

class _RatingStarsState extends State<RatingStars> {
  @override
  Widget build(BuildContext context) {
    return RatingBar.builder(
      ignoreGestures: !widget.canUpdate,
      initialRating: widget.rating.toDouble(),
      direction: Axis.horizontal,
      allowHalfRating: widget.allowHalfRating,
      itemCount: 5,
      itemSize: widget.size,
      itemPadding: const EdgeInsets.symmetric(horizontal: 2.0),
      itemBuilder: (context, _) => const Icon(
        Icons.star,
        color: Colors.amber,
      ),
      unratedColor: const Color.fromARGB(50, 192, 137, 35),
      onRatingUpdate: (rating) {
        if (widget.canUpdate && widget.onUpdate != null) {
          widget.onUpdate!(rating);
        }
      },
    );
  }
}
