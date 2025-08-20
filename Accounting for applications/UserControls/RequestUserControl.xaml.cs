using dem04.EFModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace dem04.UserControls
{
	public partial class RequestUserControl : UserControl
	{
		public Request thisRequest;
		private MainWindow EvokingWindow;
		private bool isEditing = false;
		private List<SolidColorBrush> gamma = new List<SolidColorBrush>() { 
			new SolidColorBrush(Colors.LightGreen),
			new SolidColorBrush(Colors.LightSeaGreen)
		};
		public RequestUserControl(Request request, MainWindow EvokingWindow,Dem04DbContext dbContext)
		{
			InitializeComponent();
			thisRequest = request;
			this.EvokingWindow = EvokingWindow;
			FillUserControl(thisRequest, dbContext);
		}
		private void FillUserControl(Request request, Dem04DbContext dbContext) {
			MainBorder.Background = gamma[thisRequest.RequestPriority];
			RequestStateTextBox.Text = thisRequest.RequestStateNavigation.RequestState1.ToString();
			ClientTextBox.Text = thisRequest.ClientNavigation.Surname;
			WorkerTextBox.Text = thisRequest.WorkerNavigation.Surname;
            DateOfAcceptTextBox.Text = thisRequest.DateOfAccept.ToShortDateString();
			if (thisRequest.DateOfWorkStart != null)
				DateOfWorkStartTextBox.Text = thisRequest.DateOfWorkStart.Value.ToShortDateString();
			if (thisRequest.DateOfWorkEnd != null)
				DateOfWorkEndTextBox.Text = thisRequest.DateOfWorkEnd.Value.ToShortDateString();
			EquipmentTextBox.Text = string.Join(',', thisRequest.Equipment);
			DescriptionTextBox.Text = new string(thisRequest.RequestDescription);
			RequestStateComboBox.Items.Add(dbContext.RequestStates.Select(R => R.RequestState1).ToList());
		}
		private void ChangeEditingMode() {
			ApproveChanges.Visibility = isEditing ? Visibility.Visible : Visibility.Hidden;		//change button visibility
			DiscardChanges.Visibility = isEditing ? Visibility.Visible : Visibility.Hidden;
			EditRequestButton.Visibility = isEditing ? Visibility.Hidden : Visibility.Visible;
			DeleteRequestButton.Visibility = isEditing ? Visibility.Hidden : Visibility.Visible;

			RequestStateTextBox.IsEnabled = isEditing;		//добавить проверку если админ - меняет все поля, если работник - только статус и описание

			WorkerTextBox.IsEnabled = isEditing;			//change texbox editing mode
			DescriptionTextBox.IsEnabled = isEditing;

			RequestStateComboBox.Visibility = isEditing ? Visibility.Visible : Visibility.Hidden;
            RequestStateTextBox.Visibility = isEditing ? Visibility.Hidden : Visibility.Visible;




        }
        private void EditRequestButton_Click(object sender, RoutedEventArgs e)
		{
			isEditing = true;
            ChangeEditingMode();
		}

		private void DeleteRequestButton_Click(object sender, RoutedEventArgs e)
		{
			EvokingWindow.RemoveRequest(this);
		}

		private void ApproveChanges_Click(object sender, RoutedEventArgs e)
		{
			thisRequest.RequestDescription = DescriptionTextBox.Text;
			EvokingWindow.EditRequest(this);
			isEditing = false;
			ChangeEditingMode();
		}

		private void DiscardChanges_Click(object sender, RoutedEventArgs e)
		{
			isEditing = false;
			ChangeEditingMode();
            DescriptionTextBox.Clear();
            DescriptionTextBox.Text = new string(thisRequest.RequestDescription);
        }

    }
}
