using System;
using System.Linq;
using System.Collections.Generic;
using TitaniumAS.Opc.Client.Da;
using TitaniumAS.Opc.Client.Da.Browsing;

namespace TechOPCUI.Characteristic
{
    class PressureCreator : ItemsCreator<Pressure>
    {
        readonly string[] itemDescPressureForRead = new string[] { "R" };
        private IEnumerable<OpcDaBrowseElement> opcPressureTagNamesCollection;

        public PressureCreator(OPCReader opcReader) : base(opcReader)
        {
            subStringTagName = "_PT";
        }

        internal override List<Pressure> CreateItemList()
        {
            //Считываем из OPC-Reader строки с названиями переменных
            opcPressureTagNamesCollection = opcReader.ReadDataToNodeList(subStringTagName);

            //Формируем список пустых объектов Pressure
            var resultList = new List<Pressure>();

            // пробегаем по списку из ОРС и создаем новые пустые обьекты типа Pressure
            foreach (var item in opcPressureTagNamesCollection)
                resultList.Add(new Pressure(item.Name));

            //Создаем группу для записи в OCP-сервер
            //base.InitDataGroup(itemDescPressureForWrite, "Pressures_Write_Group", out dataGroupWrite); //Не пишем давления

            //Заполняем объекты Pressure данными
            //this.UpdateItemList(ref resultList);

            return resultList;
        }

        internal override void UpdateItemList(ref List<Pressure> itemListForUpdate)
        {
            //Создаем группу для чтения из OCP-сервера
            base.InitDataGroup(itemDescPressureForRead, "Pressure_Read_Group", out dataGroupRead);

            OpcDaItemValue[] pressureValues = dataGroupRead.Read(dataGroupRead.Items, OpcDaDataSource.Device);

            int valueCollectionIterator = 0;
            var pressure = default(Pressure);
            foreach (var item in opcPressureTagNamesCollection)
            {
                //Initialization of fields of temperature instance
                pressure = itemListForUpdate.FirstOrDefault(c => c.TagName == item.Name);

                if (pressure != null)
                {
                    pressure.Val_R = pressureValues[0 + valueCollectionIterator].Error.Succeeded ? (float)pressureValues[0 + valueCollectionIterator].Value : default(float);
                }

                valueCollectionIterator += itemDescPressureForRead.Length;
            }
        }
    }
}
