import 'package:flutter/material.dart';

class BookListPage extends StatelessWidget {
  final String lessonName;
  final List<String> books;

  const BookListPage({Key? key, required this.lessonName, required this.books})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text(lessonName)),
      body: ListView.builder(
        itemCount: books.length,
        itemBuilder: (context, index) {
          return ListTile(title: Text(books[index]));
        },
      ),
    );
  }
}
