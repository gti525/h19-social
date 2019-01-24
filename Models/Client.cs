using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreHeroku.Models
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public byte[] profile_image { get; set; }

        // Constructor the client class
        /*
        public Client(int client_id, string email, string password, string first_name, string last_name, string birth_date, string address, string city, string postal_code, string province, string country, byte[] profile_image)
        {
            this.client_id = client_id;
            this.email = email;
            this.password = password;
            this.first_name = first_name;
            this.last_name = last_name;
            this.birth_date = birth_date;
            this.address = address;
            this.city = city;
            this.postal_code = postal_code;
            this.province = province;
            this.country = country;
            this.profile_image = profile_image;
        }
        */
        // Constructor for the client class, without the profile_image attribute.
        public Client(int client_id, string email, string password, string first_name, string last_name, DateTime birth_date, string address, string city, string postal_code, string province, string country)
        {
            this.client_id = client_id;
            this.email = email;
            this.password = password;
            this.first_name = first_name;
            this.last_name = last_name;
            this.birth_date = birth_date;
            this.address = address;
            this.city = city;
            this.postal_code = postal_code;
            this.province = province;
            this.country = country;
        }
    }
}
