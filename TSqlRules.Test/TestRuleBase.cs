using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace TSqlRules.Test
{
    public class TestRuleBase
    {
        private TSqlModel _Model;
        public List<TestSqlRuleProblem> _ExpectedProblems = new List<TestSqlRuleProblem>();
        private List<TestSqlRuleProblem> _ActualProblems = new List<TestSqlRuleProblem>();

        private List<string> _rulesToRun { get; set; }

        public TestRuleBase()
        {
            _Model = new TSqlModel(SqlServerVersion.Sql120, null);
        }

        public void AddFilesToModel(string fileName)
        {
            string FileContent = string.Empty;
            using (var reader = new StreamReader(fileName))
            {
                FileContent += reader.ReadToEnd();
            }
            _Model.AddObjects(FileContent);
        }

        public void AddSqlToModel(string sql)
        {
            _Model.AddObjects(sql);
        }

        public void LoadModelFromDacpac(string dacpacFile)
        {
            _Model = TSqlModel.LoadFromDacpac(
                dacpacFile,
                new ModelLoadOptions(DacSchemaModelStorageType.Memory, loadAsScriptBackedModel: true)
            );
        }

        public void RunSqlRuleTest()
        {
            CodeAnalysisService service = new CodeAnalysisServiceFactory().CreateAnalysisService(_Model.Version);
            CodeAnalysisResult result = service.Analyze(_Model);
            LoadRuleResults(result);

            // Assert
            CollectionAssert.AreEquivalent(_ExpectedProblems, _ActualProblems);
        }

        public void RunSqlRuleTest(List<string> rulesToRun)
        {
            _rulesToRun = rulesToRun;
            RunSqlRuleTest();
        }

        private void LoadRuleResults(CodeAnalysisResult result)
        {
            foreach (SqlRuleProblem problem in result.Problems)
            {
                if (_rulesToRun == null || _rulesToRun.Exists(x => x.Equals(problem.RuleId)))
                {
                    TestSqlRuleProblem actual = new TestSqlRuleProblem(problem.RuleId, problem.StartLine);
                    _ActualProblems.Add(actual);
                }
            }
        }
    }
}
