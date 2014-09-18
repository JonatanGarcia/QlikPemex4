Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindData()
            bindCmb(CmdN2)
        End If
    End Sub
    Sub bindData()
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        Dim spN3 As New DescripParametros("getNivel3", parametros)
        GridView1.DataSource = dao.getDataSet(spN3)
        GridView1.DataBind()
    End Sub
    Sub bindCmb(ddl As DropDownList)
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        Dim spN2 As New DescripParametros("getNivel2", parametros)
        ddl.DataSource = dao.getDataSet(spN2)
        ddl.DataTextField = "nivel2"
        ddl.DataValueField = "idNPTN2"
        ddl.DataBind()
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim newPageNumber As Integer = e.NewPageIndex + 1
        GridView1.PageIndex = e.NewPageIndex
        bindData()
    End Sub
    Function validar() As Boolean
        If TxtNivel3.Text = "" Then
            lblError.Text = "Inserte un nombre en nivel3"
            msg.Visible = True
            Return False
        End If
        msg.Visible = False
        Return True
    End Function
    Function validaUpdate(strNombre As String) As Boolean
        If strNombre = "" Then
            lblErrorUpdate.Text = "Inserte un nombre en Nivel3"
            msgUpdate.Visible = True
            Return False
        End If
        msgUpdate.Visible = False
        Return True
    End Function
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If validar() Then
            ocultaMsg()
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@idNPTN2", SqlDbType.Int, CmdN2.SelectedValue))
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, TxtNivel3.Text.ToUpper))

            Dim sp As New DescripParametros("AltaNivel3", parametros)
            dao.getDataSet(sp)
            TxtNivel3.Text = ""
            bindData()
        End If
    End Sub
    Sub ocultaMsg()
        msg.Visible = False
        msgUpdate.Visible = False
    End Sub
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        ocultaMsg()
        GridView1.EditIndex = -1
        bindData()
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Si y solo si esta editando   
        If ((e.Row.RowState And DataControlRowState.Edit) > 0) Then
            Dim ll As Label = CType(e.Row.FindControl("lblIdN2"), Label)
            Dim ddl As DropDownList = DirectCast(e.Row.FindControl("ddlEditN2"), DropDownList)
            bindCmb(ddl)
            ddl.SelectedValue = ll.Text
        End If
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        msgUpdate.Visible = False
        GridView1.EditIndex = e.NewEditIndex
        bindData()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        ocultaMsg()
        Dim idNPTN3 As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox1"), Label).Text
        Dim strNombre As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text
        Dim ddl As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("ddlEditN2"), DropDownList)
        Dim idNPTN2 As Integer = ddl.SelectedValue

        If validaUpdate(strNombre) Then
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@idNPTN2", SqlDbType.Int, idNPTN2))
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, strNombre.ToUpper))
            parametros.Add(New Parametros("@idNPTN3", SqlDbType.Int, idNPTN3))

            Dim sp As New DescripParametros("modificaNivel3", parametros)
            dao.getDataSet(sp)
            GridView1.EditIndex = -1
            bindData()
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As EventArgs) Handles GridView1.RowDeleting
        ocultaMsg()
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim dao As New StoredBDAccess

        Dim parametros As New List(Of Parametros)
        parametros.Add(New Parametros("@idCatNivel3", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraNivel3", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            lblErrorUpdate.Text = "El nivel que intenta eliminar ya contiene información relacionada."
            msgUpdate.Visible = True
        End Try
        bindData()
    End Sub
End Class
