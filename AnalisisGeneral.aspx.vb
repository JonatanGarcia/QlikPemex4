﻿Imports System.Data
Imports System.Drawing
Imports DotNet.Highcharts
Imports DotNet.Highcharts.Options
Imports DotNet.Highcharts.Helpers

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim selecciones(4) As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            inicializar()
            'llenar("", 0)
            msg.Visible = False
            MyAccordion.SelectedIndex = -1
            Me.Cache("Selecciones") = selecciones
            Dim ds As New DataSet
            ds = Me.Cache("myTestCache")
            LbAnio.DataSource = (From Plataforma In ds.Tables(0) _
                             Order By Plataforma("anio") Ascending _
                                Select Plataforma.Field(Of Integer)("anio")).Distinct
            LbAnio.DataBind()
            LbAnio.SelectedIndex = 4
            llenar(obtenerSeleccionados(LbAnio, "anio", 0), 1)
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


    Sub llenaGrid()
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        Dim ds3 As New DataSet
        'ds3.Merge(ds.Tables(0).Select("idPozo=1 AND idTipo=1", "intCon ASC"))  'EL SEGUNDO PARAMETRO ES ORDER BY


        Dim x1 As Double() = {0, 1, 2, 3, 4, 5, 6, 7}
        Dim y1 As Double() = {0, 200, 500, 500, 900, 980, 1500, 2000}

        Dim x2 As Double() = {0, 1, 2, 3, 4, 5, 6, 7}
        Dim y2 As Double() = {0, 240, 240, 240, 900, 980, 1640, 1980}





        '' Grafica de avance
        'Chart1.Series.Add("Ku-84")

        'Chart1.ChartAreas(0).AxisX.Title = "Días"
        'Chart1.ChartAreas(0).AxisY.Title = "Profundidad"

        'Chart1.Series("Ku-84").ChartType = DataVisualization.Charting.SeriesChartType.Line
        'Chart1.Series("Ku-84").BorderWidth = 3
        'Chart1.Series("Ku-84").Points.DataBindXY(x1, y1)
        'Chart1.Legends.Add("Legends1")

        'Chart1.Series.Add("Maloob - 51")
        'Chart1.Series("Maloob - 51").ChartType = DataVisualization.Charting.SeriesChartType.Line
        'Chart1.Series("Maloob - 51").BorderWidth = 3
        'Chart1.Series("Maloob - 51").Points.DataBindXY(x2, y2)



    End Sub

    Sub mostrar()
        Label1.Visible = True
        LbSelecciones.Visible = True
        Button2.Visible = True
        Button3.Visible = True
    End Sub
    Sub ocultar()
        Label1.Visible = False
        LbSelecciones.Visible = False
        Button2.Visible = False
        Button3.Visible = False
    End Sub
    Sub llenar(ByVal busqueda As String, ByVal bandera As Integer)


        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")

        HiddenField1.Value = busqueda
        If busqueda <> "" Then
            mostrar()
            Dim newBusqueda As New StringBuilder
            selecciones = Me.Cache("Selecciones")
            For i As Integer = 0 To selecciones.Length - 1
                If selecciones(i) <> "" Then
                    newBusqueda.Append(selecciones(i)).Append("AND ")
                End If
            Next
            Dim dsAux As New DataSet
            'dsAux.Merge(ds.Tables(0).Select(busqueda))
            dsAux.Merge(ds.Tables(0).Select(newBusqueda.ToString.Substring(0, newBusqueda.Length - 4)))
            ds = dsAux


            'WHERE IN
            'Dim ids As Integer() = {1, 2}

            'Dim a = ((From Plataforma In ds.Tables(0) _
            '         Where ids.Contains(Plataforma("idPozo")) And Plataforma("Nintervencion") = "PERFORACIÓN" _
            '                       Select Plataforma.Field(Of Double)("floatTiempo")).Sum) / 24
        End If

        '' LLenar Grid
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()


        '' LLENAR LISTAS
        'ds3.Merge(ds.Tables(0).Select("idPozo in (1,2)")) '"Nombre LIKE 'L%'            
        LbPozo.DataSource = (From Pozo In ds.Tables(0) _
                            Select Pozo.Field(Of String)("NPozo")).Distinct()
        LbPozo.DataBind()

        LbIntervencion.DataSource = (From Intervencion In ds.Tables(0) _
                                     Select Intervencion.Field(Of String)("Nintervencion")).Distinct
        LbIntervencion.DataBind()

        LbPlataforma.DataSource = (From Plataforma In ds.Tables(0) _
                                Select Plataforma.Field(Of String)("Plata")).Distinct
        LbPlataforma.DataBind()

        LbEquipo.DataSource = (From Plataforma In ds.Tables(0) _
                                Select Plataforma.Field(Of String)("Equ")).Distinct
        LbEquipo.DataBind()

        LbAnio.DataSource = (From Plataforma In ds.Tables(0) _
                             Order By Plataforma("anio") Ascending _
                                Select Plataforma.Field(Of Integer)("anio")).Distinct
        LbAnio.DataBind()


        '''' LLENAR LABEL's de dias
        LbldiasPerfora.Text = (((From PER In ds.Tables(0) _
                               Where PER("Nintervencion") = "PERFORACIÓN" _
                             Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        LblDiasTerm.Text = (((From PER In ds.Tables(0) _
                               Where PER("Nintervencion") = "TERMINACIÓN" _
                             Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        LblDiasRMA.Text = (((From PER In ds.Tables(0) _
                               Where PER("Nintervencion") = "REPARACIÓN MAYOR" _
                             Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        LblDiasNPTS.Text = (((From PER In ds.Tables(0) _
                               Where PER("N1") <> "NORMAL" _
                             Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        LblCO.Text = (((From PER In ds.Tables(0) _
                              Where PER("N1") = "NORMAL" _
                            Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        LblPozos.Text = LbPozo.Items.Count
        '''' LLENAR LABEL's de dias




        ' Grafica de avance
        Dim titulo As New Title()
        ' If bandera = 1 Then
        titulo.Text = "Grafica de Avance"
        Dim ds3 As New DataSet
        Dim progressChart As New DotNet.Highcharts.Highcharts("chart")
        progressChart.SetTitle(titulo)


        Dim plot As New PlotOptions
        plot.Series = New PlotOptionsSeries
        plot.Series.Marker = New PlotOptionsSeriesMarker
        plot.Series.Marker.Enabled = False

        Dim ay As YAxis
        ay = New YAxis
        ay.Labels = New YAxisLabels
        ay.Title = New YAxisTitle()
        ay.Title.Text = "Profundidad"
        ay.TickInterval = 500


        ay.Labels.Format = "{value:.,of}"


        Dim ll As Integer = 0
        Dim series(LbPozo.Items.Count - 1) As Series
        'Dim ax(LbPozo.Items.Count - 1) As XAxis

        Dim tamPozo As Integer = LbPozo.Items.Count - 1

        For i As Integer = 0 To tamPozo
            ds3.Merge(ds.Tables(0).Select("NPozo LIKE '%" & LbPozo.Items(i).ToString & "%'"))

            Dim b = (From Pozo In ds3.Tables(0) _
                      Order By Pozo("intCon") Ascending _
                              Select New With {
                                   .con = Pozo.Field(Of Object)("intCon"),
                                   .prof = Pozo.Field(Of Object)("intProf") * -1}).ToArray

            Dim tam As Integer = b.Count - 1

            Dim das(tam) As Object

            For f As Integer = 0 To tam
                das(f) = New Object
                das(f) = {b(f).con, b(f).prof}
            Next
            Dim datas As New Data(das)

            series(i) = New Series
            series(i).Data = datas
            Dim rand As New Random


            series(i).Color = Color.FromArgb(rand.Next(255), rand.Next(155), rand.Next(255))
            series(i).Name = LbPozo.Items(i).ToString()
            ds3.Clear()
        Next

        Dim ax As New XAxis
        ax.Title = New XAxisTitle
        ax.Title.Text = "Días"
        ax.TickInterval = 10

        progressChart.SetPlotOptions(plot)
        progressChart.SetYAxis(ay)
        progressChart.SetXAxis(ax)

        'progressChart.SetXAxis(ax)
        progressChart.SetSeries(series)

        ltrLine.Text = progressChart.ToHtmlString()
        'Else
        'ltrLine.Text = ""
        'End If



        '' ANTERIOR
        'If bandera = 1 Then
        '    Dim ds3 As New DataSet
        '    For i As Integer = 0 To LbPozo.Items.Count - 1
        '        ds3.Merge(ds.Tables(0).Select("NPozo LIKE '%" & LbPozo.Items(i).ToString & "%'"))
        '        Chart1.Series.Add(LbPozo.Items(i).ToString())
        '        Chart1.Series(LbPozo.Items(i).ToString()).ChartType = DataVisualization.Charting.SeriesChartType.Line
        '        Chart1.Series(LbPozo.Items(i).ToString()).BorderWidth = 3
        '        Dim a = (From Pozo In ds3.Tables(0) _
        '                    Order By Pozo("intCon") Ascending _
        '                    Select Pozo.Field(Of Integer)("intCon"))
        '        Dim b = (From Pozo In ds3.Tables(0) _
        '                    Order By Pozo("intCon") Ascending _
        '                    Select Pozo.Field(Of Integer)("intProf"))
        '        Chart1.Series(LbPozo.Items(i).ToString()).Points.DataBindXY(a.ToList, b.ToList)

        '        ds3.Clear()

        '    Next
        '    ds3 = Nothing
        '    Chart1.Legends.Add("Legenda1")
        'End If




        'Grafica de pastel
        Dim plotOption As New PlotOptions
        plotOption.Pie() = New PlotOptionsPie()
        plotOption.Pie.AllowPointSelect = True
        plotOption.Pie.Cursor = Enums.Cursors.Pointer
        plotOption.Pie.DataLabels = New PlotOptionsPieDataLabels
        plotOption.Pie.DataLabels.Enabled = True
        plotOption.Pie.ShowInLegend = True
        plotOption.Pie.DataLabels.Format = "<b>{point.name}</b>: {point.percentage:.1f} %"

        titulo.Text = "Distribución Npts"
        Dim pieChart As New DotNet.Highcharts.Highcharts("chart2") ' es muy importante el nombre
        pieChart.SetTitle(titulo)
        Dim seriesPie As New Series()
        Dim esperas As Double = (((From PER In ds.Tables(0) _
                              Where PER("N1") = "ESPERAS" _
                            Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        Dim po As Double = (((From PER In ds.Tables(0) _
                              Where PER("N1") = "PROBLEMAS OPERATIVOS" _
                            Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        Dim datasPie As New Data(New Object() {New Object() {"Normal", LblCO.Text}, New Object() {"Esperas", esperas}, New Object() {"PO", po}})


        Dim serieColors As New GlobalOptions
        serieColors.Colors = {Color.FromArgb(43, 143, 243), Color.FromArgb(117, 111, 111), Color.FromArgb(250, 104, 7)}
        pieChart.SetOptions(serieColors)

        seriesPie.Name = "Npts"
        seriesPie.Data = datasPie
        seriesPie.Type = Enums.ChartTypes.Pie
        pieChart.SetPlotOptions(plotOption)
        pieChart.SetSeries(seriesPie)
        ltrPieChart.Text = pieChart.ToHtmlString()


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        LbPozo.ClearSelection()
        LbEquipo.ClearSelection()
        LbPlataforma.ClearSelection()
        LbIntervencion.ClearSelection()
        LbAnio.ClearSelection()
        LbSelecciones.Items.Clear()
        HiddenField1.Value = ""
        ocultar()
        Me.Cache.Remove("Selecciones")
        Me.Cache("Selecciones") = selecciones
        llenar("", 0)
    End Sub

    Function validarDs(ds As DataSet, mensaje As String) As Boolean
        If ds.Tables.Count = 0 Then
            LblMsg.Text = " No se encontró " & mensaje
            msg.Visible = True
            Return False
        End If
        msg.Visible = False
        LblMsg.Text = ""
        Return True
    End Function

    Protected Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim msg As String = TextBox2.Text & " en la lista Pozo"
        Dim ds3 As New DataSet
        ds3.Merge(ds.Tables(0).Select("NPozo LIKE '%" & TextBox2.Text & "%'"))
        If validarDs(ds3, msg) Then
            LbPozo.Items.Clear()
            LbPozo.DataSource = (From Pozo In ds3.Tables(0) _
                                Select Pozo.Field(Of String)("NPozo") Order By ("NPozo")).Distinct()
            LbPozo.DataBind()
        End If
        bandera = False
    End Sub

    Protected Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim ds3 As New DataSet
        Dim msg As String = TextBox3.Text & " en la lista Equipo"
        ds3.Merge(ds.Tables(0).Select("Equ LIKE '%" & TextBox3.Text & "%'"))
        If validarDs(ds3, msg) Then
            LbEquipo.Items.Clear()
            LbEquipo.DataSource = (From Pozo In ds3.Tables(0) _
                                Select Pozo.Field(Of String)("Equ") Order By ("Equ")).Distinct()
            LbEquipo.DataBind()
        End If
        bandera = False
    End Sub
    Protected Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim ds3 As New DataSet
        Dim msg As String = TextBox4.Text & " en la lista Plataforma"
        ds3.Merge(ds.Tables(0).Select("plata LIKE '%" & TextBox4.Text & "%'"))
        If validarDs(ds3, msg) Then
            LbPlataforma.Items.Clear()
            LbPlataforma.DataSource = (From Pozo In ds3.Tables(0) _
                                Select Pozo.Field(Of String)("plata") Order By ("plata")).Distinct()
            LbPlataforma.DataBind()
        End If
        bandera = False
    End Sub


    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        llenar(HiddenField1.Value, 1)
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
                muestaBusqueda.Append("Año= ")
            Case 1
                muestaBusqueda.Append("Intervencion= ")
            Case 2
                muestaBusqueda.Append("Pozo= ")
            Case 3
                muestaBusqueda.Append("Plataforma= ")
            Case 4
                muestaBusqueda.Append("Equipo= ")
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

        Return busqueda.ToString.Substring(0, busqueda.Length - 2) & ")"
    End Function

    Protected Sub LbPozo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbPozo.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbPozo, "Npozo", 2), 1)
    End Sub

    Protected Sub LbIntervencion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbIntervencion.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbIntervencion, "Nintervencion", 1), 1)
    End Sub

    Protected Sub LbPlataforma_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbPlataforma.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbPlataforma, "plata", 3), 1)
    End Sub

    Protected Sub LbEquipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbEquipo.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbEquipo, "equ", 4), 1)
    End Sub

    Protected Sub LbAnio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbAnio.SelectedIndexChanged
        llenar(obtenerSeleccionados(LbAnio, "anio", 0), 1)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If LbSelecciones.Items.Count > 1 Then
            selecciones = Me.Cache("Selecciones")
            selecciones(LbSelecciones.Items.Item(LbSelecciones.Items.Count - 1).Value) = ""
            Me.Cache("Selecciones") = selecciones
            LbSelecciones.Items.Remove(LbSelecciones.Items(LbSelecciones.Items.Count - 1))
            llenar("busca", 1)
        Else
            Me.Cache.Remove("Selecciones")
            Me.Cache("Selecciones") = selecciones
            LbSelecciones.Items.Clear()
            ocultar()
            llenar("", 0)
        End If

    End Sub

    Protected Sub LbSelecciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbSelecciones.SelectedIndexChanged
        If LbSelecciones.Items.Count > 1 Then
            For i As Integer = 0 To LbSelecciones.Items.Count - 1
                If LbSelecciones.Items(i).Selected Then
                    selecciones = Me.Cache("Selecciones")
                    selecciones(LbSelecciones.Items.Item(i).Value) = ""
                    Me.Cache("Selecciones") = selecciones
                    LbSelecciones.Items.Remove(LbSelecciones.Items(i))
                    llenar("busca", 1)
                    Exit For
                End If
            Next
        Else
            Me.Cache.Remove("Selecciones")
            Me.Cache("Selecciones") = selecciones
            LbSelecciones.Items.Clear()
            ocultar()
            llenar("", 0)
        End If

        'LbSelecciones.Items.Remove(LbSelecciones.SelectedItem)
        ' End If
    End Sub

    Dim bandera As Boolean = True
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
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
            'llenar("", 0)
            ''llenaGrid()
            'Me.Cache("Selecciones") = selecciones
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub
End Class
