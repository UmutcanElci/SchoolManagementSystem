using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminPanel
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Student> StudentsWithoutClass { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }

        public int TotalStudents { get; set; }
        public int TotalTeachers { get; set; }
        public int Class3A { get; set; }
        public int Class3B { get; set; }
        public int Class3C { get; set; }
        public int Class4A { get; set; }
        public int Class4B { get; set; }
        public int Class4C { get; set; }
        public int Class5A { get; set; }
        public int Class5B { get; set; }
        public int Class5C { get; set; }
        public int Class6A { get; set; }
        public int Class6B { get; set; }
        public int Class6C { get; set; }
        public int Class7A { get; set; }
        public int Class7B { get; set; }
        public int Class7C { get; set; }
        public int Class8A { get; set; }
        public int Class8B { get; set; }
        public int Class8C { get; set; }

        private HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5123/api/") };
            DataContext = this;
            LoadStudents();
            LoadStudentsWithoutClass();
            LoadClasses();
            LoadTeachers();
        }

        private async void StudentInfoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = (Student)StudentInfoListBox.SelectedItem;
            if (selectedStudent != null)
            {
                InfoStudentName.Text = $"{selectedStudent.Name} {selectedStudent.Surname}";

                // Fetch parent information using ParentId
                var parent = await GetParent(selectedStudent.ParentId);

                // Check if parent information is retrieved successfully
                if (parent != null)
                {
                    InfoStudentMotherName.Text = parent.MotherName;
                    InfoStudentFatherName.Text = parent.FatherName;
                }
                else
                {
                    // Handle the case when parent information is not available
                    InfoStudentMotherName.Text = "N/A";
                    InfoStudentFatherName.Text = "N/A";
                }

                InfoStudentAddress.Text = selectedStudent.Address;
                InfoStudentGender.Text = selectedStudent.Gender ? "Male" : "Female";
                InfoStudentBirthDate.Text = selectedStudent.DateOfBirth.ToShortDateString();
                InfoStudentAge.Text = selectedStudent.Age;
                InfoStudentEmail.Text = selectedStudent.Email;
            }
        }

        private async void LoadStudentsForInfoContent()
        {
            try
            {
                var students = await _httpClient.GetFromJsonAsync<List<Student>>("Student/GetAllStudents");
                StudentInfoListBox.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
            }
        }

        private async void LoadTeachers()
        {
            try
            {
                var teachers = await _httpClient.GetFromJsonAsync<List<Teacher>>("Teacher/GetAllTeachers");
                Teachers = new ObservableCollection<Teacher>(teachers);
                TeacherListBoxForTeachers.ItemsSource = Teachers;
                TotalTeachers = teachers.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading teachers: {ex.Message}");
            }
        }

        private void TeacherListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeacher = (Teacher)TeacherListBoxForTeachers.SelectedItem;
            if (selectedTeacher != null)
            {
                SelectedTeacherText.Text = $"{selectedTeacher.Name} {selectedTeacher.Surname}";
            }
        }

        private void ClassListBoxForTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedClass = (Class)ClassListBoxForTeachers.SelectedItem;
            if (selectedClass != null)
            {
                SelectedClassTextForTeachers.Text = $"{selectedClass.ClassLetter} - Grade {selectedClass.Grade}";
            }
        }

        private async void AddTeacherToClass_Click(object sender, RoutedEventArgs e)
        {
            var selectedTeacher = (Teacher)TeacherListBoxForTeachers.SelectedItem;
            var selectedClass = (Class)ClassListBoxForTeachers.SelectedItem;

            if (selectedTeacher != null && selectedClass != null)
            {
                try
                {
                    var response = await _httpClient.PostAsync($"Teacher/AddTeacherToClass?teacherId={selectedTeacher.Id}&classId={selectedClass.Id}", null);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Teacher successfully added to class!");
                    }
                    else
                    {
                        MessageBox.Show("Error adding teacher to class.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher and a class.");
            }
        }

        private async void LoadStudentsWithoutClass()
        {
            try
            {
                var students = await _httpClient.GetFromJsonAsync<List<Student>>("Class/GetStudentsWithoutClass");
                StudentsWithoutClass = new ObservableCollection<Student>(students);
                StudentListBoxWithoutClass.ItemsSource = StudentsWithoutClass;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenciler yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        private async void LoadClasses()
        {
            try
            {
                var classes = await _httpClient.GetFromJsonAsync<List<Class>>("Class/GetAllClasses");
                Classes = new ObservableCollection<Class>(classes);
                ClassListBox.ItemsSource = Classes;
                ClassListBoxForTeachers.ItemsSource = Classes;

                CalculateClassCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınıflar yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        private Student selectedStudent;
        private Class selectedClass;

        private void StudentListBoxWithoutClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)StudentListBoxWithoutClass.SelectedItem;
            if (selectedStudent != null)
            {
                SelectedStudentText.Text = $"{selectedStudent.Name} {selectedStudent.Surname}";
            }
        }

        private void ClassListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedClass = (Class)ClassListBox.SelectedItem;
            if (selectedClass != null)
            {
                SelectedClassText.Text = $"{selectedClass.ClassLetter} - Grade {selectedClass.Grade}";
            }
        }

        private async void AssignStudentToClass_Click(object sender, RoutedEventArgs e)
        {
            if (selectedStudent != null && selectedClass != null)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync($"Class/AddStudentToClass?studentId={selectedStudent.Id}&classId={selectedClass.Id}", new { });
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Öğrenci sınıfa başarıyla atandı!");
                        LoadStudentsWithoutClass();
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci sınıfa atanırken bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Atama sırasında bir hata oluştu: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci ve sınıf seçin.");
            }
        }

        private async void LoadStudents()
        {
            try
            {
                var students = await _httpClient.GetFromJsonAsync<List<Student>>("RegistrationConfirmation/StudentsWithoutStudentNumber");
                StudentListBox.ItemsSource = students;
                TotalStudents = students.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenciler yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        private async void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = (Student)StudentListBox.SelectedItem;
            if (selectedStudent != null)
            {
                StudentName.Text = $"{selectedStudent.Name} {selectedStudent.Surname}";

                // Fetch parent information using ParentId
                var parent = await GetParent(selectedStudent.ParentId);

                // Check if parent information is retrieved successfully
                if (parent != null)
                {
                    StudentMotherName.Text = parent.MotherName;
                    StudentFatherName.Text = parent.FatherName;
                }
                else
                {
                    // Handle the case when parent information is not available
                    StudentMotherName.Text = "N/A";
                    StudentFatherName.Text = "N/A";
                }

                StudentAddress.Text = selectedStudent.Address;
                StudentGender.Text = selectedStudent.Gender ? "Male" : "Female";
                StudentBirthDate.Text = selectedStudent.DateOfBirth.ToShortDateString();
                StudentAge.Text = selectedStudent.Age;
                StudentEmail.Text = selectedStudent.Email;
            }
        }

        private async Task<Parent> GetParent(int? parentId)
        {
            if (parentId.HasValue)
            {
                try
                {
                    // Fetch parent information using ParentId
                    var parent = await _httpClient.GetFromJsonAsync<Parent>($"Parent/{parentId}");
                    return parent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading parent information: {ex.Message}");
                }
            }

            return null;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            DashboardContent.Visibility = Visibility.Visible;
            RegisterContent.Visibility = Visibility.Collapsed;
            ClassContent.Visibility = Visibility.Collapsed;
            TeacherContent.Visibility = Visibility.Collapsed;
            InfoContent.Visibility = Visibility.Collapsed;
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            DashboardContent.Visibility = Visibility.Collapsed;
            RegisterContent.Visibility = Visibility.Visible;
            ClassContent.Visibility = Visibility.Collapsed;
            TeacherContent.Visibility = Visibility.Collapsed;
            InfoContent.Visibility = Visibility.Collapsed;
        }

        private void Class_Click(object sender, RoutedEventArgs e)
        {
            DashboardContent.Visibility = Visibility.Collapsed;
            RegisterContent.Visibility = Visibility.Collapsed;
            ClassContent.Visibility = Visibility.Visible;
            TeacherContent.Visibility = Visibility.Collapsed;
            InfoContent.Visibility = Visibility.Collapsed;
        }

        private void Teacher_Click(object sender, RoutedEventArgs e)
        {
            DashboardContent.Visibility = Visibility.Collapsed;
            RegisterContent.Visibility = Visibility.Collapsed;
            ClassContent.Visibility = Visibility.Collapsed;
            TeacherContent.Visibility = Visibility.Visible;
            InfoContent.Visibility = Visibility.Collapsed;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            DashboardContent.Visibility = Visibility.Collapsed;
            RegisterContent.Visibility = Visibility.Collapsed;
            ClassContent.Visibility = Visibility.Collapsed;
            TeacherContent.Visibility = Visibility.Collapsed;
            InfoContent.Visibility = Visibility.Visible;
            LoadStudentsForInfoContent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ConfirmStudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Öğrenci onaylandı!");
        }

        private void SaveClass_Click(object sender, RoutedEventArgs e)
        {
            // Sınıf kaydetme işlemi burada gerçekleştirilecek
            MessageBox.Show("Sınıf kaydedildi!");
        }

        private void CalculateClassCounts()
        {
            Class3A = Classes.Count(c => c.Grade == 3 && c.ClassLetter == "A");
            Class3B = Classes.Count(c => c.Grade == 3 && c.ClassLetter == "B");
            Class3C = Classes.Count(c => c.Grade == 3 && c.ClassLetter == "C");
            Class4A = Classes.Count(c => c.Grade == 4 && c.ClassLetter == "A");
            Class4B = Classes.Count(c => c.Grade == 4 && c.ClassLetter == "B");
            Class4C = Classes.Count(c => c.Grade == 4 && c.ClassLetter == "C");
            Class5A = Classes.Count(c => c.Grade == 5 && c.ClassLetter == "A");
            Class5B = Classes.Count(c => c.Grade == 5 && c.ClassLetter == "B");
            Class5C = Classes.Count(c => c.Grade == 5 && c.ClassLetter == "C");
            Class6A = Classes.Count(c => c.Grade == 6 && c.ClassLetter == "A");
            Class6B = Classes.Count(c => c.Grade == 6 && c.ClassLetter == "B");
            Class6C = Classes.Count(c => c.Grade == 6 && c.ClassLetter == "C");
            Class7A = Classes.Count(c => c.Grade == 7 && c.ClassLetter == "A");
            Class7B = Classes.Count(c => c.Grade == 7 && c.ClassLetter == "B");
            Class7C = Classes.Count(c => c.Grade == 7 && c.ClassLetter == "C");
            Class8A = Classes.Count(c => c.Grade == 8 && c.ClassLetter == "A");
            Class8B = Classes.Count(c => c.Grade == 8 && c.ClassLetter == "B");
            Class8C = Classes.Count(c => c.Grade == 8 && c.ClassLetter == "C");
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? StudentNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }

        public string Age { get; set; }
        public int? ParentId { get; set; }
        public Parent? Parent { get; set; }
        public int? ClassId { get; set; }
        public string FullName => $"{Name} {Surname} StudentNo: {StudentNumber}";
    }

    public class Parent
    {
        public int Id { get; set; }
        public string FatherName { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class Class
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string ClassLetter { get; set; }
        public string ClassName => $"{ClassLetter} - Grade {Grade}";
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }
        public string FullName => $"{Name} {Surname}";
    }
}
