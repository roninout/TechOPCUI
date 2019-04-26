using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechOPCUI.Characteristic
{
    class Pressure
    {
        #region properties
        // название тега
        public string TagName { get; set; }
        // возвращаемое значение
        public float Val_R { get; set; }
        #endregion

        #region constructor
        public Pressure(string tagName)
        {
            this.TagName = tagName;
        }

        public Pressure(string tagName, float val_r) : this(tagName)
        {
            Val_R = val_r;
        }
        #endregion

        #region methods

        #endregion
    }
}
