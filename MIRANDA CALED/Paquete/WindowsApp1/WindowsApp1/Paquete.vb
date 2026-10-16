Public Class Paquete
    ' Campos privados
    Private _codigo As String
    Private _peso As Decimal
    Private _destino As String

    ' Propiedades
    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property

    Public Property Destino As String
        Get
            Return _destino
        End Get
        Set(value As String)
            _destino = value
        End Set
    End Property

    ' Propiedad Peso con Get y Set que rechaza valores <= 0
    Public Property Peso As Decimal
        Get
            Return _peso
        End Get
        Set(value As Decimal)
            If value <= 0 Then
                Throw New ArgumentException("El peso debe ser mayor a cero.")
            Else
                _peso = value
            End If
        End Set
    End Property

    ' Constructor con parámetros
    Public Sub New(codigo As String, peso As Decimal, destino As String)
        Me.Codigo = codigo
        Me.Peso = peso
        Me.Destino = destino
    End Sub

    ' Function para calcular el envío
    Public Function CalcularEnvio() As Decimal
        Dim tarifaPorKg As Decimal = 0

        If Destino.Equals("Local", StringComparison.OrdinalIgnoreCase) Then
            tarifaPorKg = 5
        ElseIf Destino.Equals("Nacional", StringComparison.OrdinalIgnoreCase) Then
            tarifaPorKg = 8
        End If

        Return Peso * tarifaPorKg
    End Function

    ' Sub para mostrar la información del paquete
    Public Sub MostrarInformacion(lblResultado As Label)
        lblResultado.Text = $"Código: {Codigo}" & vbCrLf &
                            $"Peso: {Peso} kg" & vbCrLf &
                            $"Destino: {Destino}"
    End Sub

    ' Formato para que se vea ordenado en el ListBox
    Public Overrides Function ToString() As String
        Return $"{Codigo} - {Peso} kg - {Destino}"
    End Function
End Class
