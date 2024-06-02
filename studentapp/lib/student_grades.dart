import 'package:flutter/material.dart';

class StudentGrades extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFFeaecf2),
      appBar: AppBar(
        title: const Text('My Grades'),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              // Title
              const Text(
                'Student Grades',
                style: TextStyle(
                  fontSize: 20.0,
                  fontWeight: FontWeight.bold,
                ),
              ),
              const SizedBox(height: 10.0), // Add spacing

              // Single Table with all Subjects
              _buildGradesTable([
                {'subject': 'Math', 'midterm': '85', 'final': '90'}, // Replace with actual data
                {'subject': 'Science', 'midterm': '78', 'final': '82'}, // Replace with actual data
                {'subject': 'English', 'midterm': '92', 'final': '95'}, // Replace with actual data
                {'subject': 'Geography', 'midterm': '80', 'final': '87'}, // Replace with actual data
              ]),
            ],
          ),
        ),
      ),
    );
  }

  // Helper function to build a single table with all subjects
  Widget _buildGradesTable(List<Map<String, String>> subjects) {
    return Table(
      border: TableBorder.all(color: Colors.grey, width: 1.0), // Table border
      columnWidths: const {
        0: FixedColumnWidth(100.0), // Adjust column widths as needed
        1: FixedColumnWidth(80.0),
        2: FixedColumnWidth(80.0),
      },
      children: [
        TableRow(
          children: [
            _buildTableCell('Subject'),
            _buildTableCell('Midterm'),
            _buildTableCell('Final'),
          ],
        ),
        // Generate rows for each subject
        for (var subject in subjects)
          TableRow(
            children: [
              _buildTableCell(subject['subject']!), // Access subject name
              _buildTableCell(subject['midterm']!), // Access Midterm grade
              _buildTableCell(subject['final']!), // Access Final grade
            ],
          ),
      ],
    );
  }

  // Helper function to create table cells
  Widget _buildTableCell(String text) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Text(
        text,
        style: const TextStyle(fontSize: 16.0),
        textAlign: TextAlign.center, // Center text in cells
      ),
    );
  }
}
