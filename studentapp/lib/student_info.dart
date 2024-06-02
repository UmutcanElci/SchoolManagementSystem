import 'package:flutter/material.dart';

class StudentInformation extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFFeaecf2),
      appBar: AppBar(
        title: const Text('My Profile'),
      ),
      body: SingleChildScrollView( // Allow scrolling for long content
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start, // Align content to left
            children: [
              // Title
              const Text(
                'Student Information',
                style: TextStyle(
                  fontSize: 20.0,
                  fontWeight: FontWeight.bold,
                ),
              ),
              const SizedBox(height: 10.0), // Add spacing

              // Table for details
              Table(
                border: TableBorder.all(color: Colors.grey, width: 1.0), // Table border
                children: [
                  TableRow(
                    children: [
                      _buildTableCell('Student Name & Surname'),
                      _buildTableCell('John Doe'),
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Student Number'),
                      _buildTableCell('123456'),
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Student Phone Number'),
                      _buildTableCell('(123) 456-7890'),
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Student Date of Birth'),
                      _buildTableCell('2000-01-01'), // Replace with actual date
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Student Address'),
                      _buildTableCell('123 Main Street, Anytown, CA 12345'), // Replace with actual address
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Student Email'),
                      _buildTableCell('johndoe@example.com'), // Replace with actual email
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Student Gender'),
                      _buildTableCell('Male'), // Replace with actual gender
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Parent Name & Surname'),
                      _buildTableCell('Jane Doe'), // Replace with parent's name
                    ],
                  ),
                  TableRow(
                    children: [
                      _buildTableCell('Parent Phone Number'),
                      _buildTableCell('(987) 654-3210'), // Replace with parent's phone number
                    ],
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  // Helper function to create table cells
  Widget _buildTableCell(String text) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Text(
        text,
        style: const TextStyle(fontSize: 16.0),
      ),
    );
  }
}
