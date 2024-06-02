import 'package:flutter/material.dart';
import 'package:studentapp/student_documents.dart'; // Assuming these files exist
import 'package:studentapp/student_grades.dart';  // in your 'studentapp' folder
import 'package:studentapp/student_info.dart';      // 

class AccountPage extends StatelessWidget {
  const AccountPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Student"),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center, // Center buttons vertically
          children: [
            _buildButton('Information', Icons.info, () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => StudentInformation(),
                ),
              );
            }),
            const SizedBox(height: 20), // Add spacing between buttons
            _buildButton('Grades', Icons.assessment, () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) =>  StudentGrades(),
                ),
              );
            }),
            const SizedBox(height: 20),
            _buildButton('Documents', Icons.folder, () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) =>  StudentDocuments(),
                ),
              );
            }),
          ],
        ),
      ),
    );
  }

  Widget _buildButton(String label, IconData icon, VoidCallback onPressed) {
    return ElevatedButton.icon(
      onPressed: onPressed,
      icon: Icon(icon, size: 50), // Adjust size as needed
      label: Text(label),
      
    );
  }
}
