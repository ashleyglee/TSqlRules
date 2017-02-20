using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSqlRules.Visitors
{
    internal class CreateTriggerStatementVisitor : TSqlFragmentVisitor
    {
        private IList<CreateTriggerStatement> _statements;

        public CreateTriggerStatementVisitor()
        {
            _statements = new List<CreateTriggerStatement>();
        }

        public override void Visit(CreateTriggerStatement node)
        {
            base.Visit(node);
            _statements.Add(node);
        }

        public IList<CreateTriggerStatement> Nodes
        {
            get
            {
                return _statements;
            }
        }
    }
}
