using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCI
{
    public partial class Form1 : Form
    {
        private int listSize = 10;
        private int numberOfIterations = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                numberOfIterations = (int)numericUpDown1.Value;
                listSize = (int)numericUpDown2.Value;
                if (numberOfIterations <= 0)
                {
                   throw new ArgumentException("numberOfIterations <= 0");
                }
                if (listSize <= 0)
                {
                    throw new ArgumentException("listsize <= 0");
                }
                cleanResultTextBox();
                startCalculationGCIForIterations();
                printOutResults();
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                appendResultTextBox(ex.Message);
                
            }
        }


        private void startCalculationGCIForIterations()
        {
            Stopwatch timer = new Stopwatch();
            ListModel lm = ListModel.getInstance();
          
            for (int i = 0; i <= numberOfIterations; i++)
            {
                timer.Reset();
                timer.Start();
                calculateGCI();
                timer.Stop();
                lm.addTime(timer.ElapsedTicks);

            }
            lm.addAverageAndProblemsizeToMap(numberOfIterations);

        }

        private void calculateGCI()
        {
            RandomGenerator rg = new RandomGenerator();
            List<int> fistList = rg.generateRandomIntList(listSize);
            List<int> secondList = rg.generateRandomIntList(listSize);


            int gci = -1;
            foreach (int i in fistList)
            {
                if (secondList.Contains(i) & i > gci)
                {
                    gci = i;
                }

            }
            //so vm does not remove it
            Console.WriteLine(gci);

        }

        private void printOutResults()
        {
            ListModel lm = ListModel.getInstance();
            Dictionary<int, long> dictionary = lm.getProblemSizeMap();

            appendResultTextBox("");
            foreach (int problemsize in dictionary.Keys)
            {
                appendResultTextBox("Problemsize: "+problemsize+" : Average: "+dictionary[problemsize] + " Ticks");
            }

        }


        private void appendResultTextBox(String text)
        {
            resultBox.AppendText(text + "\r\n");
        }

        private void cleanResultTextBox()
        {
            resultBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 20; i++)
            {
                numberOfIterations++;

                cleanResultTextBox();
                startCalculationGCIForIterations();
                printOutResults();
            }

        }

    }
}
