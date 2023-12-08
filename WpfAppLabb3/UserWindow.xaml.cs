using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppLabb3.Data;
using WpfAppLabb3.Models;

namespace WpfAppLabb3
{
	/// <summary>
	/// Interaction logic for UserWindow.xaml
	/// </summary>
	public partial class UserWindow : Window
	{
		static MongoCrud db = new MongoCrud("WpfLabb3");
		static ObservableCollection <UserModel> users = new ObservableCollection<UserModel>();

		public UserWindow()
		{
			InitializeComponent();
			GetUsers();
			ListUserBox.ItemsSource = users;
		}


		public void GetUsers()
		{
			var userlist = db.GetAllUsers("Users");
			users.Clear();
			foreach (var user in userlist) 
			{ 
				users.Add(user);
			}
			ListUserBox.ItemsSource = users;
		}

		public void DeleteUser1(string table, UserModel user)
		{
			db.DeleteUser(table, user);

		}

		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			UserModel slectedUser = ListUserBox.SelectedItem as UserModel;
			if(slectedUser != null)
			{
				DeleteUser1("Users", slectedUser);
				users.Remove(slectedUser);
			}
			 
		}

		private void UppdateBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
