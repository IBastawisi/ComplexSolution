// See https://aka.ms/new-console-template for more information
using static System.Console;
using ComplexLibrary;

static ComplexNumber ReadComplexNumber()
{
  WriteLine("Enter a complex number in the form a + bi: ");
  string? input = ReadLine();
  if (input is null)
  {
    WriteLine("Invalid input");
    return ReadComplexNumber();
  }
  ComplexNumber? result = ComplexNumber.TryParse(input);
  if (result is null)
  {
    WriteLine("Invalid input");
    return ReadComplexNumber();
  }
  return result;
}

static Operation ReadOperation()
{
  WriteLine("Enter an operation (+, -, *, /): ");
  string? input = ReadLine();
  if (input is null)
  {
    WriteLine("Invalid input");
    return Operation.Add;
  }
  return input switch
  {
    "+" => Operation.Add,
    "-" => Operation.Subtract,
    "*" => Operation.Multiply,
    "/" => Operation.Divide,
    _ => Operation.Add
  };
}

static void Calculate ()
{
  var a = ReadComplexNumber();
  var b = ReadComplexNumber();
  var operation = ReadOperation();

  var result = operation switch
  {
    Operation.Add => a + b,
    Operation.Subtract => a - b,
    Operation.Multiply => a * b,
    Operation.Divide => a / b,
    _ => a + b
  };

  WriteLine($"{a} {operation} {b} = {result}");
}

while (true)
{
  Calculate();
}

enum Operation
{
  Add,
  Subtract,
  Multiply,
  Divide
}

