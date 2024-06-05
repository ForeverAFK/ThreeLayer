
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayer.BLL;
using ThreeLayer.DAL;

namespace SSU.ThreeLayer.Common
{
    public static class DependencyResolver
    {
        static private IBaseFigures baseFigures;
        static private IFigureLogic figureLogic;

        static public IBaseFigures BaseFigures
        {
            get => baseFigures ?? (baseFigures = new BaseFigures());

        }
        static public IFigureLogic FigureLogic
        {
            get => figureLogic ?? 
            (figureLogic = new FigureLogic(BaseFigures));
        }


     }
}
