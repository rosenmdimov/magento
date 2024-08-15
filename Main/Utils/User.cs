using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Playtech.Main.Utils
{
    internal class User
    {
        static IConfigurationRoot configBuilder = new ConfigurationBuilder().
            AddJsonFile("appsettings.json").Build();
        IConfigurationSection configSection = configBuilder.GetSection("User");

        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string streetAddress;
        private string city;
        private string state;
        private string country;
        private string phoneNumber;
        private string zip;

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }

        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Country { get => country; set => country = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Zip { get => zip; set => zip = value; }

        public User() { }
        public User( string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

        }

        public User(
                string firstName, 
                string lastName, 
                string email, 
                string password, 
                string streetAddress, 
                string city, 
                string state, 
                string country, 
                string phoneNumber,
                string zip)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.streetAddress = streetAddress;
            this.city = city;
            this.state = state;
            this.country = country;
            this.phoneNumber = phoneNumber;
            this.zip = zip;
        }
    }
}
