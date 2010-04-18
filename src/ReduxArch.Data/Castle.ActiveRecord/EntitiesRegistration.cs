using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    public delegate void PostCreateSchemaEventHandler(object sender, EventArgs e);
    public delegate void PreCreateSchemaEventHandler(object sender, EventArgs e);

    public class EntitiesRegistration
    {
        public event PostCreateSchemaEventHandler PostCreateSchema;
        public event PreCreateSchemaEventHandler PreCreateSchema;

        public void CreateSchema()
        {
            this.OnPreCreateSchema(EventArgs.Empty);
            ActiveRecordStarter.CreateSchema();
            this.OnPostCreateSchema(EventArgs.Empty);
        }

        public static void CreateSchemaStatic()
        {
            ActiveRecordStarter.CreateSchema();
        }

        public static void DropSchemaStatic()
        {
            ActiveRecordStarter.DropSchema();
        }

        protected virtual void OnPostCreateSchema(EventArgs e)
        {
            if (this.PostCreateSchema != null)
            {
                this.PostCreateSchema(this, e);
            }
        }

        protected virtual void OnPreCreateSchema(EventArgs e)
        {
            if (this.PreCreateSchema != null)
            {
                this.PreCreateSchema(this, e);
            }
        }

        public static void RegisterAllEntities(params Type[] types)
        {
            if (!ActiveRecordStarter.IsInitialized)
            {
                ActiveRecordStarter.Initialize(ActiveRecordSectionHandler.Instance, types);
            }
        }

    }
}
