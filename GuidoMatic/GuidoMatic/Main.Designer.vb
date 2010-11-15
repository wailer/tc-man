<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabMain = New System.Windows.Forms.TabControl
        Me.TabCreature = New System.Windows.Forms.TabPage
        Me.lChangedGuidsValue = New System.Windows.Forms.Label
        Me.lSpawnsValue = New System.Windows.Forms.Label
        Me.lGuidsChanged = New System.Windows.Forms.Label
        Me.lSpawns = New System.Windows.Forms.Label
        Me.bReorderCreature = New System.Windows.Forms.Button
        Me.ProgressCreatureGuids = New System.Windows.Forms.ProgressBar
        Me.TabGameobject = New System.Windows.Forms.TabPage
        Me.TabDuplicar = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.tItemNuevoNombre = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tItemNuevoDisplay = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tItemIDnuevo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.tItemIDOriginal = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Creatures = New System.Windows.Forms.GroupBox
        Me.bDuplicaCreature = New System.Windows.Forms.Button
        Me.tcreatureNombreNuevo = New System.Windows.Forms.TextBox
        Me.lnuevonombrecreature = New System.Windows.Forms.Label
        Me.tcreatureDisplayNuevo = New System.Windows.Forms.TextBox
        Me.lnuevadisplay = New System.Windows.Forms.Label
        Me.tcreatureNuevaID = New System.Windows.Forms.TextBox
        Me.lnuevaidcreature = New System.Windows.Forms.Label
        Me.tcreatureIdOrigen = New System.Windows.Forms.TextBox
        Me.lcreatureid = New System.Windows.Forms.Label
        Me.CreatureWorker = New System.ComponentModel.BackgroundWorker
        Me.TabMain.SuspendLayout()
        Me.TabCreature.SuspendLayout()
        Me.TabDuplicar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Creatures.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabCreature)
        Me.TabMain.Controls.Add(Me.TabGameobject)
        Me.TabMain.Controls.Add(Me.TabDuplicar)
        Me.TabMain.Location = New System.Drawing.Point(12, 12)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(688, 319)
        Me.TabMain.TabIndex = 0
        '
        'TabCreature
        '
        Me.TabCreature.Controls.Add(Me.lChangedGuidsValue)
        Me.TabCreature.Controls.Add(Me.lSpawnsValue)
        Me.TabCreature.Controls.Add(Me.lGuidsChanged)
        Me.TabCreature.Controls.Add(Me.lSpawns)
        Me.TabCreature.Controls.Add(Me.bReorderCreature)
        Me.TabCreature.Controls.Add(Me.ProgressCreatureGuids)
        Me.TabCreature.Location = New System.Drawing.Point(4, 22)
        Me.TabCreature.Name = "TabCreature"
        Me.TabCreature.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCreature.Size = New System.Drawing.Size(680, 293)
        Me.TabCreature.TabIndex = 0
        Me.TabCreature.Text = "Creature Guids"
        Me.TabCreature.UseVisualStyleBackColor = True
        '
        'lChangedGuidsValue
        '
        Me.lChangedGuidsValue.AutoSize = True
        Me.lChangedGuidsValue.Location = New System.Drawing.Point(471, 168)
        Me.lChangedGuidsValue.Name = "lChangedGuidsValue"
        Me.lChangedGuidsValue.Size = New System.Drawing.Size(0, 13)
        Me.lChangedGuidsValue.TabIndex = 5
        '
        'lSpawnsValue
        '
        Me.lSpawnsValue.AutoSize = True
        Me.lSpawnsValue.Location = New System.Drawing.Point(274, 168)
        Me.lSpawnsValue.Name = "lSpawnsValue"
        Me.lSpawnsValue.Size = New System.Drawing.Size(0, 13)
        Me.lSpawnsValue.TabIndex = 4
        '
        'lGuidsChanged
        '
        Me.lGuidsChanged.AutoSize = True
        Me.lGuidsChanged.Location = New System.Drawing.Point(378, 169)
        Me.lGuidsChanged.Name = "lGuidsChanged"
        Me.lGuidsChanged.Size = New System.Drawing.Size(86, 13)
        Me.lGuidsChanged.TabIndex = 3
        Me.lGuidsChanged.Text = "Changed Guids :"
        '
        'lSpawns
        '
        Me.lSpawns.AutoSize = True
        Me.lSpawns.Location = New System.Drawing.Point(195, 169)
        Me.lSpawns.Name = "lSpawns"
        Me.lSpawns.Size = New System.Drawing.Size(81, 13)
        Me.lSpawns.TabIndex = 2
        Me.lSpawns.Text = "Total Spawns : "
        '
        'bReorderCreature
        '
        Me.bReorderCreature.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bReorderCreature.Location = New System.Drawing.Point(223, 28)
        Me.bReorderCreature.Name = "bReorderCreature"
        Me.bReorderCreature.Size = New System.Drawing.Size(219, 56)
        Me.bReorderCreature.TabIndex = 1
        Me.bReorderCreature.Text = "Start!"
        Me.bReorderCreature.UseVisualStyleBackColor = True
        '
        'ProgressCreatureGuids
        '
        Me.ProgressCreatureGuids.Location = New System.Drawing.Point(45, 220)
        Me.ProgressCreatureGuids.Name = "ProgressCreatureGuids"
        Me.ProgressCreatureGuids.Size = New System.Drawing.Size(581, 23)
        Me.ProgressCreatureGuids.TabIndex = 0
        '
        'TabGameobject
        '
        Me.TabGameobject.Location = New System.Drawing.Point(4, 22)
        Me.TabGameobject.Name = "TabGameobject"
        Me.TabGameobject.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGameobject.Size = New System.Drawing.Size(680, 293)
        Me.TabGameobject.TabIndex = 1
        Me.TabGameobject.Text = "GameObject Guids"
        Me.TabGameobject.UseVisualStyleBackColor = True
        '
        'TabDuplicar
        '
        Me.TabDuplicar.Controls.Add(Me.GroupBox1)
        Me.TabDuplicar.Controls.Add(Me.Creatures)
        Me.TabDuplicar.Location = New System.Drawing.Point(4, 22)
        Me.TabDuplicar.Name = "TabDuplicar"
        Me.TabDuplicar.Size = New System.Drawing.Size(680, 293)
        Me.TabDuplicar.TabIndex = 2
        Me.TabDuplicar.Text = "Duplicar"
        Me.TabDuplicar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.tItemNuevoNombre)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tItemNuevoDisplay)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tItemIDnuevo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tItemIDOriginal)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(673, 76)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "l"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(279, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Duplicar Item"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tItemNuevoNombre
        '
        Me.tItemNuevoNombre.Location = New System.Drawing.Point(568, 16)
        Me.tItemNuevoNombre.Name = "tItemNuevoNombre"
        Me.tItemNuevoNombre.Size = New System.Drawing.Size(100, 20)
        Me.tItemNuevoNombre.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(484, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Nuevo Nombre"
        '
        'tItemNuevoDisplay
        '
        Me.tItemNuevoDisplay.Location = New System.Drawing.Point(407, 17)
        Me.tItemNuevoDisplay.Name = "tItemNuevoDisplay"
        Me.tItemNuevoDisplay.Size = New System.Drawing.Size(72, 20)
        Me.tItemNuevoDisplay.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(326, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Nueva Display"
        '
        'tItemIDnuevo
        '
        Me.tItemIDnuevo.Location = New System.Drawing.Point(239, 17)
        Me.tItemIDnuevo.Name = "tItemIDnuevo"
        Me.tItemIDnuevo.Size = New System.Drawing.Size(80, 20)
        Me.tItemIDnuevo.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(180, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Nueva ID "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "ID Item Original"
        '
        'tItemIDOriginal
        '
        Me.tItemIDOriginal.Location = New System.Drawing.Point(90, 17)
        Me.tItemIDOriginal.Name = "tItemIDOriginal"
        Me.tItemIDOriginal.Size = New System.Drawing.Size(75, 20)
        Me.tItemIDOriginal.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(0, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(673, 76)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Items"
        '
        'Creatures
        '
        Me.Creatures.Controls.Add(Me.bDuplicaCreature)
        Me.Creatures.Controls.Add(Me.tcreatureNombreNuevo)
        Me.Creatures.Controls.Add(Me.lnuevonombrecreature)
        Me.Creatures.Controls.Add(Me.tcreatureDisplayNuevo)
        Me.Creatures.Controls.Add(Me.lnuevadisplay)
        Me.Creatures.Controls.Add(Me.tcreatureNuevaID)
        Me.Creatures.Controls.Add(Me.lnuevaidcreature)
        Me.Creatures.Controls.Add(Me.tcreatureIdOrigen)
        Me.Creatures.Controls.Add(Me.lcreatureid)
        Me.Creatures.Location = New System.Drawing.Point(4, 80)
        Me.Creatures.Name = "Creatures"
        Me.Creatures.Size = New System.Drawing.Size(673, 91)
        Me.Creatures.TabIndex = 10
        Me.Creatures.TabStop = False
        Me.Creatures.Text = "Creatures"
        '
        'bDuplicaCreature
        '
        Me.bDuplicaCreature.Location = New System.Drawing.Point(279, 62)
        Me.bDuplicaCreature.Name = "bDuplicaCreature"
        Me.bDuplicaCreature.Size = New System.Drawing.Size(120, 23)
        Me.bDuplicaCreature.TabIndex = 8
        Me.bDuplicaCreature.Text = "Duplicar Creature"
        Me.bDuplicaCreature.UseVisualStyleBackColor = True
        '
        'tcreatureNombreNuevo
        '
        Me.tcreatureNombreNuevo.Location = New System.Drawing.Point(569, 27)
        Me.tcreatureNombreNuevo.Name = "tcreatureNombreNuevo"
        Me.tcreatureNombreNuevo.Size = New System.Drawing.Size(100, 20)
        Me.tcreatureNombreNuevo.TabIndex = 7
        '
        'lnuevonombrecreature
        '
        Me.lnuevonombrecreature.AutoSize = True
        Me.lnuevonombrecreature.Location = New System.Drawing.Point(487, 32)
        Me.lnuevonombrecreature.Name = "lnuevonombrecreature"
        Me.lnuevonombrecreature.Size = New System.Drawing.Size(79, 13)
        Me.lnuevonombrecreature.TabIndex = 6
        Me.lnuevonombrecreature.Text = "Nuevo Nombre"
        '
        'tcreatureDisplayNuevo
        '
        Me.tcreatureDisplayNuevo.Location = New System.Drawing.Point(403, 27)
        Me.tcreatureDisplayNuevo.Name = "tcreatureDisplayNuevo"
        Me.tcreatureDisplayNuevo.Size = New System.Drawing.Size(76, 20)
        Me.tcreatureDisplayNuevo.TabIndex = 5
        '
        'lnuevadisplay
        '
        Me.lnuevadisplay.AutoSize = True
        Me.lnuevadisplay.Location = New System.Drawing.Point(323, 31)
        Me.lnuevadisplay.Name = "lnuevadisplay"
        Me.lnuevadisplay.Size = New System.Drawing.Size(76, 13)
        Me.lnuevadisplay.TabIndex = 4
        Me.lnuevadisplay.Text = "Nueva Display"
        '
        'tcreatureNuevaID
        '
        Me.tcreatureNuevaID.Location = New System.Drawing.Point(236, 28)
        Me.tcreatureNuevaID.Name = "tcreatureNuevaID"
        Me.tcreatureNuevaID.Size = New System.Drawing.Size(83, 20)
        Me.tcreatureNuevaID.TabIndex = 3
        '
        'lnuevaidcreature
        '
        Me.lnuevaidcreature.AutoSize = True
        Me.lnuevaidcreature.Location = New System.Drawing.Point(177, 33)
        Me.lnuevaidcreature.Name = "lnuevaidcreature"
        Me.lnuevaidcreature.Size = New System.Drawing.Size(53, 13)
        Me.lnuevaidcreature.TabIndex = 2
        Me.lnuevaidcreature.Text = "Nueva ID"
        '
        'tcreatureIdOrigen
        '
        Me.tcreatureIdOrigen.Location = New System.Drawing.Point(76, 30)
        Me.tcreatureIdOrigen.Name = "tcreatureIdOrigen"
        Me.tcreatureIdOrigen.Size = New System.Drawing.Size(89, 20)
        Me.tcreatureIdOrigen.TabIndex = 1
        '
        'lcreatureid
        '
        Me.lcreatureid.AutoSize = True
        Me.lcreatureid.Location = New System.Drawing.Point(9, 35)
        Me.lcreatureid.Name = "lcreatureid"
        Me.lcreatureid.Size = New System.Drawing.Size(61, 13)
        Me.lcreatureid.TabIndex = 0
        Me.lcreatureid.Text = "ID Creature"
        '
        'CreatureWorker
        '
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 343)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.TabMain.ResumeLayout(False)
        Me.TabCreature.ResumeLayout(False)
        Me.TabCreature.PerformLayout()
        Me.TabDuplicar.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Creatures.ResumeLayout(False)
        Me.Creatures.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabCreature As System.Windows.Forms.TabPage
    Friend WithEvents TabGameobject As System.Windows.Forms.TabPage
    Friend WithEvents bReorderCreature As System.Windows.Forms.Button
    Friend WithEvents ProgressCreatureGuids As System.Windows.Forms.ProgressBar
    Friend WithEvents lGuidsChanged As System.Windows.Forms.Label
    Friend WithEvents lSpawns As System.Windows.Forms.Label
    Friend WithEvents lChangedGuidsValue As System.Windows.Forms.Label
    Friend WithEvents lSpawnsValue As System.Windows.Forms.Label
    Friend WithEvents CreatureWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabDuplicar As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tItemNuevoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tItemNuevoDisplay As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tItemIDnuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tItemIDOriginal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Creatures As System.Windows.Forms.GroupBox
    Friend WithEvents lnuevadisplay As System.Windows.Forms.Label
    Friend WithEvents tcreatureNuevaID As System.Windows.Forms.TextBox
    Friend WithEvents lnuevaidcreature As System.Windows.Forms.Label
    Friend WithEvents tcreatureIdOrigen As System.Windows.Forms.TextBox
    Friend WithEvents lcreatureid As System.Windows.Forms.Label
    Friend WithEvents lnuevonombrecreature As System.Windows.Forms.Label
    Friend WithEvents tcreatureDisplayNuevo As System.Windows.Forms.TextBox
    Friend WithEvents tcreatureNombreNuevo As System.Windows.Forms.TextBox
    Friend WithEvents bDuplicaCreature As System.Windows.Forms.Button
End Class
