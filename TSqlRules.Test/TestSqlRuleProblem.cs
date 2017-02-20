using Microsoft.SqlServer.Dac.CodeAnalysis;
using System;

namespace TSqlRules.Test
{
    public class TestSqlRuleProblem
    {
        public string RuleId { get; }
        public string Description { get; }
        public string ErrorMessageString { get; }
        public string Severity { get; }
        public string SourceName { get; }
        public int StartColumn { get; }
        public int StartLine { get; }

        public TestSqlRuleProblem(SqlRuleProblem sqlRuleProblem)
        {
            RuleId = sqlRuleProblem.RuleId;
            Description = sqlRuleProblem.Description;
            ErrorMessageString = sqlRuleProblem.ErrorMessageString;
            Severity = sqlRuleProblem.Severity.ToString();
            SourceName = sqlRuleProblem.SourceName;
            StartColumn = sqlRuleProblem.StartColumn;
            StartLine = sqlRuleProblem.StartLine;
        }

        public TestSqlRuleProblem(
            string ruleId, int startLine)
        {
            RuleId = ruleId;
            StartLine = startLine;
        }


        public TestSqlRuleProblem(
            string ruleId, string description, string errorMessageString, string severity,
            string sourceName, int startColumn, int startLine)
        {
            RuleId = ruleId;
            Description = description;
            ErrorMessageString = errorMessageString;
            Severity = severity;
            SourceName = sourceName;
            StartColumn = startColumn;
            StartLine = startLine;
        }

        public override bool Equals(Object obj)
        {
            TestSqlRuleProblem test = obj as TestSqlRuleProblem;

            if (
                test.RuleId.Equals(this.RuleId, StringComparison.OrdinalIgnoreCase) &&
                test.StartLine == this.StartLine
            )
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return string.Format("{0}:{1}", RuleId, StartLine).GetHashCode();
        }
    }
}
