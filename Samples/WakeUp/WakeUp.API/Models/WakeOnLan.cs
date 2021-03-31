using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WakeUp.API.Models
{
    public class WakeOnLan
    {
        public static void WakeUp(string maquina)
        {
            var maquinaWake = GetMaquina(maquina);

            if (maquinaWake == null)
                throw new ArgumentException("Maquina não encontrada");

            Wake(maquinaWake);
        }

        private static void Wake(Maquina maquina)
        {
            var macAddress = PhysicalAddress.Parse(maquina.MacAddress);
            var ipAddress = IPAddress.Parse(maquina.IpAddress);

            var header = Enumerable.Repeat(byte.MaxValue, 6);
            var data = Enumerable.Repeat(macAddress.GetAddressBytes(), 16).SelectMany(mac => mac);

            var magicPacket = header.Concat(data).ToArray();

            using (var client = new UdpClient())
            {                
                client.Send(magicPacket, magicPacket.Length, new IPEndPoint(ipAddress, 9));
            }
        }

        private static Maquina GetMaquina(string nome)
        {
            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maquinas.csv")))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    var vMaquina = line.Split(';');
                    if (vMaquina.Any() && vMaquina[0].Equals(nome, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return new Maquina
                        {
                            Nome = vMaquina[0],
                            MacAddress = vMaquina[1],
                            IpAddress = vMaquina[2]
                        };
                    }
                }
            }

            return null;
        }
    }
}
