using Investment_Calc.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investment_Calc.Data.Models
{
    public class ContactForm : I_ContactForm
    {
        //To classify the contact type easily
        public static int TYPE_GENERAL_INQUIRY = 0;
        public static int TYPE_EXISTING_INVESTMENT = 1;
        public static int TYPE_PURCHASE_INVESTMENT = 2;

        public int Id { get; set; }

        private string _name;
        private string _email;
        private string _phoneNum;
        private string _text;
        private string _supportNotes;
        private bool _isResolved;
        private int _type;

        public string CustomerName 
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
        public string CustomerEmail
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string CustomerPhoneNumber
        {
            get
            {
                return _phoneNum;
            }
            set
            {
                _phoneNum = value;
            }
        }
        public string CustomerText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        public string SupportText
        {
            get
            {
                return _supportNotes;
            }
            set
            {
                _supportNotes = value;
            }
        }
        public bool isResolved
        {
            get
            {
                return _isResolved;
            }
            set
            {
                _isResolved = value;
            }
        }
        public int ContactType
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public ContactForm()
        {
            CustomerName = "None";
            CustomerEmail = "something@gmail.com";
            CustomerPhoneNumber = "5555555555";
            CustomerText = "None";
            ContactType = TYPE_GENERAL_INQUIRY;
            isResolved = false;
            SupportText = "";
        }

        public ContactForm(string n, string e, string pn, string txt, int con)
        {
            CustomerName = n;
            CustomerEmail = e;
            CustomerPhoneNumber = pn;
            CustomerText = txt;
            ContactType = con;
            isResolved = false;
            SupportText = "";
        }
    }
}
