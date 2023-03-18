namespace ComplexLibrary;

public class ComplexNumber
{
  public double Real { get; set; }
  public double Imaginary { get; set; }
  public ComplexNumber(double real, double imaginary)
  {
    Real = real;
    Imaginary = imaginary;
  }
  public override string ToString()
  {
    return $"{Real} + {Imaginary}i";
  }

  public static ComplexNumber TryParse(string? input)
  {
    var result = new ComplexNumber(0, 0);
    if (string.IsNullOrEmpty(input))
    {
      return result;
    }

    string[] parts = input.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

    result.Real = Convert.ToDouble(parts[0]);
    if (parts.Length == 1)
    {
      return result;
    }

    result.Imaginary = Convert.ToDouble(parts[1].TrimEnd('i'));
    if (input.Contains('-'))
    {
      result.Imaginary *= -1;
    }

    return result;
  }

  public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
  {
    return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
  }

  public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
  {
    return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
  }

  public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
  {
    return new ComplexNumber(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
  }

  public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
  {
    double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
    return new ComplexNumber((a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator, (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
  }
}
