using ThreeLayer.BLL;
using SSU.ThreeLayer.Common;
using SSU.ThreeLayer.Entities;
using System;

namespace SSU.ThreeLayer.ConsolePL
{
    class Program
    {
        static void Main()
        {

            IFigureLogic figure_logic = DependencyResolver.FigureLogic;

            Console.WriteLine("Исходная выгрузка");
            Show(figure_logic);
            Console.WriteLine();
            //figure_logic.AddFigure(new FigureRectangle(2, 2));
            //figure_logic.AddFigure(new FigureTriangle(3, 4, 5));
            //figure_logic.AddFigure(new FigureCircle(4));
            //figure_logic.AddFigure(new FigureTriangle(3));

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Введите команду: \nADD - добавить фигуру (имя + необходимые данные)" +
                    "\nDEL - удалить фигуру (ID) \nEND - остановить выполнение программы");
                string[] inData = Console.ReadLine().Split(' ', ',', ';');
                string com = inData[0];
                switch (com)
                {
                    case "ADD":
                        {
                            //string[] inData = com.Split(' ', ',', ';');
                            if (inData[1] == "Rectangle")
                            {
                                figure_logic.AddFigure(new FigureRectangle(int.Parse(inData[2]), int.Parse(inData[3])));
                            }
                            else if (inData[1] == "Triangle")
                            {
                                figure_logic.AddFigure(new FigureTriangle(int.Parse(inData[2]), int.Parse(inData[3]), int.Parse(inData[4])));
                            }
                            else if (inData[1] == "Circle")
                            {
                                figure_logic.AddFigure(new FigureCircle(int.Parse(inData[2])));
                            }
                                break;
                        }
                    case "DEL":
                        {
                            figure_logic.DeleteFigure(int.Parse(inData[1]));
                            break;
                        }
                    case "SHW":
                        Show(figure_logic);
                        break;
                    case "END":
                        isRunning = false;
                        break;
                    default:
                        break;
                }

            }
        }

        static void Show(IFigureLogic figureLogic)
        {
            foreach (Figure figure in figureLogic.GetAllFigures())
            {
                Console.Write("№{0}", figure.ID); //выводим номер клиета
                Console.WriteLine(" {0}", figure.Name); //выводим номер клиета
                Console.WriteLine(figure); //выводим информацию о клиенте на экран
            }
        }
    }
}
