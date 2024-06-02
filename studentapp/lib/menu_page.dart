import 'package:flutter/material.dart';

class MenuPage extends StatelessWidget {
  const MenuPage({Key? key}) : super(key: key);

  // Sample Menu Data (Replace with your actual menu)
  final List<Map<String, dynamic>> _menuItems = const [
    {'name': 'Chicken Salad Sandwich', 'price': 7.50},
    {'name': 'Soup of the Day', 'price': 4.95},
    {'name': 'Pasta with Marinara', 'price': 10.95},
    {'name': 'Fruit Bowl', 'price': 5.50},
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Today's Menu")),
      body: ListView.builder(
        itemCount: _menuItems.length,
        itemBuilder: (context, index) {
          return ListTile(
            title: Text(_menuItems[index]['name']),
            trailing: Text('\$${_menuItems[index]['price'].toStringAsFixed(2)}'), 
          );
        },
      ),
    );
  }
}
