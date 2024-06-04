﻿using System;
using System.Collections;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.DAL
{
    public interface IBaseFigures
    {
        void AddFigure(Figure figure);
        void DeleteFigure(string name);
        void DeleteFigure(int index);
        IEnumerable GetAllFigures();
        Figure GetFigure(int index);
    }
}