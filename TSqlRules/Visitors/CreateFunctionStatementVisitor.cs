using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSqlRules.Visitors
{
    internal class CreateFunctionStatementVisitor : TSqlFragmentVisitor
    {
        private IList<CreateFunctionStatement> _statements;

        public CreateFunctionStatementVisitor()
        {
            _statements = new List<CreateFunctionStatement>();
        }

        public override void Visit(CreateFunctionStatement node)
        {
            base.Visit(node);
            _statements.Add(node);
        }

        public IList<CreateFunctionStatement> Nodes
        {
            get
            {
                return _statements;
            }
        }
    }
}
