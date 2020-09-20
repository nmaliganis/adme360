namespace adme360.suite.ui.Views.Modules
{
    partial class UcNotifications
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
            this.laytCntrlGrpReportsContainer = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.grCntrlNotificationVehicles = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grCntrlNotificationSensors = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layCntrlNotificationsVehicles = new DevExpress.XtraLayout.LayoutControl();
            this.layCntrlGrpNotificationsVehicles = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layCntrlNotificationsSensors = new DevExpress.XtraLayout.LayoutControl();
            this.layCntrlGrpNotificationsSensors = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.laytCntrlGrpReportsContainer)).BeginInit();
            this.laytCntrlGrpReportsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCntrlNotificationVehicles)).BeginInit();
            this.grCntrlNotificationVehicles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCntrlNotificationSensors)).BeginInit();
            this.grCntrlNotificationSensors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlNotificationsVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlGrpNotificationsVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlNotificationsSensors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlGrpNotificationsSensors)).BeginInit();
            this.SuspendLayout();
            // 
            // laytCntrlGrpReportsContainer
            // 
            this.laytCntrlGrpReportsContainer.Controls.Add(this.grCntrlNotificationSensors);
            this.laytCntrlGrpReportsContainer.Controls.Add(this.grCntrlNotificationVehicles);
            this.laytCntrlGrpReportsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laytCntrlGrpReportsContainer.Location = new System.Drawing.Point(0, 0);
            this.laytCntrlGrpReportsContainer.Name = "laytCntrlGrpReportsContainer";
            this.laytCntrlGrpReportsContainer.Root = this.layoutControlGroup1;
            this.laytCntrlGrpReportsContainer.Size = new System.Drawing.Size(1498, 1163);
            this.laytCntrlGrpReportsContainer.TabIndex = 0;
            this.laytCntrlGrpReportsContainer.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1498, 1163);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // grCntrlNotificationVehicles
            // 
            this.grCntrlNotificationVehicles.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.grCntrlNotificationVehicles.AppearanceCaption.Options.UseFont = true;
            this.grCntrlNotificationVehicles.Controls.Add(this.layCntrlNotificationsVehicles);
            this.grCntrlNotificationVehicles.Location = new System.Drawing.Point(12, 12);
            this.grCntrlNotificationVehicles.Name = "grCntrlNotificationVehicles";
            this.grCntrlNotificationVehicles.Size = new System.Drawing.Size(1474, 523);
            this.grCntrlNotificationVehicles.TabIndex = 4;
            this.grCntrlNotificationVehicles.Text = "Ειδοποιήσεις Οχημάτων";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grCntrlNotificationVehicles;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1478, 527);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // grCntrlNotificationSensors
            // 
            this.grCntrlNotificationSensors.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.grCntrlNotificationSensors.AppearanceCaption.Options.UseFont = true;
            this.grCntrlNotificationSensors.Controls.Add(this.layCntrlNotificationsSensors);
            this.grCntrlNotificationSensors.Location = new System.Drawing.Point(12, 539);
            this.grCntrlNotificationSensors.Name = "grCntrlNotificationSensors";
            this.grCntrlNotificationSensors.Size = new System.Drawing.Size(1474, 612);
            this.grCntrlNotificationSensors.TabIndex = 5;
            this.grCntrlNotificationSensors.Text = "Ειδοποιήσεις Αισθητήρων ";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grCntrlNotificationSensors;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 527);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1478, 616);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layCntrlNotificationsVehicles
            // 
            this.layCntrlNotificationsVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layCntrlNotificationsVehicles.Location = new System.Drawing.Point(2, 23);
            this.layCntrlNotificationsVehicles.Name = "layCntrlNotificationsVehicles";
            this.layCntrlNotificationsVehicles.Root = this.layCntrlGrpNotificationsVehicles;
            this.layCntrlNotificationsVehicles.Size = new System.Drawing.Size(1470, 498);
            this.layCntrlNotificationsVehicles.TabIndex = 0;
            this.layCntrlNotificationsVehicles.Text = "layoutControl1";
            // 
            // layCntrlGrpNotificationsVehicles
            // 
            this.layCntrlGrpNotificationsVehicles.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layCntrlGrpNotificationsVehicles.GroupBordersVisible = false;
            this.layCntrlGrpNotificationsVehicles.Name = "layCntrlGrpNotificationsVehicles";
            this.layCntrlGrpNotificationsVehicles.Size = new System.Drawing.Size(1470, 498);
            this.layCntrlGrpNotificationsVehicles.TextVisible = false;
            // 
            // layCntrlNotificationsSensors
            // 
            this.layCntrlNotificationsSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layCntrlNotificationsSensors.Location = new System.Drawing.Point(2, 23);
            this.layCntrlNotificationsSensors.Name = "layCntrlNotificationsSensors";
            this.layCntrlNotificationsSensors.Root = this.layCntrlGrpNotificationsSensors;
            this.layCntrlNotificationsSensors.Size = new System.Drawing.Size(1470, 587);
            this.layCntrlNotificationsSensors.TabIndex = 0;
            this.layCntrlNotificationsSensors.Text = "layoutControl1";
            // 
            // layCntrlGrpNotificationsSensors
            // 
            this.layCntrlGrpNotificationsSensors.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layCntrlGrpNotificationsSensors.GroupBordersVisible = false;
            this.layCntrlGrpNotificationsSensors.Name = "layCntrlGrpNotificationsSensors";
            this.layCntrlGrpNotificationsSensors.Size = new System.Drawing.Size(1470, 587);
            this.layCntrlGrpNotificationsSensors.TextVisible = false;
            // 
            // UcNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.laytCntrlGrpReportsContainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcNotifications";
            this.Size = new System.Drawing.Size(1498, 1163);
            ((System.ComponentModel.ISupportInitialize)(this.laytCntrlGrpReportsContainer)).EndInit();
            this.laytCntrlGrpReportsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCntrlNotificationVehicles)).EndInit();
            this.grCntrlNotificationVehicles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCntrlNotificationSensors)).EndInit();
            this.grCntrlNotificationSensors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlNotificationsVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlGrpNotificationsVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlNotificationsSensors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCntrlGrpNotificationsSensors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl laytCntrlGrpReportsContainer;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl grCntrlNotificationSensors;
        private DevExpress.XtraEditors.GroupControl grCntrlNotificationVehicles;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControl layCntrlNotificationsSensors;
        private DevExpress.XtraLayout.LayoutControlGroup layCntrlGrpNotificationsSensors;
        private DevExpress.XtraLayout.LayoutControl layCntrlNotificationsVehicles;
        private DevExpress.XtraLayout.LayoutControlGroup layCntrlGrpNotificationsVehicles;
    }
}
