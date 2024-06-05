using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using SSU.ThreeLayer.Entities;

namespace ThreeLayer.DAL
{
    public class BaseFigures : IBaseFigures
    {
        int index; //номер клиента, генерируется автоматически
        Dictionary<int, Figure> figures; //список клиентов

        public BaseFigures() //конструктор класса
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate);
            if (f.Length == 0) //файл пуст, создаю новую базу
            {
                figures = new Dictionary<int, Figure>();
                index = 0;
            }
            else // иначе выполняю десериализацию
            {
                figures = (Dictionary<int, Figure>)formatter.Deserialize(f);
                ICollection key = figures.Keys; // ищу последний ключ
                foreach (int item in key)
                {
                    index = item;
                }
            }
            f.Close();

        }
        ~BaseFigures()
        {
            SaveBaseFigures();
        }
        public void AddFigure(Figure figure) //добавление нового клиента в хеш-таблицу:
        { //ключ – index, значение – экземпляр класса Figure
            index++;
            figure.ID = index;
            figures.Add(index, figure);
        }
        public void DeleteFigure(int index)
        {
            figures.Remove(index);
        }
        //удаляем клиента по фамилии
        public void DeleteFigure(string name)
        {
            ICollection key = figures.Keys;
            foreach (int index in key)
            {
                Figure item = figures[index];
                if (string.Compare(name, item.Name) == 0)
                {
                    DeleteFigure(index);
                    break;
                }
            }
        }

        public Figure GetFigure(int index)
        {
            return figures[index];
        }

        public IEnumerable GetAllFigures()
        {
            return figures.Values;
        }

        public void SaveBaseFigures()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, figures);
            }
        }

    }
}
