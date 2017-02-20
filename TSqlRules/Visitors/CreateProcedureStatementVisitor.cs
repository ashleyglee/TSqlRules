using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TSqlRules.Visitors
{
    internal class CreateProcedureStatementVisitor : TSqlFragmentVisitor
    {
        private IList<CreateProcedureStatement> _statements;

        public CreateProcedureStatementVisitor()
        {
            _statements = new List<CreateProcedureStatement>();
        }

        public override void Visit(CreateProcedureStatement node)
        {
            base.Visit(node);
            _statements.Add(node);
        }

        public IList<CreateProcedureStatement> Nodes
        {
            get
            {
                return _statements;
            }
        }
    }
}
