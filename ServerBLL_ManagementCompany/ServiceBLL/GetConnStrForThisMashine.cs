using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBLL_ManagementCompany.ServiceBLL
{
    public static class GetConnStrForThisMashine
    {
        private const string connStrServer = "DESKTOP-P136AIJ";
        private const string connStrClient = @"DMITRIY-ПК";
        private static string connStr = String.Empty;
        public static string GetConnStr()
        {
            switch (Environment.MachineName)
            {
                case (connStrServer):
                    connStr = "CompanyContext";
                    break;
                case (connStrClient):
                    connStr = "CompanyContextClient";
                    break;
            }

            return connStr;
        }
    }
}
