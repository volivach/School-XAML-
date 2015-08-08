using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataService
{
    class Program
    {
        static void Main()
        {
            SchoolService service = new SchoolService();
            var users = service.GetUsers();
            using (var host = new ServiceHost(typeof(SchoolService)))
            {
                host.Open();

                Console.WriteLine("Host started");
                Console.Read();
            }
        }
    }
}
