Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            msg.Visible = False
            bindData()
        End If
    End Sub

    Sub bindData()
        Dim dao As New StoredBDAccess

        Dim parametros As New List(Of Parametros)
        'Recuperamos el id del GridView
        Dim sp As New DescripParametros("getPlataformas", parametros)
        Dim cmd = dao.getDataSet(sp)
        GridView1.DataSource = cmd
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        msg.Visible = False
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        bindData()
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        msg.Visible = False
        GridView1.EditIndex = -1
        bindData()
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As EventArgs) Handles GridView1.RowDeleting
        'Elimina Plataformas si aun no hay informacion
        msg.Visible = False
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        'Recuperamos el id del GridView
        parametros.Add(New Parametros("@idPlataforma", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraPlataforma", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            'validador bootstrap
            lblError.Text = "La Plataforma que intenta eliminar ya contiene información relacionada."
            msg.Visible = True
        End Try
        bindData()
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        bindData()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        msg.Visible = False
        Dim idPlataforma As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox1"), TextBox).Text
        Dim strNombre As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text
        'Codigo para modificar en la BDS
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        parametros.Add(New Parametros("@idPlataforma", SqlDbType.Int, idPlataforma))
        parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, strNombre))
        Dim sp As New DescripParametros("modificaPlataforma", parametros)
        dao.getDataSet(sp)
        'Sale del modo edicion y actualiza el GridView
        GridView1.EditIndex = -1
        bindData()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim plataforma As String = txtPlataforma.Text
        If plataforma <> "" Then
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, plataforma))
            Dim sp As New DescripParametros("AltaPlataforma", parametros)
            dao.getDataSet(sp)
            bindData()
            txtPlataforma.Text = ""
            'validador bootstrap          
            msg.Visible = False
        Else
            'validador bootstrap
            lblError.Text = "Debe ingresar un nombre para la plataforma."
            msg.Visible = True
        End If
    End Sub
End Class
