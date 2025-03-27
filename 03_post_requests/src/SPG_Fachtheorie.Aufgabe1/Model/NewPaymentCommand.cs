public class NewPaymentCommand
{
    [Required]
    public int CashDeskNumber { get; set; }
    
    [Required]
    public DateTime PaymentDateTime { get; set; }
    
    [Required]
    [EnumDataType(typeof(PaymentType))]
    public string PaymentType { get; set; }
    
    [Required]
    public int EmployeeRegistrationNumber { get; set; }
}