namespace CTP_TRADER
{
    partial class DeepInstrumentView
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
            this.components = new System.ComponentModel.Container();
            this.GridView_DeepInstrumentView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_InstrumentViewRefresh = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_refreshInstrumentView = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_DeepInstrumentView)).BeginInit();
            this.contextMenuStrip_InstrumentViewRefresh.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridView_DeepInstrumentView
            // 
            this.GridView_DeepInstrumentView.AllowUserToAddRows = false;
            this.GridView_DeepInstrumentView.AllowUserToOrderColumns = true;
            this.GridView_DeepInstrumentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView_DeepInstrumentView.ContextMenuStrip = this.contextMenuStrip_InstrumentViewRefresh;
            this.GridView_DeepInstrumentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView_DeepInstrumentView.Location = new System.Drawing.Point(0, 0);
            this.GridView_DeepInstrumentView.Name = "GridView_DeepInstrumentView";
            this.GridView_DeepInstrumentView.ReadOnly = true;
            this.GridView_DeepInstrumentView.RowTemplate.Height = 23;
            this.GridView_DeepInstrumentView.Size = new System.Drawing.Size(998, 647);
            this.GridView_DeepInstrumentView.TabIndex = 0;
            // 
            // contextMenuStrip_InstrumentViewRefresh
            // 
            this.contextMenuStrip_InstrumentViewRefresh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_refreshInstrumentView});
            this.contextMenuStrip_InstrumentViewRefresh.Name = "contextMenuStrip_InvestorPositionDetail";
            this.contextMenuStrip_InstrumentViewRefresh.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip_InstrumentViewRefresh.Size = new System.Drawing.Size(95, 26);
            // 
            // toolStripMenuItem_refreshInstrumentView
            // 
            this.toolStripMenuItem_refreshInstrumentView.Name = "toolStripMenuItem_refreshInstrumentView";
            this.toolStripMenuItem_refreshInstrumentView.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_refreshInstrumentView.Text = "刷新";
            this.toolStripMenuItem_refreshInstrumentView.Click += new System.EventHandler(this.toolStripMenuItem_refreshInstrumentView_Click);
            // 
            // DeepInstrumentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 647);
            this.Controls.Add(this.GridView_DeepInstrumentView);
            this.Name = "DeepInstrumentView";
            this.Text = "行情查看";
            this.Load += new System.EventHandler(this.DeepInstrumentView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView_DeepInstrumentView)).EndInit();
            this.contextMenuStrip_InstrumentViewRefresh.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView_DeepInstrumentView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_InstrumentViewRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_refreshInstrumentView;
    }
}