Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class Conexion
    Friend _StrConexion As String
    Friend _Conexion As SqlConnection
    Friend _Commando As SqlCommand
    Friend _Parametro As SqlParameter
    Friend _Adaptador As SqlDataAdapter

    Public Sub New()
        _StrConexion = "server=localhost;uid=sa;pwd=stin2014;database=PMX_NPTS_CI;Connect Timeout=10000;"
        _Conexion = New SqlConnection(_StrConexion)
        _Commando = New SqlCommand
        _Commando.CommandTimeout = 3600
        _Adaptador = New SqlDataAdapter(_Commando)
    End Sub
End Class
