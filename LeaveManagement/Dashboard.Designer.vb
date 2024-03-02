<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.label_leaves_left = New System.Windows.Forms.Label()
        Me.data_active_requests = New System.Windows.Forms.DataGridView()
        Me.active_requests = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.data_active_requests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.label_leaves_left)
        Me.Panel1.Controls.Add(Me.data_active_requests)
        Me.Panel1.Controls.Add(Me.active_requests)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(773, 420)
        Me.Panel1.TabIndex = 15
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(167, 197)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(62, 22)
        Me.TextBox1.TabIndex = 6
        '
        'label_leaves_left
        '
        Me.label_leaves_left.AutoSize = True
        Me.label_leaves_left.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_leaves_left.Location = New System.Drawing.Point(25, 198)
        Me.label_leaves_left.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label_leaves_left.Name = "label_leaves_left"
        Me.label_leaves_left.Size = New System.Drawing.Size(127, 27)
        Me.label_leaves_left.TabIndex = 5
        Me.label_leaves_left.Text = "Leaves Left: "
        '
        'data_active_requests
        '
        Me.data_active_requests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_active_requests.Location = New System.Drawing.Point(26, 72)
        Me.data_active_requests.Margin = New System.Windows.Forms.Padding(4)
        Me.data_active_requests.Name = "data_active_requests"
        Me.data_active_requests.Size = New System.Drawing.Size(713, 92)
        Me.data_active_requests.TabIndex = 4
        '
        'active_requests
        '
        Me.active_requests.AutoSize = True
        Me.active_requests.Font = New System.Drawing.Font("Microsoft YaHei", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.active_requests.Location = New System.Drawing.Point(24, 25)
        Me.active_requests.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.active_requests.Name = "active_requests"
        Me.active_requests.Size = New System.Drawing.Size(279, 32)
        Me.active_requests.TabIndex = 3
        Me.active_requests.Text = "Active Leave Requests"
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 420)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Dashboard"
        Me.Text = "dashboardPanel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.data_active_requests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents label_leaves_left As System.Windows.Forms.Label
    Friend WithEvents data_active_requests As System.Windows.Forms.DataGridView
    Friend WithEvents active_requests As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
