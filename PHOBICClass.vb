Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class PHOBICClass
    Dim con As New SqlConnection
    Dim conPHOBIC As New SqlConnection
    Dim conNP, conPHOBIC_ERP, conPHOBIC_Mould As New SqlConnection
    Public selectedDate As DateTime
    Public Total As Integer

    Public Sub PHOBICClass()
        con.ConnectionString = ConfigurationSettings.AppSettings("conStrAPSBOX").ToString()
        conPHOBIC.ConnectionString = ConfigurationSettings.AppSettings("conStrPHOBIC").ToString()
        conNP.ConnectionString = ConfigurationSettings.AppSettings("conStrNP").ToString()
        conPHOBIC_ERP.ConnectionString = ConfigurationSettings.AppSettings("conStrPHOBIC_ERP").ToString()
        conPHOBIC_Mould.ConnectionString = ConfigurationSettings.AppSettings("conStrPHOBIC_Mould").ToString()
    End Sub


    Public Function GetNameList(ByVal byname As String) As List(Of String)
        Dim i As Integer
        Dim lst As List(Of String) = New List(Of String)
        Dim ds As New DataSet
        Dim strsql As String
        strsql = "SELECT  Distinct " + byname + " FROM dbo.View_PHOBIC_Monitor where boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'  "
        Dim cmd As New SqlCommand(strsql, conPHOBIC)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        lst.Clear()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            lst.Add(ds.Tables(0).Rows(i)(byname).ToString())
        Next

        'Dim ds1 As New DataSet
        'strsql = "SELECT  Distinct " + byname + " FROM dbo.View_PHOBIC_Monitor where boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'  "
        'cmd = New SqlCommand(strsql, conPHOBIC)
        'Dim ad_1 As New SqlDataAdapter(cmd)
        'ad_1.Fill(ds1)

        'For i = 0 To ds1.Tables(0).Rows.Count - 1
        '    If Not lst.Contains(ds1.Tables(0).Rows(i)(byname).ToString()) Then
        '        lst.Add(ds1.Tables(0).Rows(i)(byname).ToString())
        '    End If
        'Next

        'Non Preloaded..
        Dim ds2 As New DataSet
        strsql = "SELECT  Distinct " + byname + " FROM dbo.View_NONPRELOADED_Monitor where boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'  "
        cmd = New SqlCommand(strsql, conNP)
        Dim ad_2 As New SqlDataAdapter(cmd)
        ad_2.Fill(ds2)

        For i = 0 To ds2.Tables(0).Rows.Count - 1
            If Not lst.Contains(ds2.Tables(0).Rows(i)(byname).ToString()) Then
                lst.Add(ds2.Tables(0).Rows(i)(byname).ToString())
            End If
        Next

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
            'strsql = "select * from View_PHOBIC_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
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

            'PHOBIC DB
            Dim dsPHOBIC As New DataSet
            strsql = "select * from View_PHOBIC_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conPHOBIC)
            Dim ad1 = New SqlDataAdapter(cmd)
            ad1.Fill(dsPHOBIC)

            For k = 0 To dsPHOBIC.Tables(0).Rows.Count - 1
                If Not IsDBNull(row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "") = dsPHOBIC.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Qty"))
                row("Total") = total
            Next k


            'NONPRELOADED DB
            Dim dsNP As New DataSet
            strsql = "select * from View_NONPRELOADED_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conNP)
            Dim ad2 = New SqlDataAdapter(cmd)
            ad2.Fill(dsNP)

            For k = 0 To dsNP.Tables(0).Rows.Count - 1
                If Not IsDBNull(row("" & dsNP.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsNP.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsNP.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsNP.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsNP.Tables(0).Rows(k)("Hour") & "") = dsNP.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsNP.Tables(0).Rows(k)("Qty"))
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
            'strsql = "select * from View_PHOBIC_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
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
            '    row("Target") = Int(1241)
            'Next k

            'PHOBIC DB
            Dim dsPHOBIC As New DataSet
            strsql = "select * from View_PHOBIC_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conPHOBIC)
            Dim ad1 = New SqlDataAdapter(cmd)
            ad1.Fill(dsPHOBIC)

            For k = 0 To dsPHOBIC.Tables(0).Rows.Count - 1
                If Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Hour")) > 13 Then Exit For
                If Not IsDBNull(row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "") = dsPHOBIC.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Qty"))
                row("Total") = total
                row("Target") = Int(1241)
            Next k


            'NONPRELOADED DB
            Dim dsNP As New DataSet
            strsql = "select * from View_NONPRELOADED_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conNP)
            Dim ad2 = New SqlDataAdapter(cmd)
            ad2.Fill(dsNP)

            For k = 0 To dsNP.Tables(0).Rows.Count - 1
                If Convert.ToInt32(dsNP.Tables(0).Rows(k)("Hour")) > 13 Then Exit For
                If Not IsDBNull(row("" & dsNP.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsNP.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsNP.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsNP.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsNP.Tables(0).Rows(k)("Hour") & "") = dsNP.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsNP.Tables(0).Rows(k)("Qty"))
                row("Total") = total
                row("Target") = Int(1241)
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
            'strsql = "select * from View_PHOBIC_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad = New SqlDataAdapter(cmd)
            'ad.Fill(ds)

            Dim total As Integer = 0
            Dim row As DataRow = dt.NewRow()
            row(byname) = lst(i)
            ''BOX DB
            'For k = 0 To ds.Tables(0).Rows.Count - 1
            '    If Convert.ToInt32(ds.Tables(0).Rows(k)("Hour")) <= 13 Then Continue For
            '    row("" & ds.Tables(0).Rows(k)("Hour") & "") = ds.Tables(0).Rows(k)("Qty")
            '    total = total + Convert.ToInt32(ds.Tables(0).Rows(k)("Qty"))
            '    row("Total") = total
            '    row("Target") = Int(1241)
            'Next k

            'PHOBIC DB
            Dim dsPHOBIC As New DataSet
            strsql = "select * from View_PHOBIC_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conPHOBIC)
            Dim ad1 = New SqlDataAdapter(cmd)
            ad1.Fill(dsPHOBIC)

            For k = 0 To dsPHOBIC.Tables(0).Rows.Count - 1
                If Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Hour")) <= 13 Then Continue For
                If Not IsDBNull(row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsPHOBIC.Tables(0).Rows(k)("Hour") & "") = dsPHOBIC.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsPHOBIC.Tables(0).Rows(k)("Qty"))
                row("Total") = total
                row("Target") = Int(1241)
            Next k


            'NONPRELOADED DB
            Dim dsNP As New DataSet
            strsql = "select * from View_NONPRELOADED_Monitor_Hourly where " + byname + " = '" & lst(i) & "' and BoxTime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + "' AND '" + selectedDate.ToString("yyyy-MM-dd") + "' order by cast (hour as int)  "
            cmd = New SqlCommand(strsql, conNP)
            Dim ad2 = New SqlDataAdapter(cmd)
            ad2.Fill(dsNP)

            For k = 0 To dsNP.Tables(0).Rows.Count - 1
                If Convert.ToInt32(dsNP.Tables(0).Rows(k)("Hour")) <= 13 Then Continue For
                If Not IsDBNull(row("" & dsNP.Tables(0).Rows(k)("Hour") & "")) Then
                    row("" & dsNP.Tables(0).Rows(k)("Hour") & "") = Convert.ToInt32(row("" & dsNP.Tables(0).Rows(k)("Hour") & "")) + Convert.ToInt32(dsNP.Tables(0).Rows(k)("Qty"))
                Else
                    row("" & dsNP.Tables(0).Rows(k)("Hour") & "") = dsNP.Tables(0).Rows(k)("Qty")
                End If
                total = total + Convert.ToInt32(dsNP.Tables(0).Rows(k)("Qty"))
                row("Total") = total
                row("Target") = Int(1241)
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

            'shift1
            'Dim ds_shift1 As New DataSet
            'strsql = "select isnull(sum(qty),0) from View_PHOBIC_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-I' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad1 = New SqlDataAdapter(cmd)
            'ad1.Fill(ds_shift1)


            ''shift2
            'Dim ds_shift2 As New DataSet
            'strsql = "select isnull(sum(qty),0) from View_PHOBIC_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-II' and created_date BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            'cmd = New SqlCommand(strsql, con)
            'Dim ad2 = New SqlDataAdapter(cmd)
            'ad2.Fill(ds_shift2)

            'shift1 PMMA
            Dim ds_shift1_PMMA As New DataSet
            strsql = "select isnull(sum(qty_1),0) from View_PHOBIC_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-I' and boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            cmd = New SqlCommand(strsql, conPHOBIC)
            Dim ad3 = New SqlDataAdapter(cmd)
            ad3.Fill(ds_shift1_PMMA)


            'shift2  PMMA
            Dim ds_shift2_PMMA As New DataSet
            strsql = "select isnull(sum(qty_1),0) from View_PHOBIC_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-II' and boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            cmd = New SqlCommand(strsql, conPHOBIC)
            Dim ad4 = New SqlDataAdapter(cmd)
            ad4.Fill(ds_shift2_PMMA)

            'shift1 NP
            Dim ds_shift1_NP As New DataSet
            strsql = "select isnull(sum(qty_1),0) from View_NONPRELOADED_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-I' and boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            cmd = New SqlCommand(strsql, conNP)
            Dim ad5 = New SqlDataAdapter(cmd)
            ad5.Fill(ds_shift1_NP)


            'shift2  NP
            Dim ds_shift2_NP As New DataSet
            strsql = "select isnull(sum(qty_1),0) from View_NONPRELOADED_Monitor where " + byname + " = '" & lst(i) & "' and shift = 'SHIFT-II' and boxtime BETWEEN '" + selectedDate.ToString("yyyy-MM-dd") + " 06:00:00.000' AND '" + selectedDate.ToString("yyyy-MM-dd") + " 22:00:00.000'   "
            cmd = New SqlCommand(strsql, conNP)
            Dim ad6 = New SqlDataAdapter(cmd)
            ad6.Fill(ds_shift2_NP)

            dt.Rows.Add(lst(i), (Convert.ToInt32(ds_shift1_PMMA.Tables(0).Rows(0)(0)) + Convert.ToInt32(ds_shift1_NP.Tables(0).Rows(0)(0))).ToString(),
                        (Convert.ToInt32(ds_shift2_PMMA.Tables(0).Rows(0)(0)) + Convert.ToInt32(ds_shift2_NP.Tables(0).Rows(0)(0))).ToString(),
                          Convert.ToInt32(ds_shift1_PMMA.Tables(0).Rows(0)(0).ToString()) + Convert.ToInt32(ds_shift2_PMMA.Tables(0).Rows(0)(0).ToString()) + Convert.ToInt32(ds_shift1_NP.Tables(0).Rows(0)(0).ToString()) + Convert.ToInt32(ds_shift2_NP.Tables(0).Rows(0)(0).ToString()))

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

    'Phobic Cutting

    Public Function GetMouldingModelList() As List(Of String)
        Dim i As Integer
        Dim lst As List(Of String) = New List(Of String)
        Dim ds As New DataSet
        Dim strsql, Fd, Sd As String

        Dim firstDay As DateTime = New DateTime(selectedDate.Year, selectedDate.Month, 1)
        Fd = firstDay.Year.ToString("0000") + "-" + firstDay.Month.ToString("00") + "-" + firstDay.Day.ToString("00")
        Sd = selectedDate.Year.ToString("0000") + "-" + selectedDate.Month.ToString("00") + "-" + selectedDate.Day.ToString("00")

        strsql = "SELECT DISTINCT CASE WHEN Moulding.ModelNo IS NULL THEN pp.Model_name ELSE Moulding.ModelNo END AS ModelNo " & _
                "FROM  (SELECT ModelNo, Power, SUM(shiftI) AS shift1_Qty, SUM(shiftII) AS shift2_Qty, SUM(shiftIII) AS shift3_Qty, SUM(Accepted_Qty) AS Acc_Qty " & _
                        "FROM   dbo.Details_Moulding  WHERE (Date BETWEEN '" & Fd & "' AND '" & Sd & "') " & _
                        "GROUP BY ModelNo, Power) AS Moulding FULL OUTER JOIN " & _
                        "(SELECT Model_Name, Power, SUM(Qty) AS Qty FROM   dbo.Production_Plan " & _
                        "WHERE (Date BETWEEN '" & Fd & "' AND '" & Sd & "') " & _
                        "GROUP BY Model_Name, Power) AS pp ON Moulding.ModelNo = pp.Model_Name AND Moulding.Power = pp.Power "
        Dim cmd As New SqlCommand(strsql, conPHOBIC_Mould)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        lst.Clear()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            lst.Add(ds.Tables(0).Rows(i)("ModelNo").ToString())
        Next

        Return lst
    End Function

    Public Function GetMouldingReport(ByVal byModel As String) As DataTable
        Dim strsql As String
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim Fd, Sd As String
        Dim firstDay As DateTime = New DateTime(selectedDate.Year, selectedDate.Month, 1)
        Fd = firstDay.Year.ToString("0000") + "-" + firstDay.Month.ToString("00") + "-" + firstDay.Day.ToString("00")
        Sd = selectedDate.Year.ToString("0000") + "-" + selectedDate.Month.ToString("00") + "-" + selectedDate.Day.ToString("00")


        strsql = "SELECT CAST(CASE WHEN Moulding.Power IS NULL THEN pp.Power ELSE Moulding.Power END AS VARCHAR) AS Power, " & _
                        "CASE WHEN Moulding.shift1_qty IS NULL THEN 0 ELSE Moulding.shift1_qty END AS shift1, " & _
                        "CASE WHEN Moulding.shift2_Qty IS NULL THEN 0 ELSE Moulding.shift2_Qty END AS shift2, " & _
                        "CASE WHEN Moulding.shift3_Qty IS NULL THEN 0 ELSE Moulding.shift3_Qty END AS shift3, " & _
                        "CASE WHEN Moulding.Acc_Qty IS NULL THEN 0 ELSE Moulding.Acc_Qty END AS Total, " & _
                        "CASE WHEN pp.Qty IS NULL THEN 0 ELSE pp.Qty END AS Target_Qty " & _
                "FROM  (SELECT ModelNo, Power, SUM(shiftI) AS shift1_Qty, SUM(shiftII) AS shift2_Qty, SUM(shiftIII) AS shift3_Qty, SUM(Accepted_Qty) AS Acc_Qty " & _
                        "FROM   dbo.Details_Moulding WHERE (Date BETWEEN '" & Fd & "' AND '" & Sd & "') GROUP BY ModelNo, Power) AS Moulding FULL OUTER JOIN " & _
                        "(SELECT Model_Name, Power, SUM(Qty) AS Qty FROM   dbo.Production_Plan WHERE (Date BETWEEN '" & Fd & "' AND '" & Sd & "') " & _
                        "GROUP BY Model_Name, Power) AS pp ON Moulding.ModelNo = pp.Model_Name AND Moulding.Power = pp.Power " & _
                "WHERE (Moulding.ModelNo = '" & byModel & "') OR (pp.Model_Name = '" & byModel & "') " & _
                "ORDER BY CAST(CASE WHEN Moulding.Power IS NULL THEN pp.Power ELSE Moulding.Power END AS float)"
        cmd = New SqlCommand(strsql, conPHOBIC_Mould)
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
        cmd = New SqlCommand(strsql, conPHOBIC)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)
        Return dt
    End Function

    Public Function PouchReportModel(ByVal startDate As String, ByVal endDate As String) As DataTable
        Dim strsql As String
        Dim dt, dtNP As New DataTable
        Dim cmd As New SqlCommand
        Dim ds, dsNP As New DataSet
        strsql = "SELECT Model_Name, SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) AS shiftI, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS shiftII, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) + SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS Total " & _
                  "FROM  Pouch_Report " & _
                  "WHERE (Created_Date BETWEEN '" & startDate & "' AND '" & endDate & "') " & _
                  "GROUP BY Model_Name " & _
                  "ORDER BY Model_Name "

        cmd = New SqlCommand(strsql, conPHOBIC)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)

        'NP
        strsql = "SELECT Model_Name+' - (NP)' AS Model_Name, SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) AS shiftI, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS shiftII, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) + SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS Total " & _
                  "FROM  Pouch_Report " & _
                  "WHERE (Created_Date BETWEEN '" & startDate & "' AND '" & endDate & "') " & _
                  "GROUP BY Model_Name " & _
                  "ORDER BY Model_Name "
        cmd = New SqlCommand(strsql, conNP)
        Dim ad1 As New SqlDataAdapter(cmd)
        ad1.Fill(dsNP)
        dtNP = dsNP.Tables(0)

        dt.Merge(dtNP)
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

    Public Function PouchReportStation(ByVal startDate As String, ByVal endDate As String, ByVal target As String) As DataTable
        Dim strsql As String
        Dim dt, dtNP As New DataTable
        Dim cmd As New SqlCommand
        Dim ds, dsNP As New DataSet
        strsql = "SELECT PouchStation, SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) AS shiftI, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS shiftII, " & _
                        "SUM(CASE WHEN shift = 'SHIFT-I' THEN Qty_1 ELSE 0 END) + SUM(CASE WHEN shift = 'SHIFT-II' THEN Qty_1 ELSE 0 END) AS Total, " & _
                        "'" & target & "' AS Target " & _
                  "FROM  Pouch_Report " & _
                  "WHERE (Created_Date BETWEEN '" & startDate & "' AND '" & endDate & "') " & _
                  "GROUP BY PouchStation " & _
                  "ORDER BY PouchStation "
        cmd = New SqlCommand(strsql, conPHOBIC)
        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(ds)
        dt = ds.Tables(0)

        'NP
        cmd = New SqlCommand(strsql, conNP)
        Dim ad1 As New SqlDataAdapter(cmd)
        ad1.Fill(dsNP)
        dtNP = dsNP.Tables(0)

        dt.Merge(dtNP)

        Dim shift1total As Integer
        Dim shift2total As Integer
        Dim accQtytotal As Integer
        Dim TargetQtytotal As Integer
        For j As Integer = 0 To dt.Rows.Count - 1
            shift1total += Convert.ToInt32(dt.Rows(j)("shiftI").ToString())
            shift2total += Convert.ToInt32(dt.Rows(j)("shiftII").ToString())
            accQtytotal += Convert.ToInt32(dt.Rows(j)("Total").ToString())
            TargetQtytotal += Convert.ToInt32(dt.Rows(j)("Target").ToString())
        Next
        dt.Rows.Add("Total", shift1total, shift2total, accQtytotal, TargetQtytotal)
        Return dt
    End Function

End Class
