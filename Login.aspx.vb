Imports System.Data

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub ValidateUser(sender As Object, e As EventArgs)
        Try
            'Preparamos conexion
            Dim dao As New StoredBDAccess
            'mandamos los parametros a la consulta generica
            Dim listParametros As New List(Of Parametros)
            listParametros.Add(New Parametros("@Username", SqlDbType.VarChar, Login1.UserName))
            listParametros.Add(New Parametros("@Password", SqlDbType.VarChar, Login1.Password))
            'indicamos el store a ejecutar y mandamos los parametros
            Dim busca = New DescripParametros("Valida_Usuario", listParametros)
            'ejecuta consulta y devuelve resultado
            Dim user = dao.validateUser(busca)
            Select Case user
                Case -1
                    Login1.FailureText = "Usuario y/o password incorrecto."
                    Exit Select
                Case -2
                    Login1.FailureText = "La cuenta no ha sido activada."
                    Exit Select
                Case Else
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
                    Exit Select
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
