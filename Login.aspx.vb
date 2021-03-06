﻿Imports System.Data

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub ValidateUser(sender As Object, e As EventArgs)
        Try
            Dim rolUsuario As Integer = validaUsuario(Login1.UserName, Login1.Password)
            If rolUsuario > 0 Then
                Session.Add("rolUsuario", rolUsuario)
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
            Else
                Login1.FailureText = "Usuario y/o password incorrecto."
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function validaUsuario(user As String, password As String) As Integer
        'Preparamos conexion
        Dim dao As New StoredBDAccess
        'mandamos los parametros a la consulta generica
        Dim listParametros As New List(Of Parametros)
        listParametros.Add(New Parametros("@Username", SqlDbType.VarChar, user))
        listParametros.Add(New Parametros("@Password", SqlDbType.VarChar, password))
        'indicamos el store a ejecutar y mandamos los parametros
        Dim sp = New DescripParametros("Valida_Usuario", listParametros)
        'ejecuta consulta y devuelve resultado ds
        Dim dsUser = dao.getDataSet(sp)
        Dim myUser = dsUser.Tables(0).Rows(0).Item(0)
        Return myUser
    End Function
End Class
