using System;
namespace PhoneBook.Crud2.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInforamation(string message);
        void LogError(Exception exception);
    }
}