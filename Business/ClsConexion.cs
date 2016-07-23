using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Configuration;
using System.Data.OracleClient;

namespace ialbusacpr.Business
{
    class ClsConexion
    {
         

            public static String sConex = ConfigurationManager.ConnectionStrings["Maximus"].ConnectionString;
            //  public static String sConex = ConfigurationManager.ConnectionStrings["work"].ConnectionString;

            #region Codigo Adicional

            private Int32 iSucursal;

            public Int32 Sucursal
            {
                get { return iSucursal; }
                set { iSucursal = value; }
            }
            public static IPAddress GetPublicIP()
            {
                try
                {
                    WebClient wb = new WebClient();
                    string strIP = wb.DownloadString("http://ip1.dynupdate.no-ip.com:8245");
                    IPAddress ip;
                    if (IPAddress.TryParse(strIP, out ip))
                        return ip;
                    return IPAddress.None;
                }
                catch (Exception ex) { return IPAddress.None; }
            }

            public String LocalIPAddress()
            {
                IPHostEntry host;
                String localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                return localIP;// "192.168.1.20";
            }

            #endregion

        }


    }
 
