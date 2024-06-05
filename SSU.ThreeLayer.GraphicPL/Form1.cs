using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreeLayer.BLL;
using SSU.ThreeLayer.Common;
using ThreeLayer.Entities;

namespace SSU.ThreeLayer.GraphicPL
{
    public partial class Form1 : Form
    {
        IFigureLogic figure_logic = DependencyResolver.FigureLogic;
        public Form1()
        {
            InitializeComponent();
            //checkedListBox.Sorted = true;
            //checkedListBox.SelectionMode = SelectionMode.MultiExtended;
        }

        public void ClearTextBoxes()
        {
            tbA.Text = null;
            tbB.Text = null;
            tbR.Text = null;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Figure fig;
            bool NoQuestionsAsked = false;
            switch (comboBox1.Text)
            {
                case "Rectangle":
                    {
                        int a = int.Parse(tbA.Text);
                        int b = (tbB.Text != null) ? int.Parse(tbB.Text) : a;
                        fig = new FigureRectangle(a, b); 
                        checkedListBox.Items.Add(fig.ToString());
                        figure_logic.AddFigure(fig);
                        ClearTextBoxes();
                        break;
                    }
                case "Triangle":
                    {
                        int a = int.Parse(tbA.Text);
                        int b = (tbB.Text != null) ? int.Parse(tbB.Text) : a;
                        int c = (tbR.Text != null) ? int.Parse(tbR.Text) : a;
                        fig = new FigureTriangle(a, b, c); 
                        checkedListBox.Items.Add(fig.ToString());
                        figure_logic.AddFigure(fig);
                        ClearTextBoxes();
                        break; 
                    }
                case "Circle":
                    {
                        int r = int.Parse(tbR.Text);
                        fig = new FigureCircle(r);
                        checkedListBox.Items.Add(fig.ToString());
                        figure_logic.AddFigure(fig);
                        ClearTextBoxes();
                        break;
                    }
                default:
                    ClearTextBoxes();
                    break;

            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //if (checkedListBox.Ca)
                {
                foreach (var item in checkedListBox.CheckedItems.OfType<string>().ToList())
                    checkedListBox.Items.Remove(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            figure_logic.SaveAllFigures();
            MessageBox.Show("Saved Successfully");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            checkedListBox.Items.Add(figure_logic.GetAllFigures());
            MessageBox.Show("Loaded Successfully");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.Text)
            {
                case "Rectangle":
                    tbA.Enabled = true;
                    tbB.Enabled = true;
                    tbR.Enabled = false;
                    break;
                case "Triangle":
                    tbA.Enabled = true;
                    tbB.Enabled = true;
                    tbR.Enabled = true;
                    label3.Text = "C=";
                    break;
                case "Circle":
                    tbA.Enabled = false;
                    tbB.Enabled = false;
                    tbR.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
