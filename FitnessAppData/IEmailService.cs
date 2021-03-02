using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
    }
}
