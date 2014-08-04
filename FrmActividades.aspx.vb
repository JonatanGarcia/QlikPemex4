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
        ds = Me.Cache("actividades")


        'LbIntervencion.DataSource = ds.Tables(0)
        'LbIntervencion.DataTextField = "strNombre"
        'LbIntervencion.DataValueField = "idTipo"
        'LbIntervencion.DataBind()


        CmdN1.DataSource = (From N1 In ds.Tables(0) _
                            Select N1.Field(Of String)("intervencion")).Distinct ',
        '.id = N1.Field(Of Integer)("idNPTN1")}).Distinct


        'CmdN1.DataTextField = "nivel1"
        'CmdN1.DataValueField = "id"
        CmdN1.DataBind()

        'HiddenField1.Value = busqueda
        'If busqueda <> "" Then

        '    Dim newBusqueda As New StringBuilder

        '    selecciones = Me.Cache("Selecciones")
        '    For i As Integer = 0 To selecciones.Length - 1
        '        If selecciones(i) <> "" Then
        '            newBusqueda.Append(selecciones(i)).Append("AND ")
        '        End If
        '    Next
        '    Dim dsAux As New DataSet
        '    dsAux.Merge(ds.Tables(0).Select(newBusqueda.ToString.Substring(0, newBusqueda.Length - 4)))
        '    ds = dsAux

        'End If
        ' '' LLenar Grid
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

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
        If Me.Cache("actividades") Is Nothing Then
            Me.Cache.Insert("actividades", Generic("SELECT " & _
                " A.idActividad as idact, A.strNombre as act, A.secuencia, I.idTipo, " & _
                " I.strNombre as intervencion FROM CAT_ACTIVIDADES A " & _
                " INNER JOIN CAT_INTERVENCION I ON I.idTipo=A.idTipo Order by I.strNombre"))
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        llenar()
    End Sub

End Class
