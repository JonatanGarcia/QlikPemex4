Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindData()
        End If
    End Sub

    Sub bindData()
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        Dim nivel1 As New DescripParametros("getNivel1", parametros)
        Dim dsNivel1 As DataSet = dao.getDataSet(nivel1)
        GridView1.DataSource = dsNivel1
        GridView1.DataBind()
    End Sub
    Public Function validar() As Boolean
        If TxtNivel1.Text = "" Then
            lblError.Text = "Coloque un nombre en nivel 1"
            msg.Visible = True
            Return False
        End If
        msg.Visible = False
        Return True
    End Function
    Public Function validaUpdate(nombre As String) As Boolean
        If nombre = "" Then
            lblErrorUpdate.Text = "Coloque un nombre en nivel 1"
            msgUpdate.Visible = True
            Return False
        End If
        msgUpdate.Visible = False
        Return True
    End Function
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If validar() Then
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, TxtNivel1.Text.ToUpper))
            Dim sp As New DescripParametros("AltaNivel1", parametros)
            dao.getDataSet(sp)
            TxtNivel1.Text = ""
            bindData()
        End If
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

    Protected Sub GridView1_RowDeleting(sender As Object, e As EventArgs) Handles GridView1.RowDeleting
        msgUpdate.Visible = False
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        parametros.Add(New Parametros("@idCatNivel1", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraNivel1", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            lblErrorUpdate.Text = "El Nivel1 que intenta eliminar ya contiene información relacionada."
            msgUpdate.Visible = True
        End Try
        bindData()
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        msgUpdate.Visible = False
        GridView1.EditIndex = e.NewEditIndex
        bindData()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        msgUpdate.Visible = False
        Dim idN1 As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox1"), Label).Text
        Dim strNombre As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text

        If validaUpdate(strNombre) Then
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@idNPTN1", SqlDbType.Int, idN1))
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, strNombre.ToUpper))
            Dim sp As New DescripParametros("modificaNivel1", parametros)
            dao.getDataSet(sp)
            GridView1.EditIndex = -1
            bindData()
        End If

    End Sub
End Class
