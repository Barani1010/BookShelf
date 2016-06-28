<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchBookTX = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchBookCB = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DGV2 = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.DGV3 = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.DGV4 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewStaffMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditStaffInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveStaffMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShelfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewShelfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditShelfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveShelfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(0, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(655, 385)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DGV)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(647, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Staff Members"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(6, 6)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV.Size = New System.Drawing.Size(635, 295)
        Me.DGV.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ToolStrip1)
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(647, 359)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Data Entry"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchBookTX, Me.ToolStripLabel2, Me.SearchBookCB, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(641, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripLabel1.Text = "Search:"
        '
        'SearchBookTX
        '
        Me.SearchBookTX.Name = "SearchBookTX"
        Me.SearchBookTX.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(17, 22)
        Me.ToolStripLabel2.Text = "in"
        '
        'SearchBookCB
        '
        Me.SearchBookCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchBookCB.Name = "SearchBookCB"
        Me.SearchBookCB.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.BackColor = System.Drawing.Color.LightGray
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripButton1.Text = "Search"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.BackColor = System.Drawing.Color.Silver
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(85, 22)
        Me.ToolStripButton2.Text = "Cancel Search"
        '
        'TabControl2
        '
        Me.TabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Location = New System.Drawing.Point(0, 34)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(641, 319)
        Me.TabControl2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DGV2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(633, 293)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Shelves"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(-4, 0)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV2.Size = New System.Drawing.Size(641, 285)
        Me.DGV2.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DGV3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(633, 293)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Books"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(-4, 8)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV3.Size = New System.Drawing.Size(641, 277)
        Me.DGV3.TabIndex = 2
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.DGV4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(647, 359)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "Students"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'DGV4
        '
        Me.DGV4.AllowUserToAddRows = False
        Me.DGV4.AllowUserToDeleteRows = False
        Me.DGV4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV4.Location = New System.Drawing.Point(0, 6)
        Me.DGV4.Name = "DGV4"
        Me.DGV4.ReadOnly = True
        Me.DGV4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV4.Size = New System.Drawing.Size(641, 347)
        Me.DGV4.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StaffToolStripMenuItem, Me.ShelfToolStripMenuItem, Me.BookToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(667, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StaffToolStripMenuItem
        '
        Me.StaffToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewStaffMemberToolStripMenuItem, Me.EditStaffInformationToolStripMenuItem, Me.RemoveStaffMemberToolStripMenuItem})
        Me.StaffToolStripMenuItem.Name = "StaffToolStripMenuItem"
        Me.StaffToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.StaffToolStripMenuItem.Text = "Staff"
        '
        'AddNewStaffMemberToolStripMenuItem
        '
        Me.AddNewStaffMemberToolStripMenuItem.Name = "AddNewStaffMemberToolStripMenuItem"
        Me.AddNewStaffMemberToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AddNewStaffMemberToolStripMenuItem.Text = "Add New Staff Member"
        '
        'EditStaffInformationToolStripMenuItem
        '
        Me.EditStaffInformationToolStripMenuItem.Name = "EditStaffInformationToolStripMenuItem"
        Me.EditStaffInformationToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.EditStaffInformationToolStripMenuItem.Text = "Edit Staff Member"
        '
        'RemoveStaffMemberToolStripMenuItem
        '
        Me.RemoveStaffMemberToolStripMenuItem.Name = "RemoveStaffMemberToolStripMenuItem"
        Me.RemoveStaffMemberToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.RemoveStaffMemberToolStripMenuItem.Text = "Remove Staff Member"
        '
        'ShelfToolStripMenuItem
        '
        Me.ShelfToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewShelfToolStripMenuItem, Me.EditShelfToolStripMenuItem, Me.RemoveShelfToolStripMenuItem})
        Me.ShelfToolStripMenuItem.Name = "ShelfToolStripMenuItem"
        Me.ShelfToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.ShelfToolStripMenuItem.Text = "Shelf"
        '
        'AddNewShelfToolStripMenuItem
        '
        Me.AddNewShelfToolStripMenuItem.Name = "AddNewShelfToolStripMenuItem"
        Me.AddNewShelfToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddNewShelfToolStripMenuItem.Text = "Add New Shelf"
        '
        'EditShelfToolStripMenuItem
        '
        Me.EditShelfToolStripMenuItem.Name = "EditShelfToolStripMenuItem"
        Me.EditShelfToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditShelfToolStripMenuItem.Text = "Edit Shelf"
        '
        'RemoveShelfToolStripMenuItem
        '
        Me.RemoveShelfToolStripMenuItem.Name = "RemoveShelfToolStripMenuItem"
        Me.RemoveShelfToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemoveShelfToolStripMenuItem.Text = "Remove Shelf"
        '
        'BookToolStripMenuItem
        '
        Me.BookToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewBookToolStripMenuItem, Me.EditBookToolStripMenuItem, Me.RemoveBookToolStripMenuItem})
        Me.BookToolStripMenuItem.Name = "BookToolStripMenuItem"
        Me.BookToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.BookToolStripMenuItem.Text = "Book"
        '
        'AddNewBookToolStripMenuItem
        '
        Me.AddNewBookToolStripMenuItem.Name = "AddNewBookToolStripMenuItem"
        Me.AddNewBookToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.AddNewBookToolStripMenuItem.Text = "Add New Book"
        '
        'EditBookToolStripMenuItem
        '
        Me.EditBookToolStripMenuItem.Name = "EditBookToolStripMenuItem"
        Me.EditBookToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.EditBookToolStripMenuItem.Text = "Edit Book"
        '
        'RemoveBookToolStripMenuItem
        '
        Me.RemoveBookToolStripMenuItem.Name = "RemoveBookToolStripMenuItem"
        Me.RemoveBookToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.RemoveBookToolStripMenuItem.Text = "Remove Book"
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewStudentToolStripMenuItem, Me.EditStudentToolStripMenuItem, Me.SetToolStripMenuItem, Me.ToolStripMenuItem1, Me.RemoveStudentToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.StudentToolStripMenuItem.Text = "Student"
        '
        'AddNewStudentToolStripMenuItem
        '
        Me.AddNewStudentToolStripMenuItem.Name = "AddNewStudentToolStripMenuItem"
        Me.AddNewStudentToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AddNewStudentToolStripMenuItem.Text = "Add New Student"
        '
        'EditStudentToolStripMenuItem
        '
        Me.EditStudentToolStripMenuItem.Name = "EditStudentToolStripMenuItem"
        Me.EditStudentToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.EditStudentToolStripMenuItem.Text = "Edit Student"
        '
        'SetToolStripMenuItem
        '
        Me.SetToolStripMenuItem.Name = "SetToolStripMenuItem"
        Me.SetToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SetToolStripMenuItem.Text = "Set Password"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(164, 6)
        '
        'RemoveStudentToolStripMenuItem
        '
        Me.RemoveStudentToolStripMenuItem.Name = "RemoveStudentToolStripMenuItem"
        Me.RemoveStudentToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RemoveStudentToolStripMenuItem.Text = "Remove Student"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(167, 22)
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 438)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Book Bank "
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StaffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewStaffMemberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditStaffInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveStaffMemberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents ShelfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewShelfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditShelfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveShelfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents BookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SearchBookTX As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SearchBookCB As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewStudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditStudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveStudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem

End Class
