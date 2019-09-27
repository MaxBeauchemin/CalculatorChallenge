namespace Calculator.DTOs
{
    public class CalculatorToken
    {
        public string Token { get; set; }
        public decimal Value { get; set; }
        public bool Errored { get; set; }
    }
}
