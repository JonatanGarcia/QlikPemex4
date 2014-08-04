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
        ds = Me.Cache("nivel2")


        'LbIntervencion.DataSource = ds.Tables(0)
        'LbIntervencion.DataTextField = "strNombre"
        'LbIntervencion.DataValueField = "idTipo"
        'LbIntervencion.DataBind()


        'CmdN1.DataSource = (From N1 In ds.Tables(0) _
        '                   Where N1("nivel1") <> "NORMAL" _
        '                   Select New With {
        '                       .idN1 = N1("idNPTN1"),
        '                       .nivel1 = N1("nivel1")}).Distinct


        CmdN1.DataSource = (From N1 In ds.Tables(0) _
                            Select N1.Field(Of String)("nivel1")).Distinct ',
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
        If Me.Cache("nivel2") Is Nothing Then
            Me.Cache.Insert("nivel2", Generic("SELECT " & _
                " N2.idNPTN2,  N2.strNombre AS nivel2, N1.idNPTN1, N1.strNombre as nivel1 FROM CAT_NPTS_N2 N2 " & _
                " INNER JOIN CAT_NPTS_N1 N1 ON N1.idNPTN1 =N2.idNPTN1 WHERE N1.strNombre<>'NORMAL'"))
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(CmdN1.SelectedValue)
    End Sub
End Class
