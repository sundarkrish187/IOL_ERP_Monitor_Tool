Imports System
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data

Imports System.Configuration


Public Class ProductionPlanUpload
    Dim IFormatProvider As CultureInfo = CultureInfo.InvariantCulture
    Dim provider As CultureInfo = CultureInfo.InvariantCulture
    Private conString As String
    Private ssqltable As String

    Dim excelFilePath As String
    Dim cmd2 As SqlCommand
    Dim SqlCk2 As String
    Dim StrSql As String
   
    Dim dt As DataTable

    Dim OpenFileDialog1 As New OpenFileDialog ' Declare OpenFileDialog here

    Dim conPHILIC, conPHILIC_ERP, conPMMA, conPMMA_ERP, conPHOBIC, con_PHOBIC_ERP As New SqlConnection

    Private Sub cmb_Product_Type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Product_Type.SelectedIndexChanged
        'GetConnection String
    End Sub


     Private Sub LoadExcelFile()
        OpenFileDialog1.Multiselect = False

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fileName As String = Path.GetFileName(OpenFileDialog1.FileName)
            Dim excelFilePath As String = OpenFileDialog1.FileName

            ' Call GetConnection to retrieve the connection string and table name
            GetConnection()

            ' Excel connection string
            
            Dim excelconnectionstring As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelFilePath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1""")
            ' Query to select data from Excel
            Dim myexceldataquery As String = ("select * from [sheet1$]")

            Try
                ' Initialize objects for data transfer
                Dim oledbconn As New System.Data.OleDb.OleDbConnection(excelconnectionstring)
                Dim oledbcmd As New OleDbCommand(myexceldataquery, oledbconn)
                Dim ad As New OleDbDataAdapter(oledbcmd)
                Dim dt1 As New DataTable

                ad.Fill(dt1)

                ' Check if the Excel file contains data
                If dt1.Rows.Count = 0 Then
                    MessageBox.Show("No data found in the selected Excel file.")
                    Return
                End If

                Dim selectedYear As Integer = Convert.ToInt32(cmbYear.Text)
                Dim selectedMonth As Integer = Convert.ToInt32(cmbMonth.Text)
                For Each row As DataRow In dt1.Rows
                    Dim excelYear As Integer = Convert.ToInt32(row("Year"))
                    Dim excelMonth As Integer = Convert.ToInt32(row("Month"))

                    If excelYear <> selectedYear OrElse excelMonth <> selectedMonth Then
                        MessageBox.Show("The selected month and year do not match the Excel file's, Please check all rows.")
                        Return
                    End If
                Next

                ' Open connection and prepare for bulk copy
                oledbconn.Open()
                Dim dr As OleDbDataReader = oledbcmd.ExecuteReader()
                Dim bulkcopy As New SqlBulkCopy(conString)
                bulkcopy.DestinationTableName = ssqltable

                ' Bulk copy data from Excel to SQL Server
                bulkcopy.WriteToServer(dr)

                ' Close connections
                dr.Close()
                oledbconn.Close()

                MessageBox.Show("File imported successfully.")

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try

        End If


       
        
    End Sub

    Private Sub GetTableName()

       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        CheckTMP_clear()
        LoadExcelFile()
        ClearData()
    End Sub
   ' Method to get the connection string and table name based on selections
    Public Sub GetConnection()
        ' Retrieve the connection string based on the selected product and type
        If ComboBox1.Text = "PHILIC" And cmb_Product_Type.Text = "PRODUCTION" Then
            conString = ConfigurationSettings.AppSettings("conStrPHILIC_ERP").ToString()
            ssqltable = "Production_Plan1"
        ElseIf ComboBox1.Text = "PHILIC" And cmb_Product_Type.Text = "POUCH" Then
            conString = ConfigurationSettings.AppSettings("conStrPHILIC").ToString()
            ssqltable = "Pouch_Production_Plan1"
        ElseIf ComboBox1.Text = "PHILIC" And cmb_Product_Type.Text = "BOX" Then
            conString = ConfigurationSettings.AppSettings("conStrPHILIC").ToString()
            ssqltable = "Box_Production_Plan1"

        ElseIf ComboBox1.Text = "PMMA" And cmb_Product_Type.Text = "PRODUCTION" Then
            conString = ConfigurationSettings.AppSettings("conStrPMMA_ERP").ToString()
            ssqltable = "Production_Plan1"
        ElseIf ComboBox1.Text = "PMMA" And cmb_Product_Type.Text = "POUCH" Then
            conString = ConfigurationSettings.AppSettings("conStrPMMA").ToString()
            ssqltable = "Pouch_Production_Plan1"
        ElseIf ComboBox1.Text = "PMMA" And cmb_Product_Type.Text = "BOX" Then
            conString = ConfigurationSettings.AppSettings("conStrPMMA").ToString()
            ssqltable = "Box_Production_Plan1"

        ElseIf ComboBox1.Text = "PHOBIC" And cmb_Product_Type.Text = "PRODUCTION" Then
            conString = ConfigurationSettings.AppSettings("conStrPHOBIC_Mould").ToString()
            ssqltable = "Production_Plan1"
        ElseIf ComboBox1.Text = "PHOBIC" And cmb_Product_Type.Text = "POUCH" Then
            conString = ConfigurationSettings.AppSettings("conStrPHOBIC").ToString()
            ssqltable = "Pouch_Production_Plan1"
        ElseIf ComboBox1.Text = "PHOBIC" And cmb_Product_Type.Text = "BOX" Then
            conString = ConfigurationSettings.AppSettings("conStrPHOBIC").ToString()
            ssqltable = "Box_Production_Plan1"

        ElseIf ComboBox1.Text = "PHOBIC-NP(SPNT300)" And cmb_Product_Type.Text = "PRODUCTION" Then
            conString = ConfigurationSettings.AppSettings("conStrPHOBIC_Mould").ToString()
            ssqltable = "Production_Plan1"
        ElseIf ComboBox1.Text = "PHOBIC-NP(SPNT300)" And cmb_Product_Type.Text = "POUCH" Then
            conString = ConfigurationSettings.AppSettings("conStrNP").ToString()
            ssqltable = "Pouch_Production_Plan1"

        ElseIf ComboBox1.Text = "PHOBIC-NP(SPNT300)" And cmb_Product_Type.Text = "BOX" Then
            conString = ConfigurationSettings.AppSettings("conStrNP").ToString()
            ssqltable = "Box_Production_Plan1"

        ElseIf ComboBox1.Text = "SUPERPHOB" And cmb_Product_Type.Text = "PRODUCTION" Then
            conString = ConfigurationSettings.AppSettings("conStrPHOBIC_Mould").ToString()
            ssqltable = "Production_Plan1"
        ElseIf ComboBox1.Text = "SUPERPHOB" And cmb_Product_Type.Text = "POUCH" Then
            conString = ConfigurationSettings.AppSettings("conStrSUPERPHOB").ToString()
            ssqltable = "Pouch_Production_Plan1"
        ElseIf ComboBox1.Text = "SUPERPHOB" And cmb_Product_Type.Text = "BOX" Then
            conString = ConfigurationSettings.AppSettings("conStrSUPERPHOB").ToString()
            ssqltable = "Box_Production_Plan1"
        End If
    End Sub

 

  


    Private Sub CheckTMP_clear()
        GetConnection()
        Try
            ' Build the SQL query using the selected Year and Month
            Dim SqlCk2 As String = "DELETE FROM " + ssqltable + " where Year = @Year AND Month = @Month"

            ' Create a new SqlConnection object using the connection string
            Using con As New SqlConnection(conString)
                ' Create a new SqlCommand with the query and connection
                Using cmd2 As New SqlCommand(SqlCk2, con)
                    ' Add parameters to prevent SQL injection and properly handle data types
                    cmd2.Parameters.AddWithValue("@Year", cmbYear.Text)
                    cmd2.Parameters.AddWithValue("@Month", cmbMonth.Text)

                    ' Open the connection
                    con.Open()

                    ' Execute the query to delete records
                    cmd2.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Previous records for the selected year and month have been deleted.")

        Catch ex As Exception
            ' Handle the exception and display the error message
            MessageBox.Show("Error while deleting records: " & ex.Message)
        End Try
    End Sub
    Private Sub ClearData()
        ComboBox1.Text = ""
        cmb_Product_Type.Text = ""
        cmbMonth.Text = ""
        cmbYear.Text = ""

    End Sub

  

End Class
