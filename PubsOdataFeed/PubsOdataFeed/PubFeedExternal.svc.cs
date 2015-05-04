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
using PubsOdataFeed.FabianLockDown;
using System.Reflection;

namespace PubsOdataFeed
{
    public class PubFeedExternal : DataService<pubsEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("employees", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("authors", EntitySetRights.AllWrite);
            config.SetEntitySetAccessRule("titles", EntitySetRights.AllRead);
            //config.SetEntitySetAccessRule("sales", EntitySetRights.None);
            //config.SetEntitySetAccessRule("*", EntitySetRights.None);
            config.SetEntitySetAccessRule("sales", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        [WebGet]
        public IQueryable<sale> GetSale()
        {
            return CurrentDataSource.sales.AsQueryable();
        }


    }
}
