using Microsoft.AspNetCore.Mvc;
using ComplexLibrary;

namespace ComplexApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CalculatorController : ControllerBase
{
  /// <summary>
  /// Calculates the result of a complex number operation
  /// </summary>
  /// <param name="a">The first complex number in the form a+bi</param>
  /// <param name="b">The second complex number in the form a+bi</param>
  /// <param name="operation">The operation to perform (+, -, *, /) </param>
  /// <returns>The result of the operation</returns>
  /// <response code="200">Returns the result of the operation</response>
  /// <response code="400">If the input is invalid</response>
  [HttpGet(Name = "Calculate")]
  public string Calculate(string a, string b, string operation)
  {
    try
    {
      return ComplexCalculator.Calculate(a, b, operation).ToString();
    }
    catch (Exception e)
    {
      Response.StatusCode = 400;
      return e.Message;
    }
  }
}
