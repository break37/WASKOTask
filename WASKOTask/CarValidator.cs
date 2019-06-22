using System.Text.RegularExpressions;

namespace WASKOTask
{
    static class CarValidator
    {
        private const string MANUFACTURER_PATTERN = @"^[A-Z][A-Za-z]{0,14}$";
        private const string MODEL_PATTERN = @"^[A-z0-9]{1,15}$";
        private const string CAPACITY_PATTERN = @"^[0-9]{1,2}[\.,][0-9]{1,3}$";

        static public bool IsManufacturerValid(string textToValidate)
        {
            return IsValid("manufacturer", textToValidate);
        }

        static public bool IsModelValid(string textToValidate)
        {
            return IsValid("model", textToValidate);
        }

        static public bool IsCapacityValid(string textToValidate)
        {
            return IsValid("capacity", textToValidate);
        }

        static public bool IsValid(string option, string textToValidate)
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