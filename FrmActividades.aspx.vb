Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            msg.Visible = False
            bindData()
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
    Sub bindData()
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        'Recuperamos datos para el ddl y gridview
        Dim spIntervenciones As New DescripParametros("getCatIntervencion", parametros)
        Dim spActividades As New DescripParametros("getActividades", parametros)
        'llenamos DataSets para ddl y gridview 
        Dim dsIntervenciones = dao.getDataSet(spIntervenciones)
        Dim dsActividades = dao.getDataSet(spActividades)
        'Llenamos DropDown List
        ddlIntervencion.DataSource = dsIntervenciones.Tables(0)
        ddlIntervencion.DataTextField = "strNombre"
        ddlIntervencion.DataValueField = ""
        ddlIntervencion.DataBind()
        'Llenamos Grid
        GridView1.DataSource = dsIntervenciones
        GridView1.DataBind()       
    End Sub
    Sub llenaDdlIntervencion(ByVal ddl As DropDownList)
        Dim myDdl = ddl
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        Dim spInt As New DescripParametros("getCatIntervencion", parametros)
        Dim dsInt = dao.getDataSet(spInt)
        myDdl.DataSource = dsInt
        myDdl.DataTextField = "strNombre"
        myDdl.DataValueField = "idTipo"
        myDdl.DataBind()
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        bindData()
    End Sub
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        msg.Visible = False
        GridView1.EditIndex = -1
        bindData()
    End Sub
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex       
        bindData()
    End Sub
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        msg.Visible = False
        Dim actividad As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text
        Dim secuencia As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox3"), TextBox).Text
        Dim strNombre As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text
        Dim ddl As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("ddlEditInterv"), DropDownList)
        llenaDdlIntervencion(ddl)
        'Codigo para modificar en la BDS
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        parametros.Add(New Parametros("@idPlataforma", SqlDbType.Int, actividad))
        parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, strNombre))
        Dim sp As New DescripParametros("modificaPlataforma", parametros)
        dao.getDataSet(sp)
        'Sale del modo edicion y actualiza el GridView
        GridView1.EditIndex = -1
        bindData()
    End Sub
    Function validar() As Boolean
        If txtNombre.Text = "" Then
            msg.Visible = True
            lblError.Text = "Debe ingresar un nombre para la Actividad."
            Return False
        End If
        If txtSecuencia.Text = "" Then
            msg.Visible = True
            lblError.Text = "Debe ingresar un valor de secuencia (1-100)."
            Return False
        End If
        If Not IsNumeric(txtSecuencia.Text) Then
            msg.Visible = True
            lblError.Text = "El valor debe ser un numerico"
            Return False
        End If
        If txtSecuencia.Text <= 0 Then
            msg.Visible = True
            lblError.Text = "El valor debe ser mayor a cero"
            Return False
        End If
        If txtDescripcion.Text = "" Then
            msg.Visible = True
            lblError.Text = "Debe describir la Actividad " + txtNombre.Text.ToUpper
            Return False
        End If
        msg.Visible = False
        Return True
    End Function
    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If validar() Then
            Dim actividad As String = txtNombre.Text.ToUpper
            Dim secuencia As Integer = txtSecuencia.Text
            Dim descripcion As String = txtDescripcion.Text.ToUpper
            Dim tipo As Integer = ddlIntervencion.SelectedValue
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@actividad", SqlDbType.VarChar, actividad))
            parametros.Add(New Parametros("@descripcion", SqlDbType.Text, descripcion))
            parametros.Add(New Parametros("@secuencia", SqlDbType.Int, secuencia))
            parametros.Add(New Parametros("@tipo", SqlDbType.Int, tipo))
            Dim sp As New DescripParametros("AltaActividad", parametros)
            dao.getDataSet(sp)
            bindData()
            txtNombre.Text = ""
            txtSecuencia.Text = ""
            txtDescripcion.Text = ""            
        Else
            msg.Visible = True
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As EventArgs) Handles GridView1.RowDeleting
        'Elimina Actvividad si aun no hay informacion relacionada
        msg.Visible = False
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        'Recuperamos el id del GridView
        parametros.Add(New Parametros("@idActividad", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraActividad", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            'validador bootstrap
            lblError.Text = "La Actividad que intenta eliminar ya contiene información relacionada."
            msg.Visible = True
        End Try
        bindData()
    End Sub
    'Cachamos el evento y llenamos el ddl en tiempo de ejecucion
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowState = DataControlRowState.Edit Then
            Dim ddl As DropDownList = DirectCast(e.Row.FindControl("ddlEditInterv"), DropDownList)
            llenaDdlIntervencion(ddl)
        End If
    End Sub
End Class
