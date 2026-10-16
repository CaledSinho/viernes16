Public Class Form1
    ' Se cargan las opciones del ComboBox al iniciar la ventana
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDestino.Items.Clear()
        cboDestino.Items.Add("Local")
        cboDestino.Items.Add("Nacional")
    End Sub

    ' Registrar el paquete en el ListBox
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        ' Validación de Código
        If String.IsNullOrWhiteSpace(txtCodigo.Text) Then
            MessageBox.Show("Ingrese un código válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validación de Peso
        Dim peso As Decimal
        If Not Decimal.TryParse(txtPeso.Text, peso) OrElse peso <= 0 Then
            MessageBox.Show("Ingrese un peso válido (mayor a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validación de Destino
        If cboDestino.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un destino.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Crear paquete e insertarlo en el ListBox
            Dim nuevoPaquete As New Paquete(txtCodigo.Text.Trim(), peso, cboDestino.SelectedItem.ToString())
            lstPaquetes.Items.Add(nuevoPaquete)

            ' Limpiar cajas
            txtCodigo.Clear()
            txtPeso.Clear()
            cboDestino.SelectedIndex = -1
            lblResultado.Text = "Paquete registrado en la lista."

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Calcular costo del paquete seleccionado en el ListBox
    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        If lstPaquetes.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un paquete de la lista para calcular el costo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Obtener paquete seleccionado
        Dim paqueteSeleccionado As Paquete = CType(lstPaquetes.SelectedItem, Paquete)

        ' Calcular envío
        Dim costoTotal As Decimal = paqueteSeleccionado.CalcularEnvio()

        ' Mostrar resultado
        lblResultado.Text = $"Código: {paqueteSeleccionado.Codigo}" & vbCrLf &
                            $"Peso: {paqueteSeleccionado.Peso} kg" & vbCrLf &
                            $"Destino: {paqueteSeleccionado.Destino}" & vbCrLf &
                            $"Costo Envío: S/ {costoTotal:F2}"
    End Sub
End Class