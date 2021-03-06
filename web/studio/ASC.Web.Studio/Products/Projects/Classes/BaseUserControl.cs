/* 
 * 
 * (c) Copyright Ascensio System Limited 2010-2014
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 * 
 * http://www.gnu.org/licenses/agpl.html 
 * 
 */

using System.Runtime.Remoting.Messaging;
using System.Web.UI;
using ASC.Common.Security;
using System.Web.Configuration;

namespace ASC.Web.Projects
{
    public abstract class BaseUserControl : UserControl
    {
        protected BaseUserControl()
        {
            if (CallContext.GetData("CURRENT_ACCOUNT") == null && ASC.Core.SecurityContext.IsAuthenticated)
                CallContext.SetData("CURRENT_ACCOUNT", ASC.Core.SecurityContext.CurrentAccount.ID);
        }
        
        public bool IsOldFile { get { return WebConfigurationManager.AppSettings["projects.oldfiles"] == "true"; } }

        public new BasePage Page
        {
            get { return base.Page as BasePage; }
        }
    }
}