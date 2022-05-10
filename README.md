# Validator-and-data-builder
Use FluentValidation to validate data and data builder to generate randomly datas for tests.

## Requirements
- [ ] Using [FluentValidation](https://docs.fluentvalidation.net/en/latest/) to validate the customer request.
* FirstName and LastName Should not be ***null*** or ***empty***.
* Discount should not equal to ***0*** if ***assigned***
* Address should not be ***null*** or ***empty*** and between ***20***, ***250*** caracters
- [ ] Response standarization
* Actions should return [ProblemValidationDetails](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.validationproblemdetails?view=aspnetcore-6.0) for BadRequestException and [ProblemDetails](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails?view=aspnetcore-6.0) for InternalServerError.
- [ ] Using data builder and [Diverse](https://github.com/tpierrain/Diverse) library to generate randomly datas for customer tests cases.
