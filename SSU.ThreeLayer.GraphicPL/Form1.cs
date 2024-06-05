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
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.GraphicPL
{
    public partial class Form1 : Form
    {
        IFigureLogic figure_logic = DependencyResolver.FigureLogic;
        Stack<ComboBoxStyle> stack = new Stack<ComboBoxStyle>(1);
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
                        try
                        {
                            int a = int.Parse(tbA.Text);
                            int b = (tbB.Text != null) ? int.Parse(tbB.Text) : a;
                            fig = new FigureRectangle(a, b);

                            checkedListBox.Items.Add(fig.ToString());
                            figure_logic.AddFigure(fig);
                        }
                        catch//(Exception.)
                        {
                            ClearTextBoxes();
                        }
                        ClearTextBoxes();
                        break;
                    }
                case "Triangle":
                    {
                        try
                        {
                            int a = int.Parse(tbA.Text);
                            int b = (tbB.Text != null) ? int.Parse(tbB.Text) : a;
                            int c = (tbR.Text != null) ? int.Parse(tbR.Text) : a;
                            fig = new FigureTriangle(a, b, c);
                            checkedListBox.Items.Add(fig.ToString());
                            figure_logic.AddFigure(fig);
                        }
                        catch
                        {
                            ClearTextBoxes();
                        }
                        ClearTextBoxes();
                        break; 
                    }
                case "Circle":
                    {
                        try
                        {
                            int r = int.Parse(tbR.Text);
                            fig = new FigureCircle(r);
                            checkedListBox.Items.Add(fig.ToString());
                            figure_logic.AddFigure(fig);
                        }
                        catch
                        {
                            ClearTextBoxes();
                        }
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
            foreach (var item in checkedListBox.CheckedItems.OfType<Figure>().ToList())
                checkedListBox.Items.Remove(item);
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            checkedListBox.Items.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            figure_logic.SaveAllFigures();
            MessageBox.Show("Saved Successfully");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            foreach (Figure fig in figure_logic.GetAllFigures())
            {
                checkedListBox.Items.Add(fig);
                //checkedListBox.Items.Count.
            }
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
                    label3.Text = "R=";
                    break;
                default:
                    break;
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Text = null;
            comboBox1.ForeColor = Color.Black;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            comboBox1.Text = "Figure Type";
            comboBox1.ForeColor = Color.LightGray;
        }
    }
}
