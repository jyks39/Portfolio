using dem04.EFModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace dem04
{
	public partial class LoginWindow : Window
	{
		Dem04DbContext db = new Dem04DbContext();
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			Worker? worker = CheckAuthtorization(LoginTextBox.Text, PasswordTextBox.Text);
			if (worker == null)
			{
				MessageBox.Show("Указанный логин или пароль не найден!", "Авторизация не удалась");
				return;
			}
			MainWindow mainWindow = new MainWindow(worker);
			mainWindow.Show();
			this.Close();
		}
		private Worker? CheckAuthtorization(string Login, string Password) {
			if (db.Logins.Any(w => w.Login1 == Login && w.Password == Password))
				return db.Logins.Include(l => l.RoleNavigation).Include(l => l.Workers).First(w => w.Login1 == Login && w.Password == Password).Workers.First();
			return null;
		}
	}
}
