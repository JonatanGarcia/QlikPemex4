Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            msg.Visible = False
            msgUpdate.Visible = False
            bindData()
        End If
    End Sub
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
        ddlIntervencion.DataValueField = "idTipo"
        ddlIntervencion.DataBind()
        'llenamos Dropdown del Grid
        'Llenamos Grid
        GridView1.DataSource = dsActividades
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
        msgUpdate.Visible = False
        GridView1.EditIndex = -1
        bindData()
    End Sub
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        msgUpdate.Visible = False
        GridView1.EditIndex = e.NewEditIndex
        bindData()
    End Sub
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        msgUpdate.Visible = False
        Dim idActividad As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox1"), Label).Text
        Dim strNombre As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text
        Dim secuencia As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox3"), TextBox).Text
        Dim strDesc As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox5"), TextBox).Text
        Dim ddl As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("ddlEditInterv"), DropDownList)
        Dim idTipo As Integer = ddl.SelectedValue
        If validaUpdate(strNombre, secuencia, strDesc) Then            
            'Codigo para modificar en la BDS
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@idActividad", SqlDbType.Int, idActividad))
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, strNombre))
            parametros.Add(New Parametros("@strDesc", SqlDbType.VarChar, strDesc))
            parametros.Add(New Parametros("@secuencia", SqlDbType.VarChar, secuencia))
            parametros.Add(New Parametros("@idTipo", SqlDbType.VarChar, idTipo))
            Dim sp As New DescripParametros("modificaActividades", parametros)
            dao.getDataSet(sp)
            'Sale del modo edicion y actualiza el GridView
            GridView1.EditIndex = -1
            bindData()
        End If
    End Sub
    Function validaUpdate(strNombre As String, secuencia As String, strDesc As String) As Boolean
        msgUpdate.Visible = True
        If strNombre = "" Then
            lblErrorUpdate.Text = "Debe ingresar un nombre para la Actividad."
            Return False
        End If
        If Not IsNumeric(secuencia) Then
            lblErrorUpdate.Text = "Secuencia debe ser un valor numerico"
            Return False
        End If
        If secuencia < 0 Then
            lblErrorUpdate.Text = "Secuencia debe ser un valor mayor a cero"
            Return False
        End If
        If strDesc = "" Then
            lblErrorUpdate.Text = "Debe describir la Actividad " & strNombre
        End If
        msgUpdate.Visible = False
        Return True
    End Function

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
                lblError.Text = "Debe describir la Actividad " & txtNombre.Text.ToUpper
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
        msgUpdate.Visible = False
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
            lblErrorUpdate.Text = "La Actividad que intenta eliminar ya contiene información relacionada."
            msgUpdate.Visible = True
        End Try
        bindData()
    End Sub
    'Cachamos el evento y llenamos el ddl en tiempo de ejecucion
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Si y solo si esta editando   
        If ((e.Row.RowState And DataControlRowState.Edit) > 0) Then
            Dim ll As Label = CType(e.Row.FindControl("lblInter"), Label)
            Dim ddl As DropDownList = DirectCast(e.Row.FindControl("ddlEditInterv"), DropDownList)
            llenaDdlIntervencion(ddl)
            ddl.SelectedValue = ll.Text
        End If
    End Sub
End Class
