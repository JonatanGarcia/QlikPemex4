Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            inicializar()
            llenar()
        End If
    End Sub
    Sub llenar()
        Dim ds As New DataSet
        ds = Me.Cache("nptIntervencion")

        CmdIntervencion.DataSource = (From intervencion In ds.Tables(0) _
                            Select intervencion.Field(Of String)("Inter")).Distinct
        CmdIntervencion.DataBind()

       
        llenarActividades(ds, CmdIntervencion.SelectedValue)

        ds = Nothing
    End Sub
    Sub llenarActividades(ds As DataSet, inter As String)
        CmbActividades.DataSource = (From intervencion In ds.Tables(0) _
                                    Where intervencion("inter") = inter _
                                    Order By intervencion("act") _
                               Select intervencion.Field(Of String)("act")).Distinct
        CmbActividades.DataBind()
        organizaNpts(ds, CmdIntervencion.SelectedValue, CmbActividades.SelectedValue)
    End Sub
    Sub organizaNpts(ds As DataSet, inter As String, actividad As String)
        LblAsignado.DataSource = (From intervencion In ds.Tables(0) _
                                    Where intervencion("inter") = inter And intervencion("act") = actividad _
                                    Order By intervencion("nivel4") _
                                    Select intervencion.Field(Of String)("nivel4")).Distinct
        LblAsignado.DataBind()

        LblNoasignado.DataSource = (From intervencion In ds.Tables(0) _
                                    Where intervencion("act") <> actividad _
                                    Order By intervencion("nivel4") _
                                    Select intervencion.Field(Of String)("nivel4")).Distinct
        LblNoasignado.DataBind()
    End Sub
    Public Function Generic(ByVal sql As String) As DataSet
        Dim ds As New DataSet
        Dim dao As New StoredBDAccess
        Dim listParametros As New List(Of Parametros)
        listParametros.Add(New Parametros("@SQL_QUERY", SqlDbType.VarChar, sql))
        Dim busca = New DescripParametros("getGeneric", listParametros)
        ds = dao.getDataSet(busca)
        Return ds
    End Function
    Sub inicializar()
        If Me.Cache("nptIntervencion") Is Nothing Then
            Me.Cache.Insert("nptIntervencion", Generic("SELECT " & _
                " n4.strNombre as nivel4, CI.strNombre as inter, CA.strnombre as act" & _
                " FROM NPT_INTERVENCION NP " & _
                " INNER JOIN CAT_NPTS_N4 N4 ON N4.idNPTN4=NP.idNPTN4 " & _
                " INNER JOIN CAT_INTERVENCION CI ON CI.idTipo=NP.idTipo " & _
                " INNER JOIN CAT_ACTIVIDADES CA ON CA.idActividad=NP.idActividad"))
        End If
    End Sub

    Protected Sub CmdIntervencion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmdIntervencion.SelectedIndexChanged
        llenarActividades(Me.Cache("nptIntervencion"), CmdIntervencion.SelectedValue)
    End Sub

    Protected Sub CmbActividades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbActividades.SelectedIndexChanged
        organizaNpts(Me.Cache("nptIntervencion"), CmdIntervencion.SelectedValue, CmbActividades.SelectedValue)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("NO ASIGNADO= " & LblNoasignado.SelectedValue & vbCrLf & "ASIGNADO= " & LblAsignado.SelectedValue)
    End Sub
End Class
