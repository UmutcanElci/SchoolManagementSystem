import 'package:flutter/material.dart';
import 'book_list_page.dart';

class BooksPage extends StatefulWidget {
  const BooksPage({Key? key}) : super(key: key);

  @override
  _BooksPageState createState() => _BooksPageState();
}

class _BooksPageState extends State<BooksPage> {
  // Sample data (replace with your data structures later)
  final List<Map<String, dynamic>> _lessons = [
    {'lessonName': 'Mathematics', 'books': ['Calculus 1', 'Linear Algebra']},
    {'lessonName': 'Physics', 'books': ['Mechanics', 'Electromagnetism']},
    // Add more lessons here
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Books')),
      body: ListView.builder(
        itemCount: _lessons.length,
        itemBuilder: (context, index) {
          return ListTile(
            title: Text(_lessons[index]['lessonName']),
            onTap: () {
              Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => BookListPage(
                  lessonName: _lessons[index]['lessonName'], 
                  books: _lessons[index]['books'],
                ),
              ),
            );

            },
          );
        },
      ),
    );
  }
}
