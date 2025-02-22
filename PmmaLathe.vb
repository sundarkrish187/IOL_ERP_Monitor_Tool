Public Class PmmaLathe
    Dim PmmaModelIndex As Integer = 0
    Dim PhilicModelIndex As Integer = 0
    Dim PhobicModelIndex As Integer = 0

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
  
    Private Sub SplitDataTable(ByVal dt As DataTable)
        Dim dt1, dt2, dt3 As DataTable
        dt1 = dt.Clone()
        dt2 = dt.Clone()
        dt3 = dt.Clone()
        For j As Integer = 0 To dt.Rows.Count - 1
            If (j < 20) Then
                dt1.ImportRow(dt.Rows(j))
            ElseIf (j >= 20 And j <= 39) Then
                dt2.ImportRow(dt.Rows(j))
            ElseIf (j > 39) Then
                dt3.ImportRow(dt.Rows(j))
            End If
        Next
        grid.DataSource = dt1
        grid1.DataSource = dt2
        grid2.DataSource = dt3
    End Sub
  
    Private Sub LoadMethod()
        

        grid.Columns.Clear()
        grid1.Columns.Clear()
        grid2.Columns.Clear()
        cmbModel.Text = ""
        If rbPHILIC.Checked Then
            If rbFirstCut.Checked Then 'First Cut
                Dim lst As List(Of String) = New List(Of String)
                Dim dt As DataTable
                Dim PHILICcls As New PHILICClass()
                PHILICcls.PHILICClass()
                PHILICcls.selectedDate = dtpdate.Value
                If rbLocal.Checked Then 'Local
                    lst = PHILICcls.GetFirstCutModelList("'UV BLANKS(Philic Clear)'")
                    cmbModel.Items.Clear()
                    For i = 0 To lst.Count - 1
                        cmbModel.Items.Add(lst(i))
                    Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PhilicModelIndex).ToString()
                        PhilicModelIndex = PhilicModelIndex + 1
                        If PhilicModelIndex = cmbModel.Items.Count Then
                            PhilicModelIndex = 0
                        End If

                        dt = PHILICcls.GetFirstCutReport(cmbModel.Text, "'UV BLANKS(Philic Clear)'")
                        'grid.DataSource = dt

                        SplitDataTable(dt)
                        'ColorCode()
                    End If



                Else 'Export
                    lst = PHILICcls.GetFirstCutModelList("'HYDROPHILIC','UV BLANKS(Philic Yellow)'")
                    cmbModel.Items.Clear()
                    For i = 0 To lst.Count - 1
                        cmbModel.Items.Add(lst(i))
                    Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PhilicModelIndex).ToString()
                        PhilicModelIndex = PhilicModelIndex + 1
                        If PhilicModelIndex = cmbModel.Items.Count Then
                            PhilicModelIndex = 0
                        End If

                        dt = PHILICcls.GetFirstCutReport(cmbModel.Text, "'HYDROPHILIC','UV BLANKS(Philic Yellow)'")
                        'grid.DataSource = dt
                        SplitDataTable(dt)
                        'ColorCode()
                    End If


                    End If
                    lblProcessModel.Text = "PHILIC -" + cmbModel.Text + " - FIRST CUT"

            Else ' Second Cut
                    Dim lst As List(Of String) = New List(Of String)
                    Dim dt As DataTable
                    Dim PHILICcls As New PHILICClass()
                    PHILICcls.PHILICClass()
                    PHILICcls.selectedDate = dtpdate.Value
                    If rbLocal.Checked Then 'Local
                        lst = PHILICcls.GetSecondCutModelList("'UV BLANKS(Philic Clear)'")
                        cmbModel.Items.Clear()
                        For i = 0 To lst.Count - 1
                            cmbModel.Items.Add(lst(i))
                        Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PhilicModelIndex).ToString()
                        PhilicModelIndex = PhilicModelIndex + 1
                        If PhilicModelIndex = cmbModel.Items.Count Then
                            PhilicModelIndex = 0
                        End If

                        dt = PHILICcls.GetSecondCutReport(cmbModel.Text, "'UV BLANKS(Philic Clear)'")
                        'grid.DataSource = dt
                        SplitDataTable(dt)
                        'ColorCode()
                    End If


                Else 'Export

                    lst = PHILICcls.GetSecondCutModelList("'HYDROPHILIC','UV BLANKS(Philic Yellow)'")
                    cmbModel.Items.Clear()
                    For i = 0 To lst.Count - 1
                        cmbModel.Items.Add(lst(i))
                    Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PhilicModelIndex).ToString()
                        PhilicModelIndex = PhilicModelIndex + 1
                        If PhilicModelIndex = cmbModel.Items.Count Then
                            PhilicModelIndex = 0
                        End If

                        dt = PHILICcls.GetSecondCutReport(cmbModel.Text, "'HYDROPHILIC','UV BLANKS(Philic Yellow)'")
                        'grid.DataSource = dt
                        SplitDataTable(dt)
                        'ColorCode()
                    End If


                    End If
                    lblProcessModel.Text = "PHILIC -" + cmbModel.Text + " - SECOND CUT"

                End If
        End If
        If rbPHOBIC.Checked Then
            Dim lst As List(Of String) = New List(Of String)
            Dim dt As DataTable
            Dim PHOBICcls As New PHOBICClass()
            PHOBICcls.PHOBICClass()
            PHOBICcls.selectedDate = dtpdate.Value

            lst = PHOBICcls.GetMouldingModelList()
            cmbModel.Items.Clear()
            For i = 0 To lst.Count - 1
                cmbModel.Items.Add(lst(i))
            Next

            ' For Model Cycling
            cmbModel.Text = cmbModel.Items(PhobicModelIndex).ToString()
            PhobicModelIndex = PhobicModelIndex + 1
            If PhobicModelIndex = cmbModel.Items.Count Then
                PhobicModelIndex = 0
            End If

            dt = PHOBICcls.GetMouldingReport(cmbModel.Text)
            'grid.DataSource = dt

            SplitDataTable(dt)
            'ColorCode()
            lblProcessModel.Text = "PHOBIC -" + cmbModel.Text + " - MOULDING"

            
        End If
        If rbPMMA.Checked Then
            If rbFirstCut.Checked Then 'First Cut
                Dim lst As List(Of String) = New List(Of String)
                Dim dt As DataTable
                Dim PMMAcls As New PMMAClass()
                PMMAcls.PMMAClass()
                PMMAcls.selectedDate = dtpdate.Value
                If rbLocal.Checked Then 'Local
                    lst = PMMAcls.GetFirstCutModelList("'IN House PMMA blank'")
                    cmbModel.Items.Clear()
                    For i = 0 To lst.Count - 1
                        cmbModel.Items.Add(lst(i))
                    Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PmmaModelIndex).ToString()
                        PmmaModelIndex = PmmaModelIndex + 1
                        If PmmaModelIndex = cmbModel.Items.Count Then
                            PmmaModelIndex = 0
                        End If

                        dt = PMMAcls.GetFirstCutReport(cmbModel.Text, "'IN House PMMA blank'")
                        'grid.DataSource = dt

                        SplitDataTable(dt)
                        'ColorCode()
                    End If



                Else 'Export
                    lst = PMMAcls.GetFirstCutModelList("'PMMA Blank','PMMA Blank'")
                    cmbModel.Items.Clear()
                    For i = 0 To lst.Count - 1
                        cmbModel.Items.Add(lst(i))
                    Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PmmaModelIndex).ToString()
                        PmmaModelIndex = PmmaModelIndex + 1
                        If PmmaModelIndex = cmbModel.Items.Count Then
                            PmmaModelIndex = 0
                        End If

                        dt = PMMAcls.GetFirstCutReport(cmbModel.Text, "'PMMA Blank','PMMA Blank'")
                        'grid.DataSource = dt
                        SplitDataTable(dt)
                        'ColorCode()
                    End If


                End If
                lblProcessModel.Text = "PMMA -" + cmbModel.Text + " - FIRST CUT"

            Else ' Second Cut
                Dim lst As List(Of String) = New List(Of String)
                Dim dt As DataTable
                Dim PMMAcls As New PMMAClass()
                PMMAcls.PMMAClass()
                PMMAcls.selectedDate = dtpdate.Value
                If rbLocal.Checked Then 'Local
                    lst = PMMAcls.GetSecondCutModelList("'IN House PMMA blank'")
                    cmbModel.Items.Clear()
                    For i = 0 To lst.Count - 1
                        cmbModel.Items.Add(lst(i))
                    Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PmmaModelIndex).ToString()
                        PmmaModelIndex = PmmaModelIndex + 1
                        If PmmaModelIndex = cmbModel.Items.Count Then
                            PmmaModelIndex = 0
                        End If

                        dt = PMMAcls.GetSecondCutReport(cmbModel.Text, "'IN House PMMA blank'")
                        'grid.DataSource = dt
                        SplitDataTable(dt)
                        'ColorCode()
                    End If


                Else 'Export
                    lst = PMMAcls.GetSecondCutModelList("'PMMA Blank','PMMA Blank'")
                    cmbModel.Items.Clear()
                    For i = 0 To lst.Count - 1
                        cmbModel.Items.Add(lst(i))
                    Next

                    If cmbModel.Items.Count > 0 Then
                        ' For Model Cycling
                        cmbModel.Text = cmbModel.Items(PmmaModelIndex).ToString()
                        PmmaModelIndex = PmmaModelIndex + 1
                        If PmmaModelIndex = cmbModel.Items.Count Then
                            PmmaModelIndex = 0
                        End If

                        dt = PMMAcls.GetSecondCutReport(cmbModel.Text, "'PMMA Blank','PMMA Blank'")
                        'grid.DataSource = dt
                        SplitDataTable(dt)
                        'ColorCode()
                    End If


                End If
                lblProcessModel.Text = "PMMA -" + cmbModel.Text + " - SECOND CUT"

            End If
        End If
    End Sub
    

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        LoadMethod()
    End Sub

    Private Sub rbFirstCut_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbFirstCut.CheckedChanged
        PmmaModelIndex = 0
        PhilicModelIndex = 0
    End Sub

    Private Sub rbSecondCut_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSecondCut.CheckedChanged
        PmmaModelIndex = 0
        PhilicModelIndex = 0
    End Sub

    Private Sub rbLocal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbLocal.CheckedChanged
        PmmaModelIndex = 0
        PhilicModelIndex = 0
    End Sub

    Private Sub rbExport_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbExport.CheckedChanged
        PmmaModelIndex = 0
        PhilicModelIndex = 0
    End Sub

    Private Sub btnHold_Click(sender As System.Object, e As System.EventArgs) Handles btnHold.Click
        If Timer1.Enabled = True Then
            Timer1.Enabled = False
            btnHold.Text = "UnHold"
        Else
            Timer1.Enabled = True
            btnHold.Text = "Hold"
        End If
    End Sub

    Private Sub PmmaLathe_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Timer1.Enabled = True Then
            btnHold.Text = "Hold"
        Else
            btnHold.Text = "UnHold"
        End If
    End Sub

    Private Sub ColorCode()
        'GRID1
        For i As Integer = 0 To grid.Rows.Count - 1
            If Not IsDBNull(Me.grid.Rows(i).Cells("Target_Qty").Value) Then
                If Convert.ToInt32(Me.grid.Rows(i).Cells("Target_Qty").Value) = 0 Then
                    Me.grid.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    Me.grid.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If
            End If
            If Me.grid.Rows(i).Cells("Power").Value = "Total" Then
                Me.grid.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                Me.grid.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
        'GRID2
        For i As Integer = 0 To grid1.Rows.Count - 1
            If Not IsDBNull(Me.grid1.Rows(i).Cells("Target_Qty").Value) Then
                If Convert.ToInt32(Me.grid1.Rows(i).Cells("Target_Qty").Value) = 0 Then
                    Me.grid1.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    Me.grid1.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If
            End If
            If Me.grid1.Rows(i).Cells("Power").Value = "Total" Then
                Me.grid1.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                Me.grid1.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
        'GRID3
        For i As Integer = 0 To grid2.Rows.Count - 1
            If Not IsDBNull(Me.grid2.Rows(i).Cells("Target_Qty").Value) Then
                If Convert.ToInt32(Me.grid2.Rows(i).Cells("Target_Qty").Value) = 0 Then
                    Me.grid2.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    Me.grid2.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If
            End If
            If Me.grid2.Rows(i).Cells("Power").Value = "Total" Then
                Me.grid2.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                Me.grid2.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

    End Sub

    Private Sub btnFetch_Click(sender As System.Object, e As System.EventArgs) Handles btnFetch.Click
        LoadMethod()
    End Sub

    Private Sub rbPHOBIC_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbPHOBIC.CheckedChanged
        If rbPHOBIC.Checked = True Then
            GB_BlankType.Enabled = False
            GB_Process.Visible = False
            rbExport.Checked = True
        ElseIf rbPHILIC.Checked = True Then
            GB_BlankType.Enabled = True
            GB_Process.Visible = True
        Else
            GB_BlankType.Enabled = True
            GB_Process.Visible = True
        End If
    End Sub

    Private Sub rbPHILIC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPHILIC.CheckedChanged
        If rbPHOBIC.Checked = True Then
            GB_BlankType.Enabled = False
            GB_Process.Visible = False
            rbExport.Checked = True
        ElseIf rbPHILIC.Checked = True Then
            GB_BlankType.Enabled = True
            GB_Process.Visible = True
        Else
            GB_BlankType.Enabled = True
            GB_Process.Visible = True
        End If
    End Sub

    Private Sub rbPMMA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPMMA.CheckedChanged
        If rbPHOBIC.Checked = True Then
            GB_BlankType.Enabled = False
            GB_Process.Visible = False
            rbExport.Checked = True
        ElseIf rbPHILIC.Checked = True Then
            GB_BlankType.Enabled = True
            GB_Process.Visible = True
        Else
            GB_BlankType.Enabled = True
            GB_Process.Visible = True
        End If
    End Sub
End Class