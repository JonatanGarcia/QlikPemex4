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
        'Recuperamos el id del GridView
        Dim sp As New DescripParametros("getPozos", parametros)
        Dim cmd = dao.getDataSet(sp)
        GridView1.DataSource = cmd
        GridView1.DataBind()
    End Sub
    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim cia As String = txtCia.Text.ToUpper

        If validar() Then
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, cia))
            Dim sp As New DescripParametros("AltaPozo", parametros)
            dao.getDataSet(sp)
            bindData()
            txtCia.Text = ""
        Else
            'validador bootstrap
            msg.Visible = True
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        msg.Visible = False
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        bindData()
    End Sub
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        bindData()
    End Sub
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        msg.Visible = False
        GridMsg.Visible = False
        GridView1.EditIndex = -1
        bindData()
    End Sub
    Function validar() As Boolean
        If txtCia.Text = "" Then
            lblError.Text = "Debe ingresar un nombre para el Pozo"
            msg.Visible = True
            Return False
        End If
        If IsNumeric(txtCia.Text) Then
            lblError.Text = "El nombre del Pozo no puede ser numerico"
            msg.Visible = True
            Return False
        End If
        msg.Visible = False
        Return True
    End Function
    Function validaGrid(ByVal nombre As String) As Boolean
        If nombre = "" Then
            GridMsg.Visible = True
            lblGridMsg.Text = "Debe ingresar un nombre para el Pozo."
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
    Public Function Generic(ByVal sql As String) As DataSet
        Dim ds As New DataSet
        Dim dao As New StoredBDAccess
        Dim listParametros As New List(Of Parametros)
        listParametros.Add(New Parametros("@SQL_QUERY", SqlDbType.VarChar, sql))
        Dim busca = New DescripParametros("getGeneric", listParametros)
        ds = dao.getDataSet(busca)
        Return ds
    End Function       
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim idPozo As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("lblEditIdPozo"), Label).Text
        Dim strNombre As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text
        Dim visible As Boolean = DirectCast(GridView1.Rows(e.RowIndex).FindControl("CheckBox1"), CheckBox).Checked       
        If validaGrid(strNombre) Then
            'Codigo para modificar en la BDS
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@idPozo", SqlDbType.Int, idPozo))
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, strNombre))
            parametros.Add(New Parametros("@visible", SqlDbType.Bit, visible))
            Dim sp As New DescripParametros("modificaPozo", parametros)
            dao.getDataSet(sp)
            'Sale del modo edicion y actualiza el GridView
            GridView1.EditIndex = -1
            bindData()
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As EventArgs) Handles GridView1.RowDeleting
        'Elimina Pozo si aun no hay informacion
        msg.Visible = False
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        'Recuperamos el id del GridView
        parametros.Add(New Parametros("@idPozo", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraPozo", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            'validador bootstrap
            lblGridMsg.Text = "El Pozo que intenta eliminar ya contiene información relacionada."
            GridMsg.Visible = True
        End Try
        bindData()
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Si y solo si esta editando   
        If ((e.Row.RowState And DataControlRowState.Edit) > 0) Then
            Dim checkValue As Boolean = CType(e.Row.FindControl("editChkValue"), Label).Text
            Dim chkVisible As CheckBox = DirectCast(e.Row.FindControl("CheckBox1"), CheckBox)
            chkVisible.Checked = checkValue            
        End If
    End Sub
End Class