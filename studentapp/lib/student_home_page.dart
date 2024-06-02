import 'package:flutter/material.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'app_bottom_navbar.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'books_page.dart';
import 'schedule_page.dart';
import 'bus_location_page.dart';
import 'menu_page.dart';



class StudentHomePage extends StatefulWidget {
  const StudentHomePage({Key? key}) : super(key: key);

  @override
  _StudentHomePageState createState() => _StudentHomePageState();
}

class _StudentHomePageState extends State<StudentHomePage> {
   final List<Map<String, String>> _imageItems = [
    {'image': 'assets/images/image1.jpg', 'title': 'Umutcan Elci'},
    {'image': 'assets/images/image2.jpg', 'title': 'Umutcan Elci'},
    {'image': 'assets/images/image3.jpg', 'title': 'Umutcan Elci'},
    {'image': 'assets/images/image4.jpg', 'title': 'Umutcan Elci'},
    {'image': 'assets/images/image5.jpg', 'title': 'Umutcan Elci'}
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Student Home")),
      body: SingleChildScrollView(
        child: Column(
          children: [
            CarouselSlider.builder(
              itemCount: _imageItems.length,
              itemBuilder: (context, itemIndex, pageViewIndex) {
                return Column(
                  children: [
                    Image.asset(_imageItems[itemIndex]['image']!),
                    const SizedBox(height: 10),
                    Text(_imageItems[itemIndex]['title']!),
                  ],
                );
              },
              options: CarouselOptions(
                height: 330,  
                autoPlay: true,  // Enable autoplay
                enlargeCenterPage: true,  // Optional visual effect
                viewportFraction: 0.8, // Adjust how much of each slide is visible
                autoPlayInterval: const Duration(seconds: 3), // Adjust slide duration
              ),
            ),
            const SizedBox(height: 20),
            
            GridView.count(
              physics: const NeverScrollableScrollPhysics(), 
              shrinkWrap: true, 
              crossAxisCount: 2,
              childAspectRatio: 2, 
              children: [
                _buildButton('Books', Icons.book),
                _buildButton('Schedule', Icons.calendar_month),
                _buildButton('Bus Locations', Icons.directions_bus),
                _buildButton('Menu', FontAwesomeIcons.utensils),
              ],
            ),
            // Button Grid (2 rows, 2 columns)
            // ... (Your Button Grid Code)
          ],
        ),
      ),
      
      bottomNavigationBar: AppBottomNavBar(selectedIndex: 1), // 1 for 'Home'
    );
  }
    Widget _buildButton(String label, IconData icon) {
    return Padding(
      padding: const EdgeInsets.all(8.0), // Adjust margin as needed
      child: ElevatedButton(
        onPressed: () {
          if (label == 'Books') { // Check if the 'Books' button is pressed
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => const BooksPage()),
          );
        } else if (label == 'Schedule') {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => const SchedulePage()),
          );
        }
        else if (label == 'Bus Locations') {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => const BusLocationsPage()),
          );
        }
        else if (label == 'Menu') {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => const MenuPage()),
          );
        }
        },
        child: Column(
        mainAxisSize: MainAxisSize.min,
          children: [
            Icon(icon, size: 40), // Adjust size as needed
            const SizedBox(height: 5),
            Text(label),
          ],
        ),
      ),
    );
  }
}
