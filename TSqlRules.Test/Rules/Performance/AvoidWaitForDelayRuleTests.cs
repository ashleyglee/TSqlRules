using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TSqlRules.Test;

namespace TSqlRules.Rules.Performance.Tests
{
    [TestClass()]
    public class AvoidWaitForDelayRuleTests : TestRuleBase
    {
        [TestMethod]
        public void AvoidWaitForDelay_Should_Fail_When_StoredProc()
        {
            // Arrange
            string sql = @"
                CREATE PROCEDURE ProcWithWaitForDelay
                AS 
                BEGIN
                    WAITFOR DELAY '00:00:15'; -- Waits 15 seconds before executing. This should be flagged as a problem
                    RETURN SELECT * FROM dbo.Table1
                END";
            AddSqlToModel(sql);

            _ExpectedProblems.Add(new TestSqlRuleProblem(AvoidWaitForDelayRule.RuleId, 5));

            // Act
            // Assert
            var rulesToRun = new List<string>() { AvoidWaitForDelayRule.RuleId };
            RunSqlRuleTest(rulesToRun);
        }

        [TestMethod]
        public void AvoidWaitForDelay_Should_Pass_When_WaitForTime()
        {
            // Arrange
            string sql = @"
                CREATE PROCEDURE ProcWithWaitForDelay
                AS 
                BEGIN
                    WAITFOR TIME '00:00:15'; -- Executes at 15seconds after midnight. This shouldn't cause a problem
                    RETURN SELECT * FROM dbo.Table1
                END";
            AddSqlToModel(sql);

            // Act
            // Assert
            var rulesToRun = new List<string>() { AvoidWaitForDelayRule.RuleId };
            RunSqlRuleTest(rulesToRun);
        }

    }
}