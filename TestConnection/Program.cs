using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SchoolDataProvider.SchoolServiceClient("BasicHttpBinding_ISchoolService");
            int res =  client.GetSumm(5, 4);
            client.GetGroups();
            var users =  client.GetUsers();

            Console.Read();
        }
    }
}
