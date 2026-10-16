Public Class Bicicleta
    Private _codigo As String
    Private _tipo As String
    Private _tarifaPorHora As Decimal

    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property TarifaPorHora As Decimal
        Get
            Return _tarifaPorHora
        End Get
        Set(value As Decimal)
            If value <= 0 Then
                Throw New ArgumentException("La tarifa por hora debe ser mayor a cero.")
            End If
            _tarifaPorHora = value
        End Set
    End Property

    Public Sub New(codigo As String, tipo As String, tarifa As Decimal)
        Me.Codigo = codigo
        Me.Tipo = tipo
        Me.TarifaPorHora = tarifa
    End Sub

    Public Function CalcularAlquiler(horas As Integer) As Decimal
        Return _tarifaPorHora * horas
    End Function

    Public Sub MostrarInformacion(ByRef lbl As Label, horas As Integer)
        Dim total As Decimal = CalcularAlquiler(horas)
        lbl.Text = "Código: " & _codigo & " | Tipo: " & _tipo & " | Horas: " & horas & vbCrLf &
                   "Tarifa/h: S/" & _tarifaPorHora & " | Total a Pagar: S/" & total
    End Sub
End Class
