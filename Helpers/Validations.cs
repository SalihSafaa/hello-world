namespace HelloWorld;

public static class UserInputValidations
{
    public static bool ValidateString(ref string? inputString)
    {
        if(string.IsNullOrWhiteSpace(inputString))
        {
            Console.WriteLine("Invalid input");
            return false;
        }
        else
        {
            inputString=inputString.Trim();
            return true;
        }
    }
    public static bool ValidateAndCovertToInt(string? inputString,out int outputInt)
    {
        if(int.TryParse(inputString, out outputInt))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return false;
        }
    }
    public static bool ValidatePrice(string? inputString,out decimal outputPrice)
    {
        if (decimal.TryParse(inputString, out decimal output))
        {
            if(output<=0)
            {
                outputPrice=0m;
                Console.WriteLine("Invalid input");
                return false;
            }
            outputPrice=Convert.ToDecimal(output);
            return true;
        }
        else
        {
            outputPrice=0m;
            Console.WriteLine("Invalid input");
            return false;
        }
    }
}