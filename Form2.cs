using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MooreMachine//**************ESKİ PROJE
{

    public partial class Form2 : Form
    {
        Form1 _frm1 = new Form1();
        public Makine makine = new Makine();
        public string[] stateNames;


        public class Makine
        {
            public class State
            {
                public string name { get; set; }
                public List<Transition> Transitions { get; set; }
                public string Output { get; set; }

                public State(string name)
                {
                    this.name = name;
                }
            }

            public class Transition
            {
                public string Girdi { get; set; }
                public string Cikti { get; set; }  // Mealey Makinesi için çıktı
                public State State { get; set; }
            }

            public List<State> StateList = new List<State>();

        }


        public Form2(Form1 frm1)
        {
            InitializeComponent();
            _frm1 = frm1;
            update();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            update();
        }
        //Update Table Function
        public void update()
        {
            //-------------------Add Colums--------------------------------
            table.ColumnCount = (2 + _frm1.alphabetSet.Length);
            string[] columnNames = new string[_frm1.alphabetSet.Length + 2];

            columnNames[0] = "Old State";
            for (int i = 1; i <= _frm1.alphabetSet.Length; i++)
            {
                columnNames[i] = $"After Input {_frm1.alphabetSet[i - 1]}";
            }
            columnNames[_frm1.alphabetSet.Length + 1] = "Output";


            for (int i = 0; i < columnNames.Length; i++)
            {
                table.Columns[i].Name = columnNames[i];
            }
            //--------------------------------------------------------------

            //---------------------Add Rows---------------------------------

            stateNames = new string[_frm1.state_count];




            for (int i = 0; i < _frm1.state_count; i++)
            {
                stateNames[i] = $"q{i}";
            }

            for (int i = 0; i < stateNames.Length; i++)
            {
                string stateName = stateNames[i];
                Makine.State newState = new Makine.State(stateName); // Her bir öğe için bir State nesnesi oluşturuldu
                makine.StateList.Add(newState); // Oluşturulan State nesnesi StateList'e eklendi
                table.Rows.Add(stateName); // Tabloya stateNames öğeleri eklendi
            }


            //--------------------------------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow satir in table.Rows)
            {
                foreach (DataGridViewCell hucre in satir.Cells)
                { // Tabloda seçilmemiş hücre var mı diye kontrol ediliyor.

                    if (hucre.Value is null)
                    {
                        MessageBox.Show("Lütfen tabloyu eksiksiz doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var durum = makine.StateList.Find(x => x.name == satir.Cells[0].Value.ToString());
                durum.Transitions = new List<Makine.Transition>();
                durum.Output = satir.Cells[satir.Cells.Count - 1].Value.ToString();
                for (int i = 0; i < _frm1.alphabetSet.Length; i++)
                {
                    var hucre = satir.Cells[i + 1]; // Tabloda ilk sütun durum isimleri olduğu için i+1
                    var gecilenDurum = makine.StateList.Find(x => x.name == hucre.Value.ToString());
                    var gecis = new Makine.Transition()
                    {
                        Girdi = _frm1.alphabetSet[i],
                        State = gecilenDurum
                    };
                    durum.Transitions.Add(gecis);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (makine.StateList.Count == 0)
            {
                MessageBox.Show("Durum Listesi Boş,Lütfen Durum Sayısını Doğru Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string kelime = textBox1.Text;
                var simdikiDurum = makine.StateList[0];
                string durumDizesi = simdikiDurum.name + " ";
                string ciktiDizesi = simdikiDurum.Output + " ";
                foreach (var harf in kelime)
                {
                    var eslesenGecis = simdikiDurum.Transitions.Find(gecis => gecis.Girdi == harf.ToString());
                    simdikiDurum = eslesenGecis.State;

                    durumDizesi += simdikiDurum.name + " ";
                    ciktiDizesi += simdikiDurum.Output + " ";
                }
                var sonuc = (durumDizesi, ciktiDizesi);

                bool girilenKelimeGecersiz = false;
                foreach (var harf in kelime)
                {
                    if (Array.IndexOf(_frm1.alphabetSet, harf.ToString()) == -1)
                    {
                        girilenKelimeGecersiz = true;
                        break;
                    }
                }

                if (girilenKelimeGecersiz)
                {
                    MessageBox.Show("Lütfen test edeceğiniz kelimeden, alfabede bulunmayan harfleri çıkarın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (sonuc.Item1 == null || sonuc.Item2 == null)
                {
                    MessageBox.Show("Lütfen geçiş tablosunu doğru bir şekilde doldurun ve durumları tekrar oluşturun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string states = durumDizesi.Replace(" ", "\t");
                string outputs = ciktiDizesi.Replace(" ", "\t");
                string a_kelime = string.Empty;

                foreach (var harf in textBox1.Text)
                {
                    a_kelime += $"\t{harf}";
                }

                richTextBox1.Text = $"{a_kelime}\n{states}\n{outputs}";
            }
        }
    }
}

