namespace BigSixPlotter
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
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.checkedListBoxTeams = new System.Windows.Forms.CheckedListBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 0F;
            this.formsPlot1.Location = new System.Drawing.Point(12, 35);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1190, 503);
            this.formsPlot1.TabIndex = 0;
            // 
            // checkedListBoxTeams
            // 
            this.checkedListBoxTeams.FormattingEnabled = true;
            this.checkedListBoxTeams.Location = new System.Drawing.Point(1208, 78);
            this.checkedListBoxTeams.Name = "checkedListBoxTeams";
            this.checkedListBoxTeams.Size = new System.Drawing.Size(120, 349);
            this.checkedListBoxTeams.TabIndex = 1;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(1208, 433);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(120, 64);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Confirm selection";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 655);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.checkedListBoxTeams);
            this.Controls.Add(this.formsPlot1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.CheckedListBox checkedListBoxTeams;
        private System.Windows.Forms.Button buttonUpdate;
    }
}

