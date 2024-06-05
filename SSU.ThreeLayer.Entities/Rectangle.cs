using System;
using System.Xml.Serialization;

namespace ThreeLayer.Entities
{
    [Serializable]

    public class FigureRectangle : Figure
    {
        public float SideA { get; set; }    // на самом деле это не параллелограмм, а виниловая пластинка
        public float SideB { get; set; }

        public FigureRectangle(float SideA, float SideB) : base("Rectangle")
        {
            this.SideA = SideA;
            this.SideB = SideB;
        }
        public FigureRectangle(float SideA) : base("Rectangle") // квадрат
        {
            this.SideA = SideB = SideA;
        }
        public FigureRectangle(FigureRectangle item) : base("Rectangle") // копирования
        {
            SideA = item.SideA;
            SideB = item.SideB;

        }
        public override float FigurePerimeter()
        {
            return SideA * 2 + SideB * 2;
        }
        public override float FigureArea()
        {
            return SideA * SideB;
        }
        public override string ToString()
        {
            return $"{Name}: a = {SideA}, b = {SideB}";
        }

        public override void Set(params float[] arr)
        {
            if (arr.Length == 2)
            {
                SideA = arr[0];
                SideB = arr[1];
            }
            else
                throw new Exception("Неверное количество аргументов");

        }

    }
}
