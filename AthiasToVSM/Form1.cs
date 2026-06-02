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

        }
    }
}
