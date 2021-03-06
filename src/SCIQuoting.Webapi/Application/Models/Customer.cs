using System;

namespace SCIQuoting.Webapi.Application.Models{
    public enum Gender{
        Female = 1,
        Male = 2
    }
    public class Customer{

        public Customer(int ssn, string name, int gender, DateTime birthdate, Address address, string email, string phoneNumber)
        {
            this.SSN = ssn;
            this.Name = Name;
            this.Gender = (Gender)gender;
            this.Birthdate = birthdate;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        public int SSN { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Address { get; set; }
        public string Email {get; set;}
        public string PhoneNumber  {get; set;}
        public bool IsFemale{ get { return Gender == Gender.Female; } }
        public int Age{
            get{

                int age = DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now < Birthdate.AddYears(age)) age--;
                return age;
            }
        }
        private double FemaleModifier{
            get{
                if(Age >= 16 && Age <= 24) return 1.4;
                if(Age >= 25 && Age <= 60) return 1;
                if(Age > 60) return 1.2;
                return float.MaxValue;
            }
        }
        private double MaleModifier{
            get{
                if(Age >= 16 && Age <= 24) return 1.5;
                if(Age >= 25 && Age <= 35) return 1.2;
                if(Age >= 36 && Age <= 60) return 1;
                if(Age > 60) return 1.3;
                return float.MaxValue;
            }
        }
        public double Modifier { 
            get { 
                return IsFemale ? FemaleModifier : MaleModifier;
            } 
        }
    }
}