<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PouchReport_BasedOnPlan
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
        Me.btn_download = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmb_Product_Type = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_View = New System.Windows.Forms.Button()
        Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chBx_date = New System.Windows.Forms.CheckBox()
        Me.CmbDate = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToDate = New System.Windows.Forms.ComboBox()
        Me.dtpdate_to = New System.Windows.Forms.DateTimePicker()
        Me.dtpdate_from = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_download
        '
        Me.btn_download.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_download.ForeColor = System.Drawing.Color.ForestGreen
        Me.btn_download.Location = New System.Drawing.Point(751, 514)
        Me.btn_download.Name = "btn_download"
        Me.btn_download.Size = New System.Drawing.Size(174, 38)
        Me.btn_download.TabIndex = 0
        Me.btn_download.Text = "Download"
        Me.btn_download.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Month"
        '
        'cmbYear
        '
        Me.cmbYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYear.ForeColor = System.Drawing.Color.Red
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Items.AddRange(New Object() {"2022", "2023", "2024", "2025", "2026"})
        Me.cmbYear.Location = New System.Drawing.Point(162, 87)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(158, 28)
        Me.cmbYear.TabIndex = 2
        '
        'cmbMonth
        '
        Me.cmbMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonth.ForeColor = System.Drawing.Color.Red
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbMonth.Location = New System.Drawing.Point(162, 140)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(158, 28)
        Me.cmbMonth.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(390, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(816, 485)
        Me.DataGridView1.TabIndex = 9
        '
        'cmb_Product_Type
        '
        Me.cmb_Product_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Product_Type.ForeColor = System.Drawing.Color.Red
        Me.cmb_Product_Type.FormattingEnabled = True
        Me.cmb_Product_Type.Items.AddRange(New Object() {"PHILIC", "PHOBIC", "PMMA"})
        Me.cmb_Product_Type.Location = New System.Drawing.Point(162, 31)
        Me.cmb_Product_Type.Name = "cmb_Product_Type"
        Me.cmb_Product_Type.Size = New System.Drawing.Size(159, 28)
        Me.cmb_Product_Type.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Product Type"
        '
        'btn_View
        '
        Me.btn_View.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_View.ForeColor = System.Drawing.Color.DarkBlue
        Me.btn_View.Location = New System.Drawing.Point(77, 341)
        Me.btn_View.Name = "btn_View"
        Me.btn_View.Size = New System.Drawing.Size(174, 38)
        Me.btn_View.TabIndex = 12
        Me.btn_View.Text = "View"
        Me.btn_View.UseVisualStyleBackColor = True
        '
        'err
        '
        Me.err.ContainerControl = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BoxPackedMonitor.My.Resources.Resources.process
        Me.PictureBox1.Location = New System.Drawing.Point(52, 410)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(15, 90)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'chBx_date
        '
        Me.chBx_date.AutoSize = True
        Me.chBx_date.Location = New System.Drawing.Point(35, 180)
        Me.chBx_date.Name = "chBx_date"
        Me.chBx_date.Size = New System.Drawing.Size(49, 17)
        Me.chBx_date.TabIndex = 16
        Me.chBx_date.Text = "Date"
        Me.chBx_date.UseVisualStyleBackColor = True
        '
        'CmbDate
        '
        Me.CmbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbDate.ForeColor = System.Drawing.Color.Red
        Me.CmbDate.FormattingEnabled = True
        Me.CmbDate.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.CmbDate.Location = New System.Drawing.Point(147, 410)
        Me.CmbDate.Name = "CmbDate"
        Me.CmbDate.Size = New System.Drawing.Size(159, 28)
        Me.CmbDate.TabIndex = 15
        Me.CmbDate.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Date"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "To Date"
        Me.Label5.Visible = False
        '
        'ToDate
        '
        Me.ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDate.ForeColor = System.Drawing.Color.Red
        Me.ToDate.FormattingEnabled = True
        Me.ToDate.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.ToDate.Location = New System.Drawing.Point(147, 473)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(159, 28)
        Me.ToDate.TabIndex = 32
        Me.ToDate.Visible = False
        '
        'dtpdate_to
        '
        Me.dtpdate_to.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate_to.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdate_to.Location = New System.Drawing.Point(162, 263)
        Me.dtpdate_to.Name = "dtpdate_to"
        Me.dtpdate_to.Size = New System.Drawing.Size(164, 31)
        Me.dtpdate_to.TabIndex = 37
        Me.dtpdate_to.Value = New Date(2024, 11, 29, 0, 0, 0, 0)
        '
        'dtpdate_from
        '
        Me.dtpdate_from.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdate_from.Location = New System.Drawing.Point(162, 211)
        Me.dtpdate_from.Name = "dtpdate_from"
        Me.dtpdate_from.Size = New System.Drawing.Size(164, 31)
        Me.dtpdate_from.TabIndex = 36
        Me.dtpdate_from.Value = New Date(2024, 11, 29, 0, 0, 0, 0)
        '
        'PouchReport_BasedOnPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1218, 636)
        Me.Controls.Add(Me.dtpdate_to)
        Me.Controls.Add(Me.dtpdate_from)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.chBx_date)
        Me.Controls.Add(Me.CmbDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_View)
        Me.Controls.Add(Me.cmb_Product_Type)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_download)
        Me.Name = "PouchReport_BasedOnPlan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PouchReport_BasedOnPlan"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_download As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_Product_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_View As System.Windows.Forms.Button
    Friend WithEvents err As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chBx_date As System.Windows.Forms.CheckBox
    Friend WithEvents CmbDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.ComboBox
    Friend WithEvents dtpdate_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpdate_from As System.Windows.Forms.DateTimePicker
End Class
