using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.Modules.FlexMLS_TaxRates.Components
{
    public class Controller 
    {

        #region public method


        //public abstract IDataReader FlexMLS_Search(string city, string propertyType);






        public List<TaxRatesInfo> TaxRates_GetList(string town, string year)
        {
            return CBO.FillCollection<TaxRatesInfo>(DataProvider.Instance().TaxRates_GetList(town, year));
        }

      




        #endregion

        #region ISearchable Members

        /// <summary>
        /// Implements the search interface required to allow DNN to index/search the content of your
        /// module
        /// </summary>
        /// <param name="modInfo"></param>
        /// <returns></returns>
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
        //{
        //    SearchItemInfoCollection searchItems = new SearchItemInfoCollection();

        //    List<FlexMLSInfo> infos = GetFlexMLSs(modInfo.ModuleID);

        //    foreach (FlexMLSInfo info in infos)
        //    {
        //        SearchItemInfo searchInfo = new SearchItemInfo(modInfo.ModuleTitle, info.Content, info.CreatedByUser, info.CreatedDate,
        //                                            modInfo.ModuleID, info.ItemId.ToString(), info.Content, "Item=" + info.ItemId.ToString());
        //        searchItems.Add(searchInfo);
        //    }

        //    return searchItems;
        //}

        #endregion

        //#region IPortable Members

        ///// <summary>
        ///// Exports a module to xml
        ///// </summary>
        ///// <param name="ModuleID"></param>
        ///// <returns></returns>
        //public string ExportModule(int moduleID)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    List<FlexMLSInfo> infos = GetFlexMLSs(moduleID);

        //    if (infos.Count > 0)
        //    {
        //        sb.Append("<FlexMLSs>");
        //        foreach (FlexMLSInfo info in infos)
        //        {
        //            sb.Append("<FlexMLS>");
        //            sb.Append("<content>");
        //            sb.Append(XmlUtils.XMLEncode(info.Content));
        //            sb.Append("</content>");
        //            sb.Append("</FlexMLS>");
        //        }
        //        sb.Append("</FlexMLSs>");
        //    }

        //    return sb.ToString();
        //}

        ///// <summary>
        ///// imports a module from an xml file
        ///// </summary>
        ///// <param name="ModuleID"></param>
        ///// <param name="Content"></param>
        ///// <param name="Version"></param>
        ///// <param name="UserID"></param>
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //    XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "FlexMLSs");

        //    foreach (XmlNode info in infos.SelectNodes("FlexMLS"))
        //    {
        //        FlexMLSInfo FlexMLSInfo = new FlexMLSInfo();
        //        FlexMLSInfo.ModuleId = ModuleID;
        //        FlexMLSInfo.Content = info.SelectSingleNode("content").InnerText;
        //        FlexMLSInfo.CreatedByUser = UserID;

        //        //    AddFlexMLS(FlexMLSInfo);
        //    }
        //}

        //#endregion
    }

}