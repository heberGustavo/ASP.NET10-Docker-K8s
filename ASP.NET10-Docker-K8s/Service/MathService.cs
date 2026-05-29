namespace ASP.NET10_Docker_K8s.Service
{
    public class MathService
    {
        public decimal Sum(decimal first, decimal second) => first + second;
        
        public decimal Sub(decimal first, decimal second) => first - second;
        
        public decimal Mult(decimal first, decimal second) => first * second;
        
        public decimal Div(decimal first, decimal second)
        {
            if (second == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return first / second;
        }

        public decimal Mean(decimal first, decimal second) => (first + second) / 2;

        public double Sqrt(double value)
        {
            if (value < 0) throw new ArgumentException("Cannot calculate square root of negative number.");
            return (double)Math.Sqrt((double)value);
        }
    }
}
