using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    public static class Calculate
    {
        public static int Calculator(DateTime DateOfBirth, int CarYear, string Make, string Model, int Tickets, bool DUI, string coverage)
        {
            int price = 50;
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (age < 18)
                price += 100;
            else if (age < 25)
                price += 25;
            else if (age > 100)
                price += 25;
            if (CarYear < 2000)
                price += 25;
            else if (CarYear > 2015)
                price += 25;
            if(Make.ToLower() == "porsche")
            {
                price += 25;
                if (Model == "911 Carrera")
                    price += 25;
            }
            price += (10 * Tickets);
            if (DUI)
                price =(int)(price* 1.25);
            if(coverage.ToLower()=="full")
                price= (int)(price * 1.5);
            return price;


        }
    }
}