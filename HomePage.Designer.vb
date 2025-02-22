<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomePage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LotTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LensMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BoxPackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductionReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PouchReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductionPlanUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblHomeHeadingName = New System.Windows.Forms.Label()
        Me.BoxReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.LblHomeHeadingName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(829, 127)
        Me.Panel1.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Indigo
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(291, 29)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "APPASAMY ASSOCIATES"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Location = New System.Drawing.Point(3, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(826, 27)
        Me.Panel2.TabIndex = 56
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ProductionPlanUploadToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(826, 24)
        Me.MenuStrip1.TabIndex = 55
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterToolStripMenuItem
        '
        Me.MasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LotTypeToolStripMenuItem, Me.LensMasterToolStripMenuItem, Me.BoxPackingToolStripMenuItem})
        Me.MasterToolStripMenuItem.Name = "MasterToolStripMenuItem"
        Me.MasterToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.MasterToolStripMenuItem.Text = "Warehouse"
        '
        'LotTypeToolStripMenuItem
        '
        Me.LotTypeToolStripMenuItem.Name = "LotTypeToolStripMenuItem"
        Me.LotTypeToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.LotTypeToolStripMenuItem.Text = "Lathe"
        '
        'LensMasterToolStripMenuItem
        '
        Me.LensMasterToolStripMenuItem.Name = "LensMasterToolStripMenuItem"
        Me.LensMasterToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.LensMasterToolStripMenuItem.Text = "Pouch Paking"
        '
        'BoxPackingToolStripMenuItem
        '
        Me.BoxPackingToolStripMenuItem.Name = "BoxPackingToolStripMenuItem"
        Me.BoxPackingToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.BoxPackingToolStripMenuItem.Text = "Box Packing"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductionReportToolStripMenuItem, Me.PouchReportToolStripMenuItem, Me.BoxReportToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'ProductionReportToolStripMenuItem
        '
        Me.ProductionReportToolStripMenuItem.Name = "ProductionReportToolStripMenuItem"
        Me.ProductionReportToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ProductionReportToolStripMenuItem.Text = "Production report"
        '
        'PouchReportToolStripMenuItem
        '
        Me.PouchReportToolStripMenuItem.Name = "PouchReportToolStripMenuItem"
        Me.PouchReportToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.PouchReportToolStripMenuItem.Text = "Pouch report"
        '
        'ProductionPlanUploadToolStripMenuItem
        '
        Me.ProductionPlanUploadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadToolStripMenuItem})
        Me.ProductionPlanUploadToolStripMenuItem.Name = "ProductionPlanUploadToolStripMenuItem"
        Me.ProductionPlanUploadToolStripMenuItem.Size = New System.Drawing.Size(145, 20)
        Me.ProductionPlanUploadToolStripMenuItem.Text = "Production Plan Upload"
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.UploadToolStripMenuItem.Text = "Upload"
        '
        'LblHomeHeadingName
        '
        Me.LblHomeHeadingName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblHomeHeadingName.AutoSize = True
        Me.LblHomeHeadingName.BackColor = System.Drawing.Color.Transparent
        Me.LblHomeHeadingName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LblHomeHeadingName.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHomeHeadingName.ForeColor = System.Drawing.Color.Indigo
        Me.LblHomeHeadingName.Location = New System.Drawing.Point(288, 33)
        Me.LblHomeHeadingName.Name = "LblHomeHeadingName"
        Me.LblHomeHeadingName.Size = New System.Drawing.Size(245, 29)
        Me.LblHomeHeadingName.TabIndex = 54
        Me.LblHomeHeadingName.Text = "Lens Tracking System"
        '
        'BoxReportToolStripMenuItem
        '
        Me.BoxReportToolStripMenuItem.Name = "BoxReportToolStripMenuItem"
        Me.BoxReportToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.BoxReportToolStripMenuItem.Text = "Box Report"
        '
        'HomePage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(829, 500)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "HomePage"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LotTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LensMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BoxPackingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblHomeHeadingName As System.Windows.Forms.Label
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductionReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PouchReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductionPlanUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BoxReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
