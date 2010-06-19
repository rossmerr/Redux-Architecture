using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    // needs some work to get this going
    sealed class IndexRegistration
    {
        public static void RegisterAllIndexes(string rootIndexDirectory, params Type[] types)
        {
            if (ActiveRecordStarter.IsInitialized)
            {
                foreach (Type t in types)
                {                   
                    //IndexHelper.CreateIndex <t> (rootIndexDirectory);
                }
            }
        }
    }
}
