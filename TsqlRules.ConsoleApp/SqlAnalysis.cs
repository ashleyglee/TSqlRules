using System;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;

namespace TsqlRules.ConsoleApp
{
    internal class SqlAnalysis
    {
        private void RunAnalysis(TSqlModel model, string OutFile)
        {
            CodeAnalysisService service = new CodeAnalysisServiceFactory().CreateAnalysisService(model.Version);
            service.ResultsFile = OutFile;

            CodeAnalysisResult result = service.Analyze(model);

            Console.WriteLine("Code Analysis with output file {0} complete, analysis succeeded? {1}",
                OutFile, result.AnalysisSucceeded);
        }

        public void RunDacpacAnalysis(string packagePath, string OutFile)
        {
            using (TSqlModel model = TSqlModel.LoadFromDacpac(packagePath,
                new ModelLoadOptions(DacSchemaModelStorageType.Memory, loadAsScriptBackedModel: true)))
            {
                RunAnalysis(model, OutFile);
            }
        }

        public void RunAnalysisAgainstDatabase(string Server, string Database, string OutFile)
        {
            string extractedPackagePath = System.IO.Path.GetTempPath() + System.IO.Path.GetRandomFileName() + ".dacpac";

            DacServices services = new DacServices("Server=" + Server + ";Integrated Security=true;");
            services.Extract(extractedPackagePath, Database, "AppName", new Version(1, 0));

            RunDacpacAnalysis(extractedPackagePath, OutFile);
        }
    }
}