using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitaniumAS.Opc.Client.Common;
using TitaniumAS.Opc.Client.Da;
using TitaniumAS.Opc.Client.Da.Browsing;


namespace TechOPCUI
{
    internal class OPCWriter : OPCHandler
    {               
        public OPCWriter(OpcDaServer opcServer, string parentNodeDescriptor) : base(opcServer, parentNodeDescriptor)
        {            
        }

        //Method writes data to "VAL_CALC" field of Capacity object and than - to OPC server        
        //internal void WriteMultiplyCapacityItems(List<Capacity> capacityList, OpcDaGroup dataGroup, object[] values)
        //{
        //    OpcDaItem[] items = dataGroup.Items.ToArray();
        //    HRESULT[] resultsWrite = dataGroup.Write(items, values);
        //}

        

    }
}
