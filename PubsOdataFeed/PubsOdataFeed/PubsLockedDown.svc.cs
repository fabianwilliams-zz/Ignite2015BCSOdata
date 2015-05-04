//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Reflection;
using PubsOdataFeed.FabianLockDown;

namespace PubsOdataFeed
{
    public class PubsLockedDown : DataService<SalesbyTitle>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("GetAllSale", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }


        [WebGet]
        public List<SalesbyTitle> GetAllSale()
        {
            pubsEntities context = new pubsEntities();

            try
            {

                List<SalesbyTitle> newSBT = new List<SalesbyTitle>();

                var currSales = from sa in context.sales
                                join ti in context.titles
                                on sa.title_id equals ti.title_id
                                select new { ti.title_id, ti.title1, ti.type, ti.price, ti.ytd_sales, sa.ord_date };

                foreach (var item in currSales)
                {
                    SalesbyTitle s = new SalesbyTitle();

                    s.title_id = item.title_id;
                    s.Title = item.title1;
                    s.BookPrice = item.price;
                    s.ytdSales = item.ytd_sales;
                    s.OrderDate = item.ord_date;
                    s.BookType = item.type;
                    newSBT.Add(s);

                }

                return newSBT;

            }
            catch (Exception ex)
            {

                throw new ApplicationException(string.Format("An error occurred: {0}", ex.Message));

            }

        }

    }
}
