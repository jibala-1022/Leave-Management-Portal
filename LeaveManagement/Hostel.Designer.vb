<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Hostel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.comboHostels = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(26, 164)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(891, 430)
        Me.DataGridView1.TabIndex = 0
        '
        'comboHostels
        '
        Me.comboHostels.FormattingEnabled = True
        Me.comboHostels.Items.AddRange(New Object() {"All", "Lohit", "Brahmaputra", "Kameng", "Manas", "Barak", "Umiam", "Kapili", "Siang", "Disang", "Dihing", "Maried Scholars"})
        Me.comboHostels.Location = New System.Drawing.Point(119, 33)
        Me.comboHostels.Name = "comboHostels"
        Me.comboHostels.Size = New System.Drawing.Size(183, 24)
        Me.comboHostels.TabIndex = 2
        Me.comboHostels.Text = "All"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Hostel"
        '
        'comboStatus
        '
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Items.AddRange(New Object() {"All", "pending", "approved", "rejected"})
        Me.comboStatus.Location = New System.Drawing.Point(119, 63)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(183, 24)
        Me.comboStatus.TabIndex = 2
        Me.comboStatus.Text = "All"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Status"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(695, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 44)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Hostel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 620)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboStatus)
        Me.Controls.Add(Me.comboHostels)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Hostel"
        Me.Text = "Hostel"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents comboHostels As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents comboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
