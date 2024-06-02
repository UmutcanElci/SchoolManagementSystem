import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'dart:math'; // For random number generation

class BusLocationsPage extends StatefulWidget {
  const BusLocationsPage({Key? key}) : super(key: key);

  @override
  _BusLocationsPageState createState() => _BusLocationsPageState();
}

class _BusLocationsPageState extends State<BusLocationsPage> {
  GoogleMapController? _mapController;
  final LatLng _maltepeUniversity = const LatLng(40.958702, 29.140616); // Replace with actual coords
  final List<Marker> _busMarkers = [];

  @override
  void initState() {
    super.initState();
    _generateRandomBusLocations();
  }

  void _generateRandomBusLocations() {
    final random = Random();
    for (int i = 0; i < 5; i++) { // Generate 5 random bus markers
      double randomLat = _maltepeUniversity.latitude + random.nextDouble() * 0.1 - 0.05;  
      double randomLng = _maltepeUniversity.longitude + random.nextDouble() * 0.1 - 0.05;  

      _busMarkers.add(Marker(
        markerId: MarkerId(i.toString()),
        position: LatLng(randomLat, randomLng),
        icon: BitmapDescriptor.defaultMarkerWithHue(BitmapDescriptor.hueYellow), // Bus icon
      ));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Bus Locations')),
      body: GoogleMap(
        initialCameraPosition: CameraPosition(target: _maltepeUniversity, zoom: 14),
        onMapCreated: (controller) => _mapController = controller,
        markers: Set.from(_busMarkers),
      ),
    );
  }
}
