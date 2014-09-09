Imports System.Data
Partial Class Default3
    Inherits System.Web.UI.Page

   
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            inicializar()
            llenar()
        End If
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
    Function armaBusqueda() As String
        Dim cadena As New StringBuilder
        ' CrystalReportViewer1.SelectionFormula = "{comando.dateOperacion}>=DateTime(2014,01,01) AND {comando.dateOperacion}<=DateTime(2014,01,07)"        
        ' CrystalReportViewer1.SelectionFormula = "{comando.dateOperacion}>=DateTime(2014,01,01) AND {comando.NIntervencion} in ['PERFORACIÓN','TERMINACIÓN','REPARACIÓN MAYOR']"
        CrystalReportViewer1.RefreshReport()
        If cadena.ToString() = "" Then
            Return ""
        End If
        If TxtFechaInicial.Text <> "" Then
            cadena.Append("{comando.dateOperacion}>=DateTime(").Append(TxtFechaInicial.Text.Replace("-", ",")).Append(") AND ")
        End If
        If TxtFechaFinal.Text <> "" Then
            cadena.Append("{comando.dateOperacion}<=DateTime(").Append(TxtFechaFinal.Text.Replace("-", ",")).Append(") AND ")
        End If
        If LbIntervencionFinal.Items.Count > 0 Then
            Dim cadenaInter As New StringBuilder
            cadenaInter.Append("{comando.NIntervencion} in [")
            For i As Integer = 0 To LbIntervencionFinal.Items.Count - 1
                cadenaInter.Append("'").Append(LbIntervencionFinal.Items(i).Text).Append("',")
            Next

            cadena.Append(cadenaInter.ToString().Substring(0, cadenaInter.Length - 1)).Append("] AND ")
        End If
        Return cadena.ToString.Substring(0, cadena.ToString.Length - 4)
    End Function
    Sub inicializar()
        If Me.Cache("reportePozo") Is Nothing Then
            Me.Cache.Insert("reportePozo", Generic("SELECT " & _
                "CI.strNombre AS NIntervencion " & _
            "FROM  CAT_INTERVENCION CI "))
        End If
    End Sub
    Sub llenar()
        Dim ds As New DataSet
        ds = Me.Cache("reportePozo")
        LbIntervencion.DataSource = (From Intervencion In ds.Tables(0) _
                                     Select Intervencion.Field(Of String)("Nintervencion"))
        LbIntervencion.DataBind()
    End Sub
    Sub movimientos(ByVal lista1 As ListBox, ByVal lista2 As ListBox) ', posicion As Integer, campoBusqueda As String)
        Dim seleccion As Integer
        seleccion = lista1.GetSelectedIndices.Count
        Dim aux As Integer = 0
        Dim index As New List(Of ListItem)
        For i As Integer = 0 To lista1.Items.Count - 1            
            If lista1.Items(i).Selected Then
                lista2.Items.Add(lista1.Items(i).Text)
                lista2.Items(lista2.Items.Count - 1).Value = lista1.Items(i).Value
                index.Add(lista1.Items(i))
                aux = aux + 1
                If aux = seleccion Then
                    Exit For
                End If
            End If
        Next
        For i As Integer = 0 To index.Count - 1
            lista1.Items.Remove(index(i))   'poner la lista de items
        Next
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        movimientos(LbIntervencion, LbIntervencionFinal)
    End Sub
    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        movimientos(LbIntervencionFinal, LbIntervencion)
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        CrystalReportViewer1.SelectionFormula = armaBusqueda()
        'CrystalReportViewer1.SelectionFormula = ""
    End Sub
End Class
