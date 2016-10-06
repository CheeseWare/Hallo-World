using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hallo_World
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Globale variablen 
            // x für die Größe des Arrays
            int x;
            // laufvariable als Laufvariale
            int laufvariable = 0;

        // Globales Array ohne Festen Wert
        double[] zahlenarray;


        private void cmdArraybereich_Click(object sender, EventArgs e){
            // 
            double b;
            bool isNumeric = double.TryParse("txtArraybereich", out b);

            // Prüfen der gültigkeit der Variable 
            if (txtArraybereich.Text == "" || isNumeric ) {
                // Fals Falsche eingabe MEthode beenden und Fehler Nachricht ausgeben
                MessageBox.Show("Eror 0210:  Der eingegebene Wert darf nicht leer oder kleiner als 2 sein");
                return;
            }
            // Wenn die Variable gültig ist
            else {
                // Umwandeln der eingegebenen Zahl in ein Int Wert
                x = Convert.ToInt32(txtArraybereich.Text);

                // Dem Array einen Wert geben
                zahlenarray = new double [x]; 

                // Array Button und Textfeld sperren 
                cmdArraybereich.Enabled = false;
                txtArraybereich.Enabled = false;

                // Werteingabe Button und Textfeld freigeben
                cmdWertzuweisung.Enabled = true;
                txtWertzuweisung.Enabled = true;

                // Fortschritt anzeigen 
                labFortschritt.Text = laufvariable + " von " + x + " Werten eingegeben.";
            }
            // Ende Array Button
        }

        private void cmdWertzuweisung_Click(object sender, EventArgs e){
            // Prüfen ob die eingabe leer ist methode beenden
            if (txtWertzuweisung.Text == "") return;

            // Dem array die Zahl Umgewandelt übergeben
            zahlenarray[laufvariable] = Convert.ToDouble(txtWertzuweisung.Text);

            // Das Eingabefeld leere
            txtWertzuweisung.Text = "";

            // Laufvariable hochzählen
            laufvariable++;

            // Hochzählen des fortschrittes
            labFortschritt.Text = laufvariable + " von " + x + " Werten eingegeben.";

            // Wenn alle Werte eingegeben wurden dann....
            if (x == laufvariable){
                // ...  Werteingabe Button und Textfeld sperren
                cmdWertzuweisung.Enabled = false;
                txtWertzuweisung.Enabled = false;

                // textfald ausgabe zum rauskopieren Freigeben
                txtGroesstezahl.Enabled = true;

                // Größte Zahl festlegen und ausgeben
                // Mehthode '.Max' Gibt den größten Double wert des arrays wieder
                txtGroesstezahl.Text = Convert.ToString(zahlenarray.Max());
                
                // Sichtbarmachen der Labels und die eingegebenen Zahlen anzuzeigen
                labDiezahlen.Visible = true;
                labAusgabeAlles.Visible = true;

                // Variable für die Labelläange und den abzugswert
                int laengelab, abzug=0;

                // Schleife um alle Werte einzugeben
                for (int a = 0; a < x; a++ ){
                    labDiezahlen.Text += "" + zahlenarray[a] + " ; ";
                    laengelab = labDiezahlen.Text.Length - abzug;

                    // Wenn das Label zu lang ist dann einen Zeilenumbruch einstzen
                    if (laengelab >= 20){
                        labDiezahlen.Text += "\n";
                        abzug += 20;
                    }
                }
                // Neustart Button sichtbarmachen
                cmdReset.Visible = true;
            }
            // Ende Wertezuweisung Button
        }

        private void cmdReset_Click(object sender, EventArgs e){
            // Das Array leeren
            Array.Clear(zahlenarray, 0, x);

            // Array Button und Textfeld freigeben 
            cmdArraybereich.Enabled = true;
            txtArraybereich.Enabled = true;

            // Werteingabe Button und Textfeld sperren
            cmdWertzuweisung.Enabled = false;
            txtWertzuweisung.Enabled = false;

            // Der Größte wert wird freigegeben
            txtGroesstezahl.Enabled = false;

            // Alle textfelder leeren
            txtArraybereich.Text = "";
            txtGroesstezahl.Text = "";
            txtWertzuweisung.Text = "";

            // Alle ausgaben leeren
            labDiezahlen.Text = "";
            labFortschritt.Text = "";

            // alle zahlen unsichtbarmachen
            labDiezahlen.Visible = false;
            labAusgabeAlles.Visible = false;

            // Fortschritt leeren
            labFortschritt.Text = "";

            // Globale Variable 'laufvariable' zurücksetzen
            laufvariable = 0;

            // Reset Button Unsichtbar machen
            cmdReset.Visible = false;

            // Ende Reset Button
        }
    }
}
