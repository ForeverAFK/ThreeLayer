using SSU.ThreeLayer.Entities;
using System;
using System.Xml.Serialization;

namespace SSU.ThreeLayer.Entities
{
    [Serializable]

    public class FigureTriangle : Figure
    {

        public float SideA { get; set; }
        public float SideB { get; set; }
        public float SideC { get; set; }

        public FigureTriangle(float SideA, float SideB, float SideC) : base("Triangle")
        {
            this.SideA = SideA;
            this.SideB = SideB;
            this.SideC = SideC;
        }
        public FigureTriangle(float SideA) : base("Triangle")
        {
            this.SideA = SideA;
            this.SideB = SideA;
            this.SideC = SideA;
        }
        public FigureTriangle(FigureTriangle item) : base("Triangle")
        {
            this.SideA = item.SideA;
            this.SideB = item.SideB;
            this.SideC = item.SideC;
        }
        public override float FigurePerimeter()
        {
            return SideA + SideB + SideC;
        }
        public override float FigureArea()
        {
            float p = this.FigurePerimeter() / 2;
            return (float)Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
        public override string ToString()
        {
            return $"a = {SideA}, b = {SideB}, c = {SideC}";
        }

        public override void Set(params float[] arr)
        {
            if (arr.Length == 3)
            {
                if (SideA + SideB > SideC || SideA + SideC > SideB || SideB + SideC > SideA)
                {
                    SideA = arr[0];
                    SideB = arr[1];
                    SideC = arr[2];
                }
                else
                    throw new Exception("Задан невозможный треугольник");
            }
            else
                throw new Exception("Неверное количество аргументов");

        }

    }
}