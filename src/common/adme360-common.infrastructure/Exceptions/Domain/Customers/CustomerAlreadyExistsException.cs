using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Customers
{
  public class CustomerAlreadyExistsException : Exception
  {
    public string Vat { get; }
    public string BrokenRules { get; }

    public CustomerAlreadyExistsException(string vat, string brokenRules)
    {
      Vat = vat;
      BrokenRules = brokenRules;
    }

    public override string Message => $" Customer with VAT:{Vat} already Exists!\n Additional info:{BrokenRules}";
  }
}
