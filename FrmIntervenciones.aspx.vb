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
        txtAnio.Text = Now.Year
        Dim ds As New DataSet
        ds = Me.Cache("intervencion")


        'LbIntervencion.DataSource = ds.Tables(0)
        'LbIntervencion.DataTextField = "strNombre"
        'LbIntervencion.DataValueField = "idTipo"
        'LbIntervencion.DataBind()

        CmdIntervencion.DataSource = (From intervencion In ds.Tables(0) _
                            Select intervencion.Field(Of String)("Inter")).Distinct
        CmdIntervencion.DataBind()


        CmdPlataforma.DataSource = (From plataforma In ds.Tables(0) _
                            Select plataforma.Field(Of String)("plata")).Distinct
        CmdPlataforma.DataBind()

        CmdEquipo.DataSource = (From equipo In ds.Tables(0) _
                            Select equipo.Field(Of String)("equ")).Distinct
        CmdEquipo.DataBind()

        CmdSubInter.DataSource = (From subInter In ds.Tables(0) _
                            Select subInter.Field(Of String)("catSub")).Distinct
        CmdSubInter.DataBind()


        'CmdN1.DataTextField = "nivel1"
        'CmdN1.DataValueField = "id"


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
        If Me.Cache("intervencion") Is Nothing Then
            Me.Cache.Insert("intervencion", Generic("SELECT " & _
                " I.idIntervencion, CI.strNombre AS Inter, P.strNombre AS pozo, " & _
                " I.anio, CS.strNombre AS catSub, CP.strNombre as plata, CE.strNombre AS equ FROM INTERVENCION I " & _
                " INNER JOIN CAT_PLATAFORMA CP ON CP.idPlataforma=I.idPlataforma " & _
                " INNER JOIN CAT_SUB_INTERVENCION CS ON CS.idCatSubIntervencion=I.idCatSubIntervencion " & _
                " INNER JOIN CAT_EQUIPO CE ON CE.idEquipo = I.idEquipo " & _
                " INNER JOIN POZO P ON P.idPozo=I.idPozo " & _
                " INNER JOIN CAT_INTERVENCION CI ON CI.idTipo=I.idTipo"))
        End If
    End Sub


    Sub mostrarSubInter()
        LblSubInter.Visible = True
        CmdSubInter.Visible = True
    End Sub
    Sub ocultarSubInter()
        LblSubInter.Visible = False
        CmdSubInter.Visible = False
    End Sub
    Protected Sub CmdIntervencion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmdIntervencion.SelectedIndexChanged
        If CmdIntervencion.SelectedValue = "REPARACIÓN MAYOR" Then
            mostrarSubInter()
        Else
            ocultarSubInter()
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        llenar()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("LOL")
    End Sub
End Class
