import 'package:flutter/material.dart';
import 'package:mobile/models/fitpasos.dart';
import 'package:mobile/providers/fitpasos_provider.dart';
import 'package:provider/provider.dart';
import 'package:mobile/screens/pasos_create_screen2.dart';

class PasosiScreen2 extends StatefulWidget {
  const PasosiScreen2({super.key});

  @override
  State<PasosiScreen2> createState() => _PasosiScreen2State();
}

class _PasosiScreen2State extends State<PasosiScreen2> {
  late FITPasosProvider _fitPasosProvider;

  List<FITPasos> fitPasosi = <FITPasos>[];

  @override
  void initState() {
    super.initState();

    _fitPasosProvider = context.read<FITPasosProvider>();

    loadPasosi();
  }

  loadPasosi() async {
    var data = await _fitPasosProvider.get(null);

    setState(() {
      fitPasosi = data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        children: [
          ElevatedButton(
            onPressed: handleNewPasosClicked,
            child: Text('Novi pasos'),
          ),
          _buildHeader(),
          _buildPasosiList(),
        ],
      ),
    );
  }

  Widget _buildHeader() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: const [
        Text('Korisnik'),
        Text('Vrijedi do'),
        Text('Validan?'),
      ],
    );
  }

  Widget _buildPasosiList() {
    return Column(
      children: fitPasosi
          .map((pasos) => Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Text(pasos.user!.username),
                  Text(pasos.validUntil.toString().substring(0, 11)),
                  Text(pasos.isValid ? 'validan' : 'istekao'),
                ],
              ))
          .toList(),
    );
  }

  handleNewPasosClicked() {
    Navigator.of(context).pushNamed(PasosCreateScreen2.routeName);
  }
}
