using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class CustomerService
    {   
        //firstName
        public bool AddCustomer(string firstName, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            if (!IsNameValid(firstName, surname))
                return false;

            if (!IsEmailValid(email))
                return false;
            
            var age = GetAge(dateOfBirth);
            if (age < 21)
                return false;

            var companyRepository = new CompanyRepository();
            var company = companyRepository.GetById(companyId);

            var customer = new Customer
                               {
                                   Company = company,
                                   DateOfBirth = dateOfBirth,
                                   EmailAddress = email,
                                   Firstname = firstName,
                                   Surname = surname
                               };

            customer.SetCreditLimit();
            if (customer.HasCreditLimit && customer.CreditLimit < 500)
                return false;

            CustomerDataAccess.AddCustomer(customer);

            return true;
        }


        //moved these out so they can be implemented, used and tested seperatly 
        public static int GetAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        public static bool IsEmailValid(string email)
        {
            return (email.Contains("@") && email.Contains("."));
        }

        public static bool IsNameValid(string firstName, string surname)
        {
            return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname));
         }

    }
}
