using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castle.ActiveRecord;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    internal class CastleSession
    {
        public static ISessionScope GetSession()
        {
            return HttpContext.Current.Items[Name] as SessionScope;
        }

        public static void CreateSession()
        {
            HttpContext.Current.Items.Add(Name, new SessionScope());            
        }

        private static string Name
        {
            get
            {
                return "ar.sessionscope";
            }
        }
    }
}
