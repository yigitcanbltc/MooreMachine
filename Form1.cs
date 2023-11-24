namespace MooreMachine//*****************ESKÝ PROJE-------------------
{
   
    public partial class Form1 : Form
    {
        public string[] alphabetSet;
        public string[] outputSet;
        public int state_count;
        string alphabet;
        string output;
        
        public Form1()
        {
            InitializeComponent();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            state_count = int.Parse(textBox1.Text);
            alphabet = textBox2.Text;
            char[] spliter = { ',' };
            alphabetSet = alphabet.Split(spliter, StringSplitOptions.RemoveEmptyEntries);
            output = textBox3.Text;
            outputSet = output.Split(spliter, StringSplitOptions.RemoveEmptyEntries);
            Form2 frm2 = new Form2(this);
            frm2.ShowDialog();
        }
    }
}