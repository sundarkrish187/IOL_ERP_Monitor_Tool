Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class PHOBIC_Excel_Report_Class

    Dim conPHOBIC, conNP, conSuperPhob, conPHOBIC_ERP, conPHOBIC_MOULDERP As New SqlConnection
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


    Public Sub PHOBIC_Excel_class()
        conPHOBIC.ConnectionString = ConfigurationSettings.AppSettings("conStrPHOBIC").ToString()
        conNP.ConnectionString = ConfigurationSettings.AppSettings("conStrNP").ToString()
        conSuperPhob.ConnectionString = ConfigurationSettings.AppSettings("conStrSUPERPHOB").ToString()
        conPHOBIC_ERP.ConnectionString = ConfigurationSettings.AppSettings("conStrPHOBIC_ERP").ToString()
        conPHOBIC_MOULDERP.ConnectionString = ConfigurationSettings.AppSettings("conStrPHOBIC_Mould").ToString()
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

    Private Sub CheckTMP_Pouch_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Pouch_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPHOBIC)
        Catch ex As Exception


        End Try

        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Pouch_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conNP)
        Catch ex As Exception


        End Try
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Pouch_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conSuperPhob)
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

        strsql = "SELECT    CASE WHEN temp_pp.RefLot IS NULL THEN temp_rej.RefLot COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.RefLot END AS Reflot,  " & _
                        "  CASE WHEN temp_pp.Model_Name IS NULL THEN temp_rej.Model_Name COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.Model_Name END AS Model_name, " & _
                        " CASE WHEN temp_pp.Power IS NULL THEN temp_rej.Power COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.Power END AS Power, " & _
                        " CASE WHEN temp_pp.qty IS NULL THEN 0 ELSE temp_pp.qty END AS Accepted_qty,  " & _
                       " CASE WHEN temp_rej.Rejected_Qty IS NULL THEN 0 ELSE temp_rej.Rejected_Qty END AS Rejected_qty, temp_pp.Pouch_Order_Type, temp_pp.Pouch_Order_Country " & _
                        " INTO temp_Pouch_and_Rejection_Report " & _
                "  FROM     (SELECT     RefLot, Model_Name, Power, SUM(Qty_1) AS qty, Pouch_Order_Type, Pouch_Order_Country " & _
                       "  FROM          POUCH_LABEL  WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "')" & _
                       " GROUP BY RefLot, Model_Name, Power, Pouch_Order_Type, Pouch_Order_Country) AS temp_pp FULL OUTER JOIN " & _
                        " (SELECT     RefLot, CASE WHEN Brand_Name = 'HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS' THEN Model_Name + '-NP' ELSE Model_Name END AS Model_name, Power, " & _
                        " SUM(Expr1) AS Rejected_Qty FROM          (SELECT     Brand_Name, Model_name, Power, RefLot, Label, 1 AS Expr1  FROM          MOULDING.dbo.MI_FQIReject  " & _
                       "  WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "' ) GROUP BY Brand_Name, Model_name, Power, RefLot, Label) AS new_tabe " & _
                        "   WHERE      (CASE WHEN Brand_Name = 'HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS' THEN Model_Name + '-NP' ELSE Model_Name END NOT IN ('SPNT300-NP', 'AE-01')) " & _
                         " GROUP BY RefLot, Brand_Name, Model_name, Power) AS temp_rej " & _
                          " ON temp_pp.Model_Name = temp_rej.Model_name COLLATE SQL_Latin1_General_CP1_CI_AS AND  " & _
                           " temp_pp.RefLot = temp_rej.RefLot COLLATE SQL_Latin1_General_CP1_CI_AS AND temp_pp.Power = temp_rej.Power COLLATE SQL_Latin1_General_CP1_CI_AS "


        UpdateorInsertQuery_Execute(strsql, conPHOBIC)


        strsql = "SELECT    CASE WHEN temp_pp.RefLot IS NULL THEN temp_rej.RefLot COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.RefLot END AS Reflot,  " & _
                        "  CASE WHEN temp_pp.Model_Name IS NULL THEN temp_rej.Model_Name COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.Model_Name END AS Model_name, " & _
                        " CASE WHEN temp_pp.Power IS NULL THEN temp_rej.Power COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.Power END AS Power, " & _
                        " CASE WHEN temp_pp.qty IS NULL THEN 0 ELSE temp_pp.qty END AS Accepted_qty,  " & _
                       " CASE WHEN temp_rej.Rejected_Qty IS NULL THEN 0 ELSE temp_rej.Rejected_Qty END AS Rejected_qty, temp_pp.Pouch_Order_Type, temp_pp.Pouch_Order_Country " & _
                        " INTO temp_Pouch_and_Rejection_Report " & _
                "  FROM     (SELECT     RefLot, Model_Name+'-NP' AS Model_Name, Power, SUM(Qty_1) AS qty, Pouch_Order_Type, Pouch_Order_Country " & _
                       "  FROM          POUCH_LABEL  WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "')" & _
                       " GROUP BY RefLot, Model_Name, Power, Pouch_Order_Type, Pouch_Order_Country) AS temp_pp FULL OUTER JOIN " & _
                        " (SELECT     RefLot, CASE WHEN Brand_Name = 'HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS' THEN Model_Name + '-NP' ELSE Model_Name END AS Model_name, Power, " & _
                        " SUM(Expr1) AS Rejected_Qty FROM          (SELECT     Brand_Name, Model_name, Power, RefLot, Label, 1 AS Expr1  FROM          MOULDING.dbo.MI_FQIReject  " & _
                       "  WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "' ) GROUP BY Brand_Name, Model_name, Power, RefLot, Label) AS new_tabe " & _
                        "   WHERE      (CASE WHEN Brand_Name = 'HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS' THEN Model_Name + '-NP' ELSE Model_Name END  IN ('SPNT300-NP')) " & _
                         " GROUP BY RefLot, Brand_Name, Model_name, Power) AS temp_rej " & _
                          " ON temp_pp.Model_Name = temp_rej.Model_name COLLATE SQL_Latin1_General_CP1_CI_AS AND  " & _
                           " temp_pp.RefLot = temp_rej.RefLot COLLATE SQL_Latin1_General_CP1_CI_AS AND temp_pp.Power = temp_rej.Power COLLATE SQL_Latin1_General_CP1_CI_AS "


        UpdateorInsertQuery_Execute(strsql, conNP)


        strsql = "SELECT    CASE WHEN temp_pp.RefLot IS NULL THEN temp_rej.RefLot COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.RefLot END AS Reflot,  " & _
                        "  CASE WHEN temp_pp.Model_Name IS NULL THEN temp_rej.Model_Name COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.Model_Name END AS Model_name, " & _
                        " CASE WHEN temp_pp.Power IS NULL THEN temp_rej.Power COLLATE SQL_Latin1_General_CP1_CI_AS ELSE temp_pp.Power END AS Power, " & _
                        " CASE WHEN temp_pp.qty IS NULL THEN 0 ELSE temp_pp.qty END AS Accepted_qty,  " & _
                       " CASE WHEN temp_rej.Rejected_Qty IS NULL THEN 0 ELSE temp_rej.Rejected_Qty END AS Rejected_qty, temp_pp.Pouch_Order_Type, temp_pp.Pouch_Order_Country " & _
                        " INTO temp_Pouch_and_Rejection_Report " & _
                "  FROM     (SELECT     RefLot, Model_Name, Power, SUM(Qty_1) AS qty,  'Export' AS Pouch_Order_Type, 'Elies' AS Pouch_Order_Country " & _
                       "  FROM          POUCH_LABEL  WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "')" & _
                       " GROUP BY RefLot, Model_Name, Power, Pouch_Order_Type, Pouch_Order_Country) AS temp_pp FULL OUTER JOIN " & _
                        " (SELECT     RefLot, CASE WHEN Brand_Name = 'HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS' THEN Model_Name + '-NP' ELSE Model_Name END AS Model_name, Power, " & _
                        " SUM(Expr1) AS Rejected_Qty FROM          (SELECT     Brand_Name, Model_name, Power, RefLot, Label, 1 AS Expr1  FROM          MOULDING.dbo.MI_FQIReject  " & _
                       "  WHERE      (Created_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "' ) GROUP BY Brand_Name, Model_name, Power, RefLot, Label) AS new_tabe " & _
                        "   WHERE      (CASE WHEN Brand_Name = 'HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS' THEN Model_Name + '-NP' ELSE Model_Name END  IN ('AE-01')) " & _
                         " GROUP BY RefLot, Brand_Name, Model_name, Power) AS temp_rej " & _
                          " ON temp_pp.Model_Name = temp_rej.Model_name COLLATE SQL_Latin1_General_CP1_CI_AS AND  " & _
                           " temp_pp.RefLot = temp_rej.RefLot COLLATE SQL_Latin1_General_CP1_CI_AS AND temp_pp.Power = temp_rej.Power COLLATE SQL_Latin1_General_CP1_CI_AS "


        UpdateorInsertQuery_Execute(strsql, conSuperPhob)


    End Sub


    Public Function GetExcelReport_Pouch(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtNP, dtSuperPhob As New DataTable



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



        Ds = SQL_SelectQuery_Execute(strsql, conPHOBIC)
        dt = Ds.Tables(0)


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



        Ds = SQL_SelectQuery_Execute(strsql, conNP)
        dtNP = Ds.Tables(0)

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



        Ds = SQL_SelectQuery_Execute(strsql, conSuperPhob)
        dtSuperPhob = Ds.Tables(0)

        dt.Merge(dtNP)
        dt.Merge(dtSuperPhob)

        Return dt

    End Function

    'BoxPacking
 
    Private Sub CheckTMP_box_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Delete from temp_Box_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPHOBIC)
        Catch ex As Exception


        End Try

        Try
            Dim SqlCk2 As String
            SqlCk2 = "Delete from temp_Box_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conNP)
        Catch ex As Exception


        End Try
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Delete from temp_Box_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conSuperPhob)
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



        UpdateorInsertQuery_Execute(strsql, conPHOBIC)

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


        UpdateorInsertQuery_Execute(strsql, conNP)

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


        UpdateorInsertQuery_Execute(strsql, conSuperPhob)

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

        Ds = SQL_SelectQuery_Execute(strsql, conPHOBIC)
        dt = Ds.Tables(0)


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

        Ds = SQL_SelectQuery_Execute(strsql, conNP)
        dt = Ds.Tables(0)


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

        Ds = SQL_SelectQuery_Execute(strsql, conSuperPhob)
        dt = Ds.Tables(0)


        Return dt

    End Function
    'production

    Private Sub CheckTMP_Production_and_Rejection_Report()
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_Production_and_Rejection_Report"
            UpdateorInsertQuery_Execute(SqlCk2, conPHOBIC_MOULDERP)
        Catch ex As Exception


        End Try
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_rejection"
            UpdateorInsertQuery_Execute(SqlCk2, conPHOBIC_MOULDERP)
        Catch ex As Exception


        End Try
        Try
            Dim SqlCk2 As String
            SqlCk2 = "Drop Table temp_overall"
            UpdateorInsertQuery_Execute(SqlCk2, conPHOBIC_MOULDERP)
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


        strsql = "SELECT     TOP (100) PERCENT CASE WHEN accepted.REFLOT IS NULL THEN rejected.REFLOT ELSE accepted.REFLOT END AS Reflot,  " & _
                        "  CASE WHEN accepted.Model = '--Select--' THEN 'SPNT300' WHEN rejected.Model = '--Select--' THEN 'SPNT300' WHEN accepted.Model IS NULL THEN rejected.Model ELSE accepted.Model END AS Model_Name, " & _
                        " CASE WHEN accepted.Power IS NULL THEN rejected.Power ELSE accepted.Power END AS Power, " & _
                        " SUM(accepted.Acc_Qty) AS Accepted_qty, SUM(rejected.Rej_Qty) AS Rejected_Qty,  " & _
                       " (SELECT DISTINCT Order_Type FROM  BatchAllot_New WHERE  (LotNo = CASE WHEN accepted.REFLOT IS NULL THEN rejected.REFLOT ELSE accepted.REFLOT END)) AS Order_Type, " & _
                       " (SELECT DISTINCT Order_Country FROM   BatchAllot_New AS BatchAllot_New_1 WHERE   (LotNo = CASE WHEN accepted.REFLOT IS NULL THEN rejected.REFLOT ELSE accepted.REFLOT END)) AS Order_Country " & _
                        " INTO temp_Production_and_Rejection_Report " & _
                  " FROM         (SELECT     Reflot, Model, Power, SUM(Acc_Qty) AS Acc_Qty FROM          Moulding_Rejection " & _
                        " WHERE      (updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (Process_code = 'PHO SIAB 007') GROUP BY Reflot, Model, Power) AS accepted FULL OUTER JOIN  " & _
                       " (SELECT     Reflot, Model, Power, SUM(Rej_Qty) AS Rej_Qty FROM          Moulding_Rejection AS Moulding_Rejection_1 " & _
                       "  WHERE      (updated_Date BETWEEN '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "' ) AND (Process_code IN ('PHO FC 001', 'PHO LP 002', 'PHO CP 003', 'PHO HPWP 004', 'PHO SIAW 005', " & _
                       "  'PHO BP 006', 'PHO SIAB 007')) " & _
                       " GROUP BY Reflot, Model, Power) AS rejected ON accepted.Reflot = rejected.Reflot AND accepted.Model = rejected.Model AND accepted.Power = rejected.Power " & _
                       " GROUP BY CASE WHEN accepted.REFLOT IS NULL THEN rejected.REFLOT ELSE accepted.REFLOT END, " & _
                       " CASE WHEN accepted.Model = '--Select--' THEN 'SPNT300' WHEN rejected.Model = '--Select--' THEN 'SPNT300' WHEN accepted.Model IS NULL THEN rejected.Model ELSE accepted.Model END, " & _
                       " CASE WHEN accepted.Power IS NULL THEN rejected.Power ELSE accepted.Power END "


        UpdateorInsertQuery_Execute(strsql, conPHOBIC_MOULDERP)





    End Sub

    Public Function GetExcelReport_Production(ByVal year As String, ByVal month As String) As DataTable
        Dim strsql As String
        Dim dt, dtNP, dtSuperPhob As New DataTable

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


        temp_table_creation_production(year, month)

        strsql = " SELECT     dbo.Moulding_Rejection.Power, SUM(dbo.Moulding_Rejection.Rej_Qty) AS qty, dbo.BatchAllot_New.Order_Country, dbo.BatchAllot_New.Order_Type," & _
            "  CASE WHEN dbo.Moulding_Rejection.Model = '--Select--' THEN 'SPNT300' ELSE dbo.Moulding_Rejection.Model END AS Model " & _
            " INTO temp_rejection " & _
            " FROM         dbo.Moulding_Rejection INNER JOIN " & _
            " dbo.BatchAllot_New ON dbo.Moulding_Rejection.Reflot = dbo.BatchAllot_New.LotNo AND dbo.Moulding_Rejection.Power = dbo.BatchAllot_New.Power " & _
            " WHERE     (dbo.Moulding_Rejection.Updated_Date BETWEEN  '" & startDate.ToString("yyyy-MM-dd") + " 00:00:01" & "' AND '" & endDate.ToString("yyyy-MM-dd") + " 23:59:59" & "') AND (dbo.Moulding_Rejection.Process_code IN ('PHO FC 001', 'PHO LP 002', 'PHO CP 003', 'PHO HPWP 004', " & _
            "  'PHO SIAW 005', 'PHO BP 006', 'PHO SIAB 007')) AND (dbo.Moulding_Rejection.Rej_Qty <> 0) " & _
            " GROUP BY dbo.Moulding_Rejection.Power, dbo.BatchAllot_New.Order_Country, dbo.BatchAllot_New.Order_Type, " & _
            "  CASE WHEN dbo.Moulding_Rejection.Model = '--Select--' THEN 'SPNT300' ELSE dbo.Moulding_Rejection.Model END "

        UpdateorInsertQuery_Execute(strsql, conPHOBIC_MOULDERP)




        strsql = "SELECT     TOP (100) PERCENT CASE WHEN plan1.Model_Name IS NULL THEN production.Model_Name ELSE plan1.Model_Name END AS Model, CASE WHEN plan1.Power IS NULL  " & _
                 "THEN production.Power ELSE plan1.Power END AS Power, CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS Planned_Qty, CAST(CASE WHEN production.qty IS NULL  " & _
                "THEN 0 ELSE production.qty END AS INT) AS Achieved_Qty, CAST(CASE WHEN production.Rejected_qty IS NULL THEN 0 ELSE production.Rejected_qty END AS INT) AS Rejected_Qty, " & _
                 "CAST((CAST(CASE WHEN production.qty IS NULL THEN 0 ELSE production.qty END AS INT) - CAST(CASE WHEN plan1.plan_qty IS NULL THEN 0 ELSE plan1.plan_qty END AS INT)) AS INT) AS Deviation, " & _
                 "CASE WHEN plan1.Order_Country IS NULL THEN production.Order_Country ELSE plan1.Order_Country END AS Country " & _
                 " INTO temp_overall " & _
                 "FROM         (SELECT     Model_Name, Power, SUM(Planned_Qty) AS plan_qty, Order_Type, Order_Country  FROM         Production_Plan1 " & _
                "WHERE      (Year = '" & year & "') AND (Month = '" & month & "') GROUP BY Model_Name, Power, Order_Type, Order_Country) AS plan1 FULL OUTER JOIN " & _
                "(SELECT      Model_Name, Power, SUM(Accepted_qty) AS qty,  SUM(Rejected_qty) AS Rejected_qty, Order_Type, Order_Country  FROM          temp_Production_and_Rejection_Report " & _
                " GROUP BY   Model_Name, Power, Order_Type, Order_Country) AS production ON plan1.Model_Name = production.Model_Name AND plan1.Power = production.Power AND " & _
                "plan1.Order_Type = production.Order_Type AND plan1.Order_Country = production.Order_Country ORDER BY Model, CAST(CASE WHEN plan1.Power IS NULL THEN production.Power ELSE plan1.Power END AS float), Country"

        UpdateorInsertQuery_Execute(strsql, conPHOBIC_MOULDERP)

        
        strsql = " SELECT     tAchi.Model, tAchi.Power, tAchi.Planned_Qty, tAchi.Achieved_Qty + (CASE WHEN tAllo.rej IS NULL THEN 0 ELSE tAllo.rej END) AS Cutting_Qty, tAchi.Achieved_Qty, tAchi.Rejected_Qty,  " & _
                          "   (tAchi.Achieved_Qty + (CASE WHEN tAllo.rej IS NULL THEN 0 ELSE tAllo.rej END))- tAchi.Planned_Qty  AS Deviation,tAchi.Country " & _
                          " FROM         (SELECT     Model, Power, Planned_Qty, Achieved_Qty, Rejected_Qty, Deviation, Country " & _
                          " FROM          temp_overall) AS tAchi FULL OUTER JOIN " & _
                          "  (SELECT     Model, Power, Order_Country, SUM(qty) AS rej " & _
                          "   FROM          temp_rejection GROUP BY Model, Power, Order_Country) AS tAllo ON tAchi.Model = tAllo.Model AND tAchi.Power = tAllo.Power AND tAchi.Country = tAllo.Order_Country " & _
                          " ORDER BY tAchi.Model, CAST(tAchi.Power AS FLOAT) "




        Ds = SQL_SelectQuery_Execute(strsql, conPHOBIC_MOULDERP)
        dt = Ds.Tables(0)



        Return dt

    End Function

End Class
