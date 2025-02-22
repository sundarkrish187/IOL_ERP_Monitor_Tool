Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization

Public Class PMMAClass
    Dim con As New SqlConnection
    Dim conPMMA As New SqlConnection
    Dim conPMMA_ERP As New SqlConnection
    Public selectedDate As DateTime
    Public Total As Integer
    Public Sub PMMAClass()
        con.ConnectionString = ConfigurationSettings.AppSettings("conStrAPSBOX").ToString()
        conPMMA.ConnectionString = ConfigurationSettings.AppSettings("conStrPMMA").ToString()
        conPMMA_ERP.ConnectionString = ConfigurationSettings.AppSettings("conStrPMMA_ERP").ToString()
    End Sub

    Public Function GetNameList(ByVal byname As String) As List(Of String)
        Dim i As Integer
        Dim lst As List(Of String) = New List(Of String)
        Dim ds As New DataSet
        Dim strsql As String
        strsql = "SELECT  Distinct " + byname + " FROM dbo.View_PMMA_Monitor where boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'  "
        Dim cmd As New SqlCommand(strsql, conPMMA)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        lst.Clear()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            lst.Add(ds.Tables(0).Rows(i)(byname).ToString())
        Next

        'Dim ds1 As New DataSet
        'strsql = "SELECT  Distinct " + byname + " FROM dbo.View_PMMA_Monitor where boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'  "
        'cmd = New SqlCommand(strsql, conPMMA)
        'Dim ad_1 As New SqlDataAdapter(cmd)
        'ad_1.Fill(ds1)

        'For i = 0 To ds1.Tables(0).Rows.Count - 1
        '    If Not lst.Contains(ds1.Tables(0).Rows(i)(byname).ToString()) Then
        '        lst.Add(ds1.Tables(0).Rows(i)(byname).ToString())
        '    End If
        'Next

        Return lst
    End Function


    Public Function GetSummaryHourlyTable(ByVal lst As List(Of String), ByVal byname As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand



        dt.Columns.Add(byname)
        For j = 6 To 22
            dt.Columns.Add(j)
        Next j
        dt.Columns.Add("Total")


        For i = 0 To lst.Count - 1
            'Dim ds As New DataSet
            'strsql = "select * from View_PMMA_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad = New SqlDataAdapter(cmd)
            'ad.Fill(ds)

            Dim total As Integer = 0
            Dim row As DataRow = dt.NewRow()
            row(byname) = lst(i)
            ''BOX DB
            'For k = 0 To ds.Tables(0).Rows.Count - 1
            '    row("" & ds.Tables(0).Rows(k)("Hour") & "") = ds.Tables(0).Rows(k)("Qty")
            '    total = total + Convert.ToInt32(ds.Tables(0).Rows(k)("Qty"))
            '    row("Total") = total
            'Next k

            'PMMA DB
            Dim dsPMMA As New DataSet
            strsql = "select * from View_PMMA_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conPMMA)
            Dim ad1 = New SqlDataAdapter(cmd)
            ad1.Fill(dsPMMA)

            For k = 0 To dsPMMA.Tables(0).Rows.Count - 1
                If Not IsDBNull(row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "") = dsPMMA.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Qty"))
                row("Total") = total
            Next k


            dt.Rows.Add(row)
        Next




        Dim row1 As DataRow = dt.NewRow()
        row1(byname) = "Total"
        For M = 1 To dt.Columns.Count - 1
            Dim tot As Integer = 0
            For N = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(N)(M)) Then
                    tot = tot + Convert.ToInt32(dt.Rows(N)(M))
                End If
            Next
            row1(M) = tot
        Next
        dt.Rows.Add(row1)
        dt.AcceptChanges()

        Return dt

    End Function

    Public Function GetSummaryHourlyTableShift1(ByVal lst As List(Of String), ByVal byname As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand



        dt.Columns.Add(byname)
        For j = 6 To 13
            dt.Columns.Add(j)
        Next j
        dt.Columns.Add("Total")
        dt.Columns.Add("Target")

        For i = 0 To lst.Count - 1
            'Dim ds As New DataSet
            'strsql = "select * from View_PMMA_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad = New SqlDataAdapter(cmd)
            'ad.Fill(ds)

            Dim total As Integer = 0
            Dim row As DataRow = dt.NewRow()
            row(byname) = lst(i)
            ''BOX DB
            'For k = 0 To ds.Tables(0).Rows.Count - 1
            '    If Convert.ToInt32(ds.Tables(0).Rows(k)("Hour")) > 13 Then Exit For
            '    row("" & ds.Tables(0).Rows(k)("Hour") & "") = ds.Tables(0).Rows(k)("Qty")
            '    total = total + Convert.ToInt32(ds.Tables(0).Rows(k)("Qty"))
            '    row("Total") = total
            '    row("Target") = Int(878)
            'Next k

            'PMMA DB
            Dim dsPMMA As New DataSet
            strsql = "select * from View_PMMA_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conPMMA)
            Dim ad1 = New SqlDataAdapter(cmd)
            ad1.Fill(dsPMMA)

            For k = 0 To dsPMMA.Tables(0).Rows.Count - 1
                If Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Hour")) > 13 Then Exit For
                If Not IsDBNull(row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "") = dsPMMA.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Qty"))
                row("Total") = total
                row("Target") = Int(878)
            Next k


            dt.Rows.Add(row)
        Next




        Dim row1 As DataRow = dt.NewRow()
        row1(byname) = "Total"
        For M = 1 To dt.Columns.Count - 1
            Dim tot As Integer = 0
            For N = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(N)(M)) Then
                    tot = tot + Convert.ToInt32(dt.Rows(N)(M))
                End If
            Next
            row1(M) = tot
        Next
        dt.Rows.Add(row1)
        dt.AcceptChanges()

        Return dt

    End Function

    Public Function GetSummaryHourlyTableShift2(ByVal lst As List(Of String), ByVal byname As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand



        dt.Columns.Add(byname)
        For j = 14 To 22
            dt.Columns.Add(j)
        Next j
        dt.Columns.Add("Total")
        dt.Columns.Add("Target")

        For i = 0 To lst.Count - 1
            'Dim ds As New DataSet
            'strsql = "select * from View_PMMA_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad = New SqlDataAdapter(cmd)
            'ad.Fill(ds)

            Dim total As Integer = 0
            Dim row As DataRow = dt.NewRow()
            row(byname) = lst(i)
            'BOX DB
            'For k = 0 To ds.Tables(0).Rows.Count - 1
            '    If Convert.ToInt32(ds.Tables(0).Rows(k)("Hour")) <= 13 Then Continue For
            '    row("" & ds.Tables(0).Rows(k)("Hour") & "") = ds.Tables(0).Rows(k)("Qty")
            '    total = total + Convert.ToInt32(ds.Tables(0).Rows(k)("Qty"))
            '    row("Total") = total
            '    row("Target") = Int(878)
            'Next k

            'PMMA DB
            Dim dsPMMA As New DataSet
            strsql = "select * from View_PMMA_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conPMMA)
            Dim ad1 = New SqlDataAdapter(cmd)
            ad1.Fill(dsPMMA)

            For k = 0 To dsPMMA.Tables(0).Rows.Count - 1
                If Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Hour")) <= 13 Then Continue For
                If Not IsDBNull(row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsPMMA.Tables(0).Rows(k)("Hour") & "") = dsPMMA.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsPMMA.Tables(0).Rows(k)("Qty"))
                row("Total") = total
                row("Target") = Int(878)
            Next k


            dt.Rows.Add(row)
        Next




        Dim row1 As DataRow = dt.NewRow()
        row1(byname) = "Total"
        For M = 1 To dt.Columns.Count - 1
            Dim tot As Integer = 0
            For N = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(N)(M)) Then
                    tot = tot + Convert.ToInt32(dt.Rows(N)(M))
                End If
            Next
            row1(M) = tot
        Next
        dt.Rows.Add(row1)
        dt.AcceptChanges()

        Return dt

    End Function

    Public Function GetSummaryTable(ByVal lst As List(Of String), ByVal byname As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand

        dt.Columns.Add(byname)
        dt.Columns.Add("Shift-I")
        dt.Columns.Add("Shift-II")
        dt.Columns.Add("Total")

        For i = 0 To lst.Count - 1

            ''shift1
            'Dim ds_shift1 As New DataSet
            'strsql = "select isnull(sum(qty),0) from View_PMMA_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-I' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad1 = New SqlDataAdapter(cmd)
            'ad1.Fill(ds_shift1)


            ''shift2
            'Dim ds_shift2 As New DataSet
            'strsql = "select isnull(sum(qty),0) from View_PMMA_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-II' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad2 = New SqlDataAdapter(cmd)
            'ad2.Fill(ds_shift2)

            'shift1 PMMA
            Dim ds_shift1_PMMA As New DataSet
            strsql = "select isnull(sum(qty_1),0) from View_PMMA_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-I' and boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            cmd = New SqlCommand(strsql, conPMMA)
            Dim ad3 = New SqlDataAdapter(cmd)
            ad3.Fill(ds_shift1_PMMA)


            'shift2  PMMA
            Dim ds_shift2_PMMA As New DataSet
            strsql = "select isnull(sum(qty_1),0) from View_PMMA_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-II' and boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            cmd = New SqlCommand(strsql, conPMMA)
            Dim ad4 = New SqlDataAdapter(cmd)
            ad4.Fill(ds_shift2_PMMA)

            dt.Rows.Add(lst(i), (Convert.ToInt32(ds_shift1_PMMA.Tables(0).Rows(0)(0))).ToString(), (Convert.ToInt32(ds_shift2_PMMA.Tables(0).Rows(0)(0))).ToString(), Convert.ToInt32(ds_shift1_PMMA.Tables(0).Rows(0)(0).ToString()) + Convert.ToInt32(ds_shift2_PMMA.Tables(0).Rows(0)(0).ToString()))

        Next

        Dim shift1total As Integer
        Dim shift2total As Integer
        For j As Integer = 0 To dt.Rows.Count - 1
            shift1total += Convert.ToInt32(dt.Rows(j)(1).ToString())
            shift2total += Convert.ToInt32(dt.Rows(j)(2).ToString())
        Next
        dt.Rows.Add("Total", shift1total, shift2total, shift1total + shift2total)
        dt.AcceptChanges()

        Total = shift1total + shift2total
        Return dt
    End Function

    ' lens Cutting report 1st cut

    Public Function GetFirstCutModelList(ByVal byBlanks As String) As List(Of String)
        Dim i As Integer
        Dim lst As List(Of String) = New List(Of String)
        Dim ds As New DataSet
        Dim strsql, Fd, Sd As String

        Dim firstDay As DateTime = New DateTime(selectedDate.Year, selectedDate.Month, 1)
        Fd = firstDay.Year.ToString("0000") + "-" + firstDay.Month.ToString("00") + "-" + firstDay.Day.ToString("00")
        Sd = selectedDate.Year.ToString("0000") + "-" + selectedDate.Month.ToString("00") + "-" + selectedDate.Day.ToString("00")

        strsql = "SELECT   Distinct CASE WHEN Cutting.Model_name IS NULL THEN pp.Model_name ELSE Cutting.Model_name END AS Model " & _
"FROM  (SELECT Model_name, Power, BlanksType, SUM(shiftI) AS shift1_qty, SUM(shiftII) AS shift2_Qty, SUM(Accepted_Qty) AS Acc_Qty, SUM(Rejected_Qty) AS Rej_Qty FROM dbo.CuttingDetails_FirstCut  " & _
               "WHERE (Production_date between '" & Fd & "' and '" & Sd & "') AND (BlanksType in( " & byBlanks & ")) " & _
               "GROUP BY Model_name, Power, BlanksType) AS Cutting FULL OUTER JOIN " & _
               "(SELECT Model_Name, Power, Blanks_Type, Date, Qty FROM dbo.Production_Plan " & _
               "WHERE (Date between '" & Fd & "' and '" & Sd & "') AND (Blanks_Type in( " & byBlanks & "))) AS pp " & _
               "ON Cutting.Model_name = pp.Model_Name AND Cutting.Power = pp.Power AND " & _
               "Cutting.BlanksType = pp.Blanks_Type"
        Dim cmd As New SqlCommand(strsql, conPMMA_ERP)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        lst.Clear()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            lst.Add(ds.Tables(0).Rows(i)("Model").ToString())
        Next

        Return lst
    End Function


    ' lens Cutting report 2nd cut
    Public Function GetSecondCutModelList(ByVal byBlanks As String) As List(Of String)
        Dim i As Integer
        Dim lst As List(Of String) = New List(Of String)
        Dim ds As New DataSet
        Dim strsql, Fd, Sd As String
        Dim firstDay As DateTime = New DateTime(selectedDate.Year, selectedDate.Month, 1)
        Fd = firstDay.Year.ToString("0000") + "-" + firstDay.Month.ToString("00") + "-" + firstDay.Day.ToString("00")
        Sd = selectedDate.Year.ToString("0000") + "-" + selectedDate.Month.ToString("00") + "-" + selectedDate.Day.ToString("00")

        strsql = "SELECT   Distinct CASE WHEN Cutting.Model_name IS NULL THEN pp.Model_name ELSE Cutting.Model_name END AS Model " & _
"FROM  (SELECT Model_name, Power, BlanksType, SUM(shiftI) AS shift1_qty, SUM(shiftII) AS shift2_Qty, SUM(Accepted_Qty) AS Acc_Qty, SUM(Rejected_Qty) AS Rej_Qty FROM dbo.CuttingDetails_SecondCut  " & _
               "WHERE (Production_date between '" & Fd & "' and '" & Sd & "') AND (BlanksType in( " & byBlanks & ")) " & _
               "GROUP BY Model_name, Power, BlanksType) AS Cutting FULL OUTER JOIN " & _
               "(SELECT Model_Name, Power, Blanks_Type, Date, Qty FROM dbo.Production_Plan " & _
               "WHERE (Date between '" & Fd & "' and '" & Sd & "') AND (Blanks_Type in( " & byBlanks & "))) AS pp " & _
               "ON Cutting.Model_name = pp.Model_Name AND Cutting.Power = pp.Power AND " & _
               "Cutting.BlanksType = pp.Blanks_Type"
        Dim cmd As New SqlCommand(strsql, conPMMA_ERP)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        lst.Clear()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            lst.Add(ds.Tables(0).Rows(i)("Model").ToString())
        Next

        Return lst
    End Function


    Public Function GetFirstCutReport(ByVal byModel As String, ByVal byBlanks As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim Fd, Sd As String
        Dim firstDay As DateTime = New DateTime(selectedDate.Year, selectedDate.Month, 1)
        Fd = firstDay.Year.ToString("0000") + "-" + firstDay.Month.ToString("00") + "-" + firstDay.Day.ToString("00")
        Sd = selectedDate.Year.ToString("0000") + "-" + selectedDate.Month.ToString("00") + "-" + selectedDate.Day.ToString("00")


        strsql = "SELECT CASE WHEN Cutting.Power IS NULL THEN pp.Power ELSE Cutting.Power END AS Power, " & _
                        "CASE WHEN Cutting.shift1_qty IS NULL THEN 0 ELSE Cutting.shift1_qty END AS shift1, " & _
                        "CASE WHEN Cutting.shift2_Qty IS NULL THEN 0 ELSE Cutting.shift2_Qty END AS shift2, " & _
                        "CASE WHEN Cutting.shift3_Qty IS NULL THEN 0 ELSE Cutting.shift3_Qty END AS shift3, " & _
                        "CASE WHEN Cutting.Acc_Qty IS NULL THEN 0 ELSE Cutting.Acc_Qty END AS Total, " & _
                        "CASE WHEN pp.Qty IS NULL THEN 0 ELSE pp.Qty END AS Target_Qty " & _
            "FROM  (SELECT Model_name, Power, BlanksType, SUM(shiftI) AS shift1_qty, SUM(shiftII) AS shift2_Qty, SUM(shiftIII) AS shift3_Qty, SUM(Accepted_Qty) AS Acc_Qty, SUM(Rejected_Qty) AS Rej_Qty " & _
                    "FROM dbo.CuttingDetails_FirstCut WHERE (Production_date between '" & Fd & "' and '" & Sd & "') AND (BlanksType in( " & byBlanks & "))" & _
                    "GROUP BY Model_name, Power, BlanksType) AS Cutting FULL OUTER JOIN " & _
                   "(SELECT Model_Name, Power, Blanks_Type, sum(Qty) AS Qty FROM dbo.Production_Plan WHERE (Date between '" & Fd & "' and '" & Sd & "') AND (Blanks_Type in( " & byBlanks & ")) " & _
                    " GROUP BY Model_Name, Power, Blanks_Type) AS pp " & _
                   "ON Cutting.Model_name = pp.Model_Name AND Cutting.Power = pp.Power AND Cutting.BlanksType = pp.Blanks_Type " & _
            "WHERE (Cutting.Model_name = '" & byModel & "') OR (pp.Model_Name = '" & byModel & "') ORDER BY CAST(CASE WHEN Cutting.Power IS NULL THEN pp.Power ELSE Cutting.Power END AS float)"

        cmd = New SqlCommand(strsql, conPMMA_ERP)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)

        Dim shift1total As Integer
        Dim shift2total As Integer
        Dim shift3total As Integer
        Dim accQtytotal As Integer
        Dim TargetQtytotal As Integer
        For j As Integer = 0 To dt.Rows.Count - 1
            shift1total += Convert.ToInt32(dt.Rows(j)("shift1").ToString())
            shift2total += Convert.ToInt32(dt.Rows(j)("shift2").ToString())
            shift3total += Convert.ToInt32(dt.Rows(j)("shift3").ToString())
            accQtytotal += Convert.ToInt32(dt.Rows(j)("Total").ToString())
            TargetQtytotal += Convert.ToInt32(dt.Rows(j)("Target_Qty").ToString())
        Next
        dt.Rows.Add("Total", shift1total, shift2total, shift3total, accQtytotal, TargetQtytotal)
        Return dt
    End Function


    Public Function GetSecondCutReport(ByVal byModel As String, ByVal byBlanks As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim Fd, Sd As String
        Dim firstDay As DateTime = New DateTime(selectedDate.Year, selectedDate.Month, 1)
        Fd = firstDay.Year.ToString("0000") + "-" + firstDay.Month.ToString("00") + "-" + firstDay.Day.ToString("00")
        Sd = selectedDate.Year.ToString("0000") + "-" + selectedDate.Month.ToString("00") + "-" + selectedDate.Day.ToString("00")


        strsql = "SELECT CASE WHEN Cutting.Power IS NULL THEN pp.Power ELSE Cutting.Power END AS Power, " & _
                        "CASE WHEN Cutting.shift1_qty IS NULL THEN 0 ELSE Cutting.shift1_qty END AS shift1, " & _
                        "CASE WHEN Cutting.shift2_Qty IS NULL THEN 0 ELSE Cutting.shift2_Qty END AS shift2, " & _
                        "CASE WHEN Cutting.shift3_Qty IS NULL THEN 0 ELSE Cutting.shift3_Qty END AS shift3, " & _
                        "CASE WHEN Cutting.Acc_Qty IS NULL THEN 0 ELSE Cutting.Acc_Qty END AS Total, " & _
                        "CASE WHEN pp.Qty IS NULL THEN 0 ELSE pp.Qty END AS Target_Qty " & _
            "FROM  (SELECT Model_name, Power, BlanksType, SUM(shiftI) AS shift1_qty, SUM(shiftII) AS shift2_Qty, SUM(shiftIII) AS shift3_Qty, SUM(Accepted_Qty) AS Acc_Qty, SUM(Rejected_Qty) AS Rej_Qty " & _
                    "FROM dbo.CuttingDetails_SecondCut WHERE (Production_date between '" & Fd & "' and '" & Sd & "') AND (BlanksType in( " & byBlanks & "))" & _
                    "GROUP BY Model_name, Power, BlanksType) AS Cutting FULL OUTER JOIN " & _
                   "(SELECT Model_Name, Power, Blanks_Type, sum(Qty) AS Qty FROM dbo.Production_Plan WHERE (Date between '" & Fd & "' and '" & Sd & "') AND (Blanks_Type in( " & byBlanks & ")) " & _
                    " GROUP BY Model_Name, Power, Blanks_Type) AS pp " & _
                   "ON Cutting.Model_name = pp.Model_Name AND Cutting.Power = pp.Power AND Cutting.BlanksType = pp.Blanks_Type " & _
            "WHERE (Cutting.Model_name = '" & byModel & "') OR (pp.Model_Name = '" & byModel & "') ORDER BY CAST(CASE WHEN Cutting.Power IS NULL THEN pp.Power ELSE Cutting.Power END AS float)"

        cmd = New SqlCommand(strsql, conPMMA_ERP)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)

        Dim shift1total As Integer
        Dim shift2total As Integer
        Dim shift3total As Integer
        Dim accQtytotal As Integer
        Dim TargetQtytotal As Integer
        For j As Integer = 0 To dt.Rows.Count - 1
            
            shift1total += Convert.ToInt32(dt.Rows(j)("shift1").ToString())
            shift2total += Convert.ToInt32(dt.Rows(j)("shift2").ToString())
            shift3total += Convert.ToInt32(dt.Rows(j)("shift3").ToString())
            accQtytotal += Convert.ToInt32(dt.Rows(j)("Total").ToString())
            TargetQtytotal += Convert.ToInt32(dt.Rows(j)("Target_Qty").ToString())
        Next
        dt.Rows.Add("Total", shift1total, shift2total, shift3total, accQtytotal, TargetQtytotal)
        Return dt
    End Function


    'Pouch Report
    Public Function GetTargetQty(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        strsql = "SELECT Target_perDay, No_of_WorkingDays " & _
                  "FROM  Pouch_Production_Plan " & _
                  "WHERE (Year = '" & year & " ') AND (Month = '" & month & "') "
        cmd = New SqlCommand(strsql, conPMMA)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)
        Return dt
    End Function


    Public Function PouchReportModel(ByVal startDate As String, ByVal endDate As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        strsql = "SELECT Model_Name, SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) AS shiftI, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS shiftII, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) + SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS Total " & _
                  "FROM  Pouch_Report " & _
                  "WHERE (Created_Date BETWEEN '" & startDate & "' AND '" & endDate & "') " & _
                  "GROUP BY Model_Name " & _
                  "ORDER BY Model_Name "

        cmd = New SqlCommand(strsql, conPMMA)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)

        Dim shift1total As Integer
        Dim shift2total As Integer
        Dim accQtytotal As Integer
        For j As Integer = 0 To dt.Rows.Count - 1

            shift1total += Convert.ToInt32(dt.Rows(j)("shiftI").ToString())
            shift2total += Convert.ToInt32(dt.Rows(j)("shiftII").ToString())
            accQtytotal += Convert.ToInt32(dt.Rows(j)("Total").ToString())
        Next
        dt.Rows.Add("Total", shift1total, shift2total, accQtytotal)
        Return dt
    End Function

    Public Function PouchReportStation(ByVal startDate As String, ByVal endDate As String, ByVal target As String, ByVal current_target As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        strsql = "SELECT PouchStation, SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) AS shiftI, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS shiftII, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) + SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS Total, " & _
                        "'" & current_target & "' AS Current_Target, '" & target & "' AS Target " & _
                  "FROM  Pouch_Report " & _
                  "WHERE (Created_Date BETWEEN '" & startDate & "' AND '" & endDate & "') " & _
                  "GROUP BY PouchStation " & _
                  "ORDER BY PouchStation "

        cmd = New SqlCommand(strsql, conPMMA)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)

        Dim shift1total As Integer
        Dim shift2total As Integer
        Dim accQtytotal As Integer
        Dim CurrentTargetQtytotal As Integer
        Dim TargetQtytotal As Integer
        For j As Integer = 0 To dt.Rows.Count - 1
            shift1total += Convert.ToInt32(dt.Rows(j)("shiftI").ToString())
            shift2total += Convert.ToInt32(dt.Rows(j)("shiftII").ToString())
            accQtytotal += Convert.ToInt32(dt.Rows(j)("Total").ToString())
            TargetQtytotal += Convert.ToInt32(dt.Rows(j)("Target").ToString())
            CurrentTargetQtytotal += Convert.ToInt32(dt.Rows(j)("Current_Target").ToString())
        Next
        dt.Rows.Add("Total", shift1total, shift2total, accQtytotal, CurrentTargetQtytotal, TargetQtytotal)
        Return dt
    End Function

    Public Function GetTargetQtyCurrentMonthly(ByVal target_qty_current As String, ByVal target_per_day As String, ByVal no_of_days As String, ByVal stDate As String, ByVal enDate As String) As String
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        strsql = "SELECT COUNT(DISTINCT CAST(Created_Date AS varchar(10))) - 1 AS Current_target " & _
                  "FROM  POUCH_LABEL " & _
                  "WHERE (Created_Date BETWEEN '" & stDate & "' AND '" & enDate & "') "
        cmd = New SqlCommand(strsql, conPMMA)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)
        Return ((dt.Rows(0)("Current_target") * target_per_day) + target_qty_current).ToString()
    End Function
End Class
