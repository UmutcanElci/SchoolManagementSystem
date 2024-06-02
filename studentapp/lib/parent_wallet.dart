import 'package:flutter/material.dart';

class ParentWallet extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFFeaecf2),
      appBar: AppBar(
        title: Text('My Profile'),
      ),
      body: Center(
        child: Text('Parent Wallet'),
      ),
    );
  }
}
