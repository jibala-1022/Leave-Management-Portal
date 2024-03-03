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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Casual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Academic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.On_Duty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maternal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_active_requests = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.data_active_requests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.data_active_requests)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(773, 420)
        Me.Panel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(21, 303)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 30)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "LEAVES LEFT"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft YaHei", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label11.Location = New System.Drawing.Point(20, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(296, 30)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "ACTIVE LEAVE REQUESTS"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Casual, Me.Academic, Me.Medical, Me.On_Duty, Me.Maternal})
        Me.DataGridView1.Location = New System.Drawing.Point(27, 340)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(713, 65)
        Me.DataGridView1.TabIndex = 16
        '
        'Casual
        '
        Me.Casual.HeaderText = "Casual"
        Me.Casual.Name = "Casual"
        Me.Casual.ReadOnly = True
        '
        'Academic
        '
        Me.Academic.HeaderText = "Academic"
        Me.Academic.Name = "Academic"
        Me.Academic.ReadOnly = True
        '
        'Medical
        '
        Me.Medical.HeaderText = "Medical"
        Me.Medical.Name = "Medical"
        Me.Medical.ReadOnly = True
        '
        'On_Duty
        '
        Me.On_Duty.HeaderText = "On Duty"
        Me.On_Duty.Name = "On_Duty"
        Me.On_Duty.ReadOnly = True
        '
        'Maternal
        '
        Me.Maternal.HeaderText = "Maternal"
        Me.Maternal.Name = "Maternal"
        Me.Maternal.ReadOnly = True
        '
        'data_active_requests
        '
        Me.data_active_requests.BackgroundColor = System.Drawing.SystemColors.Control
        Me.data_active_requests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.data_active_requests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_active_requests.Location = New System.Drawing.Point(27, 71)
        Me.data_active_requests.Margin = New System.Windows.Forms.Padding(4)
        Me.data_active_requests.Name = "data_active_requests"
        Me.data_active_requests.Size = New System.Drawing.Size(713, 235)
        Me.data_active_requests.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 17)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "No Pending Leaves!"
        Me.Label2.Visible = False
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 420)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Dashboard"
        Me.Text = "dashboardPanel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.data_active_requests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents data_active_requests As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Casual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Academic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Medical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents On_Duty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Maternal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
