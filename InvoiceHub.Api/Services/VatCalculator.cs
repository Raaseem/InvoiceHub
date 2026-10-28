namespace InvoiceHub.Api.Services
{
    public class VatCalculator: IVatCalculator
    {
        public decimal CalculateVat(decimal amount) 
        {
            return Math.Round(amount*0.05m,2);
        }
    }
}
