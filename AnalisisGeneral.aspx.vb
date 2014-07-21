Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page


    Dim selecciones(4) As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            inicializar()
            llenar("", 0)
            'llenaGrid()
            Me.Cache("Selecciones") = selecciones
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





        ' Grafica de avance
        Chart1.Series.Add("Ku-84")

        Chart1.ChartAreas(0).AxisX.Title = "Días"
        Chart1.ChartAreas(0).AxisY.Title = "Profundidad"

        Chart1.Series("Ku-84").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("Ku-84").BorderWidth = 3
        Chart1.Series("Ku-84").Points.DataBindXY(x1, y1)
        Chart1.Legends.Add("Legends1")

        Chart1.Series.Add("Maloob - 51")
        Chart1.Series("Maloob - 51").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("Maloob - 51").BorderWidth = 3
        Chart1.Series("Maloob - 51").Points.DataBindXY(x2, y2)

       

    End Sub
    Sub llenar(ByVal busqueda As String, ByVal bandera As Integer)


        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")

        HiddenField1.Value = busqueda
        If busqueda <> "" Then

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
        If bandera = 1 Then
            Dim ds3 As New DataSet
            For i As Integer = 0 To LbPozo.Items.Count - 1
                ds3.Merge(ds.Tables(0).Select("NPozo LIKE '%" & LbPozo.Items(i).ToString & "%'"))
                Chart1.Series.Add(LbPozo.Items(i).ToString())
                Chart1.Series(LbPozo.Items(i).ToString()).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart1.Series(LbPozo.Items(i).ToString()).BorderWidth = 3
                Dim a = (From Pozo In ds3.Tables(0) _
                            Order By Pozo("intCon") Ascending _
                            Select Pozo.Field(Of Integer)("intCon"))
                Dim b = (From Pozo In ds3.Tables(0) _
                            Order By Pozo("intCon") Ascending _
                            Select Pozo.Field(Of Integer)("intProf"))
                'Dim x11 As New List(Of Integer)
                'x11 = a.ToList
                'Dim y11 As New List(Of Integer)
                'y11 = b.ToList
                Chart1.Series(LbPozo.Items(i).ToString()).Points.DataBindXY(a.ToList, b.ToList)

                ds3.Clear()

            Next
            ds3 = Nothing
            Chart1.Legends.Add("Legenda1")
        End If
       



        'Grafica de pastel
        Dim x3 As String() = {"Normal", "Esperas", "Problemas Operativos"}
        Dim y3(2) As Double
        y3(0) = CDbl(LblCO.Text)
        y3(1) = (((From PER In ds.Tables(0) _
                              Where PER("N1") = "ESPERAS" _
                            Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")
        y3(2) = (((From PER In ds.Tables(0) _
                              Where PER("N1") = "PROBLEMAS OPERATIVOS" _
                            Select PER.Field(Of Double)("floatTiempo")).Sum) / 24).ToString("00.0")

        'Chart2.Series.Add("Series1")
        Chart2.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie

        Chart2.Series("Series1").Points.DataBindXY(x3, y3)
        Me.Chart2.Legends(0).Alignment = Drawing.StringAlignment.Near

        'WHERE IN
        'Dim ids As Integer() = {1, 2}

        'Dim a = ((From Plataforma In ds.Tables(0) _
        '         Where ids.Contains(Plataforma("idPozo")) And Plataforma("Nintervencion") = "PERFORACIÓN" _
        '                       Select Plataforma.Field(Of Double)("floatTiempo")).Sum) / 24
        'MsgBox(a)
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        LbPozo.ClearSelection()
        LbEquipo.ClearSelection()
        LbPlataforma.ClearSelection()
        LbIntervencion.ClearSelection()
        LbAnio.ClearSelection()
        LbSelecciones.Items.Clear()
        HiddenField1.Value = ""

        Me.Cache.Remove("Selecciones")
        Me.Cache("Selecciones") = selecciones
        llenar("", 0)
    End Sub

    Protected Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim test As String = 2011
        Dim ds3 As New DataSet
        ds3.Merge(ds.Tables(0).Select("NPozo LIKE '%" & TextBox2.Text & "%'"))
        LbPozo.Items.Clear()
        LbPozo.DataSource = (From Pozo In ds3.Tables(0) _
                            Select Pozo.Field(Of String)("NPozo")).Distinct()
        LbPozo.DataBind()
        TextBox2.Text = ""
    End Sub

    Protected Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim ds3 As New DataSet
        ds3.Merge(ds.Tables(0).Select("Equ LIKE '%" & TextBox3.Text & "%'"))
        LbEquipo.Items.Clear()
        LbEquipo.DataSource = (From Pozo In ds3.Tables(0) _
                            Select Pozo.Field(Of String)("Equ")).Distinct()
        LbEquipo.DataBind()
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
        Chart1.ChartAreas(0).AxisX.Title = "Días"
        Chart1.ChartAreas(0).AxisY.Title = "Profundidad"

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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

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
            llenar("", 0)

        End If


        'LbSelecciones.Items.Remove(LbSelecciones.SelectedItem)
        ' End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
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

        inicializar()
        llenar("", 0)
        'llenaGrid()
        Me.Cache("Selecciones") = selecciones

    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub

    Protected Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim ds3 As New DataSet
        ds3.Merge(ds.Tables(0).Select("plata LIKE '%" & TextBox4.Text & "%'"))
        LbPlataforma.Items.Clear()
        LbPlataforma.DataSource = (From Pozo In ds3.Tables(0) _
                            Select Pozo.Field(Of String)("plata")).Distinct()
        LbPlataforma.DataBind()
    End Sub


End Class
