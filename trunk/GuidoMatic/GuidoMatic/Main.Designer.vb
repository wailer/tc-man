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
        Me.CreatureWorker = New System.ComponentModel.BackgroundWorker
        Me.TabMain.SuspendLayout()
        Me.TabCreature.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabCreature)
        Me.TabMain.Controls.Add(Me.TabGameobject)
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
End Class
