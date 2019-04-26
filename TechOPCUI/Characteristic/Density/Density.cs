using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDotNetLib.Lab.Substances;

namespace TechOPCUI.Characteristic
{
    class Density
    {
        #region properties
        public string TagName { get; set; }
        public string Description { get; set; }
        public bool Sel { get; set; }
        public bool IsValid { get; set; } //Флаг, (TRUE - данные объекта корректны для рачсчета)
        public short ValHmi { get; set; }
        public short ValCalc { get; set; }
        public short DeltaD { get; set; }
        public short CompN { get; set; }
        public double[] PercArray { get; set; }
        public string[] PercDescription { get; set; }
        private Mix Mix { get; set; }
        public Temperature Temperature { get; set; }
        public Pressure Pressure { get; set; }
        #endregion

        #region constructor
        public Density(string _tagName)
        {
            TagName = _tagName;
        }
        #endregion

        #region methods
        //Метод расчета теплоемкости с подключением библиотеки TechDotNetLib
        public double CalculateCapacity()
        {
            double _densityValue;
            try
            {
                Mix = new Mix(PercDescription, PercArray);
                _densityValue = Mix.GetDensity(Temperature.Val_R + DeltaD * 0.01F, this.Pressure.Val_R + DeltaD * 0.01F);
            }
            catch (Exception e)
            {
                IsValid = false;
                //Console.WriteLine(e.Message);
                _densityValue = -1;

            }
            return _densityValue;
        }
        #endregion
    }
}
