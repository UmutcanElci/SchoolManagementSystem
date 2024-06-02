import 'dart:io' show Platform;
import 'package:flutter/material.dart';
import 'package:studentapp/scan_page.dart';
import 'scan_screen.dart';
import 'account_page.dart';
import 'student_home_page.dart';


class AppBottomNavBar extends StatelessWidget {
  final int selectedIndex;
  const AppBottomNavBar({Key? key, required this.selectedIndex}) : super(key: key);
 
  bool isRunningOnMobile() {
    return Platform.isIOS || Platform.isAndroid;
  }
    
  List<BottomNavigationBarItem> _buildNavBarItems() {
      return [
        BottomNavigationBarItem(icon: Icon(Icons.person), label: 'Student'),
        BottomNavigationBarItem(icon: Icon(Icons.home), label: 'Home'),
        if (isRunningOnMobile())
          BottomNavigationBarItem(icon: Icon(Icons.camera_alt), label: 'Scan'),
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
              MaterialPageRoute(builder: (context) => AccountPage()), 
            );
            break;
          case 1: // Home
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => const StudentHomePage()),
            );
            break;
          case 2: // Scan
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => const ScanPage()),
            );
            break;
      }
      },
    );
  }
}
