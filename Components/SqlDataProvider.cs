using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Localization;

namespace GIBS.Modules.FlexMLS_TaxRates.Components
{
    public class SqlDataProvider : DataProvider
    {

        #region vars

        private const string providerType = "data";
        private const string moduleQualifier = "GIBS_";

        private ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);
        private string connectionString;
    //    private string FlexMLSConnectionString;
        private string providerPath;
        private string objectQualifier;
        private string databaseOwner;

        #endregion

        #region cstor

        /// <summary>
        /// cstor used to create the sqlProvider with required parameters from the configuration
        /// section of web.config file
        /// </summary>
        public SqlDataProvider()
        {



            Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];

            connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

      //    FlexMLSConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FlexMLS"].ConnectionString;

            if (connectionString == string.Empty)
                connectionString = provider.Attributes["connectionString"];

            providerPath = provider.Attributes["providerPath"];

            objectQualifier = provider.Attributes["objectQualifier"];
            if (objectQualifier != string.Empty && !objectQualifier.EndsWith("_"))
                objectQualifier += "_";

            databaseOwner = provider.Attributes["databaseOwner"];
            if (databaseOwner != string.Empty && !databaseOwner.EndsWith("."))
                databaseOwner += ".";
        }

        #endregion



        //public void LoadSettings()
        //{
        //    try
        //    {

        //        FlexMLSSettings settingsData = new FlexMLSSettings(this.mo);

        //        if (string.IsNullOrEmpty(settingsData.MlsDataBase))
        //        {
        //        //    vStartDate = DateTime.Now;
        //        }
        //        else
        //        {
        //          //  vStartDate = Convert.ToDateTime(settingsData.StartDate);
        //        }





        //    }
        //    catch (Exception ex)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, ex);
        //    }
        //}


        /// <summary>
        /// connectionString="Data Source=(local);Initial Catalog=DNN70;User ID=sa;Password=SugarCone"
        /// </summary>



        #region properties

        public string ConnectionString
        {
            get { return connectionString; }
        }


        public string ProviderPath
        {
            get { return providerPath; }
        }

        public string ObjectQualifier
        {
            get { return objectQualifier; }
        }


        public string DatabaseOwner
        {
            get { return databaseOwner; }
        }

        #endregion

        #region private methods

        private string GetFullyQualifiedName(string name)
        {
            return DatabaseOwner + ObjectQualifier + moduleQualifier + name;
        }

        private object GetNull(object field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region override methods


        public override IDataReader TaxRates_GetList(string town, string year)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("TaxRates_GetList"), town, year);
        }


      

        #endregion

    }
}