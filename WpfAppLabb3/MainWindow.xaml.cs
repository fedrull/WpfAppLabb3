using MongoDB.Driver.Core.Authentication;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppLabb3.Data;
using WpfAppLabb3.Models;

namespace WpfAppLabb3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		static MongoCrud db = new MongoCrud("WpfLabb3");
		static List<UserModel> users = new List<UserModel>();

		public MainWindow()
		{
			InitializeComponent();

		}

		private void LoginBtn_Click(object sender, RoutedEventArgs e)
		{
			UserWindow userWindow = new UserWindow();

			

			string username = TxtBoxUsername.Text;
			string password = TxtBoxPassword.Text;
			if(!db.UserExists("Users",username, password))
			{
				MessageBox.Show("Wrong Username or Password");


			}
			else
			{
				userWindow.Show();
			}
		}

		public void GetUsers()
		{
			users = db.GetAllUsers("Users");
			foreach (var user in users)
			{
				MessageBox.Show($"{user.UserName}{user.Password} found in the database");
			}
		}
		//private bool AuthenticateUser(string table,string username, string password)
		//{
		//	// Hämta användaren från databasen baserat på användarnamn
		//	UserModel user = db.("Users");

		//	// Kontrollera om användaren finns och lösenordet matchar
		//	return user != null && user.Password == password;
		//}



		private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
		{
			string username = TxtBoxUsername.Text;
			string password = TxtBoxPassword.Text;

			if (db.UserExists("Users", username,password))
			{
				MessageBox.Show("The username already exists. Please choose another one");
			}
			else
			{
				UserModel user = new UserModel(username, password);
				db.AddUser("Users", user);
				MessageBox.Show("The User has been added.");
			}



			//UserModel user = new UserModel(username, password);
			//db.AddUser("Users", user);
		}
	}
}
