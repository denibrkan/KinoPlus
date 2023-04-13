String getDuration(int minutes) {
  var hours = (minutes / 60).floor();
  var mins = minutes % 60;

  return '${hours}h ${mins}m';
}
