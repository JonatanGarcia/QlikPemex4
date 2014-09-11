Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindData()
            bindCmb(CmdN1)
        End If
    End Sub
    Sub bindData()
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        Dim spN2 As New DescripParametros("getNivel2", parametros)
        Dim dsN2 As DataSet = dao.getDataSet(spN2)
        GridView1.DataSource = dsN2
        GridView1.DataBind()
    End Sub
    Sub bindCmb(ByVal ddl As DropDownList)
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        Dim spN1 As New DescripParametros("getNivel1", parametros)
        Dim dsN1 As DataSet = dao.getDataSet(spN1)
        ddl.DataSource = dsN1
        ddl.DataTextField = "strNombre"
        ddl.DataValueField = "idNPTN1"
        ddl.DataBind()
    End Sub
    Function validar() As Boolean
        If TxtNivel2.Text = "" Then
            lblError.Text = "Inserte un nombre en Nivel2"
            msg.Visible = True
            Return False
        End If
        msg.Visible = False
        Return True
    End Function
    Function validaUpdate(strNombre As String) As Boolean
        If strNombre = "" Then
            lblErrorUpdate.Text = "Insere un nombre en Nivel2"
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
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, TxtNivel2.Text.ToUpper))
            parametros.Add(New Parametros("@idNPTN1", SqlDbType.VarChar, CmdN1.SelectedValue))
            Dim sp As New DescripParametros("AltaNivel2", parametros)
            dao.getDataSet(sp)
            TxtNivel2.Text = ""
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

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Si y solo si esta editando   
        If ((e.Row.RowState And DataControlRowState.Edit) > 0) Then
            Dim ll As Label = CType(e.Row.FindControl("lblIdN1"), Label)
            Dim ddl As DropDownList = DirectCast(e.Row.FindControl("ddlEditN1"), DropDownList)
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
        msgUpdate.Visible = False
        Dim idNPTN2 As Integer = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox1"), Label).Text
        Dim strNombre As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text

        Dim ddl As DropDownList = DirectCast(GridView1.Rows(e.RowIndex).FindControl("ddlEditN1"), DropDownList)
        Dim idNPTN1 As Integer = ddl.SelectedValue


        If validaUpdate(strNombre) Then


            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@idNPTN1", SqlDbType.Int, idNPTN1))
            parametros.Add(New Parametros("@idNPTN2", SqlDbType.Int, idNPTN2))
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, strNombre.ToUpper))

            Dim sp As New DescripParametros("modificaNivel2", parametros)
            dao.getDataSet(sp)

            'Sale del modo edicion y actualiza el GridView
            GridView1.EditIndex = -1
            bindData()
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As EventArgs) Handles GridView1.RowDeleting
        msgUpdate.Visible = False
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim dao As New StoredBDAccess

        Dim parametros As New List(Of Parametros)
        parametros.Add(New Parametros("@idCatNivel2", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraNivel2", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            lblErrorUpdate.Text = "La Actividad que intenta eliminar ya contiene información relacionada."
            msgUpdate.Visible = True
        End Try
        bindData()
    End Sub
End Class
