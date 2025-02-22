Public Class Pouch
    Dim cycle As Integer = 1
    Private Sub LabelTextUpdate(ByVal ProductName As String)
        lblModelDay.Text = ProductName + " - " + dtpdate.Value.Day.ToString("00") + " " + MonthName(dtpdate.Value.Month(), True) + " " + dtpdate.Value.Year.ToString("0000")
        lblStationDay.Text = ProductName + " - " + dtpdate.Value.Day.ToString("00") + " " + MonthName(dtpdate.Value.Month(), True) + " " + dtpdate.Value.Year.ToString("0000")
        lblModelMonth.Text = ProductName + " - " + MonthName(dtpdate.Value.Month(), True) + " " + dtpdate.Value.Year.ToString("0000")
        lblStationMonth.Text = ProductName + " - " + MonthName(dtpdate.Value.Month(), True) + " " + dtpdate.Value.Year.ToString("0000")
    End Sub

    Private Function GetTargetQtyCurrentDaily(ByVal target_qty As String) As String
        Dim StartTime, EndTime
        StartTime = dtpdate.Value.Date.ToString("dd/MM/yyyy") + " " + "06:00:01"
        If dtpdate.Value.Date < Date.Now.Date Then
            EndTime = dtpdate.Value.Date.ToString("dd/MM/yyyy") + " " + "22:00:01"
        Else
            EndTime = dtpdate.Value.ToString("dd/MM/yyyy HH:mm:ss")
        End If

        Dim elapsedTime As TimeSpan = DateTime.Parse(EndTime).Subtract(DateTime.Parse(StartTime))
        Console.WriteLine()
        Return Convert.ToInt32((elapsedTime.TotalMinutes / 60) * (target_qty / 16)).ToString()
    End Function

    Private Sub LoadMethod()
        If dtpdate.Value.Date = Date.Now.Date Then
            dtpdate.Value = DateTime.Now
        End If

        grid1.Columns.Clear()
        grid2.Columns.Clear()
        grid3.Columns.Clear()
        grid4.Columns.Clear()
        Dim dt, dtModel, dtStation, dtModelMonthly, dtStationMonthly As DataTable
        Dim stDate, enDate, target_qty, target_qty_current As String

        If rbPHILIC.Checked Then
            Dim PHILICcls As New PHILICClass()
            PHILICcls.PHILICClass()
            LabelTextUpdate("PHILIC")
            dt = PHILICcls.GetTargetQty(dtpdate.Value.Year.ToString("0000"), dtpdate.Value.Month.ToString("00"))
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Target Quantity Not Available.")
                Exit Sub
            End If
            ' day wise report
            target_qty = dt.Rows(0)("Target_perDay")
            stDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 00:00:01"
            enDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 23:00:01"
            dtModel = PHILICcls.PouchReportModel(stDate, enDate)
            grid3.DataSource = dtModel
            dtStation = PHILICcls.PouchReportStation(stDate, enDate, target_qty)
            grid1.DataSource = dtStation

            ' Month wise report
            target_qty = dt.Rows(0)("Target_perDay") * dt.Rows(0)("No_of_WorkingDays")
            stDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-01 00:00:01"
            enDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 23:00:01"
            dtModelMonthly = PHILICcls.PouchReportModel(stDate, enDate)
            grid4.DataSource = dtModelMonthly
            dtStationMonthly = PHILICcls.PouchReportStation(stDate, enDate, target_qty)
            grid2.DataSource = dtStationMonthly
        End If
        If rbPHOBIC.Checked Then
            Dim PHOBICcls As New PHOBICClass()
            PHOBICcls.PHOBICClass()
            LabelTextUpdate("PHOBIC")
            dt = PHOBICcls.GetTargetQty(dtpdate.Value.Year.ToString("0000"), dtpdate.Value.Month.ToString("00"))
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Target Quantity Not Available.")
                Exit Sub
            End If
            ' day wise report
            target_qty = dt.Rows(0)("Target_perDay")
            stDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 00:00:01"
            enDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 23:00:01"
            dtModel = PHOBICcls.PouchReportModel(stDate, enDate)
            grid3.DataSource = dtModel
            dtStation = PHOBICcls.PouchReportStation(stDate, enDate, target_qty)
            grid1.DataSource = dtStation

            ' Month wise report
            target_qty = dt.Rows(0)("Target_perDay") * dt.Rows(0)("No_of_WorkingDays")
            stDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-01 00:00:01"
            enDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 23:00:01"
            dtModelMonthly = PHOBICcls.PouchReportModel(stDate, enDate)
            grid4.DataSource = dtModelMonthly
            dtStationMonthly = PHOBICcls.PouchReportStation(stDate, enDate, target_qty)
            grid2.DataSource = dtStationMonthly
        End If
        If rbPMMA.Checked Then
            Dim PMMAcls As New PMMAClass()
            PMMAcls.PMMAClass()
            LabelTextUpdate("PMMA")
            dt = PMMAcls.GetTargetQty(dtpdate.Value.Year.ToString("0000"), dtpdate.Value.Month.ToString("00"))
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Target Quantity Not Available.")
                Exit Sub
            End If
            ' day wise report
            target_qty = dt.Rows(0)("Target_perDay")
            stDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 00:00:01"
            enDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 23:00:01"
            dtModel = PMMAcls.PouchReportModel(stDate, enDate)
            grid3.DataSource = dtModel
            target_qty_current = GetTargetQtyCurrentDaily(target_qty)
            dtStation = PMMAcls.PouchReportStation(stDate, enDate, target_qty, target_qty_current)
            grid1.DataSource = dtStation

            ' Month wise report
            target_qty = dt.Rows(0)("Target_perDay") * dt.Rows(0)("No_of_WorkingDays")
            stDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-01 00:00:01"
            enDate = dtpdate.Value.Year.ToString("0000") + "-" + dtpdate.Value.Month.ToString("00") + "-" + dtpdate.Value.Day.ToString("00") + " 23:00:01"
            dtModelMonthly = PMMAcls.PouchReportModel(stDate, enDate)
            grid4.DataSource = dtModelMonthly
            target_qty_current = PMMAcls.GetTargetQtyCurrentMonthly(target_qty_current, dt.Rows(0)("Target_perDay"), dt.Rows(0)("No_of_WorkingDays"), stDate, enDate)
            dtStationMonthly = PMMAcls.PouchReportStation(stDate, enDate, target_qty, target_qty_current)
            grid2.DataSource = dtStationMonthly
        End If
    End Sub
    Private Sub Load_CycleMethod()
        If cycle = 1 Then
            rbPHILIC.Checked = True
        ElseIf cycle = 2 Then
            rbPHOBIC.Checked = True
        ElseIf cycle = 3 Then
            rbPMMA.Checked = True
        End If
        cycle = cycle + 1
        If cycle > 3 Then
            cycle = 1
        End If
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        If chkCycle.Checked Then
            Load_CycleMethod()
            LoadMethod()
        Else
            LoadMethod()
        End If
    End Sub

    Private Sub btnFetch_Click(sender As System.Object, e As System.EventArgs) Handles btnFetch.Click
        LoadMethod()
    End Sub

    Private Sub chkCycle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCycle.CheckedChanged
        GB_Product.Enabled = Not chkCycle.Checked
    End Sub
End Class