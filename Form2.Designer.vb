<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel_PhilicStation = New System.Windows.Forms.Panel()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GB_Product = New System.Windows.Forms.GroupBox()
        Me.rbPMMA = New System.Windows.Forms.RadioButton()
        Me.rbPHOBIC = New System.Windows.Forms.RadioButton()
        Me.rbPHILIC = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbStationWise = New System.Windows.Forms.RadioButton()
        Me.rbUserWise = New System.Windows.Forms.RadioButton()
        Me.chkCycle = New System.Windows.Forms.CheckBox()
        Me.btnFetch = New System.Windows.Forms.Button()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel_ColorCode = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblRed = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblYellow = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblGreen = New System.Windows.Forms.Label()
        Me.lblNormal = New System.Windows.Forms.Label()
        Me.grid_Shift = New System.Windows.Forms.DataGridView()
        Me.lblProduct_Shift = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gridShift2 = New System.Windows.Forms.DataGridView()
        Me.lblProduct_Shift2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblBarandName = New System.Windows.Forms.Label()
        Me.gridBrandName = New System.Windows.Forms.DataGridView()
        Me.Panel_PhilicStation.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GB_Product.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel_ColorCode.SuspendLayout()
        CType(Me.grid_Shift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.gridShift2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.gridBrandName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_PhilicStation
        '
        Me.Panel_PhilicStation.Controls.Add(Me.grid)
        Me.Panel_PhilicStation.Controls.Add(Me.lblProduct)
        Me.Panel_PhilicStation.Location = New System.Drawing.Point(37, 82)
        Me.Panel_PhilicStation.Name = "Panel_PhilicStation"
        Me.Panel_PhilicStation.Size = New System.Drawing.Size(1069, 458)
        Me.Panel_PhilicStation.TabIndex = 18
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(0, 24)
        Me.grid.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grid.RowTemplate.Height = 24
        Me.grid.Size = New System.Drawing.Size(1069, 434)
        Me.grid.TabIndex = 4
        '
        'lblProduct
        '
        Me.lblProduct.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(0, 0)
        Me.lblProduct.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(1069, 24)
        Me.lblProduct.TabIndex = 3
        Me.lblProduct.Text = "PHILIC"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GB_Product)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.chkCycle)
        Me.Panel1.Controls.Add(Me.btnFetch)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1443, 81)
        Me.Panel1.TabIndex = 19
        '
        'GB_Product
        '
        Me.GB_Product.Controls.Add(Me.rbPMMA)
        Me.GB_Product.Controls.Add(Me.rbPHOBIC)
        Me.GB_Product.Controls.Add(Me.rbPHILIC)
        Me.GB_Product.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_Product.Location = New System.Drawing.Point(871, 13)
        Me.GB_Product.Name = "GB_Product"
        Me.GB_Product.Size = New System.Drawing.Size(372, 68)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbStationWise)
        Me.GroupBox1.Controls.Add(Me.rbUserWise)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(541, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 70)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Station / User"
        '
        'rbStationWise
        '
        Me.rbStationWise.AutoSize = True
        Me.rbStationWise.Checked = True
        Me.rbStationWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbStationWise.Location = New System.Drawing.Point(20, 28)
        Me.rbStationWise.Name = "rbStationWise"
        Me.rbStationWise.Size = New System.Drawing.Size(127, 28)
        Me.rbStationWise.TabIndex = 35
        Me.rbStationWise.TabStop = True
        Me.rbStationWise.Text = "Station wise"
        Me.rbStationWise.UseVisualStyleBackColor = True
        '
        'rbUserWise
        '
        Me.rbUserWise.AutoSize = True
        Me.rbUserWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUserWise.Location = New System.Drawing.Point(153, 29)
        Me.rbUserWise.Name = "rbUserWise"
        Me.rbUserWise.Size = New System.Drawing.Size(110, 28)
        Me.rbUserWise.TabIndex = 36
        Me.rbUserWise.Text = "User wise"
        Me.rbUserWise.UseVisualStyleBackColor = True
        '
        'chkCycle
        '
        Me.chkCycle.AutoSize = True
        Me.chkCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCycle.Location = New System.Drawing.Point(37, 47)
        Me.chkCycle.Name = "chkCycle"
        Me.chkCycle.Size = New System.Drawing.Size(76, 28)
        Me.chkCycle.TabIndex = 34
        Me.chkCycle.Text = "Cycle"
        Me.chkCycle.UseVisualStyleBackColor = True
        '
        'btnFetch
        '
        Me.btnFetch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFetch.Location = New System.Drawing.Point(450, 11)
        Me.btnFetch.Name = "btnFetch"
        Me.btnFetch.Size = New System.Drawing.Size(81, 31)
        Me.btnFetch.TabIndex = 33
        Me.btnFetch.Text = "Fetch"
        Me.btnFetch.UseVisualStyleBackColor = True
        '
        'dtpdate
        '
        Me.dtpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate.Location = New System.Drawing.Point(37, 11)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(406, 31)
        Me.dtpdate.TabIndex = 32
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel_ColorCode)
        Me.Panel2.Controls.Add(Me.grid_Shift)
        Me.Panel2.Controls.Add(Me.lblProduct_Shift)
        Me.Panel2.Location = New System.Drawing.Point(1120, 82)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(711, 612)
        Me.Panel2.TabIndex = 20
        '
        'Panel_ColorCode
        '
        Me.Panel_ColorCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel_ColorCode.Controls.Add(Me.Label13)
        Me.Panel_ColorCode.Controls.Add(Me.Label15)
        Me.Panel_ColorCode.Controls.Add(Me.lblRed)
        Me.Panel_ColorCode.Controls.Add(Me.Label19)
        Me.Panel_ColorCode.Controls.Add(Me.lblYellow)
        Me.Panel_ColorCode.Controls.Add(Me.Label21)
        Me.Panel_ColorCode.Controls.Add(Me.lblGreen)
        Me.Panel_ColorCode.Controls.Add(Me.lblNormal)
        Me.Panel_ColorCode.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel_ColorCode.Location = New System.Drawing.Point(0, 535)
        Me.Panel_ColorCode.Name = "Panel_ColorCode"
        Me.Panel_ColorCode.Size = New System.Drawing.Size(711, 77)
        Me.Panel_ColorCode.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 18)
        Me.Label13.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Red
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 18)
        Me.Label15.TabIndex = 7
        '
        'lblRed
        '
        Me.lblRed.AutoSize = True
        Me.lblRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRed.ForeColor = System.Drawing.Color.White
        Me.lblRed.Location = New System.Drawing.Point(58, 2)
        Me.lblRed.Name = "lblRed"
        Me.lblRed.Size = New System.Drawing.Size(86, 29)
        Me.lblRed.TabIndex = 6
        Me.lblRed.Text = "Label8"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Yellow
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(314, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 18)
        Me.Label19.TabIndex = 5
        '
        'lblYellow
        '
        Me.lblYellow.AutoSize = True
        Me.lblYellow.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYellow.ForeColor = System.Drawing.Color.White
        Me.lblYellow.Location = New System.Drawing.Point(359, 2)
        Me.lblYellow.Name = "lblYellow"
        Me.lblYellow.Size = New System.Drawing.Size(86, 29)
        Me.lblYellow.TabIndex = 4
        Me.lblYellow.Text = "Label8"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Green
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(316, 40)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 18)
        Me.Label21.TabIndex = 3
        '
        'lblGreen
        '
        Me.lblGreen.AutoSize = True
        Me.lblGreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGreen.ForeColor = System.Drawing.Color.White
        Me.lblGreen.Location = New System.Drawing.Point(360, 36)
        Me.lblGreen.Name = "lblGreen"
        Me.lblGreen.Size = New System.Drawing.Size(86, 29)
        Me.lblGreen.TabIndex = 2
        Me.lblGreen.Text = "Label8"
        '
        'lblNormal
        '
        Me.lblNormal.AutoSize = True
        Me.lblNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormal.ForeColor = System.Drawing.Color.White
        Me.lblNormal.Location = New System.Drawing.Point(51, 43)
        Me.lblNormal.Name = "lblNormal"
        Me.lblNormal.Size = New System.Drawing.Size(86, 29)
        Me.lblNormal.TabIndex = 0
        Me.lblNormal.Text = "Label8"
        '
        'grid_Shift
        '
        Me.grid_Shift.AllowUserToAddRows = False
        Me.grid_Shift.AllowUserToDeleteRows = False
        Me.grid_Shift.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid_Shift.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_Shift.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grid_Shift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Shift.Location = New System.Drawing.Point(0, 24)
        Me.grid_Shift.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grid_Shift.Name = "grid_Shift"
        Me.grid_Shift.ReadOnly = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid_Shift.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grid_Shift.RowTemplate.Height = 24
        Me.grid_Shift.Size = New System.Drawing.Size(707, 511)
        Me.grid_Shift.TabIndex = 4
        '
        'lblProduct_Shift
        '
        Me.lblProduct_Shift.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProduct_Shift.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct_Shift.Location = New System.Drawing.Point(0, 0)
        Me.lblProduct_Shift.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProduct_Shift.Name = "lblProduct_Shift"
        Me.lblProduct_Shift.Size = New System.Drawing.Size(711, 24)
        Me.lblProduct_Shift.TabIndex = 3
        Me.lblProduct_Shift.Text = "PHILIC"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Green
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(1537, 983)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 18)
        Me.Label27.TabIndex = 47
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(1579, 977)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 29)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "Fast"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1401, 984)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 18)
        Me.Label17.TabIndex = 41
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Yellow
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(1248, 983)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 18)
        Me.Label23.TabIndex = 44
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(1439, 977)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 29)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "Normal"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Red
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(1132, 981)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 18)
        Me.Label20.TabIndex = 46
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(1293, 979)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 29)
        Me.Label24.TabIndex = 43
        Me.Label24.Text = "Medium"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(1177, 977)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 29)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Slow"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gridShift2)
        Me.Panel3.Controls.Add(Me.lblProduct_Shift2)
        Me.Panel3.Location = New System.Drawing.Point(39, 548)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1067, 458)
        Me.Panel3.TabIndex = 48
        '
        'gridShift2
        '
        Me.gridShift2.AllowUserToAddRows = False
        Me.gridShift2.AllowUserToDeleteRows = False
        Me.gridShift2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gridShift2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridShift2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gridShift2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridShift2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridShift2.Location = New System.Drawing.Point(0, 24)
        Me.gridShift2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gridShift2.Name = "gridShift2"
        Me.gridShift2.ReadOnly = True
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridShift2.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridShift2.RowTemplate.Height = 24
        Me.gridShift2.Size = New System.Drawing.Size(1067, 434)
        Me.gridShift2.TabIndex = 4
        '
        'lblProduct_Shift2
        '
        Me.lblProduct_Shift2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProduct_Shift2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct_Shift2.Location = New System.Drawing.Point(0, 0)
        Me.lblProduct_Shift2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProduct_Shift2.Name = "lblProduct_Shift2"
        Me.lblProduct_Shift2.Size = New System.Drawing.Size(1067, 24)
        Me.lblProduct_Shift2.TabIndex = 3
        Me.lblProduct_Shift2.Text = "PHILIC"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblBarandName)
        Me.Panel4.Controls.Add(Me.gridBrandName)
        Me.Panel4.Location = New System.Drawing.Point(1120, 692)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(711, 268)
        Me.Panel4.TabIndex = 49
        '
        'lblBarandName
        '
        Me.lblBarandName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBarandName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarandName.Location = New System.Drawing.Point(0, 0)
        Me.lblBarandName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBarandName.Name = "lblBarandName"
        Me.lblBarandName.Size = New System.Drawing.Size(711, 24)
        Me.lblBarandName.TabIndex = 4
        Me.lblBarandName.Text = "Brand Name"
        '
        'gridBrandName
        '
        Me.gridBrandName.AllowUserToAddRows = False
        Me.gridBrandName.AllowUserToDeleteRows = False
        Me.gridBrandName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gridBrandName.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridBrandName.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridBrandName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBrandName.Location = New System.Drawing.Point(2, 26)
        Me.gridBrandName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gridBrandName.Name = "gridBrandName"
        Me.gridBrandName.ReadOnly = True
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridBrandName.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridBrandName.RowTemplate.Height = 24
        Me.gridBrandName.Size = New System.Drawing.Size(709, 240)
        Me.gridBrandName.TabIndex = 1
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1443, 859)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Panel_PhilicStation)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label26)
        Me.Name = "Form2"
        Me.Text = "BOX PACKING REFRESH IN EVERY 60 SECONDS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel_PhilicStation.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB_Product.ResumeLayout(False)
        Me.GB_Product.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel_ColorCode.ResumeLayout(False)
        Me.Panel_ColorCode.PerformLayout()
        CType(Me.grid_Shift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.gridShift2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.gridBrandName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_PhilicStation As System.Windows.Forms.Panel
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbUserWise As System.Windows.Forms.RadioButton
    Friend WithEvents rbStationWise As System.Windows.Forms.RadioButton
    Friend WithEvents chkCycle As System.Windows.Forms.CheckBox
    Friend WithEvents btnFetch As System.Windows.Forms.Button
    Friend WithEvents dtpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents GB_Product As System.Windows.Forms.GroupBox
    Friend WithEvents rbPMMA As System.Windows.Forms.RadioButton
    Friend WithEvents rbPHOBIC As System.Windows.Forms.RadioButton
    Friend WithEvents rbPHILIC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grid_Shift As System.Windows.Forms.DataGridView
    Friend WithEvents lblProduct_Shift As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents gridShift2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblProduct_Shift2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents gridBrandName As System.Windows.Forms.DataGridView
    Friend WithEvents Panel_ColorCode As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblRed As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblYellow As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblGreen As System.Windows.Forms.Label
    Friend WithEvents lblNormal As System.Windows.Forms.Label
    Friend WithEvents lblBarandName As System.Windows.Forms.Label
End Class
