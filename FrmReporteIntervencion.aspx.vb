
Partial Class Default3
    Inherits System.Web.UI.Page
    Function armaBusqueda() As String
        Dim cadena As New StringBuilder

        CrystalReportViewer1.RefreshReport()
        If cadena.ToString() = "" Then
            Return ""
        End If
        If TxtFechaInicial.Text <> "" Then
            cadena.Append("{comando.dateOperacion}>=DateTime(").Append(TxtFechaInicial.Text.Replace("-", ",")).Append(") AND ")
        End If
        If TxtFechaFinal.Text <> "" Then
            cadena.Append("{comando.dateOperacion}<=DateTime(").Append(TxtFechaFinal.Text.Replace("-", ",")).Append(") AND ")
        End If
        
        Return cadena.ToString.Substring(0, cadena.ToString.Length - 4)
    End Function
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        CrystalReportViewer1.SelectionFormula = armaBusqueda()
    End Sub

End Class
