using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitaniumAS.Opc.Client.Da;
using TitaniumAS.Opc.Client.Da.Browsing;

namespace TechOPCUI.Characteristic
{
    abstract class ItemsCreator<T>
    {
        #region fields
        protected OPCReader opcReader;
        protected IEnumerable<OpcDaBrowseElement> opcTagNamesCollection;      // коллекция названий тегов, читаемых из OPC-сервера        
        protected string subStringTagName;                                    // признак, по которому вычитываются данные из OCP ("_CAP", "_DENS", etc.)      
        internal OpcDaGroup dataGroupRead;                                    // группа переменных для чтения из OPC сервера
        internal OpcDaGroup dataGroupWrite;                                   // группа переменных для записи в OPC-сервер
        internal object[] valuesForWriting;
        #endregion

        #region constructor
        protected ItemsCreator(OPCReader opcReader)
        {
            this.opcReader = opcReader;
            opcTagNamesCollection = new List<OpcDaBrowseElement>();
        }
        #endregion

        #region methods
        //Создание групп для чтения данных из OPC-сервера
        protected void InitDataGroup(string[] itemDescription, string groupName, out OpcDaGroup dataGroup)
        {
            dataGroup = opcReader._opcServer.AddGroup(groupName);                       //Группа переменных для чтения (записи) из OPC-сервера 
            dataGroup.IsActive = true;

            List<OpcDaItemDefinition> itemDefinitions = new List<OpcDaItemDefinition>(); //Definitions для добавления в группу чтения в OPC-сервер

            foreach (var item in opcTagNamesCollection)
            {
                for (int i = 0; i < itemDescription.Length; i++)
                {
                    itemDefinitions.Add(new OpcDaItemDefinition
                    {
                        ItemId = item + "." + itemDescription[i],
                        IsActive = true
                    });
                }
            }

            OpcDaItemResult[] results = dataGroup.AddItems(itemDefinitions);    //Добавление переменных в группу

            foreach (OpcDaItemResult result in results)
            {
                if (result.Error.Failed)
                    Console.WriteLine("Error adding items: {0}", result.Error);
            }
        }
        #endregion

        #region abstract methods
        //Создает пустой список, инициализирует его пустыми объектами
        internal abstract List<T> CreateItemList();

        //Обновляет список переменных, занося в объекты листа данные из OPC-сервера
        internal abstract void UpdateItemList(ref List<T> itemListForApdate);
        #endregion
    }
}
