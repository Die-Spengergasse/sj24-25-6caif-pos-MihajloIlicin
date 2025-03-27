public class PaymentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public PaymentsController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public IActionResult CreatePayment([FromBody] NewPaymentCommand command)
    {
        if (command.PaymentDateTime > DateTime.UtcNow.AddMinutes(1))
        {
            return BadRequest(new ProblemDetails { Title = "Invalid PaymentDateTime", Detail = "Payment date cannot be more than 1 minute in the future." });
        }
        
        var cashDesk = _context.CashDesks.FirstOrDefault(cd => cd.Id == command.CashDeskNumber);
        var employee = _context.Employees.FirstOrDefault(emp => emp.RegistrationNumber == command.EmployeeRegistrationNumber);
        
        if (cashDesk == null || employee == null)
        {
            return BadRequest(new ProblemDetails { Title = "Invalid Data", Detail = "CashDesk or Employee not found." });
        }
        
        if (!Enum.TryParse(command.PaymentType, out PaymentType paymentType))
        {
            return BadRequest(new ProblemDetails { Title = "Invalid Payment Type", Detail = "The provided payment type is not valid." });
        }
        
        var payment = new Payment
        {
            CashDesk = cashDesk,
            Employee = employee,
            PaymentDateTime = command.PaymentDateTime,
            PaymentType = paymentType
        };
        
        try
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CreatePayment), new { id = payment.Id }, payment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ProblemDetails { Title = "Database Error", Detail = ex.Message });
        }
    }
}