import 'package:flutter/material.dart';

// Define a class to represent a student
class Student {
  final String name;
  final String surname;
  final String studentNumber;

  const Student(this.name, this.surname, this.studentNumber);
}

class ParentStudentInfo extends StatefulWidget {
  @override
  _ParentStudentInfoState createState() => _ParentStudentInfoState();
}

class _ParentStudentInfoState extends State<ParentStudentInfo> {
  int _selectedStudentIndex = -1; // Track selected student index (-1 for none)
  final List<Student> _students = [
    Student('John', 'Doe', '12345'),
    Student('Jane', 'Doe', '54321'),
  ];

  // Function to navigate to student information page
  void _navigateToStudentInfo(Student student) {
    // Replace "StudentInfoPage" with your actual student information page
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => StudentInfoPage(student: student)),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFFeaecf2),
      appBar: AppBar(
        title: Text('My Students'), // Change title to "My Students"
      ),
      body: ListView.builder(
        itemCount: _students.length,
        itemBuilder: (context, index) {
          final student = _students[index];
          return Padding(
            padding: const EdgeInsets.symmetric(vertical: 8.0), // Add spacing between buttons
            child: ElevatedButton(
              onPressed: () => _navigateToStudentInfo(student),
              child: ListTile(
                title: Text('${student.name} ${student.surname}'),
                subtitle: Text('Student Number: ${student.studentNumber}'),
              ),
            ),
          );
        },
      ),
    );
  }
}

// Replace this with your actual student information page
class StudentInfoPage extends StatelessWidget {
  final Student student;

  const StudentInfoPage({Key? key, required this.student}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('${student.name} ${student.surname} Info'),
      ),
      body: Center(
        child: Text(
          'Student Number: ${student.studentNumber}\n(Add more student information here)', // Add more details
        ),
      ),
    );
  }
}
