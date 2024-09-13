namespace labo3_chiffrement_etienne_malenfant
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            algorithme = new ComboBox();
            texteUtilisateur = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            texteTransforme = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            btnEncrrypter = new Button();
            btnDecrypter = new Button();
            cles = new RichTextBox();
            SuspendLayout();
            // 
            // algorithme
            // 
            algorithme.FormattingEnabled = true;
            algorithme.Location = new Point(91, 19);
            algorithme.Name = "algorithme";
            algorithme.Size = new Size(121, 23);
            algorithme.TabIndex = 0;
            algorithme.SelectedIndexChanged += algorithme_SelectedIndexChanged;
            // 
            // texteUtilisateur
            // 
            texteUtilisateur.Location = new Point(12, 78);
            texteUtilisateur.Name = "texteUtilisateur";
            texteUtilisateur.Size = new Size(317, 139);
            texteUtilisateur.TabIndex = 2;
            texteUtilisateur.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Algorithme :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(228, 22);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "Clé:";
            // 
            // texteTransforme
            // 
            texteTransforme.Location = new Point(346, 78);
            texteTransforme.Name = "texteTransforme";
            texteTransforme.ReadOnly = true;
            texteTransforme.Size = new Size(313, 139);
            texteTransforme.TabIndex = 7;
            texteTransforme.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 60);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 8;
            label4.Text = "Écrire un message :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(346, 60);
            label5.Name = "label5";
            label5.Size = new Size(114, 15);
            label5.TabIndex = 9;
            label5.Text = "Message transformé";
            // 
            // btnEncrrypter
            // 
            btnEncrrypter.Location = new Point(12, 228);
            btnEncrrypter.Name = "btnEncrrypter";
            btnEncrrypter.Size = new Size(75, 23);
            btnEncrrypter.TabIndex = 10;
            btnEncrrypter.Text = "Encrypter";
            btnEncrrypter.UseVisualStyleBackColor = true;
            btnEncrrypter.Click += chiffrer_Click;
            // 
            // btnDecrypter
            // 
            btnDecrypter.Location = new Point(93, 228);
            btnDecrypter.Name = "btnDecrypter";
            btnDecrypter.Size = new Size(75, 23);
            btnDecrypter.TabIndex = 11;
            btnDecrypter.Text = "Décrypter";
            btnDecrypter.UseVisualStyleBackColor = true;
            btnDecrypter.Click += dechiffrer_Click;
            // 
            // cles
            // 
            cles.Location = new Point(261, 19);
            cles.Name = "cles";
            cles.ReadOnly = true;
            cles.Size = new Size(398, 38);
            cles.TabIndex = 12;
            cles.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 263);
            Controls.Add(cles);
            Controls.Add(btnDecrypter);
            Controls.Add(btnEncrrypter);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(texteTransforme);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(texteUtilisateur);
            Controls.Add(algorithme);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Chiffrement";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox algorithme;
        private RichTextBox texteUtilisateur;
        private Label label1;
        private Label label2;
        private RichTextBox texteTransforme;
        private Label label4;
        private Label label5;
        private Button btnEncrrypter;
        private Button btnDecrypter;
        private RichTextBox cles;
    }
}
