namespace InvoiceHub.Api.Services
{
    public interface IVatCalculator
    {
        decimal CalculateVat(decimal amount);
    }
}
