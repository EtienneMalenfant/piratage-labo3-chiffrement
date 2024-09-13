using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 2. Un vecteur d'initialisation est une s�quence g�n�r� al�atoirement qui sert de sel � la cl� de chiffrement. 
     * C'est utilis� pour pas qu'un m�me texte chiffr� avec la m�me cl� donne le m�me texte chiffr�.
     * Sinon, on pourrait compar� le texte chiffr� avec un dictionnaire de texte chiffr� pour trouver le texte en clair.
     * On a donc besoin du vecteur d'initialisation pour d�chiffrer le data. */

namespace labo3_chiffrement_etienne_malenfant
{
    public partial class Form1 : Form
    {
        public enum NomAlgorithme
        {
            Aucun, TripleDES, AES, DSA, RSA
        }

        Object algo { get; set; } = null; // Permet de conserver la cl� intacte entre les op�rations
        byte[] hash { get; set; } = null; // Utile pour l'algorithme DSA

        public Form1()
        {
            InitializeComponent();

            algorithme.DataSource = Enum.GetValues(typeof(NomAlgorithme));
            algorithme.SelectedItem = NomAlgorithme.Aucun;
            texteUtilisateur.Focus();
        }

        private void algorithme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algorithme.SelectedValue == NomAlgorithme.Aucun.ToString())
            {
                // On vide le contenu du champ cles
                cles.Text = "";
                algo = null;
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.GenerateKey();
                tdes.GenerateIV(); // On g�n�re aussi un vecteur d'initialisation
                cles.Text = BitConverter.ToString(tdes.Key) + "   (" + tdes.KeySize + " bits)";
                algo = tdes;
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = new RijndaelManaged();

                // Coder ici : d�terminer et afficher la cl� pour cet algorithme
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.DSA.ToString())
            {
                DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
                this.cles.Text = dsa.ToXmlString(true) + "    (" + dsa.KeySize + " bits)";
                algo = dsa;
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

                // Coder ici : d�terminer et afficher la cl� pour cet algorithme
            }
        }

        private void chiffrer_Click(object sender, EventArgs e)
        {
            if (algorithme.SelectedItem.ToString() == NomAlgorithme.Aucun.ToString())
            {
                // Puisqu'aucun algorithme n'est choisi, on conserve le texte de l'utilisateur en sortie
                this.texteTransforme.Text = this.texteUtilisateur.Text;
                return;
            }

            byte[] donneesBrutes = UTF8Encoding.UTF8.GetBytes(this.texteUtilisateur.Text);
            byte[] donneesTransformees = null;

            if (algorithme.SelectedItem.ToString() == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = (TripleDESCryptoServiceProvider)algo;
                ICryptoTransform encrypteur = tdes.CreateEncryptor(tdes.Key, tdes.IV);
                donneesTransformees = encrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = (RijndaelManaged)algo;
                ICryptoTransform encrypteur = aes.CreateEncryptor(aes.Key, aes.IV);
                donneesTransformees = encrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.DSA.ToString())
            {
                // Coder ici : produire la signature pour cet algorithme
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)algo;
                donneesTransformees = rsa.Encrypt(donneesBrutes, true);
            }

            // On affiche les donn�es chiffr�es � l'utilisateur
            this.texteTransforme.Text = Convert.ToBase64String(donneesTransformees, 0, donneesTransformees.Length);
        }

        private void dechiffrer_Click(object sender, EventArgs e)
        {
            if (algorithme.SelectedItem.ToString() == NomAlgorithme.Aucun.ToString())
            {
                // Puisqu'aucun algorithme n'est choisi, on conserve le texte de l'utilisateur en sortie
                this.texteTransforme.Text = this.texteUtilisateur.Text;
                return;
            }

            byte[] donneesBrutes = Convert.FromBase64String(this.texteUtilisateur.Text);
            byte[] donneesTransformees = null;

            if (algorithme.SelectedItem.ToString() == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = (TripleDESCryptoServiceProvider)algo;
                ICryptoTransform decrypteur = tdes.CreateDecryptor(tdes.Key, tdes.IV);
                donneesTransformees = decrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.AES.ToString())
            {
                // Coder ici : d�chiffrer les donn�es pour cet algorithme
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.DSA.ToString())
            {
                DSACryptoServiceProvider dsa = (DSACryptoServiceProvider)algo;
                this.texteTransforme.Text = (dsa.VerifySignature(hash, donneesBrutes) ? "Signature valide !" : "Signature invalide !");
                return;
            }
            else if (algorithme.SelectedItem.ToString() == NomAlgorithme.RSA.ToString())
            {
                // Coder ici : d�chiffrer les donn�es pour cet algorithme
            }

            // On affiche les donn�es d�chiffr�es � l'utilisateur
            this.texteTransforme.Text = UTF8Encoding.UTF8.GetString(donneesTransformees);
        }
    }
}
