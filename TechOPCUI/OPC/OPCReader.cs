using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using TitaniumAS.Opc.Client.Common;
using TitaniumAS.Opc.Client.Da;
using TitaniumAS.Opc.Client.Da.Browsing;

namespace TechOPCUI
{
    //Class for reading data from OPC and packing it to value objects (CAPACITY, DENSITy, CONTENT, etc.)
    internal class OPCReader : OPCHandler
    { 
        internal OPCReader(OpcDaServer opcServer, string parentNodeDescriptor) : base(opcServer, parentNodeDescriptor)
        {   
        }

        //Reads Data from OPC. Fills the Nodelist from PLC
        internal IEnumerable<OpcDaBrowseElement> ReadDataToNodeList(string _subStringFromTagName) //e.g. "_CAP - for Capacity tag"
        {
            //Читаем список переменных из OCP-сервера. Фильтруем переменные-ветви и отбираем те, в именах которых содержится _subStringFromTagName (например "_CAP")
            var opcDaElementFilter = new OpcDaElementFilter() { ElementType = OpcDaBrowseFilter.Branches };
            var browser = new OpcDaBrowserAuto(_opcServer);

            var items = from s in browser.GetElements(_parentNodeDescriptor, opcDaElementFilter)
                        where s.Name.Contains(_subStringFromTagName)
                        select s;
            return items;
        }
        

        

    }
}
