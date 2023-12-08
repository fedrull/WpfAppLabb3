using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppLabb3.Models
{
	public class UserModel
	{
		[BsonId]
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

        public UserModel(string username, string password)
        {
            UserName = username;
			Password = password;
        }
    }
}
