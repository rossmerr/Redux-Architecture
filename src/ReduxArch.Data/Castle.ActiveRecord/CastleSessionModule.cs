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
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;

        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            CastleSession.CreateSession();
        }        

        private void context_EndRequest(object sender, EventArgs e)
        {
            try
            {
                CastleSession.DisposeSession();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn("Error", "EndRequest: " + ex.Message, ex);
                throw ex;
            }
        }

        public void Dispose()
        {
        }
    }
}