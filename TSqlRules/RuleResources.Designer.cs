﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TSqlRules {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RuleResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RuleResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TSqlRules.RuleResources", typeof(RuleResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-alphanumeric Column name was found in {0}..
        /// </summary>
        internal static string AlphaNumericColumnRule_ProblemDescription {
            get {
                return ResourceManager.GetString("AlphaNumericColumnRule_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Column Name does not meet naming convention.
        /// </summary>
        internal static string AlphaNumericColumnRule_RuleName {
            get {
                return ResourceManager.GetString("AlphaNumericColumnRule_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-alphanumeric Table name was found in {0}..
        /// </summary>
        internal static string AlphaNumericTableRule_ProblemDescription {
            get {
                return ResourceManager.GetString("AlphaNumericTableRule_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table does not meet naming convention.
        /// </summary>
        internal static string AlphaNumericTableRule_RuleName {
            get {
                return ResourceManager.GetString("AlphaNumericTableRule_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WAITFOR DELAY statement was found in {0}..
        /// </summary>
        internal static string AvoidWaitForDelay_ProblemDescription {
            get {
                return ResourceManager.GetString("AvoidWaitForDelay_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid using WaitFor Delay statements in stored procedures, functions and triggers..
        /// </summary>
        internal static string AvoidWaitForDelay_RuleName {
            get {
                return ResourceManager.GetString("AvoidWaitForDelay_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t create ResourceManager for {0} from {1}..
        /// </summary>
        internal static string CannotCreateResourceManager {
            get {
                return ResourceManager.GetString("CannotCreateResourceManager", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-alphanumeric Stored Procedure name was found in {0}..
        /// </summary>
        internal static string StoredProcedureNameRule_ProblemDescription {
            get {
                return ResourceManager.GetString("StoredProcedureNameRule_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stored Procedure does not meet naming guidelines.
        /// </summary>
        internal static string StoredProcedureNameRule_RuleName {
            get {
                return ResourceManager.GetString("StoredProcedureNameRule_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Primary Key was found in {0}..
        /// </summary>
        internal static string TableHasPrimaryKey_ProblemDescription {
            get {
                return ResourceManager.GetString("TableHasPrimaryKey_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table does not have Primary Key.
        /// </summary>
        internal static string TableHasPrimaryKey_RuleName {
            get {
                return ResourceManager.GetString("TableHasPrimaryKey_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-alphanumeric Trigger name was found in {0}..
        /// </summary>
        internal static string TriggerNameRule_ProblemDescription {
            get {
                return ResourceManager.GetString("TriggerNameRule_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Trigger does not meet naming convention.
        /// </summary>
        internal static string TriggerNameRule_RuleName {
            get {
                return ResourceManager.GetString("TriggerNameRule_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-alphanumeric User Function name was found in {0}..
        /// </summary>
        internal static string UserFunctionNameRule_ProblemDescription {
            get {
                return ResourceManager.GetString("UserFunctionNameRule_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User Function does not meet naming convention.
        /// </summary>
        internal static string UserFunctionNameRule_RuleName {
            get {
                return ResourceManager.GetString("UserFunctionNameRule_RuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-alphanumeric View name was found in {0}..
        /// </summary>
        internal static string ViewNameRule_ProblemDescription {
            get {
                return ResourceManager.GetString("ViewNameRule_ProblemDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to View does not meet naming convention.
        /// </summary>
        internal static string ViewNameRule_RuleName {
            get {
                return ResourceManager.GetString("ViewNameRule_RuleName", resourceCulture);
            }
        }
    }
}