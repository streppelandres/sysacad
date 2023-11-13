using Microsoft.EntityFrameworkCore;
using Persistence;
using Presentation.Login;
using System.Configuration;

namespace Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}