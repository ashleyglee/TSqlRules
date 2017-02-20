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
        RuleConstants.ViewNameRule_RuleName,
        RuleConstants.ViewNameRule_ProblemDescription,
        Category = RuleConstants.CategoryNaming,
        RuleScope = SqlRuleScope.Element),]
    public class ViewNameRule : SqlCodeAnalysisRule
    {
        public const string RuleId = "TSQL.Naming.SRN0003";

        public ViewNameRule()
        {
            // Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                View.TypeClass
            };
        }

        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            IList<SqlRuleProblem> problems = new List<SqlRuleProblem>();

            TSqlFragment fragment = ruleExecutionContext.ScriptFragment;
            RuleDescriptor ruleDescriptor = ruleExecutionContext.RuleDescriptor;

            TSqlObject modelElement = ruleExecutionContext.ModelElement;
            string elementName = RuleUtils.GetElementName(ruleExecutionContext, modelElement);

            CreateViewStatementVisitor visitor = new CreateViewStatementVisitor();
            fragment.Accept(visitor);

            // Begin with alpha character. Only contain alphanumeric.
            Regex regex = new Regex(@"^v[A-Z][a-zA-Z0-9]*$");

            return (
                from view in visitor.Nodes
                where !regex.IsMatch(view.SchemaObjectName.BaseIdentifier.Value)
                select new SqlRuleProblem(String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName), modelElement)
            ).ToList();
        }
    }
}
