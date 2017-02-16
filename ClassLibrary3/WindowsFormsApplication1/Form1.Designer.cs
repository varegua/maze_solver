namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.button1Hyde = new System.Windows.Forms.Button();
            //Page 2
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(84, 149);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(106, 38);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "Quitter";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(84, 82);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(106, 39);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Jouer";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // button1
            // 
            this.button1Hyde.Location = new System.Drawing.Point(116, 26);
            this.button1Hyde.Name = "button1";
            this.button1Hyde.Size = new System.Drawing.Size(75, 23);
            this.button1Hyde.TabIndex = 2;
            this.button1Hyde.Text = "button1";
            this.button1Hyde.UseVisualStyleBackColor = true;
            this.button1Hyde.Hide();
  

            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1Hyde);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnQuit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        private void DisplayPage2()
        {
            this.components = new System.ComponentModel.Container();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.Title = new System.Windows.Forms.Label();
            this.lblDifficult = new System.Windows.Forms.Label();
            this.btnGame = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();

            this.SuspendLayout();
            //Page 2 //
            // 
            // comboBox1
            // 
            this.cbDifficulty.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.gameBindingSource, "Difficulty", true));
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Location = new System.Drawing.Point(82, 143);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(121, 21);
            this.cbDifficulty.TabIndex = 0;

            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(98, 18);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(81, 33);
            this.Title.TabIndex = 1;
            this.Title.Text = "Maze";
            // 
            // lblDifficult
            // 
            this.lblDifficult.AutoSize = true;
            this.lblDifficult.Location = new System.Drawing.Point(79, 127);
            this.lblDifficult.Name = "lblDifficult";
            this.lblDifficult.Size = new System.Drawing.Size(48, 13);
            this.lblDifficult.TabIndex = 2;
            this.lblDifficult.Text = "Difficulté";
            // 
            // button1
            // 
            this.btnGame.Location = new System.Drawing.Point(104, 194);
            this.btnGame.Name = "button1";
            this.btnGame.Size = new System.Drawing.Size(75, 23);
            this.btnGame.TabIndex = 3;
            this.btnGame.Text = "Jouer";
            this.btnGame.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nom";
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(ClassLibrary3.mazeSolverService.Game);
            // 
            this.Controls.Remove(this.button1Hyde);
            this.Controls.Remove(this.btnPlay);
            this.Controls.Remove(this.btnQuit);

            this.Controls.Add(this.Title);
            this.Controls.Add(this.lblDifficult);
            this.Controls.Add(this.btnGame);
            this.Controls.Add(this.cbDifficulty);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
        }


        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button button1Hyde;

        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label lblDifficult;
        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource gameBindingSource;
    }
}

