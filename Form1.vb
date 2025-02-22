Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1

    Dim grandtotal As Integer
    Dim cycle As Integer = 0


    Private Sub Phobic_ColorCode()

        For i = 0 To gridPHOBIC_Station.Rows.Count - 2
            Dim qty As Integer
            Dim h As Integer
            ' I - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 6 And DateTime.Now.Hour < 14 Then
                    qty = Convert.ToInt32(gridPHOBIC_Station.Rows(i).Cells("Shift-I").Value)
                    h = (DateTime.Now.Hour - 6) ' shift start from 6 AM  2 PM
                    h = h + 1
                    If h = 0 Then
                        lblPhobic_Red.Text = " <=" & 104
                        lblPhobic_Yellow.Text = " >" & 104 & " && <=" & 133
                        lblPhobic_Normal.Text = " >" & 133 & " && <=" & 191
                        lblPhobic_Green.Text = " >" & 191
                        Exit Sub
                    Else
                        lblPhobic_Red.Text = " <=" & 104 * h
                        lblPhobic_Yellow.Text = " >" & 104 * h & " && <=" & 133 * h
                        lblPhobic_Normal.Text = " >" & 133 * h & " && <=" & 191 * h
                        lblPhobic_Green.Text = " >" & 191 * h
                    End If


                    If qty <= 104 * h Then
                        gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                    ElseIf qty > 104 * h And qty <= 133 * h Then
                        gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                    ElseIf qty > 133 * h And qty <= 191 * h Then
                        'gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    Else
                        gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblPhobic_Red.Text = " <=" & 104 * h
                lblPhobic_Yellow.Text = " >" & 104 * h & " && <=" & 133 * h
                lblPhobic_Normal.Text = " >" & 133 * h & " && <=" & 191 * h
                lblPhobic_Green.Text = " >" & 191 * h

                If qty <= 104 * h Then
                    gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                ElseIf qty > 104 * h And qty <= 133 * h Then
                    gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                ElseIf qty > 133 * h And qty <= 191 * h Then
                    'gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                Else
                    gridPHOBIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                End If
            End If


            ' II - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 14 And DateTime.Now.Hour <= 22 Then
                    qty = Convert.ToInt32(gridPHOBIC_Station.Rows(i).Cells("Shift-II").Value)
                    h = (DateTime.Now.Hour - 14) ' shift start from 2 PM 10 PM
                    h = h + 1
                    If h = 0 Then
                        lblPhobic_Red.Text = " <=" & 104
                        lblPhobic_Yellow.Text = " >" & 104 & " && <=" & 133
                        lblPhobic_Normal.Text = " >" & 133 & " && <=" & 191
                        lblPhobic_Green.Text = " >" & 191
                        Exit Sub
                    Else
                        lblPhobic_Red.Text = " <=" & 104 * h
                        lblPhobic_Yellow.Text = " >" & 104 * h & " && <=" & 133 * h
                        lblPhobic_Normal.Text = " >" & 133 * h & " && <=" & 191 * h
                        lblPhobic_Green.Text = " >" & 191 * h
                    End If

                    If qty <= 104 * h Then
                        gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                    ElseIf qty > 104 * h And qty <= 133 * h Then
                        gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                    ElseIf qty > 133 * h And qty <= 191 * h Then
                        'gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    Else
                        gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    End If

                End If
            Else ' previous day

                h = 8
                lblPhobic_Red.Text = " <=" & 104 * h
                lblPhobic_Yellow.Text = " >" & 104 * h & " && <=" & 133 * h
                lblPhobic_Normal.Text = " >" & 133 * h & " && <=" & 191 * h
                lblPhobic_Green.Text = " >" & 191 * h

                If qty <= 104 * h Then
                    gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                ElseIf qty > 104 * h And qty <= 133 * h Then
                    gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                ElseIf qty > 133 * h And qty <= 191 * h Then
                    'gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                Else
                    gridPHOBIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                End If
            End If
        Next

    End Sub

    Private Sub PMMA_ColorCode()
        For i = 0 To gridPMMA_Station.Rows.Count - 2
            Dim qty As Integer
            Dim h As Integer
            ' I - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 6 And DateTime.Now.Hour < 14 Then
                    qty = Convert.ToInt32(gridPMMA_Station.Rows(i).Cells("Shift-I").Value)
                    h = (DateTime.Now.Hour - 6) ' shift start from 6 AM  2 PM
                    h = h + 1
                    If h = 0 Then
                        lblPMMA_Red.Text = " <=" & 73
                        lblPMMA_Yellow.Text = " >" & 73 & " && <=" & 94
                        lblPMMA_Normal.Text = " >" & 94 & " && <=" & 135
                        lblPMMA_Green.Text = " >" & 135
                        Exit Sub
                    Else
                        lblPMMA_Red.Text = " <=" & 73 * h
                        lblPMMA_Yellow.Text = " >" & 73 * h & " && <=" & 94 * h
                        lblPMMA_Normal.Text = " >" & 94 * h & " && <=" & 135 * h
                        lblPMMA_Green.Text = " >" & 135 * h

                    End If

                    If qty <= 73 * h Then
                        gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                    ElseIf qty > 73 * h And qty <= 94 * h Then
                        gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                    ElseIf qty > 94 * h And qty <= 135 * h Then
                        'gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    Else
                        gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblPMMA_Red.Text = " <=" & 73 * h
                lblPMMA_Yellow.Text = " >" & 73 * h & " && <=" & 94 * h
                lblPMMA_Normal.Text = " >" & 94 * h & " && <=" & 135 * h
                lblPMMA_Green.Text = " >" & 135 * h

                If qty <= 73 * h Then
                    gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                ElseIf qty > 73 * h And qty <= 94 * h Then
                    gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                ElseIf qty > 94 * h And qty <= 135 * h Then
                    'gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                Else
                    gridPMMA_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                End If
            End If

            ' II - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 14 And DateTime.Now.Hour <= 22 Then
                    qty = Convert.ToInt32(gridPMMA_Station.Rows(i).Cells("Shift-II").Value)
                    h = (DateTime.Now.Hour - 14) ' shift start from 2 PM 10 PM
                    h = h + 1
                    If h = 0 Then
                        lblPMMA_Red.Text = " <=" & 73
                        lblPMMA_Yellow.Text = " >" & 73 & " && <=" & 94
                        lblPMMA_Normal.Text = " >" & 94 & " && <=" & 135
                        lblPMMA_Green.Text = " >" & 135
                        Exit Sub
                    Else
                        lblPMMA_Red.Text = " <=" & 73 * h
                        lblPMMA_Yellow.Text = " >" & 73 * h & " && <=" & 94 * h
                        lblPMMA_Normal.Text = " >" & 94 * h & " && <=" & 135 * h
                        lblPMMA_Green.Text = " >" & 135 * h

                    End If

                    If qty <= 73 * h Then
                        gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                    ElseIf qty > 73 * h And qty <= 94 * h Then
                        gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                    ElseIf qty > 94 * h And qty <= 135 * h Then
                        'gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    Else
                        gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblPMMA_Red.Text = " <=" & 73 * h
                lblPMMA_Yellow.Text = " >" & 73 * h & " && <=" & 94 * h
                lblPMMA_Normal.Text = " >" & 94 * h & " && <=" & 135 * h
                lblPMMA_Green.Text = " >" & 135 * h

                If qty <= 73 * h Then
                    gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                ElseIf qty > 73 * h And qty <= 94 * h Then
                    gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                ElseIf qty > 94 * h And qty <= 135 * h Then
                    'gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                Else
                    gridPMMA_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                End If
            End If

        Next
    End Sub

    Private Sub Philic_ColorCode()
        For i = 0 To gridPHILIC_Station.Rows.Count - 2
            Dim qty As Integer
            Dim h As Integer
            'I - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 6 And DateTime.Now.Hour < 14 Then
                    qty = Convert.ToInt32(gridPHILIC_Station.Rows(i).Cells("Shift-I").Value)
                    h = (DateTime.Now.Hour - 6) ' shift start from 6 AM  2 PM
                    h = h + 1
                    If h = 0 Then
                        lblPhilic_Red.Text = " <=" & 98
                        lblPhilic_Yellow.Text = " >" & 98 & " && <=" & 123
                        lblPhilic_Normal.Text = " >" & 123 & " && <=" & 174
                        lblPhilic_Green.Text = " >" & 174
                        Exit Sub
                    Else
                        lblPhilic_Red.Text = " <=" & 98 * h
                        lblPhilic_Yellow.Text = " >" & 98 * h & " && <=" & 123 * h
                        lblPhilic_Normal.Text = " >" & 123 * h & " && <=" & 174 * h
                        lblPhilic_Green.Text = " >" & 174 * h
                    End If

                    If qty <= 98 * h Then
                        gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                    ElseIf qty > 98 * h And qty <= 123 * h Then
                        gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                    ElseIf qty > 123 * h And qty <= 174 * h Then
                        'gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    Else
                        gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                    End If
                End If
            Else ' previous day
                h = 8
                lblPhilic_Red.Text = " <=" & 98 * h
                lblPhilic_Yellow.Text = " >" & 98 * h & " && <=" & 123 * h
                lblPhilic_Normal.Text = " >" & 123 * h & " && <=" & 174 * h
                lblPhilic_Green.Text = " >" & 174 * h

                If qty <= 98 * h Then
                    gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Red
                ElseIf qty > 98 * h And qty <= 123 * h Then
                    gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Yellow
                ElseIf qty > 123 * h And qty <= 174 * h Then
                    'gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                Else
                    gridPHILIC_Station.Rows(i).Cells("Shift-I").Style.BackColor = Color.Green
                End If

            End If

            'II - Shift
            If dtpdate.Value.Date = DateTime.Today Then
                If DateTime.Now.Hour >= 14 And DateTime.Now.Hour <= 22 Then
                    qty = Convert.ToInt32(gridPHILIC_Station.Rows(i).Cells("Shift-II").Value)
                    h = (DateTime.Now.Hour - 14) ' shift start from 2 PM 10 PM
                    h = h + 1
                    If h = 0 Then
                        lblPhilic_Red.Text = " <=" & 98
                        lblPhilic_Yellow.Text = " >" & 98 & " && <=" & 123
                        lblPhilic_Normal.Text = " >" & 123 & " && <=" & 174
                        lblPhilic_Green.Text = " >" & 174
                        Exit Sub
                    Else
                        lblPhilic_Red.Text = " <=" & 98 * h
                        lblPhilic_Yellow.Text = " >" & 98 * h & " && <=" & 123 * h
                        lblPhilic_Normal.Text = " >" & 123 * h & " && <=" & 174 * h
                        lblPhilic_Green.Text = " >" & 174 * h
                    End If


                    If qty <= 98 * h Then
                        gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                    ElseIf qty > 98 * h And qty <= 123 * h Then
                        gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                    ElseIf qty > 123 * h And qty <= 174 * h Then
                        'gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    Else
                        gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                    End If

                End If
            Else ' previous day
                h = 8
                lblPhilic_Red.Text = " <=" & 98 * h
                lblPhilic_Yellow.Text = " >" & 98 * h & " && <=" & 123 * h
                lblPhilic_Normal.Text = " >" & 123 * h & " && <=" & 174 * h
                lblPhilic_Green.Text = " >" & 174 * h

                If qty <= 98 * h Then
                    gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Red
                ElseIf qty > 98 * h And qty <= 123 * h Then
                    gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Yellow
                ElseIf qty > 123 * h And qty <= 174 * h Then
                    'gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                Else
                    gridPHILIC_Station.Rows(i).Cells("Shift-II").Style.BackColor = Color.Green
                End If

            End If
        Next
    End Sub



    Private Sub GetPHILICBrandSummmary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("Brand_Name")
        dt = PHILICcls.GetSummaryTable(lst, "Brand_Name")


        gridPHILIC_BrandName.DataSource = dt

        grandtotal = grandtotal + PHILICcls.Total

        lblTotal.Text = grandtotal.ToString()

    End Sub


    Private Sub GetPHILICHourlySummaryStationWise()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("Station")
        dt = PHILICcls.GetSummaryHourlyTable(lst, "Station")

        gridPHILIC_BrandName.DataSource = dt

    End Sub

    Private Sub GetPHILICStationSummmary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("Station")
        dt = PHILICcls.GetSummaryTable(lst, "Station")

        gridPHILIC_Station.DataSource = dt
        Philic_ColorCode()

    End Sub

    Private Sub GetPHILICUserSummmary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHILICcls As New PHILICClass()
        PHILICcls.PHILICClass()
        PHILICcls.selectedDate = dtpdate.Value

        lst = PHILICcls.GetNameList("box_by")
        dt = PHILICcls.GetSummaryTable(lst, "box_by")


        gridPHILIC_Station.DataSource = dt

    End Sub


    Private Sub GetPHOBICStationSummary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHOBICcls As New PHOBICClass()
        PHOBICcls.PHOBICClass()
        PHOBICcls.selectedDate = dtpdate.Value

        lst = PHOBICcls.GetNameList("Station")
        dt = PHOBICcls.GetSummaryTable(lst, "Station")


        gridPHOBIC_Station.DataSource = dt
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


        gridPHOBIC_Station.DataSource = dt
    End Sub


    Private Sub GetPHOBICBrandSummary()

        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PHOBICcls As New PHOBICClass()
        PHOBICcls.PHOBICClass()
        PHOBICcls.selectedDate = dtpdate.Value

        lst = PHOBICcls.GetNameList("Brand_Name")
        dt = PHOBICcls.GetSummaryTable(lst, "Brand_Name")

        gridPHOBIC_BrandName.DataSource = dt

        grandtotal = grandtotal + PHOBICcls.Total




    End Sub

    Private Sub GetPMMABrandSummary()
        grandtotal = 0

        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Brand_Name")
        dt = PMMAcls.GetSummaryTable(lst, "Brand_Name")

        gridPMMA_BrandName.DataSource = dt

        grandtotal = grandtotal + PMMAcls.Total

    End Sub

    Private Sub GetPMMAStationSummary()

        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Station")
        dt = PMMAcls.GetSummaryTable(lst, "Station")

        gridPMMA_Station.DataSource = dt
        PMMA_ColorCode()
    End Sub


    Private Sub GetPMMAUserSummary()
        Dim lst As List(Of String) = New List(Of String)
        Dim dt As DataTable
        Dim PMMAcls As New PMMAClass()
        PMMAcls.PMMAClass()
        PMMAcls.selectedDate = dtpdate.Value

        lst = PMMAcls.GetNameList("Box_By")
        dt = PMMAcls.GetSummaryTable(lst, "Box_By")


        gridPMMA_Station.DataSource = dt
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        GetPMMABrandSummary()
        If rbStationWise.Checked Then
            GetPMMAStationSummary()
        Else
            GetPMMAUserSummary()
        End If
        GetPHOBICBrandSummary()
        If rbStationWise.Checked Then
            GetPHOBICStationSummary()
        Else
            GetPHOBICUserSummary()
        End If
        GetPHILICBrandSummmary()
        If rbStationWise.Checked Then
            GetPHILICStationSummmary()
        Else
            GetPHILICUserSummmary()
        End If


        If chkCycle.Checked Then
            Panel_PhilicStation.Visible = False
            Panel_PhobicStation.Visible = False
            Panel_PMMAStation.Visible = False
            Panel_PhilicBrand.Visible = False
            Panel_PhobicBrand.Visible = False
            Panel_PMMABrand.Visible = False
            If cycle = 0 Then
                Panel_PhilicStation.Visible = True
                Panel_PhilicBrand.Visible = True
            ElseIf cycle = 1 Then
                Panel_PhobicStation.Visible = True
                Panel_PhobicBrand.Visible = True
            ElseIf cycle = 2 Then
                Panel_PMMAStation.Visible = True
                Panel_PMMABrand.Visible = True
            End If
            cycle = cycle + 1
            If cycle > 2 Then
                cycle = 0
            End If
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdate.ValueChanged
    
    End Sub

    Private Sub btnFetch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFetch.Click
        GetPMMABrandSummary()

        If rbStationWise.Checked Then
            GetPMMAStationSummary()

        Else
            GetPMMAUserSummary()
        End If

        GetPHOBICBrandSummary()
        If rbStationWise.Checked Then
            GetPHOBICStationSummary()

        Else
            GetPHOBICUserSummary()
        End If

        GetPHILICBrandSummmary()
        If rbStationWise.Checked Then
            GetPHILICStationSummmary()

        Else
            GetPHILICUserSummmary()
        End If
       

    End Sub

    Private Sub chkCycle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCycle.CheckedChanged
        CycleChange()
    End Sub

    Private Sub CycleChange()

        If chkCycle.Checked Then
            Panel_PhilicStation.Height = FlowLayoutPanel1.Height
            Panel_PhobicStation.Height = FlowLayoutPanel1.Height
            Panel_PMMAStation.Height = FlowLayoutPanel1.Height

            Panel_PhilicBrand.Height = FlowLayoutPanel2.Height
            Panel_PhobicBrand.Height = FlowLayoutPanel2.Height
            Panel_PMMABrand.Height = FlowLayoutPanel2.Height

            gridPHILIC_Station.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 43)
            gridPHILIC_Station.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 43)
            gridPHILIC_Station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            gridPHOBIC_Station.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 43)
            gridPHOBIC_Station.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 43)
            gridPHOBIC_Station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            gridPMMA_Station.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 43)
            gridPMMA_Station.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 43)
            gridPMMA_Station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            gridPHILIC_BrandName.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 38)
            gridPHILIC_BrandName.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 38)
            gridPHILIC_BrandName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            gridPHOBIC_BrandName.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 38)
            gridPHOBIC_BrandName.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 38)
            gridPHOBIC_BrandName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            gridPMMA_BrandName.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 38)
            gridPMMA_BrandName.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 38)
            gridPMMA_BrandName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Else
            Panel_PhilicStation.Height = 300
            Panel_PhobicStation.Height = 300
            Panel_PMMAStation.Height = 300

            Panel_PhilicBrand.Height = 300
            Panel_PhobicBrand.Height = 300
            Panel_PMMABrand.Height = 300

            Panel_PhilicStation.Visible = True
            Panel_PhobicStation.Visible = True
            Panel_PMMAStation.Visible = True

            Panel_PhilicBrand.Visible = True
            Panel_PhobicBrand.Visible = True
            Panel_PMMABrand.Visible = True

            gridPHILIC_Station.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHILIC_Station.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHILIC_Station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            gridPHOBIC_Station.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHOBIC_Station.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHOBIC_Station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            gridPMMA_Station.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPMMA_Station.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPMMA_Station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            gridPHILIC_BrandName.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHILIC_BrandName.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHILIC_BrandName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            gridPHOBIC_BrandName.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHOBIC_BrandName.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPHOBIC_BrandName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            gridPMMA_BrandName.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPMMA_BrandName.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 17)
            gridPMMA_BrandName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        End If

    End Sub

    Private Sub rbStationWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbStationWise.CheckedChanged
        btnFetch_Click(Me, e)
    End Sub

    Private Sub rbUserWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUserWise.CheckedChanged
        btnFetch_Click(Me, e)
    End Sub

    Private Sub chkPHILIC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPHILIC.CheckedChanged
        Panel_PhilicStation.Visible = chkPHILIC.Checked
        ChangeProductHeightPanel()
    End Sub

    Private Sub chkPHOBIC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPHOBIC.CheckedChanged
        Panel_PhobicStation.Visible = chkPHOBIC.Checked
        ChangeProductHeightPanel()
    End Sub

    Private Sub chkPMMA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPMMA.CheckedChanged
        Panel_PMMAStation.Visible = chkPMMA.Checked
        ChangeProductHeightPanel()
    End Sub

    Private Sub ChangeProductHeightPanel()
        Dim i As Integer = 0
        If chkPHILIC.Checked Then
            i = i + 1
        End If

        If chkPHOBIC.Checked Then
            i = i + 1
        End If

        If chkPMMA.Checked Then
            i = i + 1
        End If
        If i <> 0 Then
            Panel_PhilicStation.Height = 922 / i
            Panel_PhobicStation.Height = 922 / i
            Panel_PMMAStation.Height = 922 / i
        End If

    End Sub
End Class
