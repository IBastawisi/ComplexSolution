using Microsoft.AspNetCore.Mvc;
using ComplexLibrary;

namespace ComplexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    public CalculatorController() { }
    [HttpGet(Name = "Calculate")]
    public string Calculate(string a, string b, string operation)
    {
        var result = ComplexCalculator.Calculate(a, b, operation).ToString();
        return result;
    }
}
