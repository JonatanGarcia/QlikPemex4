Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            inicializar()
            llenar()
            ocultar()
        End If
    End Sub
    Sub llenar()
        Dim ds As New DataSet
        ds = Me.Cache("pozo")



        CmbInter.DataSource = (From N1 In ds.Tables(0) _
                            Select N1.Field(Of String)("inter")).Distinct
        CmbInter.DataBind()

        CmbTipoInter.DataSource = (From N1 In ds.Tables(0) _
                            Select N1.Field(Of String)("subInter")).Distinct
        CmbTipoInter.DataBind()

        

    End Sub
    Sub mostrar()
        LblTipo.Visible = True
        CmbTipoInter.Visible = True
    End Sub
    Sub ocultar()
        LblTipo.Visible = False
        CmbTipoInter.Visible = False
        CmbTipoInter.SelectedIndex = 0
        asignaPozo(Me.Cache("pozo"), CmbInter.SelectedValue, CmbTipoInter.SelectedValue)
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
        If Me.Cache("pozo") Is Nothing Then
            Me.Cache.Insert("pozo", Generic("SELECT " & _
                " CI.strNombre as inter, CSI.strNombre as subInter, P.strNombre as Pozo " & _
                " FROM INTERVENCION I " & _
                " INNER JOIN CAT_INTERVENCION CI ON CI.idTipo=I.idTipo " & _
                " INNER JOIN CAT_SUB_INTERVENCION CSI ON CSI.idCatSubIntervencion=I.idCatSubIntervencion " & _
                " INNER JOIN POZO P ON P.idPozo=I.idPozo"))
        End If
    End Sub

    Sub asignaPozo(ds As DataSet, intervencion As String, tipoInter As String)
        CmbPozo.DataSource = (From N1 In ds.Tables(0) _
                                Where N1("inter") = intervencion And N1("subInter") = tipoInter
                              Order By N1("Pozo") _
                            Select N1.Field(Of String)("Pozo")).Distinct
        CmbPozo.DataBind()
    End Sub
    Protected Sub CmbInter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbInter.SelectedIndexChanged
        If CmbInter.SelectedValue = "REPARACIÓN MAYOR" Then
            mostrar()
        Else
            ocultar()

        End If
    End Sub

    Protected Sub CmbTipoInter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoInter.SelectedIndexChanged
        asignaPozo(Me.Cache("pozo"), CmbInter.SelectedValue, CmbTipoInter.SelectedValue)
    End Sub
End Class
