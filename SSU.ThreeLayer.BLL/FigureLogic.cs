using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ThreeLayer.DAL;
using SSU.ThreeLayer.Entities;

namespace ThreeLayer.BLL
{
    public class FigureLogic : IFigureLogic
    {
        private IBaseFigures baseFigures;

        public FigureLogic(IBaseFigures baseFigures)
        {
            this.baseFigures = baseFigures;
        }

        public void AddFigure(Figure figure)
        {
            baseFigures.AddFigure(figure);

        }

        //удаляем клиента по номеру
        public void DeleteFigure(int index)
        {
            baseFigures.DeleteFigure(index);
        }

        public Figure GetFigure(int index)
        {
            return baseFigures.GetFigure(index);
        }

        public IEnumerable GetAllFigures()
        {
            return baseFigures.GetAllFigures();
        }
        public void SaveAllFigures()
        {
            baseFigures.SaveBaseFigures();
        }

    }
}
