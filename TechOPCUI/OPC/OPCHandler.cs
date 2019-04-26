using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitaniumAS.Opc.Client.Da;


namespace TechOPCUI
{
    //Abstract class for descriptopn of work with OPC server
    //For reading and writing to OPC
    abstract class OPCHandler
    {
        //internal string _serverDescriptor;       //e.g. "Schneider-Aut.OFS.2"
        internal string _parentNodeDescriptor;   //Parent OPC Node (e.g. "KNH_PO")        
        internal OpcDaServer _opcServer;          //Server OPC       

        internal OPCHandler(OpcDaServer opcServer, string parentNodeDescriptor)
        {
            //_serverDescriptor = serverDescriptor;
            _parentNodeDescriptor = parentNodeDescriptor;
            _opcServer = opcServer;

    }
    }
}
