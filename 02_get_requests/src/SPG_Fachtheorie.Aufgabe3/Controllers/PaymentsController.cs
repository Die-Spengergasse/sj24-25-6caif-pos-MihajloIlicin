using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private static readonly List<PaymentDetailDto> Payments = new()
    {
        new PaymentDetailDto
        {
            Id = 1,
            EmployeeFirstName = "John",
            EmployeeLastName = "Doe",
            CashDeskNumber = 5,
            PaymentType = "Credit Card",
            PaymentItems = new List<PaymentItemDto>
            {
                new PaymentItemDto { ArticleName = "Laptop", Amount = 1, Price = 999.99m },
                new PaymentItemDto { ArticleName = "Mouse", Amount = 2, Price = 19.99m }
            }
        },
        new PaymentDetailDto
        {
            Id = 2,
            EmployeeFirstName = "Jane",
            EmployeeLastName = "Smith",
            CashDeskNumber = 3,
            PaymentType = "Cash",
            PaymentItems = new List<PaymentItemDto>
            {
                new PaymentItemDto { ArticleName = "Keyboard", Amount = 1, Price = 49.99m },
                new PaymentItemDto { ArticleName = "Monitor", Amount = 1, Price = 199.99m }
            }
        }
    };

    [HttpGet]
    public IActionResult GetPayments([FromQuery] int? cashDesk, [FromQuery] DateTime? dateFrom)
    {
        var result = Payments
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                EmployeeFirstName = p.EmployeeFirstName,
                EmployeeLastName = p.EmployeeLastName,
                CashDeskNumber = p.CashDeskNumber,
                PaymentType = p.PaymentType,
                TotalAmount = p.PaymentItems.Sum(i => i.Price * i.Amount)
            });

        if (cashDesk.HasValue)
        {
            result = result.Where(p => p.CashDeskNumber == cashDesk.Value);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetPaymentById(int id)
    {
        var payment = Payments.FirstOrDefault(p => p.Id == id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }
}