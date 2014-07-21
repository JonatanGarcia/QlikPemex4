Imports Microsoft.VisualBasic

Public Class DescripParametros
    Private _nombre As String
    Private _listParametros As List(Of Parametros)
    Public Sub New(ByVal _nombre As String, ByVal _listParametros As List(Of Parametros))
        Me._nombre = _nombre
        Me._listParametros = _listParametros
    End Sub
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property ListParametros As List(Of Parametros)
        Get
            Return _listParametros
        End Get
        Set(ByVal value As List(Of Parametros))
            _listParametros = value
        End Set
    End Property
End Class
