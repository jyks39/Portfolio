using dem04.EFModel;
using dem04.UserControls;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace dem04
{
	public partial class MainWindow : Window
	{
		private Worker thisWorker;
		private Dem04DbContext db = new Dem04DbContext();
		public MainWindow(Worker worker)
		{
			InitializeComponent();
			this.thisWorker = worker;
			LoginLabel.Content = $"Вы вошли как: {db.Roles.First(r => r.Id == thisWorker.LoginNavigation.Role).Rolename} {thisWorker.Name} {thisWorker.Surname}";
			FillMainGrid();
		}
		public void FillMainGrid() { 
			int i = 0, j = 0;
			foreach (Request request in db.Requests.Include(r => r.ClientNavigation).Include(r => r.RequestStateNavigation).Include(r => r.WorkerNavigation))
			{
				if (request.WorkerNavigation == thisWorker || thisWorker.LoginNavigation.RoleNavigation.IsAdmin)//показ заявок за которые ответсвенен этот работник
				{
					RequestUserControl newRequest = new RequestUserControl(request, this,db);
					Grid.SetColumn(newRequest, i);
					Grid.SetRow(newRequest, j);
					MainGrid.Children.Add(newRequest);
					i++;
					if (i >= 4)
					{
						RowDefinition row1 = new();
						row1.Height = new GridLength(450, GridUnitType.Pixel);
						MainGrid.RowDefinitions.Add(row1);
						i = 0; j++;
					}
				}
			}
		}
		public void RemoveRequest(RequestUserControl requestUC) {
			MainGrid.Children.Remove(requestUC);
			db.Requests.Remove(requestUC.thisRequest);
			db.SaveChanges();
			RefreshData();
		}
		public void EditRequest(RequestUserControl requestUC) {
			db.SaveChanges();
		}
		public void RefreshData() {
			MainGrid.Children.Clear();
			FillMainGrid();
		}
		private void RefreshButton_Click(object sender, RoutedEventArgs e)
		{
			RefreshData();
		}

		private void CreateRequestButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LogOutButton_Click(object sender, RoutedEventArgs e)
		{
			LoginWindow loginWindow = new LoginWindow();
			loginWindow.Show();
			this.Close();
		}
	}
}
