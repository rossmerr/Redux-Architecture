using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

//  http://www.lostechies.com/blogs/rssvihla/archive/2009/06/03/castle-activerecord-and-registering-classes-at-runtime.aspx

namespace ReduxArch.Data.Castle.ActiveRecord
{
    public class RegisterTypes
    {
        public static void Register(params Type[] types)
        {
            var holder = ActiveRecordMediator.GetSessionFactoryHolder();
            foreach (var type in types)
            {
                ActiveRecordStarter.RegisterTypes(type);                
            }
        }

        public static void CreateSchema()
        {
            ActiveRecordStarter.CreateSchema();
        }

        public static void DropSchema()
        {
            ActiveRecordStarter.DropSchema();
        }
    }
}
