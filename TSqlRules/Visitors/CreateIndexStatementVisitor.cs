using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace TSqlRules.Visitors
{
    internal class CreateIndexStatementVisitor : TSqlConcreteFragmentVisitor
    {
        private IList<CreateIndexStatement> _statements;

        public CreateIndexStatementVisitor()
        {
            _statements = new List<CreateIndexStatement>();
        }

        public override void Visit(CreateIndexStatement node)
        {
            base.Visit(node);
            _statements.Add(node);
        }

        public IList<CreateIndexStatement> Nodes
        {
            get
            {
                return _statements;
            }
        }
    }
}
