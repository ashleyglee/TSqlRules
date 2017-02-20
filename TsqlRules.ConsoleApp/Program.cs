using System;

namespace TsqlRules.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            string Server = "";
            string Database = "";
            string OutFile = "";
            string DacPac = "";

            for (int i = 0; i < args.Length; i += 2)
            {
                switch (args[i])
                {
                    case "-S":
                        Server = args[i + 1];
                        break;
                    case "-d":
                        Database = args[i + 1];
                        break;
                    case "-o":
                        OutFile = args[i + 1];
                        break;
                    case "-f":
                        DacPac = args[i + 1];
                        break;
                }
            }

            DacPac = @"C:\Users\ashleyglee\Desktop\Development\SqlRulesDbProject\DbTest\DbTest\bin\Debug\DbTest.dacpac";
            OutFile = @"C:\Users\ashleyglee\Desktop\Development\SqlRulesDbProject\DbTest\DbTest\bin\Debug\out.txt";

            SqlAnalysis sqlAnalysis = new SqlAnalysis();
            if (DacPac.Equals(""))
            {
                sqlAnalysis.RunAnalysisAgainstDatabase(Server, Database, OutFile);
            }
            else
            {
                sqlAnalysis.RunDacpacAnalysis(DacPac, OutFile);
            }

            Console.WriteLine("End");
        }
    }
}
