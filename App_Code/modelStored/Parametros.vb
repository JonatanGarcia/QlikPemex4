Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class Parametros
    Private _nombreParametro As String
    Private _tipoDato As SqlDbType
    Private _valor As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal _nombreParametro As String, ByVal _tipoDato As SqlDbType, ByVal _valor As String)
        Me._nombreParametro = _nombreParametro
        Me._tipoDato = _tipoDato
        Me._valor = _valor
    End Sub

    Public Property NombreParamtero As String
        Get
            Return _nombreParametro
        End Get
        Set(ByVal value As String)
            _nombreParametro = value
        End Set
    End Property
    Public Property TipoDato As SqlDbType
        Get
            Return _tipoDato
        End Get
        Set(ByVal value As SqlDbType)
            _tipoDato = value
        End Set
    End Property
    Public Property Valor As String
        Get
            Return _valor
        End Get
        Set(ByVal value As String)
            _valor = value
        End Set
    End Property
End Class
