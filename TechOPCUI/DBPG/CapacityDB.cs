using System.ComponentModel.DataAnnotations;

namespace TechOPCUI.DBPG
{
    class CapacityDB
    {
        public int id { get; set; }
        [Key]
        public string tagname { get; set; }
        public string perc0 { get; set; }           // название компонента 0
        public string perc1 { get; set; }           // название компонента 1
        public string perc2 { get; set; }           // название компонента 2
        public string perc3 { get; set; }           // название компонента 3
        public string perc4 { get; set; }           // название компонента 4
        public string description { get; set; }     // описание обьекта Capacity
        public string temperature { get; set; }     // название тега температуры
        public string pressure { get; set; }        // название тега давления
    }
}
