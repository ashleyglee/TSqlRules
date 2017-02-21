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
        RuleConstants.SRN0001_RuleName,
        RuleConstants.SRN0001_ProblemDescription,
        Category = RuleConstants.CategoryNaming,
        RuleScope = SqlRuleScope.Element),]
    public class AlphaNumericTableRule : SqlCodeAnalysisRule
    {
        public const string RuleId = "TSQL.Naming.SRN0001";

        public AlphaNumericTableRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                Table.TypeClass
            };
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            TSqlFragment fragment = ruleExecutionContext.ScriptFragment;
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            TSqlObject modelElement = ruleExecutionContext.ModelElement;
            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            CreateTableStatementVisitor visitor = new CreateTableStatementVisitor();
            fragment.Accept(visitor);

            // Begin with alpha character
            Regex regex = new Regex(@"^[A-Z][a-zA-Z0-9]*$");

            return (
                from table in visitor.Nodes
                where !regex.IsMatch(table.SchemaObjectName.BaseIdentifier.Value)
                select new SqlRuleProblem(String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, table.SchemaObjectName.BaseIdentifier.Value), modelElement)
            ).ToList();
        }
    }
}
