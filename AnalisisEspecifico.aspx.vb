﻿Imports System.Data
Imports DotNet.Highcharts
Imports DotNet.Highcharts.Options
Imports DotNet.Highcharts.Helpers

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim selecciones(4) As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            inicializar()
            llenar("")
            Me.Cache("Selecciones") = selecciones
            MyAccordion.SelectedIndex = -1
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
    Sub inicializar()
        If Me.Cache("myTestCache") Is Nothing Then
            Me.Cache.Insert("myTestCache", Generic("SELECT " & _
                "P.idPozo ,P.strNombre as NPozo ,CI.idTipo ,CI.strNombre AS NIntervencion ,I.idIntervencion ,PE.intCon ,PE.dateOperacion ,PE.intProf ,PE.strResumen" & _
                ",PE.floatTiempo ,PE.strDetalle ,TR.idCatTr ,TR.strNombre AS Tr ,CE.idEtapa ,CE.strNombre AS Etapa ,N4.idNPTN4 ,N4.strNombre AS N4 ,N3.idNPTN3 ,N3.strNombre AS N3" & _
                ",N2.idNPTN2 ,N2.strNombre AS N2 ,N1.idNPTN1 ,N1.strNombre AS N1 ,PL.strNombre AS Plata ,CEQ.strNombre AS Equ ,CO.strNombre AS COMP ,I.anio " & _
            "FROM POZO P INNER JOIN INTERVENCION I ON I.idPozo=P.idPozo " & _
            "INNER JOIN CAT_INTERVENCION CI ON CI.idTipo=I.idTipo " & _
            "INNER JOIN CAT_PLATAFORMA PL ON PL.idPlataforma=I.idPlataforma " & _
            "INNER JOIN CAT_EQUIPO CEQ ON CEQ.idEquipo=I.idEquipo " & _
            "INNER JOIN CAT_COMPANIA CO ON CO.idCatCompania=CEQ.idCatCompania " & _
            "INNER JOIN PERFORACION PE ON PE.idIntervencion=I.idIntervencion " & _
            "INNER JOIN CAT_TR TR ON TR.idCatTr=PE.idCatTr " & _
            "INNER JOIN CAT_ETAPA CE ON CE.idEtapa=PE.idEtapa " & _
            "INNER JOIN NPT_INTERVENCION NP ON NP.idNptIntervencion=PE.idNptIntervencion " & _
            "INNER JOIN CAT_NPTS_N4 N4 ON N4.idNPTN4=NP.idNPTN4 " & _
            "INNER JOIN CAT_NPTS_N3 N3 ON N3.idNPTN3=N4.idNPTN3 " & _
            "INNER JOIN CAT_NPTS_N2 N2 ON N2.idNPTN2=N3.idNPTN2 " & _
            "INNER JOIN CAT_NPTS_N1 N1 ON N1.idNPTN1=N2.idNPTN1 " & _
             "UNION ALL " & _
            "SELECT " & _
             "P.idPozo ,P.strNombre as NPozo ,CI.idTipo ,CI.strNombre AS NIntervencion ,I.idIntervencion ,TE.intCon ,TE.dateOperacion ,TE.intProf ,TE.strResumen " & _
             ",TE.floatTiempo ,TE.strDetalle ,TR.idCatTr ,TR.strNombre AS Tr ,CE.idEtapa ,CE.strNombre AS Etapa ,N4.idNPTN4 ,N4.strNombre AS N4 ,N3.idNPTN3 ,N3.strNombre AS N3 " & _
             ",N2.idNPTN2 ,N2.strNombre AS N2 ,N1.idNPTN1 ,N1.strNombre AS N1 ,PL.strNombre AS Plata ,CEQ.strNombre AS Equ ,CO.strNombre AS COMP ,I.anio " & _
            " FROM POZO P INNER JOIN INTERVENCION I ON I.idPozo=P.idPozo " & _
            "INNER JOIN CAT_INTERVENCION CI ON CI.idTipo=I.idTipo " & _
            "INNER JOIN CAT_PLATAFORMA PL ON PL.idPlataforma=I.idPlataforma " & _
            "INNER JOIN CAT_EQUIPO CEQ ON CEQ.idEquipo=I.idEquipo " & _
            "INNER JOIN CAT_COMPANIA CO ON CO.idCatCompania=CEQ.idCatCompania " & _
            "INNER JOIN TERMINACION TE ON TE.idIntervencion=I.idIntervencion " & _
            "INNER JOIN CAT_TR TR ON TR.idCatTr=TE.idCatTr " & _
            "INNER JOIN CAT_ETAPA CE ON CE.idEtapa=TE.idEtapa " & _
            "INNER JOIN NPT_INTERVENCION NP ON NP.idNptIntervencion=TE.idNptIntervencion " & _
            "INNER JOIN CAT_NPTS_N4 N4 ON N4.idNPTN4=NP.idNPTN4 " & _
            "INNER JOIN CAT_NPTS_N3 N3 ON N3.idNPTN3=N4.idNPTN3 " & _
            "INNER JOIN CAT_NPTS_N2 N2 ON N2.idNPTN2=N3.idNPTN2 " & _
            "INNER JOIN CAT_NPTS_N1 N1 ON N1.idNPTN1=N2.idNPTN1 " & _
            "UNION ALL " & _
            "SELECT " & _
             "P.idPozo ,P.strNombre as NPozo ,CI.idTipo ,CI.strNombre AS NIntervencion ,I.idIntervencion ,R.intCon ,R.dateOperacion ,R.intProf ,R.strResumen ,R.floatTiempo " & _
             ",R.strDetalle ,TR.idCatTr ,TR.strNombre AS Tr ,CE.idEtapa ,CE.strNombre AS Etapa ,N4.idNPTN4 ,N4.strNombre AS N4 ,N3.idNPTN3 ,N3.strNombre AS N3 " & _
             ",N2.idNPTN2 ,N2.strNombre AS N2 ,N1.idNPTN1 ,N1.strNombre AS N1,PL.strNombre AS Plata ,CEQ.strNombre AS Equ ,CO.strNombre AS COMP ,I.anio " & _
            "FROM POZO P INNER JOIN INTERVENCION I ON I.idPozo=P.idPozo " & _
            "INNER JOIN CAT_INTERVENCION CI ON CI.idTipo=I.idTipo " & _
            "INNER JOIN CAT_PLATAFORMA PL ON PL.idPlataforma=I.idPlataforma " & _
            "INNER JOIN CAT_EQUIPO CEQ ON CEQ.idEquipo=I.idEquipo " & _
            "INNER JOIN CAT_COMPANIA CO ON CO.idCatCompania=CEQ.idCatCompania " & _
            "INNER JOIN RMA R ON R.idIntervencion=I.idIntervencion " & _
            "INNER JOIN CAT_TR TR ON TR.idCatTr=R.idCatTr " & _
            "INNER JOIN CAT_ETAPA CE ON CE.idEtapa=R.idEtapa " & _
            "INNER JOIN NPT_INTERVENCION NP ON NP.idNptIntervencion=R.idNptIntervencion " & _
            "INNER JOIN CAT_NPTS_N4 N4 ON N4.idNPTN4=NP.idNPTN4 " & _
            "INNER JOIN CAT_NPTS_N3 N3 ON N3.idNPTN3=N4.idNPTN3 " & _
            "INNER JOIN CAT_NPTS_N2 N2 ON N2.idNPTN2=N3.idNPTN2 " & _
            "INNER JOIN CAT_NPTS_N1 N1 ON N1.idNPTN1=N2.idNPTN1 "))
        End If
    End Sub
    Sub llenar(ByVal busqueda As String) 'LISTA
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        HiddenField1.Value = busqueda
        If busqueda <> "" Then

            Dim newBusqueda As New StringBuilder
            selecciones = Me.Cache("Selecciones")
            For i As Integer = 0 To selecciones.Length - 1
                If selecciones(i) <> "" Then
                    newBusqueda.Append(selecciones(i)).Append("AND ")
                End If
            Next
            Dim dsAux As New DataSet
            dsAux.Merge(ds.Tables(0).Select(newBusqueda.ToString.Substring(0, newBusqueda.Length - 4)))
            ds = dsAux

        End If
        '' LLenar Grid
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

        LbPozo.DataSource = (From Pozo In ds.Tables(0) _
                            Select Pozo.Field(Of String)("NPozo")).Distinct()
        LbPozo.DataBind()

        LbN1.DataSource = (From N1 In ds.Tables(0) _
                                    Order By N1("N1") Ascending _
                                    Select N1.Field(Of String)("N1")).Distinct
        LbN1.DataBind()

        LbN2.DataSource = (From N2 In ds.Tables(0) _
                                Order By N2("N2") Ascending _
                                Select N2.Field(Of String)("N2")).Distinct
        LbN2.DataBind()

        LbN3.DataSource = (From N3 In ds.Tables(0) _
                                Order By N3("N3") Ascending _
                                Select N3.Field(Of String)("N3")).Distinct
        LbN3.DataBind()

        LbN4.DataSource = (From N4 In ds.Tables(0) _
                                Order By N4("N4") Ascending _
                                Select N4.Field(Of String)("N4")).Distinct
        LbN4.DataBind()
        Me.Cache("actual") = ds
        LlenarGraficas("N1", 1, ds)

    End Sub

    Sub LlenarGraficas(ByVal nivel As String, ByVal bandera As Integer, ByVal dsAux As DataSet) ' Grficas

        'Dim lista = From N1 In dsAux.Tables(0) _
        '                        Where N1(nivel) <> "NORMAL" _
        '                            Group N1 By lol = N1(nivel)
        '                            Into Group _
        '                        Select New With {
        '                                .N1 = lol,
        '                                .dias = Group.Sum(Function(x) x.Field(Of Double)("floatTiempo") / 24)}

        'Dim tamano As Integer = lista.Count
        'Dim listaNiveles(tamano) As String
        'Dim listaDias(tamano) As Double
        'For i As Integer = 0 To tamano - 1
        '    listaNiveles(i) = lista(i).N1
        '    listaDias(i) = lista(i).dias.ToString("0.00")
        'Next

        'Chart1.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie

        'Chart1.Series("Series1").Points.DataBindXY(listaNiveles, listaDias)
        'Me.Chart1.Legends(0).Alignment = Drawing.StringAlignment.Near



        Dim lista = From N1 In dsAux.Tables(0) _
                               Where N1(nivel) <> "NORMAL" _
                                   Group N1 By nv = N1(nivel)
                                   Into Group _
                               Select New With {
                                       .N1 = nv,
                                       .dias = Group.Sum(Function(x) x.Field(Of Double)("floatTiempo") / 24)}

        Dim tamano As Integer = lista.Count



        ' Grafica de pastel
        Dim plotOption As New PlotOptions
        plotOption.Pie() = New PlotOptionsPie()
        plotOption.Pie.AllowPointSelect = True
        plotOption.Pie.Cursor = Enums.Cursors.Pointer
        plotOption.Pie.DataLabels = New PlotOptionsPieDataLabels
        plotOption.Pie.DataLabels.Enabled = True
        plotOption.Pie.ShowInLegend = True
        plotOption.Pie.DataLabels.Format = "<b>{point.name}</b>: {point.percentage:.1f} %"

        Dim pieChart As New DotNet.Highcharts.Highcharts("chart2") ' es muy importante el nombre
        Dim titulo As New Title()
        titulo.Text = nivel
        pieChart.SetTitle(titulo)
        Dim seriesPie As New Series()


        Dim valor(tamano - 1) As Object
        For i As Integer = 0 To tamano - 1
            valor(i) = {lista(i).N1, lista(i).dias.ToString("0.00")}
        Next

        Dim datasPie As New Data(valor)
        Dim serieColors As New GlobalOptions
        seriesPie.Name = "Npts"
        seriesPie.Data = datasPie
        seriesPie.Type = Enums.ChartTypes.Pie
        pieChart.SetPlotOptions(plotOption)
        pieChart.SetSeries(seriesPie)
        ltrPieChart.Text = pieChart.ToHtmlString()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        LlenarGraficas("N1", 0, Me.Cache("actual"))
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        LlenarGraficas("N2", 0, Me.Cache("actual"))
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        LlenarGraficas("N3", 0, Me.Cache("actual"))
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        LlenarGraficas("N4", 0, Me.Cache("actual"))
    End Sub
    Function validarDs(ds As DataSet, mensaje As String) As Boolean
        If ds.Tables.Count = 0 Then
            LblMsg.Text = "* No se encontró " & mensaje
            Return False
        End If
        LblMsg.Text = ""
        Return True
    End Function
    Public Sub manejadorLista(ByVal textBox As String, ByVal lista As ListBox, ByVal campoBuscar As String)
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        lista.Items.Remove(0)
        Dim ds3 As New DataSet
        Dim msg As String = textBox & "en la lista "
        ds3.Merge(ds.Tables(0).Select(campoBuscar & " LIKE '%" & textBox & "%'"))
        If validarDs(ds3, msg) Then
            lista.Items.Clear()
            lista.DataSource = (From Pozo In ds3.Tables(0) _
                                Select Pozo.Field(Of String)(campoBuscar)).Distinct()
            lista.DataBind()
        End If

    End Sub
    Protected Sub TxtPozos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPozos.TextChanged
        manejadorLista(TxtPozos.Text, LbPozo, "Npozo")
    End Sub


    Protected Sub TxtN1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtN1.TextChanged
        manejadorLista(TxtN1.Text, LbN1, "N1")
    End Sub

    Protected Sub TxtN2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtN2.TextChanged
        manejadorLista(TxtN2.Text, LbN2, "N2")
    End Sub

    Protected Sub TxtN3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtN3.TextChanged
        manejadorLista(TxtN3.Text, LbN3, "N3")
    End Sub

    Protected Sub TxtN4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtN4.TextChanged
        manejadorLista(TxtN4.Text, LbN4, "N4")
    End Sub

    Public Function obtenerSeleccionados(ByVal lista As ListBox, ByVal campoBusqueda As String, ByVal posicion As Integer) As String
        Dim ultimo As Integer = lista.GetSelectedIndices.Count
        Dim aux As Integer = 0
        Dim busqueda As New StringBuilder

        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        'Chart1.ChartAreas(0).AxisX.Title = "Días"
        'Chart1.ChartAreas(0).AxisY.Title = "Profundidad"

        Dim muestaBusqueda As New StringBuilder

        Select Case posicion
            Case 0
                muestaBusqueda.Append("Pozo= ")
            Case 1
                muestaBusqueda.Append("Nivel 1= ")
            Case 2
                muestaBusqueda.Append("Nivel 2= ")
            Case 3
                muestaBusqueda.Append("Nivel 3= ")
            Case 4
                muestaBusqueda.Append("Nivel 4= ")
        End Select


        busqueda.Append(campoBusqueda).Append(" IN('")
        For i As Integer = 0 To lista.Items.Count
            If lista.Items(i).Selected Then
                'busqueda.Append(campoBusqueda).Append("='").Append(lista.Items(i).ToString).Append("',")
                busqueda.Append(lista.Items(i).ToString).Append("','")
                muestaBusqueda.Append(lista.Items(i).ToString).Append(", ")
                aux = aux + 1
                If aux = ultimo Then
                    Exit For
                End If
            End If
        Next

        LbSelecciones.Items.Add(muestaBusqueda.ToString().Substring(0, muestaBusqueda.Length - 2))
        LbSelecciones.Items.Item(LbSelecciones.Items.Count - 1).Value = posicion


        selecciones = Me.Cache("Selecciones")
        selecciones(posicion) = busqueda.ToString.Substring(0, busqueda.Length - 2) & ")"
        Me.Cache("Selecciones") = selecciones
        mostrar()
        Return busqueda.ToString.Substring(0, busqueda.Length - 2) & ")"
    End Function

    Protected Sub LbPozo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbPozo.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbPozo, "NPozo", 0))
    End Sub

    Protected Sub LbN1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbN1.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbN1, "N1", 1))
    End Sub

    Protected Sub LbN2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbN2.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbN2, "N2", 2))
    End Sub

    Protected Sub LbN3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbN3.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbN3, "N3", 3))
    End Sub

    Protected Sub LbN4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbN4.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbN4, "N4", 4))
    End Sub

    Sub mostrar()
        Button5.Visible = True
        Label6.Visible = True
        LbSelecciones.Visible = True
    End Sub
    Sub ocultar()
        Button5.Visible = False
        Label6.Visible = False
        LbSelecciones.Visible = False
    End Sub
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        If LbSelecciones.Items.Count > 1 Then
            selecciones = Me.Cache("Selecciones")
            selecciones(LbSelecciones.Items.Item(LbSelecciones.Items.Count - 1).Value) = ""
            Me.Cache("Selecciones") = selecciones
            LbSelecciones.Items.Remove(LbSelecciones.Items(LbSelecciones.Items.Count - 1))
            llenar("busca")
        Else
            Me.Cache.Remove("Selecciones")
            Me.Cache("Selecciones") = selecciones
            LbSelecciones.Items.Clear()
            llenar("")
            ocultar()
        End If
    End Sub

    Dim bandera As Boolean = True
    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If bandera Then
            Dim sw As New System.IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)


            Dim ds As New DataSet
            ds = Me.Cache("myTestCache")

            If LbSelecciones.Items.Count <> 0 Then
                selecciones = Me.Cache("Selecciones")
                Dim newBusqueda As New StringBuilder
                For i As Integer = 0 To selecciones.Length - 1
                    If selecciones(i) <> "" Then
                        newBusqueda.Append(selecciones(i)).Append("AND ")
                    End If
                Next
                Dim dsAux As New DataSet
                'dsAux.Merge(ds.Tables(0).Select(busqueda))
                dsAux.Merge(ds.Tables(0).Select(newBusqueda.ToString.Substring(0, newBusqueda.Length - 4)))
                ds = dsAux
            End If

            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/ms-excel"
            Response.AddHeader("content-Disposition", "attachment;filename=Example.xls")



            GridView1.EnableViewState = False
            GridView1.AllowPaging = False
            '' LLenar Grid
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()

            GridView1.RenderControl(htw)
            Response.Charset = "UTF-8"
            Response.ContentEncoding = Encoding.Default


            Response.Write(sw.ToString)
            Response.End()


            'inicializar()
            'llenar("")
            ''llenaGrid()
            'Me.Cache("Selecciones") = selecciones
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        llenar(HiddenField1.Value)
    End Sub

    Protected Sub LbSelecciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LbSelecciones.SelectedIndexChanged
        If LbSelecciones.Items.Count > 1 Then
            For i As Integer = 0 To LbSelecciones.Items.Count - 1
                If LbSelecciones.Items(i).Selected Then
                    selecciones = Me.Cache("Selecciones")
                    selecciones(LbSelecciones.Items.Item(i).Value) = ""
                    Me.Cache("Selecciones") = selecciones
                    LbSelecciones.Items.Remove(LbSelecciones.Items(i))
                    llenar("busca")
                    Exit For
                End If
            Next
        Else
            Me.Cache.Remove("Selecciones")
            Me.Cache("Selecciones") = selecciones
            LbSelecciones.Items.Clear()
            ocultar()
            llenar("")
        End If
    End Sub
End Class
