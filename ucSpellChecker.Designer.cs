namespace Cobra
{
    partial class ucSpellChecker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSpellWord = new System.Windows.Forms.TextBox();
            this.btnGenSuggestion = new System.Windows.Forms.Button();
            this.dgwSuggestions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSuggestions)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSpellWord
            // 
            this.txtSpellWord.Location = new System.Drawing.Point(98, 61);
            this.txtSpellWord.Name = "txtSpellWord";
            this.txtSpellWord.Size = new System.Drawing.Size(211, 20);
            this.txtSpellWord.TabIndex = 0;
            // 
            // btnGenSuggestion
            // 
            this.btnGenSuggestion.Location = new System.Drawing.Point(315, 58);
            this.btnGenSuggestion.Name = "btnGenSuggestion";
            this.btnGenSuggestion.Size = new System.Drawing.Size(96, 23);
            this.btnGenSuggestion.TabIndex = 1;
            this.btnGenSuggestion.Text = "Check";
            this.btnGenSuggestion.UseVisualStyleBackColor = true;
            this.btnGenSuggestion.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgwSuggestions
            // 
            this.dgwSuggestions.AllowUserToAddRows = false;
            this.dgwSuggestions.AllowUserToDeleteRows = false;
            this.dgwSuggestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSuggestions.Location = new System.Drawing.Point(19, 123);
            this.dgwSuggestions.Name = "dgwSuggestions";
            this.dgwSuggestions.ReadOnly = true;
            this.dgwSuggestions.Size = new System.Drawing.Size(392, 282);
            this.dgwSuggestions.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type Word";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Spell Checking";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(95, 97);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 6;
            // 
            // ucSpellChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwSuggestions);
            this.Controls.Add(this.btnGenSuggestion);
            this.Controls.Add(this.txtSpellWord);
            this.Name = "ucSpellChecker";
            this.Size = new System.Drawing.Size(427, 421);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSuggestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSpellWord;
        private System.Windows.Forms.Button btnGenSuggestion;
        private System.Windows.Forms.DataGridView dgwSuggestions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMessage;
    }
}
