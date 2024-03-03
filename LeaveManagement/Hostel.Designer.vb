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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Hostel))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.comboHostel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.comboDateRange = New System.Windows.Forms.ComboBox()
        Me.comboType = New System.Windows.Forms.ComboBox()
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
        'comboHostel
        '
        Me.comboHostel.FormattingEnabled = True
        Me.comboHostel.Items.AddRange(New Object() {"All", "Lohit", "Brahmaputra", "Kameng", "Manas", "Barak", "Umiam", "Kapili", "Siang", "Disang", "Dihing", "Maried Scholars"})
        Me.comboHostel.Location = New System.Drawing.Point(119, 33)
        Me.comboHostel.Name = "comboHostel"
        Me.comboHostel.Size = New System.Drawing.Size(183, 24)
        Me.comboHostel.TabIndex = 2
        Me.comboHostel.Text = "All"
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
        Me.Button1.Location = New System.Drawing.Point(763, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 44)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(376, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Date Range"
        '
        'comboStatus
        '
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Items.AddRange(New Object() {"All", "Pending", "Approved", "Rejected"})
        Me.comboStatus.Location = New System.Drawing.Point(119, 63)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(183, 24)
        Me.comboStatus.TabIndex = 2
        Me.comboStatus.Text = "All"
        '
        'comboDateRange
        '
        Me.comboDateRange.FormattingEnabled = True
        Me.comboDateRange.Items.AddRange(New Object() {"All", "Today", "This Week", "This Month", "This Year"})
        Me.comboDateRange.Location = New System.Drawing.Point(478, 36)
        Me.comboDateRange.Name = "comboDateRange"
        Me.comboDateRange.Size = New System.Drawing.Size(183, 24)
        Me.comboDateRange.TabIndex = 2
        Me.comboDateRange.Text = "All"
        '
        'comboType
        '
        Me.comboType.FormattingEnabled = True
        Me.comboType.Items.AddRange(New Object() {"All", "Casual Leave", "Medical Leave", "Academic Leave", "On Duty Leave", "Maternity Leave"})
        Me.comboType.Location = New System.Drawing.Point(119, 96)
        Me.comboType.Name = "comboType"
        Me.comboType.Size = New System.Drawing.Size(183, 24)
        Me.comboType.TabIndex = 2
        Me.comboType.Text = "All"
        '
        'Hostel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 620)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboType)
        Me.Controls.Add(Me.comboDateRange)
        Me.Controls.Add(Me.comboStatus)
        Me.Controls.Add(Me.comboHostel)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Hostel"
        Me.Text = "Hostel"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents comboHostel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents comboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents comboDateRange As System.Windows.Forms.ComboBox
    Friend WithEvents comboType As System.Windows.Forms.ComboBox
End Class
