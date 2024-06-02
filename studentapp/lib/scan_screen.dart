import 'package:flutter/material.dart';
import 'package:qr_code_scanner/qr_code_scanner.dart';

class ScanScreen extends StatefulWidget {
  const ScanScreen({Key? key}) : super(key: key);

  @override
  State<ScanScreen> createState() => _ScanScreenState();
}

class _ScanScreenState extends State<ScanScreen> {
  final _qrKey = GlobalKey(debugLabel: 'QR'); // For the QR View
  QRViewController? _controller;
  Barcode? _barcodeResult;  // To stores Scanned data

  @override
  void dispose() {
    _controller?.dispose();
    super.dispose();
  }

  @override
  void reassemble() {
    super.reassemble();
    // Check for platform permissions if using Android
    _controller?.pauseCamera(); 
    _controller?.resumeCamera();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Scan QR Code')),
      body: Stack( // To overlay scanned data on camera preview
        alignment: Alignment.center, 
        children: [
          _buildQrView(context),
          // You will display the result here, if any
          _barcodeResult != null
              ? Text('Data: ${_barcodeResult!.code}')
              : const Text('Scan a code'),
        ],
      ),
    );
  }

  Widget _buildQrView(BuildContext context) {
    // Adjust the preview size as needed
    return QRView(
      key: _qrKey,
      onQRViewCreated: _onQRViewCreated, 
      overlay: QrScannerOverlayShape(
        borderColor: Colors.blue, 
        borderRadius: 5,
        borderLength: 30, 
        borderWidth: 10,
      ),
    );
  }

  void _onQRViewCreated(QRViewController controller) {
    setState(() => _controller = controller);
    controller.scannedDataStream.listen((scanData) {
      setState(() => _barcodeResult = scanData); 
    });
  }
}