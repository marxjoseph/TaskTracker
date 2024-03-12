using System.ComponentModel.DataAnnotations;

namespace ListWebsite.Models;

public class ValidateDate : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if(value is null) {
            return false;
        }
        if (value is DateTime dateTime)
        {
            return dateTime.Date >= DateTime.Now.Date;
        }
        return false;
    }
}