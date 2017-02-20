using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using TSqlRules.Visitors;

namespace TSqlRules.Rules.Naming
{
    [LocalizedExportCodeAnalysisRule(
        RuleId,
        RuleConstants.ResourceBaseName,
        RuleConstants.AlphaNumericColumnRule_RuleName,
        RuleConstants.AlphaNumericColumnRule_ProblemDescription,
        Category = RuleConstants.CategoryNaming,
        RuleScope = SqlRuleScope.Element),]
    public class AlphaNumericColumnRule : SqlCodeAnalysisRule
    {
        public const string RuleId = "TSQL.Naming.SRN0002";

        public AlphaNumericColumnRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                Table.TypeClass
            };
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            IList<SqlRuleProblem> problems = new List<SqlRuleProblem>();

            TSqlFragment fragment = ruleExecutionContext.ScriptFragment;
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            TSqlObject modelElement = ruleExecutionContext.ModelElement;
            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            CreateTableStatementVisitor visitor = new CreateTableStatementVisitor();
            fragment.Accept(visitor);

            // Begin with alpha character. Only contain alphanumeric.
            Regex regex = new Regex(@"^[A-Z][a-zA-Z0-9]*$");

            bool allowUnderscore = true;
            if (allowUnderscore)
            {
                regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9_]*$");
            }

            return (
                from table in visitor.Nodes
                where table.Definition.ColumnDefinitions.Any(x => !regex.IsMatch(x.ColumnIdentifier.Value))
                select new SqlRuleProblem(String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName), modelElement)
            ).ToList();
        }
    }
}
