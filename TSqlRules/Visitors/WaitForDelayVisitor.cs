using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSqlRules.Visitors
{
    internal class WaitForDelayVisitor : TSqlConcreteFragmentVisitor
    {
        public IList<WaitForStatement> WaitForDelayStatements { get; private set; }

        public WaitForDelayVisitor()
        {
            WaitForDelayStatements = new List<WaitForStatement>();
        }

        public override void ExplicitVisit(WaitForStatement node)
        {
            // We are only interested in WAITFOR DELAY occurrences
            if (node.WaitForOption == WaitForOption.Delay)
            {
                WaitForDelayStatements.Add(node);
            }
        }

    }
}
