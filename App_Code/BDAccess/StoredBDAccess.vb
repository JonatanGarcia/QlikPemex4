Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class StoredBDAccess
    Inherits Conexion

    Public Sub New()
    End Sub

#Region "BD"
    Public Function getDataTable(ByVal descripcion As DescripParametros) As DataTable
        Dim dt As New DataTable
        Dim obj As New Object
        Try
            _Adaptador = New SqlDataAdapter
            _Commando.CommandText = descripcion.Nombre
            _Commando.CommandType = CommandType.StoredProcedure
            _Commando.Connection = _Conexion
            _Conexion.Open()
            _Commando.Parameters.Clear()
            For i As Integer = 0 To descripcion.ListParametros.Count - 1
                _Commando.Parameters.Add(descripcion.ListParametros(i).NombreParamtero, descripcion.ListParametros(i).TipoDato, descripcion.ListParametros(i).Valor.Length).Value = descripcion.ListParametros(i).Valor
            Next
            _Adaptador.SelectCommand = _Commando
            _Adaptador.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            _Conexion.Close()
        End Try
        Return dt
    End Function
    Public Function getDataSet(ByVal descripcion As DescripParametros) As DataSet
        Dim ds As New DataSet
        Dim obj As New Object
        Try
            _Adaptador = New SqlDataAdapter
            _Commando.CommandText = descripcion.Nombre
            _Commando.CommandType = CommandType.StoredProcedure
            _Commando.Connection = _Conexion
            _Conexion.Open()
            _Commando.Parameters.Clear()
            For i As Integer = 0 To descripcion.ListParametros.Count - 1
                _Commando.Parameters.Add(descripcion.ListParametros(i).NombreParamtero, descripcion.ListParametros(i).TipoDato, descripcion.ListParametros(i).Valor.Length).Value = descripcion.ListParametros(i).Valor
            Next
            _Adaptador.SelectCommand = _Commando
            _Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        Finally
            _Conexion.Close()
        End Try
        Return ds
    End Function

#End Region


End Class
