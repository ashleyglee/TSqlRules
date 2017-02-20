using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSqlRules.Visitors
{
    internal class CreateTableStatementVisitor : TSqlConcreteFragmentVisitor
    {
        private IList<CreateTableStatement> _statements;

        public CreateTableStatementVisitor()
        {
            _statements = new List<CreateTableStatement>();
        }

        public override void Visit(CreateTableStatement node)
        {
            base.Visit(node);
            _statements.Add(node);
        }

        public IList<CreateTableStatement> Nodes
        {
            get
            {
                return _statements;
            }
        }
    }
}
