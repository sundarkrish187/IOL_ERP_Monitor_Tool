Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class PHILIC_Excel_Report_Class

    Dim conPHILIC, conPHILIC_ERP As New SqlConnection
    Dim Ds As New DataSet
    Private pro_comboYear As String
    Private Pro_comboMonth As String
    Private Pro_ToDate As String
    Private Pro_comboDate As String

    Private Pro_checkBox_date As Boolean

    Public Sub New(ByVal comboYear As String, ByVal comboMonth As String, ByVal comboDate As String, ByVal ToDate As String, ByVal checkBox_date As Boolean)
        pro_comboYear = comboYear
        Pro_comboMonth = comboMonth
        Pro_comboDate = comboDate
        Pro_ToDate = ToDate
        Pro_checkBox_date = checkBox_date
    End Sub

    Public Sub PHILIC_Excel_class()
        conPHILIC.ConnectionString = ConfigurationSettings.AppSettings("conStrPHILIC").ToString()
        conPHILIC_ERP.ConnectionString = ConfigurationSettings.AppSettings("conStrPHILIC_ERP").ToString()
    End Sub

    Public Function SQL_SelectQuery_Execute(ByVal StrSql As String, ByVal con As SqlConnection) As DataSet

        Dim ds As New DataSet
        Dim Cmd As New SqlCommand(StrSql, con)
        Dim ad As New SqlDataAdapter(Cmd)
        ad.Fill(ds)
        Return ds

    End Function

    Public Sub UpdateorInsertQuery_Execute(ByVal strQuery As String, ByVal con As SqlConnection)

        Dim strsql As String
        strsql = strQuery
        Dim cmd As New SqlCommand(strsql, con)
        If con.State = Data.ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Function compare_Rejection_and_Pouch_Packed(ByVal year As String, ByVal month As String) As Boolean

        Dim startDate As New DateTime(year, month, 1)
        Dim endDate As DateTime = startDate.AddMonths(1).AddDays(-1)

        'startDate = startDate.ToString("yyyy-MM-dd") + " 00:00:01"
        'endDate = endDate.ToString("yyyy-MM-dd") + " 23:59:59"

        Dim parsedFromDate As DateTime = DateTime.Parse(Pro_comboDate)
        Dim parsedToDate As DateTime = DateTime.Parse(Pro_ToDate)
        startDate = parsedFromDate.ToString("yyyy-MM-dd") + " 00:00:01"
        endDate = parsedToDate.ToString("yyyy-MM-dd") + " 00:00:01"

        Dim strsql As String
        Dim dtPHILIC, dtPHILIC_ERP As New DataTable

        strsql = "SELECT     Model_Name, Power, SUM(Qty_1) AS Qty, Pouch_Order_Type, Pouch_Order_Country  " & _
                "FROM         POUCH_LABEL " & _
                "WHERE     (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "' )  " & _
               "GROUP BY Model_Name, Power, Pouch_Order_Type, Pouch_Order_Country "

        Ds = SQL_SelectQuery_Execute(strsql, conPHILIC)
        dtPHILIC = Ds.Tables(0)


        strsql = "SELECT     Model, Power, SUM(RejectedQty) AS Rejected_Qty " & _
                "FROM         MinFQI   " & _
               "WHERE     (Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') " & _
               "GROUP BY Model, Power  ORDER BY Model, Power "

        Ds = SQL_SelectQuery_Execute(strsql, conPHILIC_ERP)
        dtPHILIC_ERP = Ds.Tables(0)

        If dtPHILIC.Rows.Count = dtPHILIC_ERP.Rows.Count Then
            Return True
        Else
            Return False
        End If

    End Function


    Private Sub CheckTMP_Pouch_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Pouch_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPHILIC)
        Catch ex As Exception


        End Try

        
    End Sub



    Public Sub temp_table_creation(ByVal year As String, ByVal month As String)


        CheckTMP_Pouch_and_Rejection_Report()

        Dim startDate As New DateTime()
        Dim endDate As New DateTime()
        If Pro_checkBox_date = True Then
            Dim parsedFromDate As DateTime = DateTime.Parse(Pro_comboDate)
            Dim parsedToDate As DateTime = DateTime.Parse(Pro_ToDate)
            startDate = parsedFromDate.ToString("yyyy-MM-dd") + " 00:00:01"
            endDate = parsedToDate.ToString("yyyy-MM-dd") + " 00:00:01"
        Else
            startDate = New DateTime(year, month, 1)
            endDate = startDate.AddMonths(1).AddDays(-1)
        End If

        startDate = startDate.ToString("yyyy-MM-dd") + " 00:00:01"
        endDate = endDate.ToString("yyyy-MM-dd") + " 23:59:59"

        Dim strsql As String
        Dim dtPMMA As New DataTable

        strsql = "SELECT     CASE WHEN Acc.Model_Name IS NULL THEN Rej.Model ELSE Acc.Model_Name END AS Model_Name, CASE WHEN Acc.Power IS NULL THEN Rej.Power ELSE Acc.Power END AS Power,   " & _
                " CASE WHEN SUM(Acc.Qty) IS NULL THEN 0 ELSE SUM(Acc.Qty) END AS Accepted_qty, CASE WHEN SUM(Rej.Rejected_Qty) IS NULL THEN 0 ELSE SUM(Rej.Rejected_Qty) END AS Rejected_qty, " & _
                " Acc.Pouch_Order_Type, Acc.Pouch_Order_Country  " & _
                "INTO temp_Pouch_and_Rejection_Report  " & _
                " FROM         (SELECT     RefLot AS Tumblingno, Model_Name, Power, SUM(Qty_1) AS Qty, Pouch_Order_Type, Pouch_Order_Country  FROM          POUCH_LABEL " & _
                "  WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "')  GROUP BY RefLot, Model_Name, Power, Pouch_Order_Type, Pouch_Order_Country) AS Acc FULL OUTER JOIN " & _
                " (SELECT     TumblingNo, Model, Power, SUM(RejectedQty) AS Rejected_Qty FROM          IOL_ERP.dbo.MinFQI " & _
                " WHERE      (Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:00" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') " & _
                " GROUP BY TumblingNo, Model, Power) AS Rej ON Acc.Tumblingno = Rej.TumblingNo AND Acc.Model_Name = Rej.Model AND Acc.Power = Rej.Power " & _
                " GROUP BY CASE WHEN Acc.Model_Name IS NULL THEN Rej.Model ELSE Acc.Model_Name END, CASE WHEN Acc.Power IS NULL THEN Rej.Power ELSE Acc.Power END, Acc.Pouch_Order_Type, Acc.Pouch_Order_Country "

        UpdateorInsertQuery_Execute(strsql, conPHILIC)

    End Sub


    Public Function GetExcelReport_Pouch(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtGalaxy As New DataTable

        'If compare_Rejection_and_Pouch_Packed(year, month) = False Then
        '    MsgBox("(PHILIC) Rejection Details Comparison failed. Please Contact ERP Team.", MsgBoxStyle.Information)
        '    Return dt
        'End If

        temp_table_creation(year, month)



        strsql = "SELECT     TOP (100) PERCENT CASE WHEN plan1.Model_Name IS NULL THEN pouch.Model_Name ELSE plan1.Model_Name END AS Model, CASE WHEN plan1.Power IS NULL  " & _
                "THEN pouch.Power ELSE plan1.Power END AS Power, CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS Planned_Qty, CAST(CASE WHEN pouch.qty IS NULL  " & _
               "THEN 0 ELSE pouch.qty END AS INT) AS Achieved_Qty, CAST(CASE WHEN pouch.Rejected_qty IS NULL THEN 0 ELSE pouch.Rejected_qty END AS INT) AS Rejected_Qty, " & _
                "CAST((CAST(CASE WHEN pouch.qty IS NULL THEN 0 ELSE pouch.qty END AS INT) - CAST(CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS INT)) AS INT) AS Deviation, " & _
                "CASE WHEN plan1.Order_Country IS NULL THEN pouch.Pouch_Order_Country ELSE plan1.Order_Country END AS Country " & _
               "FROM         (SELECT     Model_Name, Power, SUM(Planned_Qty) AS plan_qty, Order_Type, Order_Country  FROM         Pouch_Production_Plan1 " & _
               "WHERE      (Year = '" & year & "') AND (Month = '" & month & "') GROUP BY Model_Name, Power, Order_Type, Order_Country) AS plan1 FULL OUTER JOIN " & _
               "(SELECT      Model_Name, Power, SUM(Accepted_qty) AS qty,  SUM(Rejected_qty) AS Rejected_qty, Pouch_Order_Type, Pouch_Order_Country  FROM          temp_Pouch_and_Rejection_Report " & _
               " GROUP BY   Model_Name, Power, Pouch_Order_Type, Pouch_Order_Country) AS pouch ON plan1.Model_Name = pouch.Model_Name AND plan1.Power = pouch.Power AND " & _
               "plan1.Order_Type = pouch.Pouch_Order_Type AND plan1.Order_Country = pouch.Pouch_Order_Country ORDER BY Model, CAST(CASE WHEN plan1.Power IS NULL THEN pouch.Power ELSE plan1.Power END AS float), Country"



        Ds = SQL_SelectQuery_Execute(strsql, conPHILIC)
        dt = Ds.Tables(0)


        Return dt

    End Function

    'BoxPacking

    Private Sub CheckTMP_box_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Delete from temp_Box_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPHILIC)
        Catch ex As Exception


        End Try


    End Sub
    Public Sub temp_boxtable_creation(ByVal year As String, ByVal month As String)

        'Check only PMMA Except GalaxyLens
        CheckTMP_box_and_Rejection_Report()

        Dim startDate As New DateTime()
        Dim endDate As New DateTime()
        If Pro_checkBox_date = True Then
            Dim parsedFromDate As DateTime = DateTime.Parse(Pro_comboDate)
            Dim parsedToDate As DateTime = DateTime.Parse(Pro_ToDate)

            startDate = parsedFromDate.ToString("yyyy-MM-dd") + " 00:00:01"
            endDate = parsedToDate.ToString("yyyy-MM-dd") + " 00:00:01"

        Else
            startDate = New DateTime(year, month, 1)
            endDate = startDate.AddMonths(1).AddDays(-1)
        End If

        startDate = startDate.ToString("yyyy-MM-dd") + " 00:00:01"
        endDate = endDate.ToString("yyyy-MM-dd") + " 23:59:59"

        Dim strsql As String
        Dim dtPMMA As New DataTable


        strsql = " INSERT INTO temp_Box_and_Rejection_Report                       (model, pwr, achieved, reject, pack_model) " & _
          "SELECT     CASE WHEN p.Model_Name IS NULL THEN r.model_name ELSE p.model_name END AS model, CASE WHEN p.Power IS NULL THEN r.power ELSE p.power END AS pwr, " & _
          "  CASE WHEN SUM(p.Packing) IS NULL THEN 0 ELSE SUM(p.Packing) END AS achieved, CASE WHEN SUM(r.Rejection) IS NULL THEN 0 ELSE SUM(r.Rejection) END AS reject,  " & _
          " CASE WHEN p.Packing_Model IS NULL THEN r.packing_model ELSE p.packing_model END AS pack_model " & _
          " FROM         (SELECT     Model_Name, Power, SUM(Qty_1) AS Rejection, Packing_Model " & _
                   " FROM          POUCH_LABEL " & _
          "       WHERE      (Box_Reject_Date BETWEEN'" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Box_Reject = 1) " & _
          " GROUP BY Model_Name, Power, Packing_Model) AS r FULL OUTER JOIN " & _
          "      (SELECT     Model_Name, Power, SUM(Qty_1) AS Packing, Packing_Model                  FROM          POUCH_LABEL AS POUCH_LABEL_1 " & _
      "  WHERE      (Boxtime BETWEEN'" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Box_Packing = 1) " & _
      "    GROUP BY Model_Name, Power, Packing_Model) AS p ON p.Model_Name = r.Model_Name AND p.Power = r.Power AND p.Packing_Model = r.Packing_Model " & _
      " GROUP BY CASE WHEN p.Model_Name IS NULL THEN r.model_name ELSE p.model_name END, CASE WHEN p.Power IS NULL THEN r.power ELSE p.power END, CASE WHEN p.Packing_Model IS NULL  " & _
      "  THEN r.packing_model ELSE p.packing_model END ORDER BY model, pwr, pack_model "



        UpdateorInsertQuery_Execute(strsql, conPHILIC)

    End Sub
    Public Function GetExcelReport_box(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtGalaxy As New DataTable

        'If compare_Rejection_and_box_Packed(year, month) = False Then
        '    MsgBox("(PMMA) Rejection Details Comparison failed. Please Contact ERP Team.", MsgBoxStyle.Information)
        '    Return dt
        'End If

        temp_boxtable_creation(year, month)




        strsql = "SELECT     TOP (100) PERCENT CASE WHEN plan1.Model_Name IS NULL THEN box.model ELSE plan1.Model_Name END AS Model, CASE WHEN plan1.Power IS NULL  " & _
             "THEN box.Pwr ELSE plan1.Power END AS Power, CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS Planned_Qty, CAST(CASE WHEN box.qty IS NULL  " & _
            "THEN 0 ELSE box.qty END AS INT) AS Achieved_Qty, CAST(CASE WHEN box.Rejected_qty IS NULL THEN 0 ELSE box.Rejected_qty END AS INT) AS Rejected_Qty, " & _
             "CAST((CAST(CASE WHEN box.qty IS NULL THEN 0 ELSE box.qty END AS INT) - CAST(CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS INT)) AS INT) AS Deviation, " & _
             "CASE WHEN plan1.Order_Country IS NULL THEN box.pack_model ELSE plan1.Order_Country END AS Remarks " & _
            "FROM         (SELECT     Model_Name, Power, SUM(Planned_Qty) AS plan_qty, Order_Type, Order_Country  FROM        Box_Production_Plan1 " & _
            "WHERE      (Year = '" & year & "') AND (Month = '" & month & "') GROUP BY Model_Name, Power, Order_Type, Order_Country) AS plan1 FULL OUTER JOIN " & _
            "(SELECT      model, Pwr, SUM(achieved) AS qty,  SUM(reject) AS Rejected_qty, pack_model  FROM      temp_Box_and_Rejection_Report " & _
            " GROUP BY   model, Pwr, pack_model ) AS box ON plan1.Model_Name = box.model AND plan1.Power = box.Pwr AND " & _
            "plan1.Order_Type = box.pack_model AND plan1.Order_Country = box.pack_model ORDER BY Model, CAST(CASE WHEN plan1.Power IS NULL THEN box.Pwr ELSE plan1.Power END AS float), Remarks"

        Ds = SQL_SelectQuery_Execute(strsql, conPHILIC)
        dt = Ds.Tables(0)

        'Ds = SQL_SelectQuery_Execute(strsql, conGalaxy)
        'dtGalaxy = Ds.Tables(0)

        'dt.Merge(dtGalaxy)

        Return dt

    End Function

   


    'Production


    Private Sub CheckTMP_Production_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Production_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPHILIC_ERP)
        Catch ex As Exception


        End Try



    End Sub

    Public Sub temp_table_creation_production(ByVal year As String, ByVal month As String)


        CheckTMP_Production_and_Rejection_Report()
        Dim startDate As New DateTime()
        Dim endDate As New DateTime()
        If Pro_checkBox_date = True Then
            Dim parsedFromDate As DateTime = DateTime.Parse(Pro_comboDate)
            Dim parsedToDate As DateTime = DateTime.Parse(Pro_ToDate)
            startDate = parsedFromDate.ToString("yyyy-MM-dd") + " 00:00:01"
            endDate = parsedToDate.ToString("yyyy-MM-dd") + " 00:00:01"

        Else
            startDate = New DateTime(year, month, 1)
            endDate = startDate.AddMonths(1).AddDays(-1)
        End If
        


        startDate = startDate.ToString("yyyy-MM-dd") + " 00:00:01"
        endDate = endDate.ToString("yyyy-MM-dd") + " 23:59:59"

        Dim strsql As String


        strsql = "SELECT     CASE WHEN temp_pp.Model IS NULL THEN temp_rej.Model ELSE temp_pp.Model END AS Model_Name, CASE WHEN temp_pp.Power IS NULL  " & _
                        " THEN temp_rej.Power ELSE temp_pp.Power END AS Power, SUM(CASE WHEN temp_pp.Accepted_Qty IS NULL THEN 0 ELSE temp_pp.Accepted_Qty END) AS Accepted_qty,  " & _
                        "  SUM(CASE WHEN temp_rej.Rejected_Qty IS NULL THEN 0 ELSE temp_rej.Rejected_Qty END) AS Rejected_qty, CASE WHEN temp_pp.Order_Type IS NULL " & _
                        " THEN temp_rej.Order_Type ELSE temp_pp.Order_Type END AS Order_Type, CASE WHEN temp_pp.Order_Country IS NULL   " & _
                        " THEN temp_rej.Order_Country ELSE temp_pp.Order_Country END AS Order_Country  " & _
                  "INTO temp_Production_and_Rejection_Report  " & _
                  " FROM         (SELECT     wk_prs.Tumbling_No, wk_prs.Model, wk_prs.Power, wk_prs.Accepted_Qty, wk_prs.Production_LotNo, BatchAllot.Order_Type, BatchAllot.Order_Country " & _
                        " FROM         (SELECT     CAST(Tumbling_No AS varchar) AS Tumbling_No, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS Power, SUM(Accepted_Qty) " & _
                        " AS Accepted_Qty, CAST(Tumbling_No AS varchar) AS Production_LotNo   FROM          work_In__Progress1 " & _
                        " WHERE      (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Process_Code = 'PHI 0014 MI FOR CL') " & _
                        " GROUP BY Tumbling_No, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)) AS wk_prs INNER JOIN " & _
                        " BatchAllot ON BatchAllot.LotNo = wk_prs.Tumbling_No ) AS temp_pp FULL OUTER JOIN " & _
                        " (SELECT     wk_prs.Tumbling_No, wk_prs.Model, wk_prs.Power, wk_prs.Rejected_Qty, wk_prs.Production_LotNo, BatchAllot.Order_Type, BatchAllot.Order_Country " & _
                        "FROM         (SELECT     CAST(Tumbling_No AS varchar) AS Tumbling_No, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS Power, SUM(Rejected_Qty) " & _
                        " AS Rejected_Qty, CAST(Tumbling_No AS varchar) AS Production_LotNo FROM          work_In__Progress1 AS work_In__Progress1_1 " & _
                        " WHERE      (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Rejected_Qty <> 0) AND (Process_Code IN ('PHI 0011 LI SC', 'PHI 0001 BLO FC', 'PHI 0002 LA FC', " & _
                        " 'PHI 0003 MI FC', 'PHI 0004 LM FC', 'PHI 0005 LI FC', 'PHI 0006 DE BLO FC', 'PHI 0007 BLO SC', 'PHI 0008 LA SC', 'PHI 0009 MI SC', 'PHI 0010 MI AND HT', 'PHI 0012 MILLING', " & _
                        "'PHI 0013 DE BLO SC', 'PHI 0015 LC', 'PHI 0014 MI FOR CL')) AND (Received_Qty <> Accepted_Qty) GROUP BY Tumbling_No, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)) AS wk_prs INNER JOIN " & _
                        " BatchAllot ON BatchAllot.LotNo = wk_prs.Tumbling_No) AS temp_rej ON temp_pp.Tumbling_No = temp_rej.Tumbling_No AND temp_pp.Model = temp_rej.Model AND " & _
                        " temp_pp.Power = temp_rej.Power AND temp_pp.Order_Type = temp_rej.Order_Type AND temp_pp.Order_Country = temp_rej.Order_Country  " & _
                        " GROUP BY CASE WHEN temp_pp.Model IS NULL THEN temp_rej.Model ELSE temp_pp.Model END, CASE WHEN temp_pp.Power IS NULL THEN temp_rej.Power ELSE temp_pp.Power END,  " & _
                        "  CASE WHEN temp_pp.Order_Type IS NULL THEN temp_rej.Order_Type ELSE temp_pp.Order_Type END, CASE WHEN temp_pp.Order_Country IS NULL " & _
                        "  THEN temp_rej.Order_Country ELSE temp_pp.Order_Country END "


        UpdateorInsertQuery_Execute(strsql, conPHILIC_ERP)





    End Sub


    Public Function GetExcelReport_Production(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtGalaxy As New DataTable

        temp_table_creation_production(year, month)



        'strsql = "SELECT     TOP (100) PERCENT CASE WHEN plan1.Model_Name IS NULL THEN production.Model_Name ELSE plan1.Model_Name END AS Model, CASE WHEN plan1.Power IS NULL  " & _
        '         "THEN production.Power ELSE plan1.Power END AS Power, CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS Planned_Qty, CAST(CASE WHEN production.qty IS NULL  " & _
        '        "THEN 0 ELSE production.qty END AS INT) AS Achieved_Qty, CAST(CASE WHEN production.Rejected_qty IS NULL THEN 0 ELSE production.Rejected_qty END AS INT) AS Rejected_Qty, " & _
        '         "CAST((CAST(CASE WHEN production.qty IS NULL THEN 0 ELSE production.qty END AS INT) - CAST(CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS INT)) AS INT) AS Deviation, " & _
        '         "CASE WHEN plan1.Order_Country IS NULL THEN production.Order_Country ELSE plan1.Order_Country END AS Country " & _
        '        "FROM         (SELECT     Model_Name, Power, SUM(Planned_Qty) AS plan_qty, Order_Type, Order_Country  FROM         Production_Plan1 " & _
        '        "WHERE      (Year = '" & year & "') AND (Month = '" & month & "') GROUP BY Model_Name, Power, Order_Type, Order_Country) AS plan1 FULL OUTER JOIN " & _
        '        "(SELECT      Model_Name, Power, SUM(Accepted_qty) AS qty,  SUM(Rejected_qty) AS Rejected_qty, Order_Type, Order_Country  FROM          temp_Production_and_Rejection_Report " & _
        '        " GROUP BY   Model_Name, Power, Order_Type, Order_Country) AS production ON plan1.Model_Name = production.Model_Name AND plan1.Power = production.Power AND " & _
        '        "plan1.Order_Type = production.Order_Type AND plan1.Order_Country = production.Order_Country ORDER BY Model, CAST(CASE WHEN plan1.Power IS NULL THEN production.Power ELSE plan1.Power END AS float), Country"


        strsql = "SELECT TOP (100) PERCENT COALESCE(plan1.Model_Name, production.Model_Name) AS Model, COALESCE(plan1.Power, production.Power) AS Power, COALESCE(plan1.plan_qty, 0) AS Planned_Qty,CAST(COALESCE(production.qty, 0) + COALESCE(production.Rejected_qty, 0) AS INT) AS Cutting_Qty, CAST(COALESCE(production.qty, 0) AS INT) AS Achieved_Qty, CAST(COALESCE(production.Rejected_qty, 0) AS INT) AS Rejected_Qty,  CAST(COALESCE(production.qty, 0) + COALESCE(production.Rejected_qty, 0) AS INT) - CAST(COALESCE(plan1.plan_qty, 0) AS INT) AS Deviation, COALESCE(plan1.Order_Country, production.Order_Country) AS Country FROM (SELECT Model_Name, Power, SUM(Planned_Qty) AS plan_qty, Order_Type, Order_Country FROM Production_Plan1 WHERE (Year = '" & year & "') AND (Month = '" & month & "') " & _
" GROUP BY Model_Name, Power, Order_Type, Order_Country) AS plan1 FULL OUTER JOIN (SELECT Model_Name, Power, SUM(Accepted_qty) AS qty, SUM(Rejected_qty) AS Rejected_qty, Order_Type, Order_Country FROM temp_Production_and_Rejection_Report GROUP BY Model_Name, Power, Order_Type, Order_Country) AS production ON plan1.Model_Name = production.Model_Name AND plan1.Power = production.Power AND plan1.Order_Type = production.Order_Type AND plan1.Order_Country = production.Order_Country ORDER BY Model, CAST(COALESCE(plan1.Power, production.Power) AS FLOAT), Country "
        Ds = SQL_SelectQuery_Execute(strsql, conPHILIC_ERP)
        dt = Ds.Tables(0)



        Return dt

    End Function

End Class
