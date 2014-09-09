Imports System.Data
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
        Dim sp As New DescripParametros("getCias", parametros)
        Dim cmd = dao.getDataSet(sp)
        GridView1.DataSource = cmd
        GridView1.DataBind()
    End Sub
    Function validar() As Boolean
        If txtCia.Text = "" Then
            lblError.Text = "Debe ingresar un nombre para la Compañia"
            msg.Visible = True
            Return False
        End If
        If IsNumeric(txtCia.Text) Then
            lblError.Text = "El nombre de la Compañia no puede ser numerico"
            msg.Visible = True
            Return False
        End If
        msg.Visible = False
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
    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim cia As String = txtCia.Text.ToUpper
        If validar() Then
            Dim dao As New StoredBDAccess
            Dim parametros As New List(Of Parametros)
            parametros.Add(New Parametros("@nombre", SqlDbType.VarChar, cia))
            Dim sp As New DescripParametros("AltaCia", parametros)
            dao.getDataSet(sp)
            bindData()
            txtCia.Text = ""
        Else
            'validador bootstrap
            msg.Visible = True
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As EventArgs) Handles GridView1.RowDeleting
        'Elimina Compañia si aun no hay informacion
        msg.Visible = False
        Dim lnkRemove As LinkButton = DirectCast(sender, LinkButton)
        Dim dao As New StoredBDAccess
        Dim parametros As New List(Of Parametros)
        'Recuperamos el id del GridView
        parametros.Add(New Parametros("@idCatCompania", SqlDbType.Int, lnkRemove.CommandArgument))
        Dim sp As New DescripParametros("borraCia", parametros)
        Try
            dao.getDataSet(sp)
        Catch ex As Exception
            'validador bootstrap
            lblError.Text = "La Compañia que intenta eliminar ya contiene información relacionada."
            msg.Visible = True
        End Try
        bindData()
    End Sub
End Class