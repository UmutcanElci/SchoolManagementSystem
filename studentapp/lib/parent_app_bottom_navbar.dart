import 'dart:io' show Platform;
import 'package:flutter/material.dart';
import 'package:studentapp/parent_home_page.dart';
import 'package:studentapp/parent_student_info.dart';
import 'package:studentapp/parent_wallet.dart';


class PrentAppBottomNavbar extends StatelessWidget {
  final int selectedIndex;
  const PrentAppBottomNavbar({Key? key, required this.selectedIndex}) : super(key: key);
 
  bool isRunningOnMobile() {
    return Platform.isIOS || Platform.isAndroid;
  }
    
  List<BottomNavigationBarItem> _buildNavBarItems() {
      return [
        BottomNavigationBarItem(icon: Icon(Icons.person), label: 'Student'),
        BottomNavigationBarItem(icon: Icon(Icons.home), label: 'Home'),
        BottomNavigationBarItem(icon: Icon(Icons.camera_alt), label: 'Wallet'),
      ];
  }

  @override
  Widget build(BuildContext context) {
    return BottomNavigationBar(
      items: _buildNavBarItems(),
      currentIndex: selectedIndex,
      onTap: (index) {
        switch (index) {
          case 0: // Account 
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => ParentStudentInfo()), 
            );
            break;
          case 1: // Home
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) =>  ParentHomePage()),
            );
            break;
          case 2: // Scan
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) =>  ParentWallet()),
            );
            break;
      }
      },
    );
  }
}
