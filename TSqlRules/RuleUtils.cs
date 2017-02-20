using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;

namespace TSqlRules
{
    internal static class RuleUtils
    {
        /// <summary>
        /// Gets a formatted element name with the default style <see cref="ElementNameStyle.EscapedFullyQualifiedName"/>
        /// </summary>
        public static string GetElementName(SqlRuleExecutionContext ruleExecutionContext, TSqlObject modelElement)
        {
            return GetElementName(modelElement, ruleExecutionContext, ElementNameStyle.EscapedFullyQualifiedName);
        }

        /// <summary>
        /// Gets a formatted element name
        /// </summary>
        public static string GetElementName(TSqlObject modelElement, SqlRuleExecutionContext ruleExecutionContext, ElementNameStyle style)
        {
            // Get the element name using the built in DisplayServices. This provides a number of useful formatting options to
            // make a name user-readable
            var displayServices = ruleExecutionContext.SchemaModel.DisplayServices;
            string elementName = displayServices.GetElementName(modelElement, style);
            return elementName;
        }

        public static bool IsInlineTableValuedFunction(TSqlObject modelElement)
        {
            return TableValuedFunction.TypeClass.Equals(modelElement.ObjectType)
                           && FunctionType.InlineTableValuedFunction ==
                modelElement.GetMetadata<FunctionType>(TableValuedFunction.FunctionType);
        }
    }
}
