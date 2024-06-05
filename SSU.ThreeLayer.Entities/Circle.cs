using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLayer.Entities
{

    [Serializable]
    public class FigureCircle : Figure
    {
        public float Radius { get; set; }


        public FigureCircle() : base("Circle") { }
        public FigureCircle(float radius) : base("Circle")
        {
            Radius = radius;
        }
        public FigureCircle(FigureCircle item) : base("Circle")   // ?????
        {
            Radius = item.Radius;
        }

        public override float FigurePerimeter()
        {
            return 2 * (float)Math.PI * Radius;
        }
        public override float FigureArea()
        {
            return (float)Math.PI * Radius * Radius;
        }
        public override string ToString()
        {
            float local_pi = (float)Math.PI;
            return $"{Name}: r = {Radius}, pi ~ {local_pi}";
        }

        public override void Set(params float[] arr)
        {
            if (arr.Length == 1)
            {
                Radius = arr[0];
            }
            else
                throw new Exception("Неверное количество аргументов");

        }
    }
}
