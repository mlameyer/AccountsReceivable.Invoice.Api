using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountsReceivable.InvoiceOperations.Api.Interfaces.Managers;
using AccountsReceivable.InvoiceOperations.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountsReceivable.InvoiceOperations.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceManager _manager;

        public InvoiceController(IInvoiceManager manager, ILogger<InvoiceController> logger)
        {
            _logger = logger;
            _manager = manager;
        }

        //GET: api/Invoice
        [HttpGet("{invoiceid}")]
        public Invoice Get(long invoiceid)
        {
            return _manager.GetInvoiceByInvoiceID(invoiceid);
        }

        //POST api/Invoice
        [HttpPost("{Invoice}")]
        public void Post(Invoice invoice)
        {
            _manager.CreateInvoiceRecord(invoice);
        }

        // GET: api/Invoice
        [HttpGet]
        public string Get()
        {
            return "hello world";
        }
    }
}