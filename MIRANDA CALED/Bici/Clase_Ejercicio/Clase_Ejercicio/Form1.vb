Public Class Form1

    Private miBicicleta As Bicicleta

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboTipo.Items.Add("Montaña")
        cboTipo.Items.Add("Urbana")
        cboTipo.Items.Add("Eléctrica")
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If String.IsNullOrWhiteSpace(txtCodigo.Text) Then
            MessageBox.Show("Por favor, ingrese el código de la bicicleta.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCodigo.Focus()
            Return
        End If

        If cboTipo.SelectedIndex = -1 Then
            MessageBox.Show("Por favor, seleccione un tipo de bicicleta.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTipo.Focus()
            Return
        End If

        Dim tipo As String = cboTipo.SelectedItem.ToString()
        Dim tarifa As Decimal = 0

        Select Case tipo
            Case "Montaña"
                tarifa = 8D
            Case "Urbana"
                tarifa = 5D
            Case "Eléctrica"
                tarifa = 12D
        End Select

        Try
            miBicicleta = New Bicicleta(txtCodigo.Text.Trim(), tipo, tarifa)
            MessageBox.Show("¡Bicicleta registrada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        If miBicicleta Is Nothing Then
            MessageBox.Show("Primero debe registrar una bicicleta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim horas As Integer
        If Not Integer.TryParse(txtHoras.Text, horas) OrElse horas <= 0 Then
            MessageBox.Show("Ingrese una cantidad de horas válida (número entero mayor a cero).", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHoras.Focus()
            Return
        End If

        miBicicleta.MostrarInformacion(lblResultado, horas)
    End Sub

End Class