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

  public static ComplexNumber? TryParse(string s)
  {
    if (String.IsNullOrEmpty(s))
    {
      return null;
    }

    string[] parts = s.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

    if (parts.Length != 2)
    {
      return null;
    }
    if (!double.TryParse(parts[0], out double real))
    {
      return null;
    }
    if (!double.TryParse(parts[1].TrimEnd('i'), out double imaginary))
    {
      return null;
    }

    if (s.Contains('-'))
    {
      imaginary = -imaginary;
    }

    return new ComplexNumber(real, imaginary);
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
