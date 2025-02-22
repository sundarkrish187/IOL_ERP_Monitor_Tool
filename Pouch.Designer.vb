<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pouch
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GB_Product = New System.Windows.Forms.GroupBox()
        Me.rbPMMA = New System.Windows.Forms.RadioButton()
        Me.rbPHOBIC = New System.Windows.Forms.RadioButton()
        Me.rbPHILIC = New System.Windows.Forms.RadioButton()
        Me.chkCycle = New System.Windows.Forms.CheckBox()
        Me.btnFetch = New System.Windows.Forms.Button()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.grid1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblStationDay = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblStationMonth = New System.Windows.Forms.Label()
        Me.grid2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblModelMonth = New System.Windows.Forms.Label()
        Me.grid4 = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblModelDay = New System.Windows.Forms.Label()
        Me.grid3 = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GB_Product.SuspendLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.grid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GB_Product)
        Me.Panel1.Controls.Add(Me.chkCycle)
        Me.Panel1.Controls.Add(Me.btnFetch)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 100)
        Me.Panel1.TabIndex = 20
        '
        'GB_Product
        '
        Me.GB_Product.Controls.Add(Me.rbPMMA)
        Me.GB_Product.Controls.Add(Me.rbPHOBIC)
        Me.GB_Product.Controls.Add(Me.rbPHILIC)
        Me.GB_Product.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_Product.Location = New System.Drawing.Point(1401, 4)
        Me.GB_Product.Margin = New System.Windows.Forms.Padding(4)
        Me.GB_Product.Name = "GB_Product"
        Me.GB_Product.Padding = New System.Windows.Forms.Padding(4)
        Me.GB_Product.Size = New System.Drawing.Size(496, 84)
        Me.GB_Product.TabIndex = 40
        Me.GB_Product.TabStop = False
        Me.GB_Product.Text = "Product"
        '
        'rbPMMA
        '
        Me.rbPMMA.AutoSize = True
        Me.rbPMMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPMMA.Location = New System.Drawing.Point(352, 32)
        Me.rbPMMA.Margin = New System.Windows.Forms.Padding(4)
        Me.rbPMMA.Name = "rbPMMA"
        Me.rbPMMA.Size = New System.Drawing.Size(105, 33)
        Me.rbPMMA.TabIndex = 38
        Me.rbPMMA.Text = "PMMA"
        Me.rbPMMA.UseVisualStyleBackColor = True
        '
        'rbPHOBIC
        '
        Me.rbPHOBIC.AutoSize = True
        Me.rbPHOBIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPHOBIC.Location = New System.Drawing.Point(183, 32)
        Me.rbPHOBIC.Margin = New System.Windows.Forms.Padding(4)
        Me.rbPHOBIC.Name = "rbPHOBIC"
        Me.rbPHOBIC.Size = New System.Drawing.Size(125, 33)
        Me.rbPHOBIC.TabIndex = 37
        Me.rbPHOBIC.Text = "PHOBIC"
        Me.rbPHOBIC.UseVisualStyleBackColor = True
        '
        'rbPHILIC
        '
        Me.rbPHILIC.AutoSize = True
        Me.rbPHILIC.Checked = True
        Me.rbPHILIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPHILIC.Location = New System.Drawing.Point(40, 32)
        Me.rbPHILIC.Margin = New System.Windows.Forms.Padding(4)
        Me.rbPHILIC.Name = "rbPHILIC"
        Me.rbPHILIC.Size = New System.Drawing.Size(109, 33)
        Me.rbPHILIC.TabIndex = 36
        Me.rbPHILIC.TabStop = True
        Me.rbPHILIC.Text = "PHILIC"
        Me.rbPHILIC.UseVisualStyleBackColor = True
        '
        'chkCycle
        '
        Me.chkCycle.AutoSize = True
        Me.chkCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCycle.Location = New System.Drawing.Point(49, 58)
        Me.chkCycle.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCycle.Name = "chkCycle"
        Me.chkCycle.Size = New System.Drawing.Size(95, 33)
        Me.chkCycle.TabIndex = 34
        Me.chkCycle.Text = "Cycle"
        Me.chkCycle.UseVisualStyleBackColor = True
        '
        'btnFetch
        '
        Me.btnFetch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFetch.Location = New System.Drawing.Point(600, 14)
        Me.btnFetch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFetch.Name = "btnFetch"
        Me.btnFetch.Size = New System.Drawing.Size(108, 38)
        Me.btnFetch.TabIndex = 33
        Me.btnFetch.Text = "Fetch"
        Me.btnFetch.UseVisualStyleBackColor = True
        '
        'dtpdate
        '
        Me.dtpdate.Checked = False
        Me.dtpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate.Location = New System.Drawing.Point(49, 14)
        Me.dtpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(540, 37)
        Me.dtpdate.TabIndex = 32
        '
        'grid1
        '
        Me.grid1.AllowUserToAddRows = False
        Me.grid1.AllowUserToDeleteRows = False
        Me.grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid1.Location = New System.Drawing.Point(7, 55)
        Me.grid1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grid1.Name = "grid1"
        Me.grid1.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid1.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid1.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.grid1.RowTemplate.Height = 24
        Me.grid1.Size = New System.Drawing.Size(1227, 273)
        Me.grid1.TabIndex = 22
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblStationDay)
        Me.GroupBox2.Controls.Add(Me.grid1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 107)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(1233, 329)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'lblStationDay
        '
        Me.lblStationDay.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStationDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationDay.Location = New System.Drawing.Point(3, 17)
        Me.lblStationDay.Name = "lblStationDay"
        Me.lblStationDay.Size = New System.Drawing.Size(1227, 36)
        Me.lblStationDay.TabIndex = 4
        Me.lblStationDay.Text = "PHILIC - 05 July 2023"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblStationMonth)
        Me.GroupBox3.Controls.Add(Me.grid2)
        Me.GroupBox3.Location = New System.Drawing.Point(1276, 107)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(1233, 329)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        '
        'lblStationMonth
        '
        Me.lblStationMonth.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStationMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationMonth.Location = New System.Drawing.Point(3, 17)
        Me.lblStationMonth.Name = "lblStationMonth"
        Me.lblStationMonth.Size = New System.Drawing.Size(1227, 36)
        Me.lblStationMonth.TabIndex = 4
        Me.lblStationMonth.Text = "PHILIC - July 2023"
        '
        'grid2
        '
        Me.grid2.AllowUserToAddRows = False
        Me.grid2.AllowUserToDeleteRows = False
        Me.grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid2.Location = New System.Drawing.Point(7, 55)
        Me.grid2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grid2.Name = "grid2"
        Me.grid2.ReadOnly = True
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid2.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.grid2.RowTemplate.Height = 24
        Me.grid2.Size = New System.Drawing.Size(1227, 273)
        Me.grid2.TabIndex = 22
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblModelMonth)
        Me.GroupBox4.Controls.Add(Me.grid4)
        Me.GroupBox4.Location = New System.Drawing.Point(1276, 441)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(1233, 852)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        '
        'lblModelMonth
        '
        Me.lblModelMonth.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblModelMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelMonth.Location = New System.Drawing.Point(3, 17)
        Me.lblModelMonth.Name = "lblModelMonth"
        Me.lblModelMonth.Size = New System.Drawing.Size(1227, 43)
        Me.lblModelMonth.TabIndex = 4
        Me.lblModelMonth.Text = "PHILIC - July 2023"
        '
        'grid4
        '
        Me.grid4.AllowUserToAddRows = False
        Me.grid4.AllowUserToDeleteRows = False
        Me.grid4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.grid4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid4.Location = New System.Drawing.Point(6, 60)
        Me.grid4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grid4.Name = "grid4"
        Me.grid4.ReadOnly = True
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid4.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.grid4.RowTemplate.Height = 24
        Me.grid4.Size = New System.Drawing.Size(1227, 791)
        Me.grid4.TabIndex = 22
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblModelDay)
        Me.GroupBox5.Controls.Add(Me.grid3)
        Me.GroupBox5.Location = New System.Drawing.Point(0, 441)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Size = New System.Drawing.Size(1233, 852)
        Me.GroupBox5.TabIndex = 24
        Me.GroupBox5.TabStop = False
        '
        'lblModelDay
        '
        Me.lblModelDay.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblModelDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelDay.Location = New System.Drawing.Point(3, 17)
        Me.lblModelDay.Name = "lblModelDay"
        Me.lblModelDay.Size = New System.Drawing.Size(1227, 43)
        Me.lblModelDay.TabIndex = 4
        Me.lblModelDay.Text = "PHILIC - 05 July 2023"
        '
        'grid3
        '
        Me.grid3.AllowUserToAddRows = False
        Me.grid3.AllowUserToDeleteRows = False
        Me.grid3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.grid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid3.Location = New System.Drawing.Point(7, 60)
        Me.grid3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grid3.Name = "grid3"
        Me.grid3.ReadOnly = True
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid3.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.grid3.RowTemplate.Height = 24
        Me.grid3.Size = New System.Drawing.Size(1227, 791)
        Me.grid3.TabIndex = 22
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30000
        '
        'Pouch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1057)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Pouch"
        Me.Text = "POUCH PACKED REFRESH IN EVERY 30 SECONDS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB_Product.ResumeLayout(False)
        Me.GB_Product.PerformLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.grid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GB_Product As System.Windows.Forms.GroupBox
    Friend WithEvents rbPMMA As System.Windows.Forms.RadioButton
    Friend WithEvents rbPHOBIC As System.Windows.Forms.RadioButton
    Friend WithEvents rbPHILIC As System.Windows.Forms.RadioButton
    Friend WithEvents chkCycle As System.Windows.Forms.CheckBox
    Friend WithEvents btnFetch As System.Windows.Forms.Button
    Friend WithEvents dtpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStationDay As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStationMonth As System.Windows.Forms.Label
    Friend WithEvents grid2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblModelMonth As System.Windows.Forms.Label
    Friend WithEvents grid4 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblModelDay As System.Windows.Forms.Label
    Friend WithEvents grid3 As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
