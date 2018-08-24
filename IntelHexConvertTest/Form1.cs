using IntelHex;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IntelHexConvertTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void bSourceMore_Click(object sender, EventArgs e)
        {
            var oDialog = new OpenFileDialog();

            if (oDialog.ShowDialog() == DialogResult.OK)
            {
                eSource.Text = oDialog.FileName;
            }
        }

        private void bDestinationMore_Click(object sender, EventArgs e)
        {
            var sDialog = new SaveFileDialog();

            if (sDialog.ShowDialog() == DialogResult.OK)
            {
                eDestination.Text = sDialog.FileName;
            }
        }

        private void bConvert_Click(object sender, EventArgs e)
        {
            if (eSource.Text == string.Empty || !File.Exists(eSource.Text) || eDestination.Text == string.Empty)
            {
                MessageBox.Show("Incorrect source or target file");
                return;
            }

            var converter = new IntelHexConverter(eSource.Text);
            var result = converter.ConverToIntelHex();

            SaveResultToFile(result);
        }

        private void SaveResultToFile(List<string> resultLines)
        {
            var s = new StreamWriter(eDestination.Text, false);

            foreach (var resultLine in resultLines)
            {
                s.Write(resultLine);
            }

            s.Close();

            MessageBox.Show("File generated");
        }
    }
}
