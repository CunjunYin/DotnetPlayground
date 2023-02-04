using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Laboratory.Core;

namespace Laboratory.Models;
public class TestModel: IValidatableObject
{
    private TestCore _test;

    [FromQuery]
    public string? name { get; set; } =  "";

    public TestModel(TestCore test)
    {
        _test = test;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(1==0) {
            yield return new ValidationResult("Empty client id Uri");
        }

        // if (_test.Run().Result)
        // {
        //     yield return new ValidationResult("Invalid"); 
        // }
    }


}