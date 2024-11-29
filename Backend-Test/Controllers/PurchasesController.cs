using Backend_Test.Application.Interfaces;
using Backend_Test.Domain.Exceptions;
using Backend_Test.Domain.Models;
using Backend_Test.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_Test.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly ICsvService _csvService;

        public PurchaseController(IPurchaseService purchaseService, ICsvService csvService)
        {
            _purchaseService = purchaseService;
            _csvService = csvService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetAll()
        {
            var purchases = await _purchaseService.GetAllAsync();
            return Ok(purchases);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetById(int id)
        {
            var purchase = await _purchaseService.GetByIdAsync(id);
            if (purchase == null)
            {
                throw new NotFoundException(ErrorMessage.PurchaseNotFoundById(id));
            }
            return Ok(purchase);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetByCustomerId(int customerId)
        {
            var purchases = await _purchaseService.GetByCustomerIdAsync(customerId);
            return Ok(purchases);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new BadRequestException(ErrorMessage.PurchaseInvalid);
            }

            await _purchaseService.AddAsync(purchase);
            return CreatedAtAction(nameof(GetById), new { id = purchase.Id }, purchase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Purchase purchase)
        {
            if (id != purchase.Id)
            {
                throw new BadRequestException(ErrorMessage.IdNotMatch);
            }

            await _purchaseService.UpdateAsync(purchase);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var purchase = await _purchaseService.GetByIdAsync(id);
            if (purchase == null)
            {
                throw new NotFoundException(ErrorMessage.PurchaseNotFoundById(id));
            }

            await _purchaseService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("purchases/get/{id}/report")]
        public async Task<ActionResult<byte[]>> GetPurchaseReportById(int id)
        {
            var report = await _csvService.GenerateCsvReportAsync(id);
            if (report == null)
            {
                throw new NotFoundException(ErrorMessage.ReportPurchaseNotFoundById(id));
            }

            return File(report, "text/csv", "purchase_report.csv");
        }
    }
}
