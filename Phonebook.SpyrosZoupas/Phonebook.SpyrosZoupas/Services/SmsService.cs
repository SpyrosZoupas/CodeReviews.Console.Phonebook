using Microsoft.Extensions.Configuration;
using Phonebook.SpyrosZoupas.DAL.Models;
using Spectre.Console;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Phonebook.SpyrosZoupas.Services
{
    public class SmsService
    {
        public void SendMessage(Contact contact)
        {
            ConfigurationBuilder configurationBuilder = new();
            IConfiguration configuration = configurationBuilder.AddUserSecrets<SmsService>().Build();
            var senderPhoneNumber = configuration.GetSection("Sms")["from_phone_number"];
            var sid = configuration.GetSection("Sms")["account_sid"];
            var token = configuration.GetSection("Sms")["auth_token"];

            TwilioClient.Init(sid, token);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(contact.PhoneNumber));
            messageOptions.From = senderPhoneNumber;
            messageOptions.Body = AnsiConsole.Ask<string>("[cyan]Please type message content:[/]");

            var message = MessageResource.Create(messageOptions);

            AnsiConsole.WriteLine($"[purple]Message sent to {contact.PhoneNumber}. Message text:\n{message.Body}[/]");
        }
    }

}
