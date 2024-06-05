using System;
using System.Collections;
using ThreeLayer.Entities;

namespace ThreeLayer.BLL
{
    public interface IFigureLogic
    {
        void AddFigure(Figure figure);
        void DeleteFigure(int index);
        IEnumerable GetAllFigures();
        Figure GetFigure(int index);
        void SaveAllFigures();
    }
}