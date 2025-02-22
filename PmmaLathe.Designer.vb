<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PmmaLathe
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GB_BlankType = New System.Windows.Forms.GroupBox()
        Me.rbExport = New System.Windows.Forms.RadioButton()
        Me.rbLocal = New System.Windows.Forms.RadioButton()
        Me.GB_Process = New System.Windows.Forms.GroupBox()
        Me.rbSecondCut = New System.Windows.Forms.RadioButton()
        Me.rbFirstCut = New System.Windows.Forms.RadioButton()
        Me.GB_Product = New System.Windows.Forms.GroupBox()
        Me.rbPMMA = New System.Windows.Forms.RadioButton()
        Me.rbPHOBIC = New System.Windows.Forms.RadioButton()
        Me.rbPHILIC = New System.Windows.Forms.RadioButton()
        Me.btnHold = New System.Windows.Forms.Button()
        Me.btnFetch = New System.Windows.Forms.Button()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.lblProcessModel = New System.Windows.Forms.Label()
        Me.grid1 = New System.Windows.Forms.DataGridView()
        Me.grid2 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.GB_BlankType.SuspendLayout()
        Me.GB_Process.SuspendLayout()
        Me.GB_Product.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbModel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GB_BlankType)
        Me.Panel1.Controls.Add(Me.GB_Process)
        Me.Panel1.Controls.Add(Me.GB_Product)
        Me.Panel1.Controls.Add(Me.btnHold)
        Me.Panel1.Controls.Add(Me.btnFetch)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1922, 100)
        Me.Panel1.TabIndex = 20
        '
        'cmbModel
        '
        Me.cmbModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.FormattingEnabled = True
        Me.cmbModel.Location = New System.Drawing.Point(129, 44)
        Me.cmbModel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(298, 24)
        Me.cmbModel.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 25)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Model"
        '
        'GB_BlankType
        '
        Me.GB_BlankType.Controls.Add(Me.rbExport)
        Me.GB_BlankType.Controls.Add(Me.rbLocal)
        Me.GB_BlankType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_BlankType.Location = New System.Drawing.Point(731, 13)
        Me.GB_BlankType.Name = "GB_BlankType"
        Me.GB_BlankType.Size = New System.Drawing.Size(278, 68)
        Me.GB_BlankType.TabIndex = 40
        Me.GB_BlankType.TabStop = False
        Me.GB_BlankType.Text = "Blanks Type"
        '
        'rbExport
        '
        Me.rbExport.AutoSize = True
        Me.rbExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbExport.Location = New System.Drawing.Point(145, 27)
        Me.rbExport.Name = "rbExport"
        Me.rbExport.Size = New System.Drawing.Size(83, 28)
        Me.rbExport.TabIndex = 38
        Me.rbExport.Text = "Export"
        Me.rbExport.UseVisualStyleBackColor = True
        '
        'rbLocal
        '
        Me.rbLocal.AutoSize = True
        Me.rbLocal.Checked = True
        Me.rbLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLocal.Location = New System.Drawing.Point(30, 26)
        Me.rbLocal.Name = "rbLocal"
        Me.rbLocal.Size = New System.Drawing.Size(73, 28)
        Me.rbLocal.TabIndex = 36
        Me.rbLocal.TabStop = True
        Me.rbLocal.Text = "Local"
        Me.rbLocal.UseVisualStyleBackColor = True
        '
        'GB_Process
        '
        Me.GB_Process.Controls.Add(Me.rbSecondCut)
        Me.GB_Process.Controls.Add(Me.rbFirstCut)
        Me.GB_Process.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_Process.Location = New System.Drawing.Point(1098, 13)
        Me.GB_Process.Name = "GB_Process"
        Me.GB_Process.Size = New System.Drawing.Size(278, 68)
        Me.GB_Process.TabIndex = 40
        Me.GB_Process.TabStop = False
        Me.GB_Process.Text = "Process"
        '
        'rbSecondCut
        '
        Me.rbSecondCut.AutoSize = True
        Me.rbSecondCut.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSecondCut.Location = New System.Drawing.Point(145, 27)
        Me.rbSecondCut.Name = "rbSecondCut"
        Me.rbSecondCut.Size = New System.Drawing.Size(127, 28)
        Me.rbSecondCut.TabIndex = 38
        Me.rbSecondCut.Text = "Second Cut"
        Me.rbSecondCut.UseVisualStyleBackColor = True
        '
        'rbFirstCut
        '
        Me.rbFirstCut.AutoSize = True
        Me.rbFirstCut.Checked = True
        Me.rbFirstCut.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFirstCut.Location = New System.Drawing.Point(30, 26)
        Me.rbFirstCut.Name = "rbFirstCut"
        Me.rbFirstCut.Size = New System.Drawing.Size(96, 28)
        Me.rbFirstCut.TabIndex = 36
        Me.rbFirstCut.TabStop = True
        Me.rbFirstCut.Text = "First Cut"
        Me.rbFirstCut.UseVisualStyleBackColor = True
        '
        'GB_Product
        '
        Me.GB_Product.Controls.Add(Me.rbPMMA)
        Me.GB_Product.Controls.Add(Me.rbPHOBIC)
        Me.GB_Product.Controls.Add(Me.rbPHILIC)
        Me.GB_Product.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_Product.Location = New System.Drawing.Point(1460, 13)
        Me.GB_Product.Name = "GB_Product"
        Me.GB_Product.Size = New System.Drawing.Size(344, 68)
        Me.GB_Product.TabIndex = 40
        Me.GB_Product.TabStop = False
        Me.GB_Product.Text = "Product"
        '
        'rbPMMA
        '
        Me.rbPMMA.AutoSize = True
        Me.rbPMMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPMMA.Location = New System.Drawing.Point(264, 26)
        Me.rbPMMA.Name = "rbPMMA"
        Me.rbPMMA.Size = New System.Drawing.Size(85, 28)
        Me.rbPMMA.TabIndex = 38
        Me.rbPMMA.Text = "PMMA"
        Me.rbPMMA.UseVisualStyleBackColor = True
        '
        'rbPHOBIC
        '
        Me.rbPHOBIC.AutoSize = True
        Me.rbPHOBIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPHOBIC.Location = New System.Drawing.Point(137, 26)
        Me.rbPHOBIC.Name = "rbPHOBIC"
        Me.rbPHOBIC.Size = New System.Drawing.Size(98, 28)
        Me.rbPHOBIC.TabIndex = 37
        Me.rbPHOBIC.Text = "PHOBIC"
        Me.rbPHOBIC.UseVisualStyleBackColor = True
        '
        'rbPHILIC
        '
        Me.rbPHILIC.AutoSize = True
        Me.rbPHILIC.Checked = True
        Me.rbPHILIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPHILIC.Location = New System.Drawing.Point(30, 26)
        Me.rbPHILIC.Name = "rbPHILIC"
        Me.rbPHILIC.Size = New System.Drawing.Size(85, 28)
        Me.rbPHILIC.TabIndex = 36
        Me.rbPHILIC.TabStop = True
        Me.rbPHILIC.Text = "PHILIC"
        Me.rbPHILIC.UseVisualStyleBackColor = True
        '
        'btnHold
        '
        Me.btnHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHold.Location = New System.Drawing.Point(542, 50)
        Me.btnHold.Name = "btnHold"
        Me.btnHold.Size = New System.Drawing.Size(81, 31)
        Me.btnHold.TabIndex = 33
        Me.btnHold.Text = "Hold"
        Me.btnHold.UseVisualStyleBackColor = True
        Me.btnHold.Visible = False
        '
        'btnFetch
        '
        Me.btnFetch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFetch.Location = New System.Drawing.Point(542, 13)
        Me.btnFetch.Name = "btnFetch"
        Me.btnFetch.Size = New System.Drawing.Size(81, 31)
        Me.btnFetch.TabIndex = 33
        Me.btnFetch.Text = "Fetch"
        Me.btnFetch.UseVisualStyleBackColor = True
        '
        'dtpdate
        '
        Me.dtpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate.Location = New System.Drawing.Point(10, 7)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(417, 31)
        Me.dtpdate.TabIndex = 32
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30000
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(0, 132)
        Me.grid.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.grid.RowTemplate.Height = 24
        Me.grid.Size = New System.Drawing.Size(630, 932)
        Me.grid.TabIndex = 22
        '
        'lblProcessModel
        '
        Me.lblProcessModel.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProcessModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessModel.Location = New System.Drawing.Point(0, 100)
        Me.lblProcessModel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProcessModel.Name = "lblProcessModel"
        Me.lblProcessModel.Size = New System.Drawing.Size(1922, 32)
        Me.lblProcessModel.TabIndex = 21
        Me.lblProcessModel.Text = "PMMA-207- FIRST CUT"
        '
        'grid1
        '
        Me.grid1.AllowUserToAddRows = False
        Me.grid1.AllowUserToDeleteRows = False
        Me.grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid1.Location = New System.Drawing.Point(634, 134)
        Me.grid1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grid1.Name = "grid1"
        Me.grid1.ReadOnly = True
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid1.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.grid1.RowTemplate.Height = 24
        Me.grid1.Size = New System.Drawing.Size(630, 932)
        Me.grid1.TabIndex = 22
        '
        'grid2
        '
        Me.grid2.AllowUserToAddRows = False
        Me.grid2.AllowUserToDeleteRows = False
        Me.grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid2.Location = New System.Drawing.Point(1269, 134)
        Me.grid2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grid2.Name = "grid2"
        Me.grid2.ReadOnly = True
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid2.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.grid2.RowTemplate.Height = 24
        Me.grid2.Size = New System.Drawing.Size(630, 932)
        Me.grid2.TabIndex = 22
        '
        'PmmaLathe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1922, 859)
        Me.Controls.Add(Me.grid2)
        Me.Controls.Add(Me.grid1)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.lblProcessModel)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "PmmaLathe"
        Me.Text = "LATHE CUTTING REFRESH IN EVERY 30 SECONDS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB_BlankType.ResumeLayout(False)
        Me.GB_BlankType.PerformLayout()
        Me.GB_Process.ResumeLayout(False)
        Me.GB_Process.PerformLayout()
        Me.GB_Product.ResumeLayout(False)
        Me.GB_Product.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GB_Product As System.Windows.Forms.GroupBox
    Friend WithEvents rbPMMA As System.Windows.Forms.RadioButton
    Friend WithEvents rbPHOBIC As System.Windows.Forms.RadioButton
    Friend WithEvents rbPHILIC As System.Windows.Forms.RadioButton
    Friend WithEvents btnFetch As System.Windows.Forms.Button
    Friend WithEvents dtpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GB_Process As System.Windows.Forms.GroupBox
    Friend WithEvents rbSecondCut As System.Windows.Forms.RadioButton
    Friend WithEvents rbFirstCut As System.Windows.Forms.RadioButton
    Friend WithEvents btnHold As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents lblProcessModel As System.Windows.Forms.Label
    Friend WithEvents GB_BlankType As System.Windows.Forms.GroupBox
    Friend WithEvents rbExport As System.Windows.Forms.RadioButton
    Friend WithEvents rbLocal As System.Windows.Forms.RadioButton
    Friend WithEvents grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents grid2 As System.Windows.Forms.DataGridView
End Class
