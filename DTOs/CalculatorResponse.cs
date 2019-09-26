namespace Calculator.DTOs
{
    public class CalculatorResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal Value { get; set; }
    }
}
