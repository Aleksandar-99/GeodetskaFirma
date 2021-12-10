using System;
using System.Windows.Forms;

namespace Baze_Podataka_Projekat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HideAllViews();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.parcelaTableAdapter.Fill(this.dataBaseDataSet.Parcela);
            this.zaposleniTableAdapter.Fill(this.dataBaseDataSet.Zaposleni);
            this.premerTableAdapter.Fill(this.dataBaseDataSet.Premer);
            this.plataTableAdapter.Fill(this.dataBaseDataSet.Plata);
            this.objekatTableAdapter.Fill(this.dataBaseDataSet.Objekat);
            this.klijentTableAdapter.Fill(this.dataBaseDataSet.Klijent);
            this.geometarTableAdapter.Fill(this.dataBaseDataSet.Geometar);

            GlavniComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PretragaItemComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void GlavniComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GlavniComboBox.SelectedItem.Equals("Geometar"))
            {
                HideAllViews(); GeometarView.Visible = true; pretragaGeometra();
            }
            else if (GlavniComboBox.SelectedItem.Equals("Klijent"))
            {
                HideAllViews(); KlijentView.Visible = true; pretragaKlijent();
            }
            else if (GlavniComboBox.SelectedItem.Equals("Objekat"))
            {
                HideAllViews(); ObjekatView.Visible = true; pretragaObjekat();
            }
            else if (GlavniComboBox.SelectedItem.Equals("Parcela"))
            {
                HideAllViews(); ParcelaView.Visible = true; pretragaParcela();
            }
            else if (GlavniComboBox.SelectedItem.Equals("Plata"))
            {
                HideAllViews(); PlataView.Visible = true; pretragaPlata();
            }
            else if (GlavniComboBox.SelectedItem.Equals("Premer"))
            {
                HideAllViews(); PremerView.Visible = true; pretragaPremer();
            }
            else if (GlavniComboBox.SelectedItem.Equals("Zaposleni")) { 
                HideAllViews(); ZaposleniView.Visible = true; pretragaZaposleni();
            }

            label2.Visible = true; label3.Visible = true;
            PretragaItemComboBox.Visible = true;
            GlavnaTXTPretraga.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            Izbrisati.Visible = true; Dodati.Visible = true; ; Sacuvati.Visible = true; ; Iskljuciti.Visible = true;

            PretragaItemComboBox.Items.Clear();
            int counter = GlavniComboBox.SelectedIndex;

            string[] stringGeometra = new string[] { "ID Geometra", "Ime Geometra", "Prezime Geometra", "Adresa", "Broj Telefona", "ID Plate" };
            string[] stringKlijent = new string[] { "ID Klijenta", "Ime Klijenta", "Prezime Klijenta", "Telefon", "Adresa" };
            string[] stringObjekat = new string[] { "ID Objekta","ID Klijenta","Broj Parcele", "Broj Objekta", "Sirina", "Duzina"};
            string[] stringParcela = new string[] { "Broj Parcele","ID Klijenta","ID Objekta","Adresa", "Ime Klijenta", "Prezime Klijenta", "Sirina", "Duzina" };
            string[] stringPlata = new string[] { "ID Plate", "Iznos Plate" };
            string[] stringPremer = new string[] { "ID Premera","Broj Parcele", "Sirina", "Duzina", "Datum Premera", "ID Geometra", "ID Klijenta" };
            string[] stringZaposleni = new string[] { "ID Zaposlenog","Ime Zaposlenog", "Prezime Zaposlenog", "Adresa", "Telefon", "ID Plata" };

            switch (counter)
            {
                case 0: PretragaItemComboBox.Items.AddRange(stringGeometra); break;
                case 1: PretragaItemComboBox.Items.AddRange(stringKlijent); break;
                case 2: PretragaItemComboBox.Items.AddRange(stringObjekat); break;
                case 3: PretragaItemComboBox.Items.AddRange(stringParcela); break;
                case 4: PretragaItemComboBox.Items.AddRange(stringPlata); break;
                case 5: PretragaItemComboBox.Items.AddRange(stringPremer); break;
                case 6: PretragaItemComboBox.Items.AddRange(stringZaposleni); break;
            }
        }
        private void HideAllViews()
        {
            GeometarView.Visible = false;
            KlijentView.Visible = false;
            ObjekatView.Visible = false;
            ParcelaView.Visible = false;
            PlataView.Visible = false;
            PremerView.Visible = false;
            ZaposleniView.Visible = false;
            Izbrisati.Visible = false;
            Dodati.Visible = false;
            Sacuvati.Visible = false;
            PretragaItemComboBox.Visible = false;
            GlavnaTXTPretraga.Visible = false;

            iDGeometraTextBox.Visible = false; iDGeometraLabel.Visible = false;
            imeGeometraTextBox.Visible = false; imeGeometraLabel.Visible = false;
            prezimeGeometraLabel.Visible = false; prezimeGeometraTextBox.Visible = false;
            adresaLabel.Visible = false; adresaTextBox.Visible = false;
            brojTelefonaLabel.Visible = false; brojTelefonaTextBox.Visible = false;
            iDPlataLabel.Visible = false; iDPlataTextBox.Visible = false;

            iDKlijentLabel.Visible = false; iDKlijentTextBox.Visible = false;
            imeLabel.Visible = false; imeTextBox.Visible = false;
            prezimeLabel.Visible = false; prezimeTextBox.Visible = false;
            brojTelefonaLabel1.Visible = false; brojTelefonaTextBox1.Visible = false;
            adresaLabel1.Visible = false; adresaTextBox1.Visible = false;

            iDObjektaLabel.Visible = false; iDObjektaTextBox.Visible = false;
            iDKlijentaLabel.Visible = false; iDKlijentaTextBox.Visible = false;
            brojParceleLabel.Visible = false; brojParceleTextBox.Visible = false;
            brojObjektaLabel.Visible = false; brojObjektaTextBox.Visible = false;
            sirinaLabel.Visible = false; sirinaTextBox.Visible = false;
            duzinaLabel.Visible = false; duzinaTextBox.Visible = false;
            ozakonjenjeLabel.Visible = false; ozakonjenjeCheckBox.Visible = false;

            brojParceleLabel1.Visible = false; brojParceleTextBox1.Visible = false;
            iDKIjentaLabel.Visible = false; iDKIjentaTextBox.Visible = false;
            iDObjektaLabel1.Visible = false; iDObjektaTextBox1.Visible = false;
            adresaLabel2.Visible = false; adresaTextBox2.Visible = false;
            imeKlijentaLabel.Visible = false; imeKlijentaTextBox.Visible = false;
            prezimeKlijentaLabel.Visible = false; prezimeKlijentaTextBox.Visible = false;
            sirinaLabel1.Visible = false; sirinaTextBox1.Visible = false;
            duzinaLabel1.Visible = false; duzinaTextBox1.Visible = false;

            iDPlataLabel1.Visible = false; iDPlataTextBox1.Visible = false;
            iznosPlateLabel.Visible = false; iznosPlateTextBox.Visible = false;

            iDPremerLabel.Visible = false; iDPremerTextBox.Visible = false;
            brojParceleLabel2.Visible = false; brojParceleTextBox2.Visible = false;
            sirinaLabel2.Visible = false; sirinaTextBox2.Visible = false;
            duzinaLabel2.Visible = false; duzinaTextBox2.Visible = false;
            datumPremeraLabel.Visible = false; datumPremeraTextBox.Visible = false;
            iDGeometraLabel1.Visible = false; iDGeometraTextBox1.Visible = false;
            iDKlijentaLabel1.Visible = false; iDKlijentaTextBox1.Visible = false;

            iDZaposlenogLabel.Visible = false; iDZaposlenogTextBox.Visible = false;
            imeZaposlenogLabel.Visible = false; imeZaposlenogTextBox.Visible = false;
            prezimeZaposlenogLabel.Visible = false; prezimeZaposlenogTextBox.Visible = false;
            adresaLabel3.Visible = false; adresaTextBox3.Visible = false;
            telefonLabel.Visible = false; telefonTextBox.Visible = false;
            iDPlataLabel2.Visible = false; iDPlataTextBox2.Visible = false;
        }

        private void Izbrisati_Click(object sender, EventArgs e)
        {
            string msg = "Da li zelite ovo obrisati?";
            string naslov = "Seminarski - Biblioteka";

            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon ico = MessageBoxIcon.Question;

            DialogResult result;
            result = MessageBox.Show(this, msg, naslov, button, ico);
            if (result == DialogResult.Yes)
            {
                if (GlavniComboBox.SelectedItem == "Geometar")
                {
                    this.geometarBindingSource.RemoveCurrent();
                    this.geometarBindingSource.EndEdit();
                    this.geometarTableAdapter.Update(this.dataBaseDataSet.Geometar);
                    this.geometarTableAdapter.Fill(this.dataBaseDataSet.Geometar);
                }
                else if (GlavniComboBox.SelectedItem == "Klijent")
                {
                    this.klijentBindingSource.RemoveCurrent();
                    this.klijentBindingSource.EndEdit();
                    this.klijentTableAdapter.Update(this.dataBaseDataSet.Klijent);
                    this.klijentTableAdapter.Fill(this.dataBaseDataSet.Klijent);
                }
                else if (GlavniComboBox.SelectedItem == "Objekat")
                {
                    this.objekatBindingSource.RemoveCurrent();
                    this.objekatBindingSource.EndEdit();
                    this.objekatTableAdapter.Update(this.dataBaseDataSet.Objekat);
                    this.objekatTableAdapter.Fill(this.dataBaseDataSet.Objekat);
                }
                else if (GlavniComboBox.SelectedItem == "Parcela")
                {
                    this.parcelaBindingSource.RemoveCurrent();
                    this.parcelaBindingSource.EndEdit();
                    this.parcelaTableAdapter.Update(this.dataBaseDataSet.Parcela);
                    this.parcelaTableAdapter.Fill(this.dataBaseDataSet.Parcela);
                }
                else if (GlavniComboBox.SelectedItem == "Premer")
                {
                    this.premerBindingSource.RemoveCurrent();
                    this.premerBindingSource.EndEdit();
                    this.premerTableAdapter.Update(this.dataBaseDataSet.Premer);
                    this.premerTableAdapter.Fill(this.dataBaseDataSet.Premer);
                }
                else if (GlavniComboBox.SelectedItem == "Plata")
                {
                    this.plataBindingSource.RemoveCurrent();
                    this.plataBindingSource.EndEdit();
                    this.plataTableAdapter.Update(this.dataBaseDataSet.Plata);
                    this.plataTableAdapter.Fill(this.dataBaseDataSet.Plata);
                }
                else if (GlavniComboBox.SelectedItem == "Zaposleni")
                {
                    this.zaposleniBindingSource.RemoveCurrent();
                    this.zaposleniBindingSource.EndEdit();
                    this.zaposleniTableAdapter.Update(this.dataBaseDataSet.Zaposleni);
                    this.zaposleniTableAdapter.Fill(this.dataBaseDataSet.Zaposleni);
                }

            }
            else
            {
                return;
            }
        }
        private void Dodati_Click(object sender, EventArgs e)
        {
            if (GlavniComboBox.SelectedItem == "Geometar") { geometarBindingSource.AddNew(); }
            else if (GlavniComboBox.SelectedItem == "Klijent") { klijentBindingSource.AddNew(); }
            else if (GlavniComboBox.SelectedItem == "Objekat") { objekatBindingSource.AddNew(); }
            else if (GlavniComboBox.SelectedItem == "Parcela") { parcelaBindingSource.AddNew(); }
            else if (GlavniComboBox.SelectedItem == "Plata") { plataBindingSource.AddNew(); }
            else if (GlavniComboBox.SelectedItem == "Premer") { premerBindingSource.AddNew(); }
            else if (GlavniComboBox.SelectedItem == "Zaposleni") { zaposleniBindingSource.AddNew(); }
        }
        private void Sacuvati_Click(object sender, EventArgs e)
        {
            string msg = "Da li zelite ovo sacuvati?";
            string naslov = "Seminarski - Biblioteka";

            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon ico = MessageBoxIcon.Question;

            DialogResult result;
            result = MessageBox.Show(this, msg, naslov, button, ico);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (GlavniComboBox.SelectedItem == "Geometar")
                    {
                        this.geometarBindingSource.EndEdit();
                        this.geometarTableAdapter.Update(this.dataBaseDataSet.Geometar);
                        this.geometarTableAdapter.Fill(this.dataBaseDataSet.Geometar);
                        MessageBox.Show("Sacuvano!", naslov, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (GlavniComboBox.SelectedItem == "Klijent")
                    {
                        this.klijentBindingSource.EndEdit();
                        this.klijentTableAdapter.Update(this.dataBaseDataSet.Klijent);
                        this.klijentTableAdapter.Fill(this.dataBaseDataSet.Klijent);
                        MessageBox.Show("Sacuvano!", naslov, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (GlavniComboBox.SelectedItem == "Objekat")
                    {
                        this.objekatBindingSource.EndEdit();
                        this.objekatTableAdapter.Update(this.dataBaseDataSet.Objekat);
                        this.objekatTableAdapter.Fill(this.dataBaseDataSet.Objekat);
                        MessageBox.Show("Sacuvano!", naslov, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (GlavniComboBox.SelectedItem == "Parcela")
                    {
                        this.parcelaBindingSource.EndEdit();
                        this.parcelaTableAdapter.Update(this.dataBaseDataSet.Parcela);
                        this.parcelaTableAdapter.Fill(this.dataBaseDataSet.Parcela);
                        MessageBox.Show("Sacuvano!", naslov, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (GlavniComboBox.SelectedItem == "Zaposleni")
                    {
                        this.zaposleniBindingSource.EndEdit();
                        this.zaposleniTableAdapter.Update(this.dataBaseDataSet.Zaposleni);
                        this.zaposleniTableAdapter.Fill(this.dataBaseDataSet.Zaposleni);
                        MessageBox.Show("Sacuvano!", naslov, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (GlavniComboBox.SelectedItem == "Plata")
                    {
                        this.plataBindingSource.EndEdit();
                        this.plataTableAdapter.Update(this.dataBaseDataSet.Plata);
                        this.plataTableAdapter.Fill(this.dataBaseDataSet.Plata);
                        MessageBox.Show("Sacuvano!", naslov, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (GlavniComboBox.SelectedItem == "Premer")
                    {
                        this.premerBindingSource.EndEdit();
                        this.premerTableAdapter.Update(this.dataBaseDataSet.Premer);
                        this.premerTableAdapter.Fill(this.dataBaseDataSet.Premer);
                        MessageBox.Show("Sacuvano!", naslov, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Desila se greska! \nMolimo vas da proverite moguce opsege za date vrednosti pa pokusajte ponovo!");
                }

            }
            else
            {
                return;
            }
        }
        private void Iskljuciti_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GlavnaTXTPretraga_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            int counter = PretragaItemComboBox.SelectedIndex;

            if (GlavniComboBox.SelectedItem == "Geometar")
            {
                bs.DataSource = GeometarView.DataSource;
                bs.Filter = GeometarView.Columns[counter].HeaderText.ToString() + " LIKE '" + GlavnaTXTPretraga.Text.ToString() + "%'";
            }
            else if (GlavniComboBox.SelectedItem == "Klijent")
            {
                bs.DataSource = KlijentView.DataSource;
                bs.Filter = KlijentView.Columns[counter].HeaderText.ToString() + " LIKE '" + GlavnaTXTPretraga.Text.ToString() + "%'";
            }
            else if (GlavniComboBox.SelectedItem == "Objekat")
            {
                bs.DataSource = ObjekatView.DataSource;
                bs.Filter = ObjekatView.Columns[counter].HeaderText.ToString() + " LIKE '" + GlavnaTXTPretraga.Text.ToString() + "%'";
            }
            else if (GlavniComboBox.SelectedItem == "Parcela")
            {
                bs.DataSource = ParcelaView.DataSource;
                bs.Filter = ParcelaView.Columns[counter].HeaderText.ToString() + " LIKE '" + GlavnaTXTPretraga.Text.ToString() + "%'";
            }
            else if (GlavniComboBox.SelectedItem == "Premer")
            {
                bs.DataSource = PremerView.DataSource;
                bs.Filter = PremerView.Columns[counter].HeaderText.ToString() + " LIKE '" + GlavnaTXTPretraga.Text.ToString() + "%'";
            }
            else if (GlavniComboBox.SelectedItem == "Plata")
            {
                bs.DataSource = PlataView.DataSource;
                bs.Filter = PlataView.Columns[counter].HeaderText.ToString() + " LIKE '" + GlavnaTXTPretraga.Text.ToString() + "%'";
            }
            else if (GlavniComboBox.SelectedItem == "Zaposleni")
            {
                bs.DataSource = ZaposleniView.DataSource;
                bs.Filter = ZaposleniView.Columns[counter].HeaderText.ToString() + " LIKE '" + GlavnaTXTPretraga.Text.ToString() + "%'";
            }
        }

        private void pretragaGeometra() {
            iDGeometraTextBox.Visible = true; iDGeometraLabel.Visible = true;
            imeGeometraTextBox.Visible = true; imeGeometraLabel.Visible = true;
            prezimeGeometraLabel.Visible = true; prezimeGeometraTextBox.Visible = true;
            adresaLabel.Visible = true; adresaTextBox.Visible = true;
            brojTelefonaLabel.Visible = true; brojTelefonaTextBox.Visible = true;
            iDPlataLabel.Visible = true; iDPlataTextBox.Visible = true;
        }
        private void pretragaKlijent() {
            iDKlijentLabel.Visible = true; iDKlijentTextBox.Visible = true;
            imeLabel.Visible = true; imeTextBox.Visible = true;
            prezimeLabel.Visible = true; prezimeTextBox.Visible = true;
            brojTelefonaLabel1.Visible = true; brojTelefonaTextBox1.Visible = true;
            adresaLabel1.Visible = true; adresaTextBox1.Visible = true;
        }
        private void pretragaObjekat() 
        {
            iDObjektaLabel.Visible = true; iDObjektaTextBox.Visible = true;
            iDKlijentaLabel.Visible = true; iDKlijentaTextBox.Visible = true;
            brojParceleLabel.Visible = true; brojParceleTextBox.Visible = true;
            brojObjektaLabel.Visible = true; brojObjektaTextBox.Visible = true;
            sirinaLabel.Visible = true; sirinaTextBox.Visible = true;
            duzinaLabel.Visible = true; duzinaTextBox.Visible = true;
            ozakonjenjeLabel.Visible = true; ozakonjenjeCheckBox.Visible = true;
        }
        private void pretragaParcela() {
            brojParceleLabel1.Visible = true; brojParceleTextBox1.Visible = true;
            iDKIjentaLabel.Visible = true; iDKIjentaTextBox.Visible = true;
            iDObjektaLabel1.Visible = true; iDObjektaTextBox1.Visible = true;
            adresaLabel2.Visible = true; adresaTextBox2.Visible = true;
            imeKlijentaLabel.Visible = true; imeKlijentaTextBox.Visible = true;
            prezimeKlijentaLabel.Visible = true; prezimeKlijentaTextBox.Visible = true;
            sirinaLabel1.Visible = true; sirinaTextBox1.Visible = true;
            duzinaLabel1.Visible = true; duzinaTextBox1.Visible = true;
        }
        private void pretragaPlata() {
            iDPlataLabel1.Visible = true; iDPlataTextBox1.Visible = true;
            iznosPlateLabel.Visible = true; iznosPlateTextBox.Visible = true;
        }
        private void pretragaPremer() {
            iDPremerLabel.Visible = true; iDPremerTextBox.Visible = true;
            brojParceleLabel2.Visible = true; brojParceleTextBox2.Visible = true;
            sirinaLabel2.Visible = true; sirinaTextBox2.Visible = true;
            duzinaLabel2.Visible = true; duzinaTextBox2.Visible = true;
            datumPremeraLabel.Visible = true; datumPremeraTextBox.Visible = true;
            iDGeometraLabel1.Visible = true; iDGeometraTextBox1.Visible = true;
            iDKlijentaLabel1.Visible = true; iDKlijentaTextBox1.Visible = true; 
        }
        private void pretragaZaposleni() {
            iDZaposlenogLabel.Visible = true; iDZaposlenogTextBox.Visible = true;
            imeZaposlenogLabel.Visible = true; imeZaposlenogTextBox.Visible = true;
            prezimeZaposlenogLabel.Visible = true; prezimeZaposlenogTextBox.Visible = true;
            adresaLabel3.Visible = true; adresaTextBox3.Visible = true;
            telefonLabel.Visible = true; telefonTextBox.Visible = true;
            iDPlataLabel2.Visible = true; iDPlataTextBox2.Visible = true;
        }

    }
}
