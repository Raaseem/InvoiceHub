using InvoiceHub.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController: ControllerBase
    {
        private readonly IVatCalculator _vat;

        public InvoicesController(IVatCalculator vat)
        {
            _vat = vat;
        }

    }
}
