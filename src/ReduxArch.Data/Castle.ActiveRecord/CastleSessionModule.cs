using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castle.ActiveRecord;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    public class CastleSessionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(context_EndRequest);
            CastleSession.CreateSession();
        }        

        public void Dispose()
        {            
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            try
            {
                var scope = CastleSession.GetSession();
                if (scope != null)
                {
                    scope.Dispose();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn("Error", "EndRequest: " + ex.Message, ex);
                throw ex;
            }
        }        
    }
}