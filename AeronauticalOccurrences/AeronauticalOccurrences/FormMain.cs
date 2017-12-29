using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AeronauticalOccurrences
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\data\\CADASTRO_DAS_IES_2011.csv";
            
            FileHelper.LerCSV(path);

            FileHelper.Search("RIO GRANDE DO SUL");
            
        }

    }
}
