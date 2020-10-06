namespace Facturacion.Front.Data
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    public class DocumentoData
    {
        static Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        readonly string BD = Config.AppSettings.Settings["BaseDato"].Value.ToString();
        readonly string SERVER = Config.AppSettings.Settings["Servidor"].Value.ToString();
        readonly string Conexion;
        public DocumentoData()
        {
            Conexion = @"Data Source=" + SERVER + ";Initial Catalog=" + BD + ";User ID=infhotel; Password=4gust1n-fl0r14n;";
        }

    }
}
