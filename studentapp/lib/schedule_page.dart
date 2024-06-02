import 'package:flutter/material.dart';

class SchedulePage extends StatefulWidget {
  const SchedulePage({Key? key}) : super(key: key);

  @override
  _SchedulePageState createState() => _SchedulePageState();
}

class _SchedulePageState extends State<SchedulePage> {
  final List<Map<String, dynamic>> _scheduleData = [
    {
    'day': 'Monday',
    'classes': [
      {'time': '13:00 - 15:00', 'course': 'Mathematics I'},
      {'time': '15:15 - 16:45', 'course': 'Computer Science'},
    ]
  },
  {
    'day': 'Tuesday',
    'classes': [
      {'time': '9:00 - 10:30', 'course': 'Physics'},
      {'time': '11:00 - 12:00', 'course': 'Literature'},
    ]
  },
  {
    'day': 'Wednesday',
    'classes': [
      {'time': '8:30 - 10:00', 'course': 'Chemistry'}, 
    ]
  },
  {
    'day': 'Thursday',
    'classes': [
      {'time': '14:00 - 15:30', 'course': 'Art History'},
      {'time': '16:00 - 17:00', 'course': 'Sports'},
    ]
  },
  {
    'day': 'Friday',
    'classes': [
      {'time': '10:00 - 11:30', 'course': 'Biology'},
    ]
  },
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Schedule')),
      body: ListView.builder(
        itemCount: _scheduleData.length,
        itemBuilder: (context, index) {
          final day = _scheduleData[index];
          return Card( 
            margin: const EdgeInsets.all(10.0),
            child: Padding(
              padding: const EdgeInsets.all(15.0), 
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(day['day'], style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                  const SizedBox(height: 10),
                  ...day['classes'].map((course) => Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text('${course['time']} - ${course['course']}'),
                      const SizedBox(height: 5), 
                    ],
                  )).toList(),
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}
