import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/models/fitpasos.dart';
import 'package:mobile/providers/fitpasos_provider.dart';
import 'package:mobile/screens/pasos_create_screen.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';

class PasosiScreen extends StatefulWidget {
  const PasosiScreen({super.key});

  @override
  State<PasosiScreen> createState() => _PasosiScreenState();
}

class _PasosiScreenState extends State<PasosiScreen> {
  late FITPasosProvider _fitPasosiProvider;
  bool _loading = false;
  List<FITPasos> fitPasosi = <FITPasos>[];

  @override
  void initState() {
    super.initState();

    _fitPasosiProvider = context.read<FITPasosProvider>();

    loadPasosi();
  }

  loadPasosi() async {
    try {
      _loading = true;
      fitPasosi = await _fitPasosiProvider.get(null);
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }

    setState(() {
      _loading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: [
          ElevatedButton(
              onPressed: handleNewPassosClick, child: Text("Novi pasos")),
          _buildFitPasosiList(),
        ],
      ),
    );
  }

  void handleNewPassosClick() {
    Navigator.of(context).pushReplacementNamed(PasosCreateScreen.routeName);
  }

  Widget _buildFitPasosiList() {
    if (_loading) {
      return Column(
        children: const [
          SizedBox(
            height: 130,
          ),
          Center(
            child: CircularProgressIndicator(
              color: Colors.lightBlueAccent,
            ),
          ),
        ],
      );
    } else if (fitPasosi.isEmpty) {
      return const Center(child: Text('Prazno :('));
    }
    return Column(
      children: [
        _buildFitPasosiListHeader(),
        _buildFitPasosiListView(fitPasosi),
      ],
    );
  }

  Widget _buildFitPasosiListHeader() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        Text("Korisnicko ime"),
        Text("Datum vazenja"),
        Text("Validan?"),
      ],
    );
  }

  Widget _buildFitPasosiListView(List<FITPasos> fitPasosi) {
    return Column(
      children: fitPasosi
          .map(
            (pasos) => Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Text(pasos.user!.username),
                  Text(DateFormat.yM().format(pasos.validUntil)),
                  Text(pasos.isValid.toString()),
                ]),
          )
          .toList(),
    );
  }
}
