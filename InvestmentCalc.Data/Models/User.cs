using Investment_Calc.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investment_Calc.Data.Models
{
    public class User : I_User
    {
        public static int CLASS_USER = 0;
        public static int CLASS_ADMIN = 1;

        private string _name;
        private int _classification;

        public int Id { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Classification
        {
            get
            {
                return _classification;
            }
            set
            {
                _classification = value;
            }
        }

        public bool isAdmin()
        {
            if(User.CLASS_ADMIN == Classification)
            {
                return true;
            }
            return false;
        }

        public User()
        {
            Name = "Customer Support Agent";
            Classification = User.CLASS_ADMIN;
        }

        public User(string name)
        {
            Name = name;
            Classification = User.CLASS_USER;
        }
    }
}
