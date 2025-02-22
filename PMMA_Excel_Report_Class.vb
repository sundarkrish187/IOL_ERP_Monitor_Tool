
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class PMMA_Excel_Report_Class

    Dim conPMMA, conGalaxy, conPMMAERP As New SqlConnection
    Dim Ds As New DataSet

    Private pro_comboYear As String
    Private Pro_comboMonth As String
    Private Pro_comboDate As String
    Private Pro_ToDate As String
    Private Pro_checkBox_date As Boolean

    Public Sub New(ByVal comboYear As String, ByVal comboMonth As String, ByVal comboDate As String, ByVal ToDate As String, ByVal checkBox_date As Boolean)
        pro_comboYear = comboYear
        Pro_comboMonth = comboMonth
        Pro_comboDate = comboDate
        Pro_ToDate = ToDate
        Pro_checkBox_date = checkBox_date
    End Sub

    Public Sub PMMA_Excel_class()
        conPMMA.ConnectionString = ConfigurationSettings.AppSettings("conStrPMMA").ToString()
        conGalaxy.ConnectionString = ConfigurationSettings.AppSettings("conStrGALAXYLENS").ToString()
        conPMMAERP.ConnectionString = ConfigurationSettings.AppSettings("conStrPMMA_ERP").ToString()
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
        Dim dtPMMA, dtPMMA_ERP As New DataTable

        strsql = "SELECT     Model_Name, Power, GlassyLotno, SUM(Qty_1) AS Qty, Pouch_Order_Type, Pouch_Order_Country  " & _
                "FROM       POUCH_LABEL " & _
                "WHERE     (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "' )  " & _
               "GROUP BY Model_Name, Power, GlassyLotno, Pouch_Order_Type, Pouch_Order_Country "

        Ds = SQL_SelectQuery_Execute(strsql, conPMMA)
        dtPMMA = Ds.Tables(0)


        'strsql = "SELECT     LotNo, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS power, SUM(Rejected_Qty) AS Qty " & _
        '        "FROM         work_In__Progress1   " & _
        '       "WHERE     (Process_Name = 'PMA - FQI MICROSCOPIC INSPECTION') AND (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (dbo.CSVParser(Product_Description, 2) <> 'ES701') " & _
        '       "GROUP BY LotNo, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)"

        strsql = "SELECT     LotNo, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS power, SUM(Rejected_Qty) AS Qty " & _
              "FROM         work_In__Progress1   " & _
             "WHERE     (Process_Name = 'PMA - FQI MICROSCOPIC INSPECTION') AND (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "')  " & _
             "GROUP BY LotNo, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)"

        Ds = SQL_SelectQuery_Execute(strsql, conPMMAERP)
        dtPMMA_ERP = Ds.Tables(0)

        If dtPMMA.Rows.Count = dtPMMA_ERP.Rows.Count Then
            Return True
        Else
            Return False
        End If

    End Function


    Private Sub CheckTMP_Pouch_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Pouch_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPMMA)
        Catch ex As Exception


        End Try

        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Pouch_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conGalaxy)


        Catch ex As Exception


        End Try
    End Sub

    Public Sub temp_table_creation(ByVal year As String, ByVal month As String)

        'Check only PMMA Except GalaxyLens
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

        strsql = "SELECT     temp_pp.Model_Name, temp_pp.Power, temp_pp.GlassyLotno, temp_pp.Expr1 AS Accepted_qty, tem_rej.Expr1 AS Rejected_qty, temp_pp.Pouch_Order_Type, temp_pp.Pouch_Order_Country  " & _
                "INTO temp_Pouch_and_Rejection_Report  " & _
                "FROM         (SELECT     Model_Name, Power, GlassyLotno, SUM(Qty_1) AS Expr1, Pouch_Order_Type, Pouch_Order_Country FROM          POUCH_LABEL " & _
                "WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "')  " & _
               "GROUP BY Model_Name, Power, GlassyLotno, Pouch_Order_Type, Pouch_Order_Country) AS temp_pp INNER JOIN " & _
                "(SELECT     LotNo, PMMA_ERP.dbo.CSVParser(Product_Description, 2) AS Model, PMMA_ERP.dbo.CSVParser(Product_Description, 4) AS power, SUM(Rejected_Qty) AS Expr1 " & _
                "FROM          PMMA_ERP.dbo.work_In__Progress1 WHERE      (Process_Name = 'PMA - FQI MICROSCOPIC INSPECTION') AND (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') " & _
                "GROUP BY LotNo, PMMA_ERP.dbo.CSVParser(Product_Description, 2), PMMA_ERP.dbo.CSVParser(Product_Description, 4)) AS tem_rej ON temp_pp.Model_Name = tem_rej.Model AND " & _
                "temp_pp.Power = tem_rej.power AND temp_pp.GlassyLotno = tem_rej.LotNo"

        UpdateorInsertQuery_Execute(strsql, conPMMA)


        strsql = "SELECT     temp_pp.Model_Name, temp_pp.Power,  temp_pp.Expr1 AS Accepted_qty, tem_rej.Expr1 AS Rejected_qty, temp_pp.Pouch_Order_Type, temp_pp.Pouch_Order_Country  " & _
                "INTO temp_Pouch_and_Rejection_Report  " & _
                "FROM         (SELECT     Model_Name, Power, SUM(Qty_1) AS Expr1, 'Export' AS Pouch_Order_Type, 'Elies' AS Pouch_Order_Country FROM          POUCH_LABEL " & _
                "WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "')  " & _
               "GROUP BY Model_Name, Power) AS temp_pp INNER JOIN " & _
                "(SELECT     PMMA_ERP.dbo.CSVParser(Product_Description, 2) AS Model, PMMA_ERP.dbo.CSVParser(Product_Description, 4) AS power, SUM(Rejected_Qty) AS Expr1 " & _
                "FROM          PMMA_ERP.dbo.work_In__Progress1 WHERE      (Process_Name = 'PMA - FQI MICROSCOPIC INSPECTION') AND (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (dbo.CSVParser(Product_Description, 2)= 'ES701') " & _
                "GROUP BY  PMMA_ERP.dbo.CSVParser(Product_Description, 2), PMMA_ERP.dbo.CSVParser(Product_Description, 4)) AS tem_rej ON temp_pp.Model_Name = tem_rej.Model AND " & _
                "temp_pp.Power = tem_rej.power  "

        UpdateorInsertQuery_Execute(strsql, conGalaxy)


    End Sub


    Public Function GetExcelReport_Pouch(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtGalaxy As New DataTable

        'If compare_Rejection_and_Pouch_Packed(year, month) = False Then
        '    MsgBox("(PMMA) Rejection Details Comparison failed. Please Contact ERP Team.", MsgBoxStyle.Information)
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

        Ds = SQL_SelectQuery_Execute(strsql, conPMMA)
        dt = Ds.Tables(0)

        'Ds = SQL_SelectQuery_Execute(strsql, conGalaxy)
        'dtGalaxy = Ds.Tables(0)

        'dt.Merge(dtGalaxy)

        Return dt

    End Function
    'BoxPacking
    Private Sub CheckTMP_box_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Delete from temp_Box_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPMMA)
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



        UpdateorInsertQuery_Execute(strsql, conPMMA)

    End Sub
    Public Function GetExcelReport_box(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtGalaxy As New DataTable


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




       

        Ds = SQL_SelectQuery_Execute(strsql, conPMMA)
        dt = Ds.Tables(0)


        Return dt

    End Function

    'PRODUCTION

    Private Sub CheckTMP_Production_and_Rejection_Report()

        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Lathe_rejection_report"
            UpdateorInsertQuery_Execute(SqlCk2, conPMMAERP)
        Catch ex As Exception


        End Try


        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Production_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPMMAERP)
        Catch ex As Exception


        End Try


        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_achieve"
            UpdateorInsertQuery_Execute(SqlCk2, conPMMAERP)
        Catch ex As Exception


        End Try

        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_alloted"
            UpdateorInsertQuery_Execute(SqlCk2, conPMMAERP)
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
            startDate = parsedFromDate.ToString("yyyy-MM-dd")
            endDate = parsedToDate.ToString("yyyy-MM-dd")
        Else
            startDate = New DateTime(year, month, 1)
            endDate = startDate.AddMonths(1).AddDays(-1)
        End If

        startDate = startDate.ToString("yyyy-MM-dd") + " 00:00:01"
        endDate = endDate.ToString("yyyy-MM-dd") + " 23:59:59"

        Dim strsql As String


        strsql = " SELECT     LotNo, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS Power, SUM(Rejected_Qty) AS Rejected_Qty, LotNo AS Production_LotNo, " & _
                        " (SELECT DISTINCT Order_Type FROM          BatchAllot AS BatchAllot_2 WHERE      (work_In__Progress1.LotNo BETWEEN LotNo AND LotTo)) AS Order_Type, " & _
                        " (SELECT DISTINCT Order_Country FROM          BatchAllot AS BatchAllot_1 WHERE      (work_In__Progress1.LotNo BETWEEN LotNo AND LotTo)) AS Order_Country" & _
                 " INTO            temp_Lathe_rejection_report " & _
                 " FROM         work_In__Progress1 " & _
                 " WHERE     (Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Process_Code IN ('PMA 0014 LI SC')) AND (Rejected_Qty <> 0) AND (Received_Qty <> Accepted_Qty) " & _
                 " GROUP BY LotNo, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4) "


        UpdateorInsertQuery_Execute(strsql, conPMMAERP)



        'strsql = " INSERT INTO temp_Lathe_rejection_report " & _
        '         " SELECT     Tumbling_No, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS Power, SUM(Rejected_Qty) AS Rejected_Qty,  " & _
        '               "  (SELECT     TOP (1) Lot_no FROM          working_process_Child WHERE      (TumblingLotNo = work_In__Progress1.Tumbling_No)) AS Production_LotNo, " & _
        '               " CASE WHEN (SELECT     TOP (1) Lot_no FROM          dbo.working_process_Child AS working_process_Child_2 WHERE      (TumblingLotNo = dbo.work_In__Progress1.Tumbling_No)) IS NULL THEN " & _
        '               "  (SELECT DISTINCT Order_Type FROM          dbo.PMMA_ReMattTumbling  WHERE      (GlassyLotNo = Tumbling_No)) ELSE " & _
        '               "  (SELECT DISTINCT Order_Type FROM          dbo.BatchAllot WHERE      ((SELECT     TOP (1) Lot_no FROM         dbo.working_process_Child AS working_process_Child_2 " & _
        '               "  WHERE     (TumblingLotNo = dbo.work_In__Progress1.Tumbling_No)) BETWEEN LotNo AND LotTo)) END AS Order_Type, CASE WHEN (SELECT     TOP (1) Lot_no " & _
        '               "  FROM          dbo.working_process_Child AS working_process_Child_2 WHERE      (TumblingLotNo = dbo.work_In__Progress1.Tumbling_No)) IS NULL THEN " & _
        '               "  (SELECT DISTINCT Order_Country FROM          dbo.PMMA_ReMattTumbling WHERE      (GlassyLotNo = Tumbling_No)) ELSE (SELECT DISTINCT Order_Country " & _
        '               "   FROM          dbo.BatchAllot WHERE      ((SELECT     TOP (1) Lot_no FROM         dbo.working_process_Child AS working_process_Child_2 " & _
        '               "  WHERE     (TumblingLotNo = dbo.work_In__Progress1.Tumbling_No)) BETWEEN lotNo AND LotTo)) END AS Order_Country " & _
        '        " FROM         work_In__Progress1 " & _
        '       " WHERE     (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Process_Code IN ('PMA 0019 PI TUM', 'PMA 0020 POW SEGRI')) AND (Rejected_Qty <> 0) AND (Received_Qty <> Accepted_Qty)  " & _
        '       " GROUP BY Tumbling_No, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)  "

        strsql = "WITH RejectionDetails AS (" &
       "SELECT Tumbling_No, dbo.CSVParser(Product_Description, 2) AS Model, " & _
       "dbo.CSVParser(Product_Description, 4) AS Power, SUM(Rejected_Qty) AS Rejected_Qty " & _
       "FROM work_In__Progress1 " &
       "WHERE Updated_Date BETWEEN '2024-10-01 00:00:01' AND '2024-10-31 23:59:59' " & _
       "AND Process_Code IN ('PMA 0019 PI TUM', 'PMA 0020 POW SEGRI') " & _
       "AND Rejected_Qty <> 0 AND Received_Qty <> Accepted_Qty " & _
       "GROUP BY Tumbling_No, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)) " & _
        "INSERT INTO temp_Lathe_rejection_report " & _
       "SELECT rd.Tumbling_No, rd.Model, rd.Power, rd.Rejected_Qty, wp.Lot_no AS Production_LotNo, " & _
       "COALESCE(ba.Order_Type, pr.Order_Type) AS Order_Type, COALESCE(ba.Order_Country, pr.Order_Country) AS Order_Country " & _
       "FROM RejectionDetails rd " & _
       "OUTER APPLY (SELECT TOP (1) Lot_no FROM working_process_Child WHERE TumblingLotNo = rd.Tumbling_No) wp " & _
       "OUTER APPLY (SELECT DISTINCT Order_Type, Order_Country FROM PMMA_ReMattTumbling WHERE GlassyLotNo = rd.Tumbling_No) pr " & _
       "OUTER APPLY (SELECT DISTINCT Order_Type, Order_Country FROM BatchAllot WHERE wp.Lot_no BETWEEN LotNo AND LotTo) ba;"



        UpdateorInsertQuery_Execute(strsql, conPMMAERP)


        strsql = " SELECT     CASE WHEN temp_pp.Model IS NULL THEN temp_rej.Model ELSE temp_pp.Model END AS Model_Name, CASE WHEN temp_pp.Power IS NULL THEN temp_rej.Power ELSE temp_pp.Power END AS Power, " & _
                 " SUM(CASE WHEN temp_pp.Accepted_Qty IS NULL THEN 0 ELSE temp_pp.Accepted_Qty END) AS Accepted_qty, SUM(CASE WHEN temp_rej.Rejected_Qty IS NULL THEN 0 ELSE temp_rej.Rejected_Qty END) AS Rejected_qty,  " & _
                 " CASE WHEN temp_pp.Order_Type IS NULL THEN temp_rej.Order_Type ELSE temp_pp.Order_Type END AS Order_Type, CASE WHEN temp_pp.Order_Country IS NULL THEN temp_rej.Order_Country ELSE temp_pp.Order_Country END AS Order_Country " & _
           " INTO temp_Production_and_Rejection_Report " & _
          " FROM         (SELECT     LotNo, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS Power, SUM(Accepted_Qty) AS Accepted_Qty, LotNo AS Production_LotNo,  " & _
                    " (SELECT DISTINCT Order_Type FROM          BatchAllot AS BatchAllot_2 WHERE      (work_In__Progress1.LotNo BETWEEN LotNo AND LotTo)) AS Order_Type, " & _
                    " (SELECT DISTINCT Order_Country FROM          BatchAllot AS BatchAllot_1 WHERE      (work_In__Progress1.LotNo BETWEEN LotNo AND LotTo)) AS Order_Country" & _
                 " FROM          work_In__Progress1  WHERE      (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Process_Code = 'PMA 0014 LI SC')  " & _
                 " GROUP BY LotNo, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)) AS temp_pp FULL OUTER JOIN " & _
                 "  (SELECT     LotNo AS Tumbling_no, Model, Power, Rejected_Qty, Production_LotNo, Order_Type, Order_Country " & _
                 "  FROM          temp_Lathe_rejection_report) AS temp_rej ON temp_pp.Model = temp_rej.Model AND temp_pp.Power = temp_rej.Power AND temp_pp.Order_Type = temp_rej.Order_Type AND " & _
                 "  temp_pp.Order_Country = temp_rej.Order_Country AND temp_pp.LotNo = temp_rej.Tumbling_no " & _
            "GROUP BY CASE WHEN temp_pp.Model IS NULL THEN temp_rej.Model ELSE temp_pp.Model END, CASE WHEN temp_pp.Power IS NULL THEN temp_rej.Power ELSE temp_pp.Power END,  " & _
                 " CASE WHEN temp_pp.Order_Type IS NULL THEN temp_rej.Order_Type ELSE temp_pp.Order_Type END, CASE WHEN temp_pp.Order_Country IS NULL  " & _
                 " THEN temp_rej.Order_Country ELSE temp_pp.Order_Country END "

        UpdateorInsertQuery_Execute(strsql, conPMMAERP)


    End Sub

    Public Function GetExcelReport_Production(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtGalaxy As New DataTable

        Dim startDate As New DateTime()
        Dim endDate As New DateTime()
        If Pro_checkBox_date = True Then
            Dim parsedFromDate As DateTime = DateTime.Parse(Pro_comboDate)
            Dim parsedToDate As DateTime = DateTime.Parse(Pro_ToDate)
            startDate = parsedFromDate.ToString("yyyy-MM-dd")
            endDate = parsedToDate.ToString("yyyy-MM-dd")
        Else
            startDate = New DateTime(year, month, 1)
            endDate = startDate.AddMonths(1).AddDays(-1)
        End If

        startDate = startDate.ToString("yyyy-MM-dd") + " 00:00:01"
        endDate = endDate.ToString("yyyy-MM-dd") + " 23:59:59"

        temp_table_creation_production(year, month)



        strsql = "SELECT     TOP (100) PERCENT CASE WHEN plan1.Model_Name IS NULL THEN production.Model_Name ELSE plan1.Model_Name END AS Model, CASE WHEN plan1.Power IS NULL  " & _
                 "THEN production.Power ELSE plan1.Power END AS Power, CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS Planned_Qty, CAST(CASE WHEN production.qty IS NULL  " & _
                "THEN 0 ELSE production.qty END AS INT) AS Achieved_Qty, CAST(CASE WHEN production.Rejected_qty IS NULL THEN 0 ELSE production.Rejected_qty END AS INT) AS Rejected_Qty, " & _
                 "CAST((CAST(CASE WHEN production.qty IS NULL THEN 0 ELSE production.qty END AS INT) - CAST(CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS INT)) AS INT) AS Deviation, " & _
                 "CASE WHEN plan1.Order_Country IS NULL THEN production.Order_Country ELSE plan1.Order_Country END AS Country " & _
                  "INTO temp_achieve " & _
                "FROM         (SELECT     Model_Name, Power, SUM(Planned_Qty) AS plan_qty, Order_Type, Order_Country  FROM         Production_Plan1 " & _
                "WHERE      (Year = '" & year & "') AND (Month = '" & month & "') GROUP BY Model_Name, Power, Order_Type, Order_Country) AS plan1 FULL OUTER JOIN " & _
                "(SELECT      Model_Name, Power, SUM(Accepted_qty) AS qty,  SUM(Rejected_qty) AS Rejected_qty, Order_Type, Order_Country  FROM          temp_Production_and_Rejection_Report " & _
                " GROUP BY   Model_Name, Power, Order_Type, Order_Country) AS production ON plan1.Model_Name = production.Model_Name AND plan1.Power = production.Power AND " & _
                "plan1.Order_Type = production.Order_Type AND plan1.Order_Country = production.Order_Country ORDER BY Model,  CAST(CASE WHEN plan1.Power IS NULL THEN production.Power ELSE plan1.Power END AS float) , Country"


        UpdateorInsertQuery_Execute(strsql, conPMMAERP)


        strsql = "SELECT     LotNo, dbo.CSVParser(Product_Description, 2) AS Model, dbo.CSVParser(Product_Description, 4) AS Power, SUM(Accepted_Qty) + SUM(Rejected_Qty) AS tot,  " & _
                " (SELECT DISTINCT Order_Type FROM          BatchAllot AS BatchAllot_2  WHERE      (work_In__Progress1.LotNo BETWEEN LotNo AND LotTo)) AS Order_Type, " & _
               "(SELECT DISTINCT Order_Country FROM          BatchAllot AS BatchAllot_1 WHERE      (work_In__Progress1.LotNo BETWEEN LotNo AND LotTo)) AS Order_Country " & _
               "INTO  temp_alloted " & _
               "FROM         work_In__Progress1  " & _
               "WHERE     (Updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Process_Code = 'PMA 0014 LI SC') " & _
               "GROUP BY LotNo, dbo.CSVParser(Product_Description, 2), dbo.CSVParser(Product_Description, 4)"

        UpdateorInsertQuery_Execute(strsql, conPMMAERP)



        strsql = " SELECT     tAchi.Model, tAchi.Power, tAchi.Planned_Qty, CASE WHEN tAllo.Tot IS NULL THEN 0 ELSE tAllo.Tot END AS Cutting_Qty, tAchi.Achieved_Qty, tAchi.Rejected_Qty, CASE WHEN tAllo.Tot IS NULL   " & _
                "  THEN 0 ELSE tAllo.Tot END - tAchi.Planned_Qty AS Deviation, tAchi.Country " & _
                "  FROM         (SELECT     Model, Power, Planned_Qty, Achieved_Qty, Rejected_Qty, Deviation, Country  " & _
                "   FROM          temp_achieve) AS tAchi FULL OUTER JOIN " & _
                "  (SELECT     Model, Power, Order_Country, SUM(tot) AS Tot " & _
                "  FROM          temp_alloted " & _
                " GROUP BY Model, Power, Order_Country) AS tAllo ON tAchi.Model = tAllo.Model AND tAchi.Power = tAllo.Power AND tAchi.Country = tAllo.Order_Country  " & _
                "  ORDER BY tAchi.Model, CAST(tAchi.Power AS FLOAT) "

        Ds = SQL_SelectQuery_Execute(strsql, conPMMAERP)
        dt = Ds.Tables(0)
        Return dt

    End Function
End Class
