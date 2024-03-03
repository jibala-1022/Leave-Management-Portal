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
        Me.label_leaves_left = New System.Windows.Forms.Label()
        Me.data_active_requests = New System.Windows.Forms.DataGridView()
        Me.active_requests = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Casual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Academic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.On_Duty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maternal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.data_active_requests, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.label_leaves_left)
        Me.Panel1.Controls.Add(Me.data_active_requests)
        Me.Panel1.Controls.Add(Me.active_requests)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(580, 341)
        Me.Panel1.TabIndex = 15
        '
        'label_leaves_left
        '
        Me.label_leaves_left.AutoSize = True
        Me.label_leaves_left.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_leaves_left.Location = New System.Drawing.Point(16, 252)
        Me.label_leaves_left.Name = "label_leaves_left"
        Me.label_leaves_left.Size = New System.Drawing.Size(94, 21)
        Me.label_leaves_left.TabIndex = 5
        Me.label_leaves_left.Text = "Leaves Left"
        '
        'data_active_requests
        '
        Me.data_active_requests.BackgroundColor = System.Drawing.SystemColors.Control
        Me.data_active_requests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.data_active_requests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_active_requests.Location = New System.Drawing.Point(20, 58)
        Me.data_active_requests.Name = "data_active_requests"
        Me.data_active_requests.Size = New System.Drawing.Size(535, 191)
        Me.data_active_requests.TabIndex = 4
        '
        'active_requests
        '
        Me.active_requests.AutoSize = True
        Me.active_requests.Font = New System.Drawing.Font("Microsoft YaHei", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.active_requests.Location = New System.Drawing.Point(18, 20)
        Me.active_requests.Name = "active_requests"
        Me.active_requests.Size = New System.Drawing.Size(221, 27)
        Me.active_requests.TabIndex = 3
        Me.active_requests.Text = "Active Leave Requests"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Casual, Me.Academic, Me.Medical, Me.On_Duty, Me.Maternal})
        Me.DataGridView1.Location = New System.Drawing.Point(20, 276)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(535, 53)
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
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 341)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Dashboard"
        Me.Text = "dashboardPanel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.data_active_requests, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents label_leaves_left As System.Windows.Forms.Label
    Friend WithEvents data_active_requests As System.Windows.Forms.DataGridView
    Friend WithEvents active_requests As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Casual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Academic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Medical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents On_Duty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Maternal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
