using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Configuration;

namespace Hex.Client
{
    public class WcfProxy<T>
    {
        public static T CreateChannel()
        {
            string serviceBaseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = String.Format(serviceBaseAddress, typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();

            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }
    }
}
