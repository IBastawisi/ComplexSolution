// See https://aka.ms/new-console-template for more information
using static System.Console;
using ComplexLibrary;

static ComplexNumber ReadComplexNumber()
{
  WriteLine("Enter a complex number in the form a + bi: ");
  string? input = ReadLine();
  ComplexNumber result = ComplexNumber.TryParse(input);
  return result;
}

static Operation ReadOperation()
{
  WriteLine("Enter an operation (+, -, *, /): ");
  string? input = ReadLine();
  return ComplexCalculator.ParseOperation(input);
}

static void Calculate ()
{
  var a = ReadComplexNumber();
  var b = ReadComplexNumber();
  var operation = ReadOperation();
  var result = ComplexCalculator.Calculate(a, b, operation);

  WriteLine($"{a} {operation} {b} = {result}");
}

while (true)
{
  Calculate();
}

