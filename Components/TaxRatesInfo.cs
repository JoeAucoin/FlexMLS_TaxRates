using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace GIBS.Modules.FlexMLS_TaxRates.Components
{
    public class TaxRatesInfo
    {
        //private vars exposed thro the
        //properties


        // TAXRATES

        private double taxRate;
        private int _TaxYear = 0;
        private string _Town = "";
      

        /// <summary>
        /// empty cstor
        /// </summary>
        public TaxRatesInfo()
        {
        }


     



        #region properties

     
     
        // TAXRATES

        public double TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; }
        }
                
        public int TaxYear
        {
            get { return _TaxYear; }
            set { _TaxYear = value; }
        }

        public string Town
        {
            get { return _Town; }
            set { _Town = value; }
        }

  


        #endregion
    }
}