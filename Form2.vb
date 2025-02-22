Public Class Form2

    Dim cycle As Integer = 1

    Private Sub GetPHILICHourlySummaryStationWise()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("Station")
        lblProduct.Text = "PHILIC SHIFT - I"
        dt = PHILICcls.GetSummaryHourlyTableShift1(lst, "Station")
        grid.DataSource = dt


        lblProduct_Shift2.Text = "PHILIC SHIFT - II"
        dt = PHILICcls.GetSummaryHourlyTableShift2(lst, "Station")
        gridShift2.DataSource = dt

    End Sub

    Private Sub GetPHILICHourlySummaryUserWise()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("Box_by")
        lblProduct.Text = "PHILIC SHIFT - I"
        dt = PHILICcls.GetSummaryHourlyTableShift1(lst, "Box_by")
        grid.DataSource = dt

        lblProduct_Shift2.Text = "PHILIC SHIFT - II"
        dt = PHILICcls.GetSummaryHourlyTableShift2(lst, "Box_by")
        gridShift2.DataSource = dt

    End Sub

    Private Sub GetPHILICStationSummary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("Station")
        dt = PHILICcls.GetSummaryTable(lst, "Station")

        grid_Shift.DataSource = dt
        Philic_ColorCode()

    End Sub

    Private Sub Philic_ColorCode()
        For i = 0 To grid_Shift.Rows.Count - 2
            Dim qty As Integer
            Dim h As Integer
            'I - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 6 And DateTime.Now.Hour < 14 Then
                    qty = Convert.ToInt32(grid_Shift.Rows(i).Cells("Shift-I").Value)
                    h = (DateTime.Now.Hour - 6) ' shift start from 6 AM  2 PM
                    h = h + 1
                    If h = 0 Then
                        lblRed.Text = " <=" & 98
                        lblYellow.Text = " >" & 98 & " && <=" & 123
                        lblNormal.Text = " >" & 123 & " && <=" & 174
                        lblGreen.Text = " >" & 174
                        Exit Sub
                    Else
                        lblRed.Text = " <=" & 98 * h
                        lblYellow.Text = " >" & 98 * h & " && <=" & 123 * h
                        lblNormal.Text = " >" & 123 * h & " && <=" & 174 * h
                        lblGreen.Text = " >" & 174 * h
                    End If

                    If qty <= 98 * h Then
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                    ElseIf qty > 98 * h And qty <= 123 * h Then
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                    ElseIf qty > 123 * h And qty <= 174 * h Then
                        'grid_ShiftPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    Else
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblRed.Text = " <=" & 98 * h
                lblYellow.Text = " >" & 98 * h & " && <=" & 123 * h
                lblNormal.Text = " >" & 123 * h & " && <=" & 174 * h
                lblGreen.Text = " >" & 174 * h

                If qty <= 98 * h Then
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                ElseIf qty > 98 * h And qty <= 123 * h Then
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                ElseIf qty > 123 * h And qty <= 174 * h Then
                    'grid_ShiftPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                Else
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                End If

            End If

            'II - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 14 And DateTime.Now.Hour <= 22 Then
                    qty = Convert.ToInt32(grid_Shift.Rows(i).Cells("Shift-II").Value)
                    h = (DateTime.Now.Hour - 14) ' shift start from 2 PM 10 PM
                    h = h + 1
                    If h = 0 Then
                        lblRed.Text = " <=" & 98
                        lblYellow.Text = " >" & 98 & " && <=" & 123
                        lblNormal.Text = " >" & 123 & " && <=" & 174
                        lblGreen.Text = " >" & 174
                        Exit Sub
                    Else
                        lblRed.Text = " <=" & 98 * h
                        lblYellow.Text = " >" & 98 * h & " && <=" & 123 * h
                        lblNormal.Text = " >" & 123 * h & " && <=" & 174 * h
                        lblGreen.Text = " >" & 174 * h
                    End If


                    If qty <= 98 * h Then
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                    ElseIf qty > 98 * h And qty <= 123 * h Then
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                    ElseIf qty > 123 * h And qty <= 174 * h Then
                        'grid_ShiftPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    Else
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    End If

                End If
            Else ' previous day
                h = 8
                lblRed.Text = " <=" & 98 * h
                lblYellow.Text = " >" & 98 * h & " && <=" & 123 * h
                lblNormal.Text = " >" & 123 * h & " && <=" & 174 * h
                lblGreen.Text = " >" & 174 * h

                If qty <= 98 * h Then
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                ElseIf qty > 98 * h And qty <= 123 * h Then
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                ElseIf qty > 123 * h And qty <= 174 * h Then
                    'grid_ShiftPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                Else
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                End If

            End If
        Next
    End Sub

    Private Sub GetPHILICUserSummary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("box_by")
        dt = PHILICcls.GetSummaryTable(lst, "box_by")


        grid_Shift.DataSource = dt

    End Sub
    Private Sub GetPHILICBrandSummmary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("Brand_Name")
        dt = PHILICcls.GetSummaryTable(lst, "Brand_Name")


        gridBrandName.DataSource = dt

        

    End Sub


    '-------------------------------


    Private Sub GetPMMABrandSummary()


        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Brand_Name")
        dt = PMMAcls.GetSummaryTable(lst, "Brand_Name")

        gridBrandName.DataSource = dt


    End Sub

    Private Sub GetPMMAStationSummary()

        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Station")
        dt = PMMAcls.GetSummaryTable(lst, "Station")

        grid_Shift.DataSource = dt
        PMMA_ColorCode()
    End Sub

    Private Sub PMMA_ColorCode()
        For i = 0 To grid_Shift.Rows.Count - 2
            Dim qty As Integer
            Dim h As Integer
            ' I - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 6 And DateTime.Now.Hour < 14 Then
                    qty = Convert.ToInt32(grid_Shift.Rows(i).Cells("Shift-I").Value)
                    h = (DateTime.Now.Hour - 6) ' shift start from 6 AM  2 PM
                    h = h + 1
                    If h = 0 Then
                        lblRed.Text = " <=" & 73
                        lblYellow.Text = " >" & 73 & " && <=" & 94
                        lblNormal.Text = " >" & 94 & " && <=" & 135
                        lblGreen.Text = " >" & 135
                        Exit Sub
                    Else
                        lblRed.Text = " <=" & 73 * h
                        lblYellow.Text = " >" & 73 * h & " && <=" & 94 * h
                        lblNormal.Text = " >" & 94 * h & " && <=" & 135 * h
                        lblGreen.Text = " >" & 135 * h

                    End If

                    If qty <= 73 * h Then
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                    ElseIf qty > 73 * h And qty <= 94 * h Then
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                    ElseIf qty > 94 * h And qty <= 135 * h Then
                        'grid_ShiftPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    Else
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblRed.Text = " <=" & 73 * h
                lblYellow.Text = " >" & 73 * h & " && <=" & 94 * h
                lblNormal.Text = " >" & 94 * h & " && <=" & 135 * h
                lblGreen.Text = " >" & 135 * h

                If qty <= 73 * h Then
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                ElseIf qty > 73 * h And qty <= 94 * h Then
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                ElseIf qty > 94 * h And qty <= 135 * h Then
                    'grid_ShiftPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                Else
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                End If
            End If

            ' II - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 14 And DateTime.Now.Hour <= 22 Then
                    qty = Convert.ToInt32(grid_Shift.Rows(i).Cells("Shift-II").Value)
                    h = (DateTime.Now.Hour - 14) ' shift start from 2 PM 10 PM
                    h = h + 1
                    If h = 0 Then
                        lblRed.Text = " <=" & 73
                        lblYellow.Text = " >" & 73 & " && <=" & 94
                        lblNormal.Text = " >" & 94 & " && <=" & 135
                        lblGreen.Text = " >" & 135
                        Exit Sub
                    Else
                        lblRed.Text = " <=" & 73 * h
                        lblYellow.Text = " >" & 73 * h & " && <=" & 94 * h
                        lblNormal.Text = " >" & 94 * h & " && <=" & 135 * h
                        lblGreen.Text = " >" & 135 * h

                    End If

                    If qty <= 73 * h Then
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                    ElseIf qty > 73 * h And qty <= 94 * h Then
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                    ElseIf qty > 94 * h And qty <= 135 * h Then
                        'grid_ShiftPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    Else
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblRed.Text = " <=" & 73 * h
                lblYellow.Text = " >" & 73 * h & " && <=" & 94 * h
                lblNormal.Text = " >" & 94 * h & " && <=" & 135 * h
                lblGreen.Text = " >" & 135 * h

                If qty <= 73 * h Then
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                ElseIf qty > 73 * h And qty <= 94 * h Then
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                ElseIf qty > 94 * h And qty <= 135 * h Then
                    'grid_ShiftPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                Else
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                End If
            End If

        Next
    End Sub

    Private Sub GetPMMAHourlySummaryStationWise()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Station")
        lblProduct.Text = "PMMA SHIFT-I"
        dt = PMMAcls.GetSummaryHourlyTableShift1(lst, "Station")
        grid.DataSource = dt

        lblProduct_Shift2.Text = "PMMA SHIFT-II"
        dt = PMMAcls.GetSummaryHourlyTableShift2(lst, "Station")
        gridShift2.DataSource = dt

    End Sub

    Private Sub GetPMMAHourlySummaryUserWise()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Box_by")
        lblProduct.Text = "PMMA SHIFT-I"
        dt = PMMAcls.GetSummaryHourlyTableShift1(lst, "Box_by")
        grid.DataSource = dt

        lblProduct_Shift2.Text = "PMMA SHIFT-II"
        dt = PMMAcls.GetSummaryHourlyTableShift2(lst, "Box_by")
        gridShift2.DataSource = dt

    End Sub

    Private Sub GetPMMAUserSummary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Box_By")
        dt = PMMAcls.GetSummaryTable(lst, "Box_By")


        grid_Shift.DataSource = dt
    End Sub

    '-----------------------------------

    Private Sub Phobic_ColorCode()

        For i = 0 To grid_Shift.Rows.Count - 2
            Dim qty As Integer
            Dim h As Integer
            ' I - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 6 And DateTime.Now.Hour < 14 Then
                    qty = Convert.ToInt32(grid_Shift.Rows(i).Cells("Shift-I").Value)
                    h = (DateTime.Now.Hour - 6) ' shift start from 6 AM  2 PM
                    h = h + 1
                    If h = 0 Then
                        lblRed.Text = " <=" & 104
                        lblYellow.Text = " >" & 104 & " && <=" & 133
                        lblNormal.Text = " >" & 133 & " && <=" & 191
                        lblGreen.Text = " >" & 191
                        Exit Sub
                    Else
                        lblRed.Text = " <=" & 104 * h
                        lblYellow.Text = " >" & 104 * h & " && <=" & 133 * h
                        lblNormal.Text = " >" & 133 * h & " && <=" & 191 * h
                        lblGreen.Text = " >" & 191 * h
                    End If


                    If qty <= 104 * h Then
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                    ElseIf qty > 104 * h And qty <= 133 * h Then
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                    ElseIf qty > 133 * h And qty <= 191 * h Then
                        'grid_ShiftPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    Else
                        grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblRed.Text = " <=" & 104 * h
                lblYellow.Text = " >" & 104 * h & " && <=" & 133 * h
                lblNormal.Text = " >" & 133 * h & " && <=" & 191 * h
                lblGreen.Text = " >" & 191 * h

                If qty <= 104 * h Then
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                ElseIf qty > 104 * h And qty <= 133 * h Then
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                ElseIf qty > 133 * h And qty <= 191 * h Then
                    'grid_ShiftPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                Else
                    grid_Shift.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                End If
            End If


            ' II - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 14 And DateTime.Now.Hour <= 22 Then
                    qty = Convert.ToInt32(grid_Shift.Rows(i).Cells("Shift-II").Value)
                    h = (DateTime.Now.Hour - 14) ' shift start from 2 PM 10 PM
                    h = h + 1
                    If h = 0 Then
                        lblRed.Text = " <=" & 104
                        lblYellow.Text = " >" & 104 & " && <=" & 133
                        lblNormal.Text = " >" & 133 & " && <=" & 191
                        lblGreen.Text = " >" & 191
                        Exit Sub
                    Else
                        lblRed.Text = " <=" & 104 * h
                        lblYellow.Text = " >" & 104 * h & " && <=" & 133 * h
                        lblNormal.Text = " >" & 133 * h & " && <=" & 191 * h
                        lblGreen.Text = " >" & 191 * h
                    End If

                    If qty <= 104 * h Then
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                    ElseIf qty > 104 * h And qty <= 133 * h Then
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                    ElseIf qty > 133 * h And qty <= 191 * h Then
                        'grid_ShiftPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    Else
                        grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    End If

                End If
            Else ' previous day

                h = 8
                lblRed.Text = " <=" & 104 * h
                lblYellow.Text = " >" & 104 * h & " && <=" & 133 * h
                lblNormal.Text = " >" & 133 * h & " && <=" & 191 * h
                lblGreen.Text = " >" & 191 * h

                If qty <= 104 * h Then
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                ElseIf qty > 104 * h And qty <= 133 * h Then
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                ElseIf qty > 133 * h And qty <= 191 * h Then
                    'grid_ShiftPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                Else
                    grid_Shift.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                End If
            End If
        Next

    End Sub

    Private Sub GetPHOBICStationSummary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHOBICcls As New PHOBICClass()
        PHOBICcls.PHOBICClass()
        PHOBICcls.selectedDate = dtpdate.Value

        lst = PHOBICcls.GetNameList("Station")
        dt = PHOBICcls.GetSummaryTable(lst, "Station")


        grid_Shift.DataSource = dt
        Phobic_ColorCode()
    End Sub

    Private Sub GetPHOBICUserSummary()

        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHOBICcls As New PHOBICClass()
        PHOBICcls.PHOBICClass()
        PHOBICcls.selectedDate = dtpdate.Value

        lst = PHOBICcls.GetNameList("box_by")
        dt = PHOBICcls.GetSummaryTable(lst, "box_by")


        grid_Shift.DataSource = dt
    End Sub

    Private Sub GetPHOBICBrandSummary()

        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHOBICcls As New PHOBICClass()
        PHOBICcls.PHOBICClass()
        PHOBICcls.selectedDate = dtpdate.Value

        lst = PHOBICcls.GetNameList("Brand_Name")
        dt = PHOBICcls.GetSummaryTable(lst, "Brand_Name")

        'grid.DataSource = dt
        gridBrandName.DataSource = dt





    End Sub

    Private Sub GetPHOBICHourlySummaryStationWise()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHOBICcls As New PHOBICClass()
        PHOBICcls.PHOBICClass()
        PHOBICcls.selectedDate = dtpdate.Value

        lst = PHOBICcls.GetNameList("Station")
        lblProduct.Text = "PHOBIC SHIFT-I"
        dt = PHOBICcls.GetSummaryHourlyTableShift1(lst, "Station")
        grid.DataSource = dt

        lblProduct_Shift2.Text = "PHOBIC SHIFT-II"
        dt = PHOBICcls.GetSummaryHourlyTableShift2(lst, "Station")
        gridShift2.DataSource = dt

    End Sub

    Private Sub GetPHOBICHourlySummaryUserWise()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHOBICcls As New PHOBICClass()
        PHOBICcls.PHOBICClass()
        PHOBICcls.selectedDate = dtpdate.Value

        lst = PHOBICcls.GetNameList("Box_by")
        lblProduct.Text = "PHOBIC SHIFT-I"
        dt = PHOBICcls.GetSummaryHourlyTableShift1(lst, "Box_by")
        grid.DataSource = dt

        lblProduct_Shift2.Text = "PHOBIC SHIFT-II"
        dt = PHOBICcls.GetSummaryHourlyTableShift2(lst, "Box_by")
        gridShift2.DataSource = dt


    End Sub

    Private Sub LoadGridViewFormats()
        With grid.ColumnHeadersDefaultCellStyle
            .Font = New Font(.Font.FontFamily, .Font.Size, _
             .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With
        With gridShift2.ColumnHeadersDefaultCellStyle
            .Font = New Font(.Font.FontFamily, .Font.Size, _
             .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With
        With grid_Shift.ColumnHeadersDefaultCellStyle
            .Font = New Font(.Font.FontFamily, .Font.Size, _
             .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With
        With gridBrandName.ColumnHeadersDefaultCellStyle
            .Font = New Font(.Font.FontFamily, .Font.Size, _
             .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With

        'grid.Columns("Target").DefaultCellStyle.ForeColor = Color.White
        'grid.Columns("Target").DefaultCellStyle.BackColor = Color.LightGray
        'gridShift2.Columns("Target").DefaultCellStyle.ForeColor = Color.White
        'gridShift2.Columns("Target").DefaultCellStyle.BackColor = Color.LightSalmon
    End Sub


    Private Sub btnFetch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFetch.Click
        LoadMethod()
        LoadGridViewFormats()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If chkCycle.Checked Then
            Load_CycleMethod()
            LoadGridViewFormats()
        Else
            LoadMethod()
            LoadGridViewFormats()
        End If

    End Sub


    Private Sub Load_CycleMethod()
        grid.Columns.Clear()

        If cycle = 1 Then
            lblProduct.Text = rbPHILIC.Text
            lblProduct_Shift.Text = rbPHILIC.Text
            If rbStationWise.Checked Then  'Station wise
                GetPHILICHourlySummaryStationWise()
                GetPHILICStationSummary()
                GetPHILICBrandSummmary()
            Else ' user wise
                GetPHILICHourlySummaryUserWise()
                GetPHILICUserSummary()
                GetPHILICBrandSummmary()
            End If
        ElseIf cycle = 2 Then
            lblProduct.Text = rbPHOBIC.Text
            lblProduct_Shift.Text = rbPHOBIC.Text
            If rbStationWise.Checked Then  'Station wise
                GetPHOBICHourlySummaryStationWise()
                GetPHOBICStationSummary()
                GetPHOBICBrandSummary()
            Else ' user wise
                GetPHOBICHourlySummaryUserWise()
                GetPHOBICUserSummary()
                GetPHOBICBrandSummary()
            End If
            'ElseIf cycle = 3 Then
            '    lblProduct.Text = rbPMMA.Text
            '    lblProduct_Shift.Text = rbPMMA.Text
            '    If rbStationWise.Checked Then  'Station wise
            '        GetPMMAHourlySummaryStationWise()
            '        GetPMMAStationSummary()
            '        GetPMMABrandSummary()
            '    Else ' user wise
            '        GetPMMAHourlySummaryUserWise()
            '        GetPMMAUserSummary()
            '        GetPMMABrandSummary()
            '    End If
        End If
        cycle = cycle + 1
        If cycle > 2 Then
            cycle = 1
        End If


    End Sub

    Private Sub LoadMethod()
        grid.Columns.Clear()

        If rbPHILIC.Checked Then
            lblProduct.Text = rbPHILIC.Text
            lblProduct_Shift.Text = rbPHILIC.Text
            If rbStationWise.Checked Then  'Station wise
                GetPHILICHourlySummaryStationWise()
                GetPHILICStationSummary()
                GetPHILICBrandSummmary()

            Else ' user wise
                GetPHILICHourlySummaryUserWise()
                GetPHILICUserSummary()
                GetPHILICBrandSummmary()
            End If
        End If


        If rbPHOBIC.Checked Then
            lblProduct.Text = rbPHOBIC.Text
            lblProduct_Shift.Text = rbPHOBIC.Text
            If rbStationWise.Checked Then  'Station wise
                GetPHOBICHourlySummaryStationWise()
                GetPHOBICStationSummary()
                GetPHOBICBrandSummary()
            Else ' user wise
                GetPHOBICHourlySummaryUserWise()
                GetPHOBICUserSummary()
                GetPHOBICBrandSummary()
            End If
        End If

        If rbPMMA.Checked Then
            lblProduct.Text = rbPMMA.Text
            lblProduct_Shift.Text = rbPMMA.Text
            If rbStationWise.Checked Then  'Station wise
                GetPMMAHourlySummaryStationWise()
                GetPMMAStationSummary()
                GetPMMABrandSummary()

            Else ' user wise
                GetPMMAHourlySummaryUserWise()
                GetPMMAUserSummary()
                GetPMMABrandSummary()

            End If
        End If
    End Sub

    Private Sub chkCycle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCycle.CheckedChanged
        GB_Product.Enabled = Not chkCycle.Checked
    End Sub
End Class