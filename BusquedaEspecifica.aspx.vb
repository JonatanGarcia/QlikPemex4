Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page

    Dim selecciones(4) As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            msg.Visible = False
            inicializar()
            llenar("")
            MyAccordion.SelectedIndex = -1
        End If

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        movimientos(LbInicial, LbFinal)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        movimientos(LbFinal, LbInicial)
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
            'lista1.Items.Remove(lista1.Items(index(i)))   'poner la lista de items
            lista1.Items.Remove(index(i))   'poner la lista de items
        Next
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

    Sub llenar(ByVal busqueda As String)
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
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

    End Sub
    'Public Function obtenerSeleccionados(ByVal lista As ListBox, ByVal campoBusqueda As String, ByVal posicion As Integer) As String
    '    Dim ultimo As Integer = lista.GetSelectedIndices.Count
    '    Dim aux As Integer = 0
    '    Dim busqueda As New StringBuilder

    '    Dim ds As New DataSet
    '    ds = Me.Cache("myTestCache")

    '    Dim muestaBusqueda As New StringBuilder

    '    Select Case posicion
    '        Case 0
    '            muestaBusqueda.Append("Año= ")
    '        Case 1
    '            muestaBusqueda.Append("Intervencion= ")
    '        Case 2
    '            muestaBusqueda.Append("Pozo= ")
    '        Case 3
    '            muestaBusqueda.Append("Plataforma= ")
    '        Case 4
    '            muestaBusqueda.Append("Equipo= ")
    '    End Select


    '    busqueda.Append(campoBusqueda).Append(" IN('")
    '    For i As Integer = 0 To lista.Items.Count
    '        If lista.Items(i).Selected Then
    '            'busqueda.Append(campoBusqueda).Append("='").Append(lista.Items(i).ToString).Append("',")
    '            busqueda.Append(lista.Items(i).ToString).Append("','")
    '            muestaBusqueda.Append(lista.Items(i).ToString).Append(", ")
    '            aux = aux + 1
    '            If aux = ultimo Then
    '                Exit For
    '            End If
    '        End If
    '    Next

    '    LbSelecciones.Items.Add(muestaBusqueda.ToString().Substring(0, muestaBusqueda.Length - 2))
    '    LbSelecciones.Items.Item(LbSelecciones.Items.Count - 1).Value = posicion


    '    selecciones = Me.Cache("Selecciones")
    '    selecciones(posicion) = busqueda.ToString.Substring(0, busqueda.Length - 2) & ")"
    '    Me.Cache("Selecciones") = selecciones

    '    Return busqueda.ToString.Substring(0, busqueda.Length - 2) & ")"
    'End Function
 
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        movimientos(LbAnio,LbAnioFinal)
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        movimientos(LbAnioFinal, LbAnio)
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        movimientos(LbPozo, LbPozoFinal)
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        movimientos(LbPozoFinal, LbPozo)
    End Sub

    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        movimientos(LbEquipo, LbEquipoFinal)
    End Sub

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        movimientos(LbEquipoFinal, LbEquipo)
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        movimientos(LbIntervencion, LbIntervencionFinal)
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        movimientos(LbIntervencionFinal, LbIntervencion)
    End Sub

    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        movimientos(LbPlataforma, LbPlataformaFinal)
    End Sub

    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        movimientos(LbPlataformaFinal, LbPlataforma)
    End Sub

    Public Function llenarGrid(ByVal ds As DataSet) As DataSet
      

        'Dim ds3 As New DataSet
        'ds3.Merge(ds.Tables(0).Select("idPozo=1", "intCon ASC"))

        'filtros
        'WHERE IN        

        ' Ocultar columnas
        For i As Integer = 0 To LbInicial.Items.Count - 1
            GridView1.Columns(LbInicial.Items(i).Value).Visible = False
        Next
        ' Mostrar columnas
        For i As Integer = 0 To LbFinal.Items.Count - 1
            GridView1.Columns(LbFinal.Items(i).Value).Visible = True
        Next

        If ds.Tables.Count > 0 Then
            Dim query = From datos In ds.Tables(0) _
                       Select New With { _
                           .Pozo = datos.Field(Of String)("NPozo"), _
                           .Intervencion = datos.Field(Of String)("NIntervencion"), _
                           .Consecutivo = datos.Field(Of Integer)("intCon"), _
                           .Fecha = datos.Field(Of Date)("dateOperacion"), _
                           .Profundidad = datos.Field(Of Integer)("intProf"), _
                           .resumen = datos.Field(Of String)("strResumen"), _
                           .horas = datos.Field(Of Double)("floatTiempo"), _
                           .dias = (datos.Field(Of Double)("floatTiempo")) / 24, _
                           .Detalle = datos.Field(Of String)("strDetalle"), _
                           .Diametro = datos.Field(Of String)("Tr"), _
                           .Etapa = datos.Field(Of String)("Etapa"), _
                           .Nivel4 = datos.Field(Of String)("N4"), _
                           .Nivel3 = datos.Field(Of String)("N3"), _
                           .Nivel2 = datos.Field(Of String)("N2"), _
                           .Nivel1 = datos.Field(Of String)("N1"), _
                           .Plataforma = datos.Field(Of String)("Plata"), _
                           .Equipo = datos.Field(Of String)("Equ"), _
                           .compania = datos.Field(Of String)("COMP"), _
                           .anio = datos.Field(Of Integer)("anio")}



            GridView1.DataSource = query.ToList
            GridView1.DataBind()
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If

        Return ds
    End Function

    Dim bandera As Boolean = True
    Protected Sub Unnamed3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        'saber que campos va a mostrar
        Dim mostrarCampos As Integer = LbFinal.Items.Count
        If mostrarCampos > 0 Then
            If validarRangos() Then
                Dim ds As New DataSet
                ds = Me.Cache("myTestCache")


                Dim countAnio, countPozo, countEquipo, countIntervencion, countPlataforma As Integer


                countAnio = LbAnioFinal.Items.Count
                countPozo = LbPozoFinal.Items.Count
                countEquipo = LbEquipoFinal.Items.Count
                countIntervencion = LbIntervencionFinal.Items.Count
                countPlataforma = LbPlataformaFinal.Items.Count

                If countAnio > 0 Then ' validar LOS DS 
                    ds = ListaSeleccionados(countAnio, LbAnioFinal, "anio", ds)
                End If
                If countPozo > 0 And ds.Tables.Count > 0 Then
                    ds = ListaSeleccionados(countPozo, LbPozoFinal, "Npozo", ds)
                End If

                If countEquipo > 0 And ds.Tables.Count > 0 Then
                    ds = ListaSeleccionados(countEquipo, LbEquipoFinal, "equ", ds)
                End If
                If countIntervencion > 0 And ds.Tables.Count > 0 Then
                    ds = ListaSeleccionados(countIntervencion, LbIntervencionFinal, "NIntervencion", ds)
                End If
                If countPlataforma > 0 And ds.Tables.Count > 0 Then
                    ds = ListaSeleccionados(countPlataforma, LbPlataformaFinal, "Plata", ds)
                End If

                If SeleccionFechas() Then
                    Dim dsAux As New DataSet
                    dsAux.Merge(ds.Tables(0).Select("dateOperacion>='" & TxtFechaInicial.Text & "' AND dateOperacion<='" & TxtFechaFinal.Text & "'"))
                    ds = dsAux
                End If
                msg.Visible = False
                If ds.Tables.Count > 0 Then
                    llenarGrid(ds)
                    Me.Cache("pageIndex") = ds
                    MyAccordion.SelectedIndex = 2
                Else
                    LblError.Text = "No se econtro información con estos filtros"
                    MyAccordion.SelectedIndex = 1
                    msg.Visible = True
                End If
            End If
        Else
            LblError.Text = " Seleccione que campos quiere mostrar"
            MyAccordion.SelectedIndex = 0
            msg.Visible = True
        End If
    End Sub

    Public Function SeleccionFechas() As Boolean
        If TxtFechaInicial.Text = "" Then
            Return False
        End If
        If TxtFechaFinal.Text = "" Then
            Return False
        End If
        Return True
    End Function

    Public Function validarRangos() As Boolean
        LblError.Text = ""
        If TxtFechaFinal.Text < TxtFechaInicial.Text Then
            LblError.Text = " Verifique su rango de fechas"
            MyAccordion.SelectedIndex = 1
            msg.Visible = True
            Return False
        End If
        Return True
    End Function
    Function ListaSeleccionados(ByVal contador As Integer, ByVal lista As ListBox, ByVal campo As String, ByVal ds As DataSet) As DataSet

        Dim busqueda As New StringBuilder
        busqueda.Append(campo).Append(" IN('")
        For i As Integer = 0 To contador - 1
            busqueda.Append(lista.Items(i).Text).Append("','")
        Next
        Dim dsAux As New DataSet
        dsAux.Merge(ds.Tables(0).Select(busqueda.ToString.Substring(0, busqueda.Length - 2) & ")"))
        Return dsAux
    End Function

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid(Me.Cache("pageIndex"))
    End Sub
    ''paginacion
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub

    Function validarDs(ds As DataSet, mensaje As String) As Boolean
        If ds.Tables.Count = 0 Then
            LblError.Text = " No se encontró " & mensaje
            msg.Visible = True
            Return False
        End If
        msg.Visible = False
        Return True
    End Function
    Protected Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim ds3 As New DataSet
        ds3.Merge(ds.Tables(0).Select("NPozo LIKE '%" & TextBox3.Text & "%'"))
        Dim msg As String = TextBox3.Text & " en la lista Pozo"
        If validarDs(ds3, msg) Then
            LbPozo.Items.Clear()
            LbPozo.DataSource = (From Pozo In ds3.Tables(0) _
                                Select Pozo.Field(Of String)("NPozo")).Distinct()
            LbPozo.DataBind()
        End If
        bandera = False
    End Sub

    Protected Sub TextBox5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim ds3 As New DataSet
        ds3.Merge(ds.Tables(0).Select("Equ LIKE '%" & TextBox5.Text & "%'"))
        Dim msg As String = TextBox5.Text & " en la lista Equipo"
        If validarDs(ds3, msg) Then
            LbEquipo.Items.Clear()
            LbEquipo.DataSource = (From Pozo In ds3.Tables(0) _
                                Select Pozo.Field(Of String)("Equ")).Distinct()
            LbEquipo.DataBind()
        End If
        bandera = False
    End Sub

    Protected Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim ds As New DataSet
        ds = Me.Cache("myTestCache")
        LbAnio.Items.Remove(0)
        Dim ds3 As New DataSet
        ds3.Merge(ds.Tables(0).Select("plata LIKE '%" & TextBox4.Text & "%'"))
        Dim msg As String = TextBox4.Text & " en la lista Plataforma"
        If validarDs(ds3, msg) Then
            LbPlataforma.Items.Clear()
            LbPlataforma.DataSource = (From Pozo In ds3.Tables(0) _
                                Select Pozo.Field(Of String)("plata")).Distinct()
            LbPlataforma.DataBind()
        End If
        bandera = False
    End Sub

    Protected Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click

        If bandera Then
            Dim sw As New System.IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            Dim ds As New DataSet

            ds = Me.Cache("pageIndex")



            Dim countAnio, countPozo, countEquipo, countIntervencion, countPlataforma As Integer


            countAnio = LbAnioFinal.Items.Count
            countPozo = LbPozoFinal.Items.Count
            countEquipo = LbEquipoFinal.Items.Count
            countIntervencion = LbIntervencionFinal.Items.Count
            countPlataforma = LbPlataformaFinal.Items.Count

            If countAnio > 0 Then
                ds = ListaSeleccionados(countAnio, LbAnioFinal, "anio", ds)
            End If
            If countPozo > 0 Then
                ds = ListaSeleccionados(countPozo, LbPozoFinal, "Npozo", ds)
            End If

            If countEquipo > 0 Then
                ds = ListaSeleccionados(countEquipo, LbEquipoFinal, "equ", ds)
            End If
            If countIntervencion > 0 Then
                ds = ListaSeleccionados(countIntervencion, LbIntervencionFinal, "NIntervencion", ds)
            End If
            If countPlataforma > 0 Then
                ds = ListaSeleccionados(countPlataforma, LbPlataformaFinal, "Plata", ds)
            End If


            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/ms-excel"
            Response.AddHeader("content-Disposition", "attachment;filename=Example.xls")



            GridView1.EnableViewState = False
            GridView1.AllowPaging = False

            '' LLenar Grid
            llenarGrid(ds)


            GridView1.RenderControl(htw)
            Response.Charset = "UTF-8"
            Response.ContentEncoding = Encoding.Default
            Response.Write(sw.ToString)
            Response.End()
        End If
    End Sub


    'Protected Sub LbSelecciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LbSelecciones.SelectedIndexChanged
    '    If LbSelecciones.Items.Count > 1 Then
    '        For i As Integer = 0 To LbSelecciones.Items.Count - 1
    '            If LbSelecciones.Items(i).Selected Then
    '                selecciones = Me.Cache("Selecciones")
    '                selecciones(LbSelecciones.Items.Item(i).Value) = ""
    '                Me.Cache("Selecciones") = selecciones
    '                LbSelecciones.Items.Remove(LbSelecciones.Items(i))
    '                llenar("busca")
    '                Exit For
    '            End If
    '        Next
    '    Else
    '        Me.Cache.Remove("Selecciones")
    '        Me.Cache("Selecciones") = selecciones
    '        LbSelecciones.Items.Clear()
    '        llenar("")
    '    End If
    'End Sub
End Class
