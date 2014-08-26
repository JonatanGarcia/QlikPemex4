Imports DotNet.Highcharts
Imports DotNet.Highcharts.Options
Imports DotNet.Highcharts.Helpers

Partial Class GraficaEjemplo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim titulo As New Title()
        titulo.Text = "Grafica de Avance"

        Dim progressChart As New DotNet.Highcharts.Highcharts("chart")
        progressChart.SetTitle(titulo)

        Dim Cat As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

        Dim ax As New XAxis
        ax.Categories = Cat
        Dim series As New Series()
        Dim datas As New Data(New Object() {29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4})
        series.Data = datas

        progressChart.SetXAxis(ax)
        progressChart.SetSeries(series)

        ltrChart.Text = progressChart.ToHtmlString()

    End Sub

End Class
