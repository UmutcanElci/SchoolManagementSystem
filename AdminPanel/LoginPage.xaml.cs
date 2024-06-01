using System.Windows;

namespace AdminPanel;

public partial class LoginPage : Window
{
    public LoginPage()
    {
        InitializeComponent();
    }
    private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}