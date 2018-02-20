using System;

namespace SCIQuoting.Webapi.Model{
    public enum Gender{
        Female = 1,
        Male = 2
    }
    public class Costumer{
        public int SSN { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Adress { get; set; }
        public string Email {get; set;}
        public string PhoneNumber  {get; set;}
    }
}