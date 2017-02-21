using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TSqlRules.Visitors;

namespace TSqlRules.Rules.Design
{
    [LocalizedExportCodeAnalysisRule(
        RuleId,
        RuleConstants.ResourceBaseName,
        RuleConstants.SRD0001_RuleName,
        RuleConstants.SRD0001_ProblemDescription,
        Category = RuleConstants.CategoryDesign,
        RuleScope = SqlRuleScope.Element),]
    public class TableHasNamedPrimaryKeyRule : SqlCodeAnalysisRule
    {
        /// <summary>
        /// The Rule ID should resemble a fully-qualified class name. In the Visual Studio UI
        /// rules are grouped by "Namespace + Category", and each rule is shown using "Short ID: DisplayName".
        /// For this rule, that means the grouping will be "Public.Dac.Samples.Performance", with the rule
        /// shown as "SR1004: Avoid using WaitFor Delay statements in stored procedures, functions and triggers."
        /// </summary>
        public const string RuleId = "TSQL.Design.SRD0001";

        public TableHasNamedPrimaryKeyRule()
        {
            // This rule supports Tables. Only those objects will be passed to the Analyze method
            SupportedElementTypes = new[]
            {
                ModelSchema.Table,
                ModelSchema.Procedure
            };
        }

        /// <summary>
        /// Ensure Primary Key included for each table
        /// is created
        /// </summary>
        /// <param name="ruleExecutionContext"></param>
        /// <returns></returns>
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
                let isTemp = table.SchemaObjectName.BaseIdentifier.Value.StartsWith("#") || table.SchemaObjectName.BaseIdentifier.Value.StartsWith("@")
                where !isTemp && !table.Definition.TableConstraints.OfType<UniqueConstraintDefinition>().Any(x => x.IsPrimaryKey)
                select new SqlRuleProblem(String.Format(CultureInfo.CurrentCulture, ruleDescriptor.DisplayDescription, elementName), modelElement)
            ).ToList();

            //List<SqlRuleProblem> problems = new List<SqlRuleProblem>();
            //TSqlObject sqlObj = ruleExecutionContext.ModelElement;
            //if (sqlObj != null)
            //{
            //    if (sqlObj.Name != null && sqlObj.Name.Parts != null && sqlObj.Name.Parts.Any(x => x.StartsWith("#") || x.StartsWith("@")))
            //    {
            //        return problems;
            //    }

            //    var child = sqlObj.GetChildren(DacQueryScopes.All).FirstOrDefault(x => x.ObjectType == PrimaryKeyConstraint.TypeClass);
            //    if (child == null)
            //    {
            //        string msg = string.Format(Message, RuleUtils.GetElementName(ruleExecutionContext, sqlObj));
            //        problems.Add(new SqlRuleProblem(msg, sqlObj));
            //    }
            //}

            //return problems;
        }
    }
}
