using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfAppLabb3.Models;

namespace WpfAppLabb3.Data
{
	internal class MongoCrud
	{
		private IMongoDatabase db;
		public MongoCrud(string databse)
		{
			var client = new MongoClient("");
			db = client.GetDatabase(databse);
		}

		public void AddUser(string table, UserModel user)
		{
			var collection = db.GetCollection<UserModel>(table);
			collection.InsertOne(user);
		}
		public void DeleteUser() 
		{
		
		}
		public List<UserModel> GetAllUsers(string table)
		{
			var collection = db.GetCollection<UserModel>(table);
			return collection.Find(_ => true).ToList();
		}
		public UserModel GetUserById(string table, Guid id)
		{
			var collection = db.GetCollection<UserModel>(table);
			return collection.AsQueryable().ToList().Find(x => x.Id == id);
		}

		public bool UserExists(string table,string username, string password)
		{
			
			List<UserModel> users = new List<UserModel>();
			users = GetAllUsers(table);

			foreach (UserModel user in users)
			{
				if (user.UserName == username && user.Password == password)
				{
					return true; 
				}
			}

			return false;
		}


	}
}
