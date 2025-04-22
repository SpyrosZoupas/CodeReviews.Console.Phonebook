using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Phonebook.SpyrosZoupas.Util
{
    public class Validation
    {
        public string GetEmailInput(string message) =>
            AnsiConsole.Prompt(
                new TextPrompt<string>($"{message} (please use format email@domain.tld):")
                .Validate((s) =>
                {
                    var emailAddressAttribute = new EmailAddressAttribute();
                    return Regex.IsMatch(s, @"^\w+([-+.']\w+)*@(\[*\w+)([-.]\w+)*\.\w+([-.]\w+\])*$")
                        ? Spectre.Console.ValidationResult.Success()
                        : Spectre.Console.ValidationResult.Error("[red]Invalid email format. Please enter an email in the format of email@domain.tld.[/]");

                }));

        public string GetPhoneNumberInput(string message) =>
            AnsiConsole.Prompt(
                new TextPrompt<string>($"{message} (please enter full phone number including country code):")
                .Validate((s) =>
                {
                    var phoneNumberAttribute = new PhoneAttribute();
                    return Regex.Match(s, @"^(\+[0-9]{12})$").Success
                        ? Spectre.Console.ValidationResult.Success()
                        : Spectre.Console.ValidationResult.Error("[red]Invalid phone number format. Example of correct phone number: +441234567899[/]");

                }));
    }
}
