﻿using System;
namespace PhoneBook.Crud2.Brokers
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogInforamation(string message) =>
            Console.WriteLine(message);
        public void LogError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
    }
}
