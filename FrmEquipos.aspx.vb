Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            msg.Visible = False
            GridMsg.Visible = False
            bindData()
        End If
    End Sub
    Sub bindData()
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        'Recuperamos datos para el ddl y gridview
        Dim spCias As New DescripParametros("getCias", parametros)
        Dim spEquipos As New DescripParametros("getEquipos", parametros)
        'llenamos DataSets para ddl y gridview 
        Dim dsCias = dao.getDataSet(spCias)
        Session.Add("dsCias", dsCias)
        Dim dsEquipos = dao.getDataSet(spEquipos)
        Session.Add("dsEquipos", dsEquipos)
        'Llenamos DropDown List
        ddlCia.DataSource = dsCias.Tables(0)
        ddlCia.DataTextField = "strNombre"
        ddlCia.DataValueField = "idCatCompania"
        ddlCia.DataBind()
        'Llenamos Grid
        GridView1.DataSource = dsEquipos
        GridView1.DataBind()
    End Sub
    Sub llenaDdlCias(ByVal ddl As DropDownList)
        Dim myDdl = ddl
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        Dim spInt As New DescripParametros("getCias", parametros)
        Dim dsInt = dao.getDataSet(spInt)
        myDdl.DataSource = dsInt
        myDdl.DataTextField = "strNombre"
        myDdl.DataValueField = "idCatCompania"
        myDdl.DataBind()
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
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        bindData()
    End Sub
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        bindData()
    End Sub
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating  
        'Recuperamos valores a actualizar
        Dim idEquipo As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox3"), Label).Text
        Dim equipo As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox1"), TextBox).Text
        Dim ddlCia As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("ddlEditCia"), DropDownList)
        Dim idCia As Integer = 0
        For i As Integer = 0 To ddlCia.Items.Count - 1
            If ddlCia.Items(i).Selected Then
                idCia = ddlCia.Items(i).Value
                Exit For
            End If
        Next       
        'Validamos y Actualizamos
        If validaGrid(equipo) Then
            'Codigo para modificar en la BDS
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@idEquipo", SqlDbType.Int, idEquipo))
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, equipo))
            parametros.Add(New Parametros("@idCia", SqlDbType.Int, idCia))
            Dim sp As New DescripParametros("modificaEquipo", parametros)
            dao.getDataSet(sp)
            'Sale del modo edicion y actualiza el GridView
            GridView1.EditIndex = -1
            bindData()
        End If
    End Sub
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        msg.Visible = False
        GridMsg.Visible = False
        GridView1.EditIndex = -1
        bindData()
    End Sub
    Function validaNuevo() As Boolean
        If txtEquipo.Text = "" Then
            msg.Visible = True
            lblError.Text = "Debe ingresar un nombre para el Equipo."
            Return False
        End If
        If IsNumeric(txtEquipo.Text) Then
            msg.Visible = True
            lblError.Text = "El valor no puede ser completamente numerico"
            Return False
        End If
        msg.Visible = False
        Return True
    End Function
    Function validaGrid(ByVal nombre As String) As Boolean
        If nombre = "" Then
            GridMsg.Visible = True
            lblGridMsg.Text = "Debe ingresar un nombre para el Equipo."
            Return False
        End If
        If IsNumeric(nombre) Then
            GridMsg.Visible = True
            lblGridMsg.Text = "El Nombre no puede ser completamente numerico"
            Return False
        End If
        GridMsg.Visible = False
        Return True
    End Function
    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If validaNuevo() Then
            Dim equipo As String = txtEquipo.Text.ToUpper
            Dim cia As Integer = ddlCia.SelectedValue
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@Nombre", SqlDbType.VarChar, equipo))
            parametros.Add(New Parametros("@idCia", SqlDbType.Int, cia))
            Dim sp As New DescripParametros("AltaEquipo", parametros)
            dao.getDataSet(sp)
            bindData()
            txtEquipo.Text = ""
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
        parametros.Add(New Parametros("@idEquipo", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraEquipo", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            'validador bootstrap
            lblGridMsg.Text = "El Equipo que intenta eliminar ya contiene información relacionada."
            GridMsg.Visible = True
        End Try
        bindData()
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Si y solo si esta editando   
        If ((e.Row.RowState And DataControlRowState.Edit) > 0) Then
            'Label necesario para obtener la compañia que tiene en ese momento el equipo
            Dim idCia As Label = CType(e.Row.FindControl("lblIdCia"), Label)
            Dim ddl As DropDownList = DirectCast(e.Row.FindControl("ddlEditCia"), DropDownList)
            llenaDdlCias(ddl)
            ddl.SelectedValue = idCia.Text
        End If
    End Sub
End Class
