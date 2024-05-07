using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    internal static class Program
    {
        private const decimal PretMinim = 0.01m;
        private const int CantitateMinima = 1;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // creare formular
            Form1 form1 = new Form1();

            // Adaugi label-urile și casetele de text pe formular
            Label lblDenumire = new Label() { Text = "Denumire:", Location = new System.Drawing.Point(20, 20), Width = 80 };
            TextBox txtDenumire = new TextBox() { Location = new System.Drawing.Point(120, 20) };
            Label lblPret = new Label() { Text = "Preț:", Location = new System.Drawing.Point(20, 50), Width = 80 };
            TextBox txtPret = new TextBox() { Location = new System.Drawing.Point(120, 50) };
            Label lblCantitate = new Label() { Text = "Cantitate:", Location = new System.Drawing.Point(20, 80), Width = 80 };
            TextBox txtCantitate = new TextBox() { Location = new System.Drawing.Point(120, 80) };

            form1.Controls.Add(lblDenumire);
            form1.Controls.Add(txtDenumire);
            form1.Controls.Add(lblPret);
            form1.Controls.Add(txtPret);
            form1.Controls.Add(lblCantitate);
            form1.Controls.Add(txtCantitate);

            // buton salvare
            Button btnSave = new Button() { Text = "Salvare", Location = new System.Drawing.Point(20, form1.Height - 120), Width = 80 };
            btnSave.Click += (sender, e) =>
            {
                // Resetarea culorare
                lblDenumire.ForeColor = Color.Blue;
                lblPret.ForeColor = Color.Blue;
                lblCantitate.ForeColor = Color.Blue;

                string denumire = txtDenumire.Text;
                string pretText = txtPret.Text;
                string cantitateText = txtCantitate.Text;

                // validare denumire
                if (!string.IsNullOrEmpty(denumire))
                {
                    foreach (char c in denumire)
                    {
                        if (!char.IsLetter(c))
                        {
                            lblDenumire.ForeColor = Color.Red;
                            MessageBox.Show("Denumirea introdusă trebuie să conțină doar litere.", "Eroare");
                            return;
                        }
                    }
                }
                else
                {
                    lblDenumire.ForeColor = Color.Red;
                    MessageBox.Show("Trebuie să introduceți o denumire.", "Eroare");
                    return;
                }

                // valdisare preț
                if (!decimal.TryParse(pretText, out decimal pret) || pret < PretMinim)
                {
                    lblPret.ForeColor = Color.Red;
                    MessageBox.Show($"Prețul introdus nu este valid. Trebuie să fie un număr mai mare decât {PretMinim}.", "Eroare");
                    return;
                }

                // validare cantitate
                if (!int.TryParse(cantitateText, out int cantitate) || cantitate < CantitateMinima)
                {
                    lblCantitate.ForeColor = Color.Red;
                    MessageBox.Show($"Cantitatea introdusă nu este validă. Trebuie să fie un număr întreg mai mare sau egal cu {CantitateMinima}.", "Eroare");
                    return;
                }

                string data = $"Denumire: {denumire}, Preț: {pret}, Cantitate: {cantitate}";

                string filePath = "date_salvate.txt";

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
                {
                    file.WriteLine(data);
                }

                MessageBox.Show($"Datele au fost salvate în fișierul {filePath}.");
            };

            form1.Controls.Add(btnSave);

            // buton refresh refresh
            Button btnRefresh = new Button() { Text = "Refresh", Location = new System.Drawing.Point(120, form1.Height - 120), Width = 80 };
            btnRefresh.Click += (sender, e) =>
            {
                txtDenumire.Text = "";
                txtPret.Text = "";
                txtCantitate.Text = "";
                lblDenumire.ForeColor = Color.Black;
                lblPret.ForeColor = Color.Black;
                lblCantitate.ForeColor = Color.Black;
            };

            form1.Controls.Add(btnRefresh);

            // butonul afișare date fișier
            Button btnShowData = new Button() { Text = "Afișare date", Location = new System.Drawing.Point(220, form1.Height - 120), Width = 100 };
            btnShowData.Click += (sender, e) =>
            {
                string filePath = "date_salvate.txt";

                if (System.IO.File.Exists(filePath))
                {
                    string data = System.IO.File.ReadAllText(filePath);
                    MessageBox.Show(data, "Date salvate în fișier");
                }
                else
                {
                    MessageBox.Show("Nu există date salvate în fișier.", "Eroare");
                }
            };

            form1.Controls.Add(btnShowData);

            Application.Run(form1);
        }
    }
}
