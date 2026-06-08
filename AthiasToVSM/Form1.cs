using EmberPlusProviderClassLib.Model;

namespace AthiasToVSM
{
    public partial class Form1 : Form
    {
        public Form1(AppConfig config)
        {
            InitializeComponent();
            lbIP.Text = config.AnthiasIP;
            lbPort.Text = config.Port.ToString();
            lbDescription.Text = config.Identifier;

            dgPages.DataSource = config.Pages.Select(p => new { p.Name, p.Id }).ToList();
        }

        private void dgPages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Program.SetActiveByIndex(e.RowIndex);
            }
        }
    }
}
