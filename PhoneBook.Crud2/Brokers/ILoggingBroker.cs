using System;
namespace PhoneBook.Crud2.Brokers
{
    internal interface ILoggingBroker
    {
        void LogInforamation(string message);
        void LogError(Exception exception);
    }
}
