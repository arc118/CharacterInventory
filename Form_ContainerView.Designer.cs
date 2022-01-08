using System;

namespace Character_Inventory
{
    partial class Form_ContainerView
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
            this.treeView_Container = new System.Windows.Forms.TreeView();
            this.button_closeWindow = new System.Windows.Forms.Button();
            this.label_formHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView_Container
            // 
            this.treeView_Container.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.treeView_Container.Location = new System.Drawing.Point(12, 26);
            this.treeView_Container.Name = "treeView_Container";
            this.treeView_Container.Size = new System.Drawing.Size(427, 240);
            this.treeView_Container.TabIndex = 0;
            this.treeView_Container.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_Container_KeyDown);
            this.treeView_Container.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeView_Container_KeyPress);
            // 
            // button_closeWindow
            // 
            this.button_closeWindow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_closeWindow.Location = new System.Drawing.Point(168, 272);
            this.button_closeWindow.Name = "button_closeWindow";
            this.button_closeWindow.Size = new System.Drawing.Size(111, 23);
            this.button_closeWindow.TabIndex = 1;
            this.button_closeWindow.Text = "Close Window";
            this.button_closeWindow.UseVisualStyleBackColor = true;
            this.button_closeWindow.Click += new System.EventHandler(this.button_closeWindow_Click);
            // 
            // label_formHelp
            // 
            this.label_formHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_formHelp.AutoSize = true;
            this.label_formHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_formHelp.Location = new System.Drawing.Point(12, 9);
            this.label_formHelp.Name = "label_formHelp";
            this.label_formHelp.Size = new System.Drawing.Size(312, 13);
            this.label_formHelp.TabIndex = 2;
            this.label_formHelp.Text = "Select Item and then Press \"Enter\" to open webpage.";
            // 
            // Form_ContainerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 301);
            this.Controls.Add(this.label_formHelp);
            this.Controls.Add(this.button_closeWindow);
            this.Controls.Add(this.treeView_Container);
            this.Name = "Form_ContainerView";
            this.Text = "Containers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView treeView_Container;
        private System.Windows.Forms.Button button_closeWindow;
        private System.Windows.Forms.Label label_formHelp;
    }
}