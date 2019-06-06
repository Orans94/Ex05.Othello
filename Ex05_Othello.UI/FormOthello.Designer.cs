namespace Ex05_Othello.UI
{
    partial class FormOthello
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelBoard
            // 
            this.flowLayoutPanelBoard.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelBoard.Name = "flowLayoutPanelBoard";
            this.flowLayoutPanelBoard.Size = new System.Drawing.Size(413, 426);
            this.flowLayoutPanelBoard.TabIndex = 0;
            // 
            // FormOthello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 450);
            this.Controls.Add(this.flowLayoutPanelBoard);
            this.Name = "FormOthello";
            this.Text = "FormOthello";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBoard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBoard;
    }
}