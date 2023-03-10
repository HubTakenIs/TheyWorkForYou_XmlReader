using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace hubXmlReaderFormApp
{
    public partial class Form1 : Form
    {
        // private DataGridView RegmemDataGridView = new DataGridView();

        public Form1()
        {
            //this.Controls.Add(RegmemDataGridView);
            
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IRemoteDocumentReader<IPerson> myRemoteXmlReader = Factory.GetRemoteDocumentReader();
            List<IPerson> regMemList = myRemoteXmlReader.GetAllData("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml");
            InitializeDataGridView(regMemList);
            dataGridView1.Size = dataGridView1.ClientSize;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
            
            //dataGridView1.DataSource = test;
            // dataGridView1.ColumnHeadersVisible = true;
            //RegmemDataGridView.DataSource = test;


            // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.columns?view=windowsdesktop-7.0

            //RegmemDataGridView.AutoGenerateColumns = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void InitializeDataGridView(List<IPerson> dataList)
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("index", typeof(int));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("ID",typeof(string));
            dt.Columns.Add("Image", typeof(Image));
            dt.Columns.Add("Party",typeof(string));
            dt.Columns.Add("Constituency",typeof(string));
            dt.Columns.Add("Donor",typeof(string));
            dt.Columns.Add("Donations",typeof(decimal));   
            for (int i = 0; i < dataList.Count; i++)
            {
               
                RegMem RegMem = (RegMem)dataList[i];

                string regMemName = RegMem.Name;
                string regMemID = RegMem.id;
                string regMemDonor = RegMem.donor;
                decimal totalPayments = 0;
                foreach (decimal payment in RegMem.PaymentsReceived)
                {
                    totalPayments = totalPayments + payment;
                }

                string ImageURL = "https://www.theyworkforyou.com/people-images/mps/"+ regMemID + ".jpg";
                Image MemberPhoto = null;
                WebClient wClient = new WebClient();
                try
                {
                    byte[] imageByte = wClient.DownloadData(ImageURL);
                    MemoryStream stream = new MemoryStream(imageByte);
                    MemberPhoto = Image.FromStream(stream);
                }
                catch (Exception ex)
                {
                    byte[] imageByte = wClient.DownloadData("https://cdn-icons-png.flaticon.com/128/2748/2748558.png");
                    MemoryStream stream = new MemoryStream(imageByte);
                    MemberPhoto = Image.FromStream(stream);

                }
                
                dt.Rows.Add(i + 1, regMemName, regMemID, MemberPhoto, "party", "Constituency", regMemDonor, totalPayments);
            }
            
            dataGridView1.DataSource = dt;
        }
    }
}
