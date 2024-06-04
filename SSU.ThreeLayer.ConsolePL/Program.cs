using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.Common;
using SSU.ThreeLayer.Entities;
using System;

namespace SSU.ThreeLayer.ConsolePL
{
    class Program
    {
        static void Main()
        {

            //IClientLogic cl = DependencyResolver.ClientLogic;
            //Console.WriteLine("Исходная выгрузка");
            //Show(cl);

            //cl.AddClient("Иванов");
            ////вносим данные о покупках первого клиента
            //cl.AddBuying(1, new DateTime(2009, 2, 1), 1000);
            //cl.AddBuying(1, new DateTime(2009, 2, 1), 2050);
            ////создаем нового клиента, его номер автоматически равен 2
            //cl.AddClient("Петров");
            ////создаем нового клиента, его номер автоматически равен 3
            //cl.AddClient("Сидоров");
            ////вносим данные о покупках третьего клиента
            //cl.AddBuying(3, new DateTime(2009, 2, 3), 1500);
            ////вносим данные о покупках Петрова
            //cl.AddBuying("Петров", new DateTime(2009, 2, 4), 1700);
            ////создаем нового клиента, его номер автоматически равен 3
            //cl.AddClient("Пирогов");
            ////выводим информацию из базы клиентов

            //Console.WriteLine("\nУточненная база клиентов");
            //Show(cl);
            //cl.DeleteClient(2); //удаляем клиента с номером 2
            //cl.DeleteClient("Пирогов"); //удаляем клиента с фамилией Пирогов
            //                            //выводим информацию из базы клиентов
            //Console.WriteLine("\nИзмененная база клиентов");
            //Show(cl);
            IFigureLogic figure_logic = DependencyResolver.FigureLogic;

            Console.WriteLine("Исходная выгрузка");
            Show(figure_logic);

            figure_logic.AddFigure(new FigureRectangle(2, 2));
            figure_logic.AddFigure(new FigureTriangle(3, 4, 5));
            figure_logic.AddFigure(new FigureCircle(4));
            figure_logic.AddFigure(new FigureTriangle(3));

            figure_logic.DeleteFigure(2);

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
