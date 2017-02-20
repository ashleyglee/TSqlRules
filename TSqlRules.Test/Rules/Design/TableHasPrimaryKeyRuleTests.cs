using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TSqlRules.Test;

namespace TSqlRules.Rules.Design.Tests
{
    [TestClass()]
    public class TableHasPrimaryKeyRuleTests : TestRuleBase
    {
        [TestMethod]
        public void TableHasPrimaryKey_Should_Pass_When_NamedPK()
        {
            // Arrange
            string sql = @"
                CREATE TABLE TestTable
                (
                    [Column1] INT NOT NULL,
                    [Column2] VARCHAR(20) NOT NULL,
                    CONSTRAINT [PK_TestTable] PRIMARY KEY (Column1)
                );";
            AddSqlToModel(sql);

            // no exptected problems

            // Act
            // Assert
            var rulesToRun = new List<string>() { TableHasNamedPrimaryKeyRule.RuleId };
            RunSqlRuleTest(rulesToRun);
        }

        [TestMethod]
        public void TableHasPrimaryKey_Should_Fail_When_UnNamedPK()
        {
            // Arrange
            string sql = @"
                CREATE TABLE TestTable
                (
                    [Column1] INT NOT NULL PRIMARY KEY,
                    [Column2] VARCHAR(20) NOT NULL,
                );";
            AddSqlToModel(sql);

            _ExpectedProblems.Add(new TestSqlRuleProblem(TableHasNamedPrimaryKeyRule.RuleId, 2));

            // Act
            // Assert
            var rulesToRun = new List<string>() { TableHasNamedPrimaryKeyRule.RuleId };
            RunSqlRuleTest(rulesToRun);
        }

        [TestMethod]
        public void TableHasPrimaryKey_Should_Fail_When_MissingPK()
        {
            // Arrange
            string sql = @"
                CREATE TABLE TestTable
                (
                    [Column1] INT NOT NULL,
                    [Column2] VARCHAR(20) NOT NULL,
                );";
            AddSqlToModel(sql);

            _ExpectedProblems.Add(new TestSqlRuleProblem(TableHasNamedPrimaryKeyRule.RuleId, 2));

            // Act
            // Assert
            var rulesToRun = new List<string>() { TableHasNamedPrimaryKeyRule.RuleId };
            RunSqlRuleTest(rulesToRun);
        }

    }
}