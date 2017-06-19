using System;

namespace App
{
    public class Customer
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public bool HasCreditLimit { get; set; }

        public int CreditLimit { get; set; }

        public Company Company { get; set; }


        //TODO: I would put the logic for this back into the Customer service code - in a reallife example into the business layer.
        // I also assume that the copany name is replaced with classification so gold = veryImportant , silver = important and bronze = others and would refactor accordingly
        public void SetCreditLimit()
        {
            if (Company.Name == "VeryImportantClient")
            {
                // Skip credit check
                HasCreditLimit = false;
            }
            else
            {
                // Do credit check
                HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(Firstname, Surname, DateOfBirth);

                    CreditLimit = creditLimit;
                    //double credit limit for important clients
                    if (Company.Name == "ImportantClient")
                        creditLimit = creditLimit * 2;
                }

            }
        }
    }
}