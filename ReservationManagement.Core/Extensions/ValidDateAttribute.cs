using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationManagement.Core.Extensions
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date >= DateTime.Now.Date; // Validates that the date is not in the past
            }
            return false;
        }
    }
}
