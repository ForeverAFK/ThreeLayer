using System;
using System.Collections;
using ThreeLayer.Entities;

namespace ThreeLayer.DAL
{
    public interface IBaseFigures
    {
        void AddFigure(Figure figure);
        void DeleteFigure(string name);
        void DeleteFigure(int index);
        IEnumerable GetAllFigures();
        Figure GetFigure(int index);
        void SaveBaseFigures();
     }
}