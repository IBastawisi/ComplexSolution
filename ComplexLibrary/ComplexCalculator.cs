namespace ComplexLibrary;
public enum Operation
{
  Add,
  Subtract,
  Multiply,
  Divide
}

public class ComplexCalculator
{
  public static Operation ParseOperation(string? operation)
  {
    return operation switch
    {
      "+" => Operation.Add,
      "-" => Operation.Subtract,
      "*" => Operation.Multiply,
      "/" => Operation.Divide,
      _ => Operation.Add
    };
  }
  public static ComplexNumber Calculate(ComplexNumber a, ComplexNumber b, Operation operation) => operation switch
  {
    Operation.Add => a + b,
    Operation.Subtract => a - b,
    Operation.Multiply => a * b,
    Operation.Divide => a / b,
    _ => a + b
  };
  public static ComplexNumber Calculate(string a, string b, string operation)
  {
    var A = ComplexNumber.TryParse(a);
    var B = ComplexNumber.TryParse(b);
    var op = ParseOperation(operation);
    if (A is null || B is null)
    {
      throw new ArgumentException("Invalid input");
    }
    return Calculate(A, B, op);
  }
}