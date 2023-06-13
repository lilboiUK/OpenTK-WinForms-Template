namespace OpenTK_WinForms_Template
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            glParentPanel = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // glParentPanel
            // 
            glParentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            glParentPanel.BackColor = SystemColors.AppWorkspace;
            glParentPanel.BorderStyle = BorderStyle.Fixed3D;
            glParentPanel.Location = new Point(12, 12);
            glParentPanel.Name = "glParentPanel";
            glParentPanel.Size = new Size(960, 937);
            glParentPanel.TabIndex = 1;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1;
            timer.Tick += OnTimerTick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 961);
            Controls.Add(glParentPanel);
            Name = "MainForm";
            Text = "Form";
            Load += OnFormLoad;
            SizeChanged += OnFormResize;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel glParentPanel;
        private System.Windows.Forms.Timer timer;
        private BindingSource bindingSource1;
    }
}