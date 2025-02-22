Public Class HomePage


    Private Sub BoxPackingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BoxPackingToolStripMenuItem.Click
        Dim boxPackingFrm As New Form2
        boxPackingFrm.Show()
    End Sub

    Private Sub LotTypeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LotTypeToolStripMenuItem.Click
        Dim latheFrm As New PmmaLathe
        latheFrm.Show()

    End Sub

    Private Sub LensMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LensMasterToolStripMenuItem.Click
        Dim pouchFrm As New Pouch
        pouchFrm.Show()
    End Sub

    Private Sub PouchReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PouchReportToolStripMenuItem.Click
        Dim pouchFrm As New PouchReport_BasedOnPlan
        pouchFrm.MdiParent = Me
        pouchFrm.Show()

    End Sub

    Private Sub ProductionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionReportToolStripMenuItem.Click
        Dim productionFrm As New Production_Report_BasedOnPlan
        productionFrm.MdiParent = Me
        productionFrm.Show()
    End Sub

    Private Sub UploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        Dim productionFrm As New ProductionPlanUpload
        productionFrm.MdiParent = Me
        productionFrm.Show()
    End Sub

    Private Sub BoxReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxReportToolStripMenuItem.Click
        Dim productionFrm As New BoxReport_BasedOnPlan
        productionFrm.MdiParent = Me
        productionFrm.Show()
    End Sub
End Class