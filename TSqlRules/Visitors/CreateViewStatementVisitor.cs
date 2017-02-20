using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSqlRules.Visitors
{
    internal class CreateViewStatementVisitor : TSqlFragmentVisitor
    {
        private IList<CreateViewStatement> _statements;

        public CreateViewStatementVisitor()
        {
            _statements = new List<CreateViewStatement>();
        }

        public override void Visit(CreateViewStatement node)
        {
            base.Visit(node);
            _statements.Add(node);
        }

        public IList<CreateViewStatement> Nodes
        {
            get
            {
                return _statements;
            }
        }
    }
}
