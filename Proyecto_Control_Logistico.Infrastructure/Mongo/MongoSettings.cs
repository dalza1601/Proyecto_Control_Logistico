using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
