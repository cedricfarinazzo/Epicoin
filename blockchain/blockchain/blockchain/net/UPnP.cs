using System;
using Mono.Nat;

namespace blockchain
{
    public class UPnP
    {
        public UPnP()
        {
            NatUtility.DeviceFound += DeviceFound;
            NatUtility.DeviceLost += DeviceLost;
            NatUtility.StartDiscovery();
        }
        
        private void DeviceFound(object sender, DeviceEventArgs args)
        {
            INatDevice device = device = args.Device;
            device.CreatePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.getport, Epicoin.getport));
            device.CreatePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.mineport, Epicoin.mineport));
            device.CreatePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.peerport, Epicoin.peerport));
            device.CreatePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.transport, Epicoin.transport));
 
            foreach (Mapping portMap in device.GetAllMappings())
            {
                Console.WriteLine(portMap.ToString());
            }
 
            Console.WriteLine(device.GetExternalIP().ToString());
        }
 
        private void DeviceLost(object sender, DeviceEventArgs args)
        {
            INatDevice device = args.Device;           
            device.DeletePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.getport, Epicoin.getport));
            device.DeletePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.mineport, Epicoin.mineport));
            device.DeletePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.peerport, Epicoin.peerport));
            device.DeletePortMap(new Mapping(Mono.Nat.Protocol.Tcp, Epicoin.transport, Epicoin.transport));
        }
    }
}