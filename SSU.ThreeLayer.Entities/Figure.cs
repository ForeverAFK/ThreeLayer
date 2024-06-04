using System;
using System.Collections.Generic;

namespace SSU.ThreeLayer.Entities
{
    [Serializable]

    public abstract class Figure : IComparable<Figure>
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Figure(string name)
        {
            this.Name = name;
        }

        public int CompareTo(Figure item)
        {
            return this.FigureArea().CompareTo(item.FigureArea());
        }

        abstract public float FigurePerimeter();
        abstract public float FigureArea();

        abstract public void Set(params float[] ar);

    }
}
