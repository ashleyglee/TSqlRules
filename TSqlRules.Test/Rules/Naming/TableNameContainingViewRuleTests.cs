using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TSqlRules.Test;

namespace TSqlRules.Rules.Naming.Tests
{
    [TestClass()]
    public class TableNameContainingViewRuleTests : TestRuleBase
    {
        [TestMethod]
        public void TableContainsView_Should_Pass_When_TableNameNotContainsView()
        {
            // Arrange
            string sql = @"
                CREATE TABLE [dbo].[MyTable]
                (
	                [Id] INT NOT NULL
                )
                ";
            AddSqlToModel(sql);

            // no expected problems

            // Act
            // Assert
            var rulesToRun = new List<string>() { TableNameContainingViewRule.RuleId };
            RunSqlRuleTest(rulesToRun);
        }

        [TestMethod]
        public void TableContainsView_Should_Fail_When_TableNameContainsView()
        {
            // Arrange
            string sql = @"
                CREATE TABLE [dbo].[MyTableView]
                (
	                [Id] INT NOT NULL
                )
                ";
            AddSqlToModel(sql);

            _ExpectedProblems.Add(new TestSqlRuleProblem(TableNameContainingViewRule.RuleId, 2));

            // Act
            // Assert
            var rulesToRun = new List<string>() { TableNameContainingViewRule.RuleId };
            RunSqlRuleTest(rulesToRun);
        }
    }
}