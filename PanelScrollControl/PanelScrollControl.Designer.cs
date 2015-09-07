namespace Cintio.PanelScrollControl
{
    partial class PanelScrollControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelScrollControl));
            this._btnScrollUp = new System.Windows.Forms.Button();
            this._btnScrollDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnScrollUp
            // 
            this._btnScrollUp.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnScrollUp.Image = ((System.Drawing.Image)(resources.GetObject("_btnScrollUp.Image")));
            this._btnScrollUp.Location = new System.Drawing.Point(0, 0);
            this._btnScrollUp.Name = "_btnScrollUp";
            this._btnScrollUp.Size = new System.Drawing.Size(150, 12);
            this._btnScrollUp.TabIndex = 19;
            this._btnScrollUp.UseVisualStyleBackColor = true;
            this._btnScrollUp.MouseLeave += new System.EventHandler(this._btnScrollUp_MouseLeave);
            this._btnScrollUp.MouseHover += new System.EventHandler(this._btnScrollUp_MouseHover);
            // 
            // _btnScrollDown
            // 
            this._btnScrollDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnScrollDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnScrollDown.Image = ((System.Drawing.Image)(resources.GetObject("_btnScrollDown.Image")));
            this._btnScrollDown.Location = new System.Drawing.Point(0, 138);
            this._btnScrollDown.Name = "_btnScrollDown";
            this._btnScrollDown.Size = new System.Drawing.Size(150, 12);
            this._btnScrollDown.TabIndex = 20;
            this._btnScrollDown.UseVisualStyleBackColor = true;
            this._btnScrollDown.MouseLeave += new System.EventHandler(this._btnScrollDown_MouseLeave);
            this._btnScrollDown.MouseHover += new System.EventHandler(this._btnScrollDown_MouseHover);
            // 
            // PanelScrollControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnScrollDown);
            this.Controls.Add(this._btnScrollUp);
            this.Name = "PanelScrollControl";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button _btnScrollUp;
        public System.Windows.Forms.Button _btnScrollDown;


    }
}
