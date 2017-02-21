using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TSqlRules.Visitors;

namespace TSqlRules.Rules.Naming
{
    [LocalizedExportCodeAnalysisRule(
        RuleId,
        RuleConstants.ResourceBaseName,
        RuleConstants.SRN0007_RuleName,
        RuleConstants.SRN0007_ProblemDescription,
        Category = RuleConstants.CategoryNaming,
        RuleScope = SqlRuleScope.Element),]
    public class TableNameContainingViewRule : SqlCodeAnalysisRule
    {
        public const string RuleId = "TSQL.Naming.SRN0007";

        public TableNameContainingViewRule()
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

            return (
                from table in visitor.Nodes
                where table.SchemaObjectName.BaseIdentifier.Value.ToUpper().Contains("VIEW")
                select new SqlRuleProblem(String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName), modelElement)
            ).ToList();
        }
    }
}
