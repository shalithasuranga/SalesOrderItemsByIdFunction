using SalesOrderItemsByIdFunction.serverless;
using System;
using System.Text;

namespace SalesOrderItemsByIdFunction
{
    class Program
    {
        private static string getStdin() {
            StringBuilder buffer = new StringBuilder();
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                buffer.AppendLine(s);
            }
            return buffer.ToString();
        }

        static void Main(string[] args) {
            string buffer = "2";
            ServerlessFunction f = new ServerlessFunction();

            string responseValue = f.Handle(buffer);

            if (responseValue != null)
            {
                Console.Write(responseValue);
            }
            Console.Read();
        }
    }
}
