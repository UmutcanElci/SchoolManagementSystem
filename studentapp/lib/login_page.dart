import 'package:flutter/material.dart';
import 'package:studentapp/parent_home_page.dart';
import 'variables.dart' as globals;
import 'student_home_page.dart';  // Import the student homepage file
import 'package:studentapp/register_page.dart';
class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  // Variables
  bool _isSelectedStudent = true;
  final _studentNumberController = TextEditingController();
  final _passwordController = TextEditingController();
  
  // Helper Functions

void _onRegisterPressed() {
  Navigator.push(
    context,
    MaterialPageRoute(builder: (context) => const RegisterPage()), // Navigate to the RegisterPage
  );
}

void _onSkipPressed() { 
  Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => _isSelectedStudent ? const StudentHomePage() :  ParentHomePage()), // Route based on selection
    );
}
  void _onForgotPasswordPressed() { /* Handle Forgot Password */ }

  void _onSelected(bool isSelectedStudent) {
    setState(() {
      _isSelectedStudent = isSelectedStudent;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: SingleChildScrollView(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              // Logo Image
              Image.asset(
                'assets/images/logo.jpg', // Placeholder, replace with your logo
                width: 150,  // Adjust size as desired
              ), 
              const SizedBox(height: 20),

              // Student/Parent buttons with animation
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  AnimatedContainer(
                    duration: const Duration(milliseconds: 200),
                    width: _isSelectedStudent ? 120 : 80,
                    decoration: BoxDecoration(
                      color: _isSelectedStudent ? Colors.blue : Colors.grey[200],
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: TextButton(
                      onPressed: () => _onSelected(true),
                      child: const Text('Student'),
                    ),
                  ),
                  const SizedBox(width: 10),
                  AnimatedContainer(
                    duration: const Duration(milliseconds: 200),
                    width: !_isSelectedStudent ? 120 : 80,
                    decoration: BoxDecoration(
                      color: !_isSelectedStudent ? Colors.blue : Colors.grey[200],
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: TextButton(
                      onPressed: () => _onSelected(false),
                      child: const Text('Parent'),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 20),

              // Input Fields
              TextField(
                controller: _studentNumberController,
                decoration: const InputDecoration(hintText: 'Student Number'),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: _passwordController,
                obscureText: true, // For hiding password input
                decoration: const InputDecoration(hintText: 'Password'),
              ),
              const SizedBox(height: 10),

              // Buttons
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  ElevatedButton(onPressed: _onSkipPressed, child: const Text('Login')),
                   ElevatedButton(onPressed: _onRegisterPressed,child: const Text('Register'),
              ),
                ],
              ),

              // Forgot Password
              TextButton(
                onPressed: _onForgotPasswordPressed,
                child: const Text('Forgot Password?'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
