using System;
using System.Collections;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public interface IFigureLogic
    {
        void AddFigure(Figure figure);
        void DeleteFigure(int index);
        IEnumerable GetAllFigures();
        Figure GetFigure(int index);
    }
}