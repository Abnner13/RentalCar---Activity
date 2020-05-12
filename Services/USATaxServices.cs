namespace InterfacePRO.Services
{
    public class USATaxServices : ITaxService
    {
         public double Tax(double amount)
        {
            if (amount <= 250.00)
            {
                return amount * 0.11;
            }
            else
            {
                return amount * 0.03;
            }
        }
    }
}
