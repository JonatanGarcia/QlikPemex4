
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim idAcceso = Convert.ToInt32(Session("rolUsuario").ToString)
        If idAcceso <> 1 Then
            mCargas.Visible = False
            mCatalogos.Visible = False
        End If
    End Sub
End Class

