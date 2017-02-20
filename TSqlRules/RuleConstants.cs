namespace TSqlRules
{
    internal static class RuleConstants
    {
        /// <summary>
        /// The name of the resources file to use when looking up rule resources
        /// </summary>
        public const string ResourceBaseName = "TSqlRules.RuleResources";

        /// <summary>
        /// Lookup name inside the resources file for the select asterisk rule name
        /// </summary>
        public const string AvoidWaitForDelay_RuleName = "AvoidWaitForDelay_RuleName";
        public const string TableHasPrimaryKey_RuleName = "TableHasPrimaryKey_RuleName";
        public const string AlphaNumericTableRule_RuleName = "AlphaNumericTableRule_RuleName";
        public const string AlphaNumericColumnRule_RuleName = "AlphaNumericColumnRule_RuleName";
        public const string StoredProcedureNameRule_RuleName = "StoredProcedureNameRule_RuleName";
        public const string UserFunctionNameRule_RuleName = "UserFunctionNameRule_RuleName";
        public const string ViewNameRule_RuleName = "ViewNameRule_RuleName";
        public const string TriggerNameRule_RuleName = "TriggerNameRule_RuleName";
        public const string IndexSecondaryFileGroup_RuleName = "IndexSecondaryFileGroup_RuleName";
        public const string IndexArchiveFileGroup_RuleName = "IndexArchiveFileGroup_RuleName";
        //public const string _RuleName = "_RuleName";

        /// <summary>
        /// Lookup ID inside the resources file for the select asterisk description
        /// </summary>
        public const string AvoidWaitForDelay_ProblemDescription = "AvoidWaitForDelay_ProblemDescription";
        public const string TableHasPrimaryKey_ProblemDescription = "TableHasPrimaryKey_ProblemDescription";
        public const string AlphaNumericTableRule_ProblemDescription = "AlphaNumericTableRule_ProblemDescription";
        public const string AlphaNumericColumnRule_ProblemDescription = "AlphaNumericColumnRule_ProblemDescription";
        public const string StoredProcedureNameRule_ProblemDescription = "StoredProcedureNameRule_ProblemDescription";
        public const string UserFunctionNameRule_ProblemDescription = "UserFunctionNameRule_ProblemDescription";
        public const string ViewNameRule_ProblemDescription = "ViewNameRule_ProblemDescription";
        public const string TriggerNameRule_ProblemDescription = "TriggerNameRule_ProblemDescription";
        public const string IndexSecondaryFileGroup_ProblemDescription = "IndexSecondaryFileGroup_ProblemDescription";
        public const string IndexArchiveFileGroup_ProblemDescription = "IndexArchiveFileGroup_ProblemDescription";
        //public const string _ProblemDescription = "_ProblemDescription";

        /// <summary>
        /// Categories (should not be localized)
        /// </summary>
        public const string CategoryDesign = "Design";
        public const string CategoryPerformance = "Performance";
        public const string CategoryNaming = "Naming";
    }
}
