Imports Excel = Microsoft.Office.Interop.Excel

Public Class BoxReport_BasedOnPlan
    Dim comboYear As String
    Dim comboMonth As String
    Dim comboDate As String
    Dim cmpTodate As String
    Dim checkBox_date As Boolean

    Private Sub PouchReport_BasedOnPlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ExportToExcel(ByVal dt As DataTable, ByVal excelFilePath As String)
        Dim xlApp As New Excel.Application()
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorkSheet As Excel.Worksheet = CType(xlWorkBook.Worksheets(1), Excel.Worksheet)

        Dim i As Integer = 0
        Dim j As Integer = 0

        ' Writing Headers
        For Each column As DataColumn In dt.Columns
            j += 1
            xlWorkSheet.Cells(1, j) = column.ColumnName
        Next

        ' Writing Data
        FrmProgress.Show()
        FrmProgress.ProgressBar1.Maximum = dt.Rows.Count
        FrmProgress.ProgressBar1.Style = ProgressBarStyle.Continuous
        FrmProgress.ProgressBar1.Value = 0
        Application.DoEvents()

        For Each row As DataRow In dt.Rows
            i += 1
            j = 0
            For Each column As DataColumn In dt.Columns
                j += 1
                xlWorkSheet.Cells(i + 1, j) = row(column.ColumnName)
            Next

            FrmProgress.ProgressBar1.Value += 1
            Application.DoEvents()
        Next

        ' Save the Excel file
        xlWorkBook.SaveAs(excelFilePath)
        xlWorkBook.Close()
        xlApp.Quit()

        ReleaseObject(xlApp)
        ReleaseObject(xlWorkBook)
        ReleaseObject(xlWorkSheet)

        FrmProgress.Dispose()

    End Sub
    Private Sub GetPMMA_Box_Report()
        Dim dt As DataTable
        Dim PMMA_Excel_cls As New PMMA_Excel_Report_Class(comboYear, comboMonth, comboDate, cmpTodate, checkBox_date)
        PMMA_Excel_cls.PMMA_Excel_class()
        dt = PMMA_Excel_cls.GetExcelReport_box(cmbYear.Text, cmbMonth.Text)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub GetPHILIC_Box_Report()
        Dim dt As DataTable
        Dim PHILIC_Excel_cls As New PHILIC_Excel_Report_Class(comboYear, comboMonth, comboDate, cmpTodate, checkBox_date)
        PHILIC_Excel_cls.PHILIC_Excel_class()
        dt = PHILIC_Excel_cls.GetExcelReport_Box(cmbYear.Text, cmbMonth.Text)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub GetPHOBIC_Box_Report()
        Dim dt As DataTable
        Dim PHOBIC_Excel_cls As New PHOBIC_Excel_Report_Class(comboYear, comboMonth, comboDate, cmpTodate, checkBox_date)
        PHOBIC_Excel_cls.PHOBIC_Excel_class()
        dt = PHOBIC_Excel_cls.GetExcelReport_box(cmbYear.Text, cmbMonth.Text)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Production_Report()

        If cmb_Product_Type.Text = "PHILIC" Then
            GetPHILIC_Box_Report()
        ElseIf cmb_Product_Type.Text = "PHOBIC" Then
            GetPHOBIC_Box_Report()
        ElseIf cmb_Product_Type.Text = "PMMA" Then
            GetPMMA_Box_Report()
        End If

    End Sub

    Private Sub btn_download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_download.Click
        Dim dt As DataTable
        dt = DataGridView1.DataSource
        Dim excelFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" + cmb_Product_Type.Text + "_BOX_REPORT_" + DateTime.Now().ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx"
        ExportToExcel(dt, excelFilePath)
        MsgBox("Excel file exported successfully!", MsgBoxStyle.Information)
    End Sub

    Private Sub btn_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_View.Click


        If cmb_Product_Type.Text = "" Then
            err.SetError(cmb_Product_Type, "This information is required")
            Exit Sub
        Else
            err.SetError(cmb_Product_Type, "")
        End If

        If cmb_Product_Type.SelectedItem Is Nothing Then
            err.SetError(cmb_Product_Type, " Please Select Valid Product_Type")
            Exit Sub
        End If

        If cmbMonth.Text = "" Then
            err.SetError(cmbMonth, "This information is required")
            Exit Sub
        Else
            err.SetError(cmbMonth, "")
        End If

        If cmbMonth.SelectedItem Is Nothing Then
            err.SetError(cmbMonth, " Please Select Valid Month")
            Exit Sub
        End If

        If cmbYear.Text = "" Then
            err.SetError(cmbYear, "This information is required")
            Exit Sub
        Else
            err.SetError(cmbYear, "")
        End If

        If cmbYear.SelectedItem Is Nothing Then
            err.SetError(cmbYear, " Please Select Valid Year")
            Exit Sub
        End If

        If chBx_date.Checked = True Then
            If CmbDate.Text = "" Then
                err.SetError(CmbDate, "This information is required")
                Exit Sub
            Else
                err.SetError(CmbDate, "")
            End If

            If CmbDate.SelectedItem Is Nothing Then
                err.SetError(CmbDate, " Please Select Valid Date")
                Exit Sub
            End If
        End If

        DataGridView1.DataSource = Nothing
        comboYear = cmbYear.Text
        comboMonth = cmbMonth.Text
        comboDate = CmbDate.Text
        cmpTodate = ToDate.Text
        checkBox_date = chBx_date.Checked


        FrmLoading.Show()
        Application.DoEvents()

        Production_Report()

        FrmLoading.Dispose()





    End Sub

    Private Sub cmb_Product_Type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Product_Type.SelectedIndexChanged

        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        cmbMonth.Text = ""
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        If cmbYear.Text = "" Then
            err.SetError(cmbYear, "This information is required")
            Exit Sub
        Else
            err.SetError(cmbYear, "")
        End If

        If cmbYear.SelectedItem Is Nothing Then
            err.SetError(cmbYear, " Please Select Valid Year")
            Exit Sub
        End If

        CmbDate.Text = ""
        DataGridView1.DataSource = Nothing

        CmbDate.Items.Clear()
        Dim daysInMonth As Integer = DateTime.DaysInMonth(cmbYear.Text, cmbMonth.Text)
        For day As Integer = 1 To daysInMonth
            CmbDate.Items.Add(day)
        Next

    End Sub

    Private Sub chBx_date_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chBx_date.CheckedChanged
        CmbDate.Text = ""
        If chBx_date.Checked = True Then
            Label4.Visible = True
            Label5.Visible = True
            CmbDate.Visible = True
            ToDate.Visible = True
        Else
            Label4.Visible = False
            Label5.Visible = False
            CmbDate.Visible = False
            ToDate.Visible = False
        End If
    End Sub

    Private Sub CmbDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDate.SelectedIndexChanged
        If cmbMonth.Text = "" Then
            err.SetError(cmbMonth, "This information is required")
            Exit Sub
        Else
            err.SetError(cmbMonth, "")
        End If

        If cmbMonth.SelectedItem Is Nothing Then
            err.SetError(cmbMonth, " Please Select Valid Month")
            Exit Sub
        End If

        DataGridView1.DataSource = Nothing
    End Sub
End Class