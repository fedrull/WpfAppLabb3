using System;
using System.Collections.Generic;
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
		static List<UserModel> users = new List<UserModel>();

		public UserWindow()
		{
			InitializeComponent();
			GetUsers();
			
		}


		public void GetUsers()
		{
			users = db.GetAllUsers("Users");
			foreach (var user in users)
			{

				string userString = $"{user.UserName} - {user.Password}";
				CombooBoox.Items.Add(userString);

			}
		}

		public void DeleteUser1(string table, UserModel user)
		{
			db.DeleteUser(table, user);

		}

		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			var user = CombooBoox.SelectedItem as UserModel;
			DeleteUser1("Users", user);
		}

		private void UppdateBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
