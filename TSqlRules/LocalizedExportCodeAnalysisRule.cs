using Microsoft.SqlServer.Dac.CodeAnalysis;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace TSqlRules
{
    internal class LocalizedExportCodeAnalysisRuleAttribute : ExportCodeAnalysisRuleAttribute
    {
        private readonly string _resourceBaseName;
        private readonly string _displayNameResourceId;
        private readonly string _descriptionResourceId;

        private ResourceManager _resourceManager;
        private string _displayName;
        private string _descriptionValue;

        /// <summary>
        /// Creates the attribute, with the specified rule ID, the fully qualified
        /// name of the resource file that will be used for looking up display name
        /// and description, and the Ids of those resources inside the resource file.
        /// </summary>
        public LocalizedExportCodeAnalysisRuleAttribute(
            string id,
            string resourceBaseName,
            string displayNameResourceId,
            string descriptionResourceId)
            : base(id, null)
        {
            _resourceBaseName = resourceBaseName;
            _displayNameResourceId = displayNameResourceId;
            _descriptionResourceId = descriptionResourceId;
        }

        /// <summary>
        /// Rules in a different assembly would need to overwrite this
        /// </summary>
        /// <returns></returns>
        protected virtual Assembly GetAssembly()
        {
            return GetType().Assembly;
        }

        private void EnsureResourceManagerInitialized()
        {
            var resourceAssembly = GetAssembly();

            try
            {
                _resourceManager = new ResourceManager(_resourceBaseName, resourceAssembly);
            }
            catch (Exception ex)
            {
                var msg = String.Format(CultureInfo.CurrentCulture, RuleResources.CannotCreateResourceManager, _resourceBaseName, resourceAssembly);
                throw new RuleException(msg, ex);
            }
        }

        private string GetResourceString(string resourceId)
        {
            EnsureResourceManagerInitialized();
            return _resourceManager.GetString(resourceId, CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Overrides the standard DisplayName and looks up its value inside a resources file
        /// </summary>
        public override string DisplayName
        {
            get
            {
                if (_displayName == null)
                {
                    _displayName = GetResourceString(_displayNameResourceId);
                }
                return _displayName;
            }
        }

        /// <summary>
        /// Overrides the standard Description and looks up its value inside a resources file
        /// </summary>
        public override string Description
        {
            get
            {
                if (_descriptionValue == null)
                {
                    _descriptionValue = GetResourceString(_descriptionResourceId);
                }
                return _descriptionValue;
            }
        }
    }
}
