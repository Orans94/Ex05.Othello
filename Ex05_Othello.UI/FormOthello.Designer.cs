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
            this.flowLayoutPanelBoard.Location = new System.Drawing.Point(14, 15);
            this.flowLayoutPanelBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelBoard.Name = "flowLayoutPanelBoard";
            this.flowLayoutPanelBoard.Size = new System.Drawing.Size(465, 532);
            this.flowLayoutPanelBoard.TabIndex = 0;
            this.flowLayoutPanelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelBoard_Paint);
            // 
            // FormOthello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 562);
            this.Controls.Add(this.flowLayoutPanelBoard);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormOthello";
            this.Text = "FormOthello";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBoard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBoard;
    }
}