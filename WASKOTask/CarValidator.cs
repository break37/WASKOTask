using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WASKOTask
{
    static class CarValidator
    {
        private const string MANUFACTURER_PATTERN = @"^[A-Z][A-Za-z]*$";
        private const string MODEL_PATTERN = @"^[A-z0-9]+$";
        private const string CAPACITY_PATTERN = @"^[0-9][\.,][0-9]$";

        static public bool isManufacturerValid(string textToValidate)
        {
            return isValid("manufacturer", textToValidate);
        }

        static public bool isModelValid(string textToValidate)
        {
            return isValid("model", textToValidate);
        }

        static public bool isCapacityValid(string textToValidate)
        {
            return isValid("capacity", textToValidate);
        }

        static public bool isValid(string option, string textToValidate)
        {
            string pattern = "";
            if (option.ToLower() == "manufacturer") pattern = MANUFACTURER_PATTERN;
            if (option.ToLower() == "model") pattern = MODEL_PATTERN;
            if (option.ToLower() == "capacity") pattern = CAPACITY_PATTERN;

            Match validationRresult = Regex.Match(textToValidate, pattern);
            if (validationRresult.Success)
                return true;
            return false;
        }
    }
}