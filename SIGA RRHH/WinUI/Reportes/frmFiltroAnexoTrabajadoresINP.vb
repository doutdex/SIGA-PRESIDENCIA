﻿Imports cl.presidencia.Argo.Reportes

Public Class frmFiltroAnexoTrabajadoresINP
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents cboPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVisualizar As DevExpress.XtraEditors.SimpleButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cboPeriodo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton
        Me.btnVisualizar = New DevExpress.XtraEditors.SimpleButton
        Me.SuspendLayout()
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Location = New System.Drawing.Point(8, 24)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(284, 21)
        Me.cboPeriodo.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Período"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(8, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(122, 23)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(168, 56)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(122, 23)
        Me.btnVisualizar.TabIndex = 28
        Me.btnVisualizar.Text = "Visualizar"
        '
        'frmFiltroAnexoTrabajadoresINP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 110)
        Me.Controls.Add(Me.cboPeriodo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnVisualizar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltroAnexoTrabajadoresINP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla Anexo Trabajadores INP"
        Me.ResumeLayout(False)

    End Sub

#End Region
    
    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ventanaReporte1 As New ventanaReporte
        Dim reporte As New rptAnexoTrabajadoresINP
        WinUI.UtilCrystalReports.UtilReport.setConnection(reporte)
        Dim strFormulaSeleccion = "{VW_IMPOSICIONES.PERIODO_ID}=" & Me.cboPeriodo.SelectedValue
        strFormulaSeleccion &= " AND {VW_IMPOSICIONES.REGIMEN_PREVISIONAL_AFP}=""INP"""
        ventanaReporte1.rptVisor.SelectionFormula = strFormulaSeleccion
        ventanaReporte1.rptVisor.DisplayGroupTree = False
        ventanaReporte1.rptVisor.ReportSource = reporte
        ventanaReporte1.Show()
        Me.Close()
    End Sub

    Private Sub frmFiltroAnexoTrabajadoresINP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboPeriodo.DisplayMember = "DESCRIPCION_PERIODO"
        cboPeriodo.ValueMember = "PERIODO_ID"

        repositorio.Show()
        cboPeriodo.DataSource = repositorio.dvPeriodo
        cboPeriodo.Refresh()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class
