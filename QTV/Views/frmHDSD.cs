using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTV.Views
{
    public partial class frmHDSD : Form
    {
        private PdfViewer pdfViewer;

        public frmHDSD()
        {
            InitializeComponent();
            pdfViewer = new PdfViewer
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pdfViewer);
        }

        private void frmHDSD_Load(object sender, EventArgs e)
        {
            byte[] pdfData = Properties.Resources.HDSD;

            // Save the byte array to a temporary file
            string tempFilePath = Path.Combine(Path.GetTempPath(), "HDSD.pdf");
            File.WriteAllBytes(tempFilePath, pdfData);

            // Load the temporary file in the PdfViewer
            var document = PdfDocument.Load(tempFilePath);
            pdfViewer.Document = document;
        }
    }
}
