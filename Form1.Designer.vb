<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtentete = New System.Windows.Forms.TextBox()
        Me.grbrecherche = New System.Windows.Forms.GroupBox()
        Me.btnrechercher = New System.Windows.Forms.Button()
        Me.txtrecherche = New System.Windows.Forms.TextBox()
        Me.txtentete2 = New System.Windows.Forms.TextBox()
        Me.grbinfo = New System.Windows.Forms.GroupBox()
        Me.cmbcategorie = New System.Windows.Forms.ComboBox()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.tslblstatut = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblcategorie = New System.Windows.Forms.Label()
        Me.nudannee = New System.Windows.Forms.NumericUpDown()
        Me.btnenregistrer = New System.Windows.Forms.Button()
        Me.btnannuler = New System.Windows.Forms.Button()
        Me.nudquantite = New System.Windows.Forms.NumericUpDown()
        Me.cbbgenre = New System.Windows.Forms.ComboBox()
        Me.lblquantite = New System.Windows.Forms.Label()
        Me.txtisbn = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblisbn = New System.Windows.Forms.Label()
        Me.txtauteur = New System.Windows.Forms.TextBox()
        Me.txtTitre = New System.Windows.Forms.TextBox()
        Me.lbltitre = New System.Windows.Forms.Label()
        Me.lblauteur = New System.Windows.Forms.Label()
        Me.lblanneepub = New System.Windows.Forms.Label()
        Me.grbliste = New System.Windows.Forms.GroupBox()
        Me.dgvliste = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.grbbouton = New System.Windows.Forms.GroupBox()
        Me.btnmodifier = New System.Windows.Forms.Button()
        Me.btnsupprimer = New System.Windows.Forms.Button()
        Me.btnajouter = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.id_livres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Auteur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anneepublication = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ISBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.genre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categorie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcategorie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbrecherche.SuspendLayout()
        Me.grbinfo.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        CType(Me.nudannee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudquantite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbliste.SuspendLayout()
        CType(Me.dgvliste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.grbbouton.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtentete
        '
        Me.txtentete.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtentete.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtentete.Location = New System.Drawing.Point(12, 12)
        Me.txtentete.Name = "txtentete"
        Me.txtentete.ReadOnly = True
        Me.txtentete.Size = New System.Drawing.Size(860, 13)
        Me.txtentete.TabIndex = 0
        Me.txtentete.Text = "GESTION DE LA BIBLIOTHEQUE "
        Me.txtentete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grbrecherche
        '
        Me.grbrecherche.Controls.Add(Me.btnrechercher)
        Me.grbrecherche.Controls.Add(Me.txtrecherche)
        Me.grbrecherche.Location = New System.Drawing.Point(383, 70)
        Me.grbrecherche.Name = "grbrecherche"
        Me.grbrecherche.Size = New System.Drawing.Size(489, 49)
        Me.grbrecherche.TabIndex = 1
        Me.grbrecherche.TabStop = False
        Me.grbrecherche.Text = "Rechercher un livre"
        '
        'btnrechercher
        '
        Me.btnrechercher.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnrechercher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrechercher.Location = New System.Drawing.Point(408, 16)
        Me.btnrechercher.Name = "btnrechercher"
        Me.btnrechercher.Size = New System.Drawing.Size(75, 23)
        Me.btnrechercher.TabIndex = 1
        Me.btnrechercher.Text = "Rechercher"
        Me.btnrechercher.UseVisualStyleBackColor = False
        '
        'txtrecherche
        '
        Me.txtrecherche.Location = New System.Drawing.Point(6, 19)
        Me.txtrecherche.Name = "txtrecherche"
        Me.txtrecherche.Size = New System.Drawing.Size(396, 20)
        Me.txtrecherche.TabIndex = 0
        Me.txtrecherche.Text = "rechercher un livres par ISBN"
        '
        'txtentete2
        '
        Me.txtentete2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtentete2.Location = New System.Drawing.Point(12, 28)
        Me.txtentete2.Name = "txtentete2"
        Me.txtentete2.ReadOnly = True
        Me.txtentete2.Size = New System.Drawing.Size(860, 13)
        Me.txtentete2.TabIndex = 2
        Me.txtentete2.Text = "Application vb.net /mySQL complete avec operation CRUD"
        Me.txtentete2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grbinfo
        '
        Me.grbinfo.Controls.Add(Me.cmbcategorie)
        Me.grbinfo.Controls.Add(Me.StatusStrip2)
        Me.grbinfo.Controls.Add(Me.lblcategorie)
        Me.grbinfo.Controls.Add(Me.nudannee)
        Me.grbinfo.Controls.Add(Me.btnenregistrer)
        Me.grbinfo.Controls.Add(Me.btnannuler)
        Me.grbinfo.Controls.Add(Me.nudquantite)
        Me.grbinfo.Controls.Add(Me.cbbgenre)
        Me.grbinfo.Controls.Add(Me.lblquantite)
        Me.grbinfo.Controls.Add(Me.txtisbn)
        Me.grbinfo.Controls.Add(Me.Label2)
        Me.grbinfo.Controls.Add(Me.lblisbn)
        Me.grbinfo.Controls.Add(Me.txtauteur)
        Me.grbinfo.Controls.Add(Me.txtTitre)
        Me.grbinfo.Controls.Add(Me.lbltitre)
        Me.grbinfo.Controls.Add(Me.lblauteur)
        Me.grbinfo.Controls.Add(Me.lblanneepub)
        Me.grbinfo.Enabled = False
        Me.grbinfo.Location = New System.Drawing.Point(12, 120)
        Me.grbinfo.Name = "grbinfo"
        Me.grbinfo.Size = New System.Drawing.Size(365, 343)
        Me.grbinfo.TabIndex = 3
        Me.grbinfo.TabStop = False
        Me.grbinfo.Text = "Information sur le livre"
        '
        'cmbcategorie
        '
        Me.cmbcategorie.FormattingEnabled = True
        Me.cmbcategorie.Items.AddRange(New Object() {"jeunesse", "young adult", "new adult", "adult", "bande dessine", "beaux livres", "manuel"})
        Me.cmbcategorie.Location = New System.Drawing.Point(31, 267)
        Me.cmbcategorie.Name = "cmbcategorie"
        Me.cmbcategorie.Size = New System.Drawing.Size(328, 21)
        Me.cmbcategorie.TabIndex = 9
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblstatut})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 318)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(359, 22)
        Me.StatusStrip2.TabIndex = 11
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'tslblstatut
        '
        Me.tslblstatut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tslblstatut.Name = "tslblstatut"
        Me.tslblstatut.Size = New System.Drawing.Size(53, 17)
        Me.tslblstatut.Text = "Message"
        '
        'lblcategorie
        '
        Me.lblcategorie.AutoSize = True
        Me.lblcategorie.Location = New System.Drawing.Point(6, 251)
        Me.lblcategorie.Name = "lblcategorie"
        Me.lblcategorie.Size = New System.Drawing.Size(88, 13)
        Me.lblcategorie.TabIndex = 8
        Me.lblcategorie.Text = "categorie du livre"
        '
        'nudannee
        '
        Me.nudannee.Location = New System.Drawing.Point(31, 110)
        Me.nudannee.Maximum = New Decimal(New Integer() {2027, 0, 0, 0})
        Me.nudannee.Minimum = New Decimal(New Integer() {1400, 0, 0, 0})
        Me.nudannee.Name = "nudannee"
        Me.nudannee.Size = New System.Drawing.Size(328, 20)
        Me.nudannee.TabIndex = 2
        Me.nudannee.Value = New Decimal(New Integer() {1400, 0, 0, 0})
        '
        'btnenregistrer
        '
        Me.btnenregistrer.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnenregistrer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnenregistrer.Location = New System.Drawing.Point(284, 292)
        Me.btnenregistrer.Name = "btnenregistrer"
        Me.btnenregistrer.Size = New System.Drawing.Size(75, 23)
        Me.btnenregistrer.TabIndex = 0
        Me.btnenregistrer.Text = "Enregistrer"
        Me.btnenregistrer.UseVisualStyleBackColor = False
        '
        'btnannuler
        '
        Me.btnannuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnannuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnannuler.Location = New System.Drawing.Point(187, 292)
        Me.btnannuler.Name = "btnannuler"
        Me.btnannuler.Size = New System.Drawing.Size(75, 23)
        Me.btnannuler.TabIndex = 1
        Me.btnannuler.Text = "Annuler"
        Me.btnannuler.UseVisualStyleBackColor = False
        '
        'nudquantite
        '
        Me.nudquantite.Location = New System.Drawing.Point(31, 228)
        Me.nudquantite.Maximum = New Decimal(New Integer() {1400, 0, 0, 0})
        Me.nudquantite.Name = "nudquantite"
        Me.nudquantite.Size = New System.Drawing.Size(328, 20)
        Me.nudquantite.TabIndex = 7
        '
        'cbbgenre
        '
        Me.cbbgenre.FormattingEnabled = True
        Me.cbbgenre.Items.AddRange(New Object() {"Roman", "Science-fiction", "Conte", "Poesie", "Theatre", "Policier", "Biographie"})
        Me.cbbgenre.Location = New System.Drawing.Point(31, 188)
        Me.cbbgenre.Name = "cbbgenre"
        Me.cbbgenre.Size = New System.Drawing.Size(328, 21)
        Me.cbbgenre.TabIndex = 7
        '
        'lblquantite
        '
        Me.lblquantite.AutoSize = True
        Me.lblquantite.Location = New System.Drawing.Point(6, 212)
        Me.lblquantite.Name = "lblquantite"
        Me.lblquantite.Size = New System.Drawing.Size(47, 13)
        Me.lblquantite.TabIndex = 0
        Me.lblquantite.Text = "Quantite"
        '
        'txtisbn
        '
        Me.txtisbn.Location = New System.Drawing.Point(31, 149)
        Me.txtisbn.Name = "txtisbn"
        Me.txtisbn.Size = New System.Drawing.Size(328, 20)
        Me.txtisbn.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Genre litteraire"
        '
        'lblisbn
        '
        Me.lblisbn.AutoSize = True
        Me.lblisbn.Location = New System.Drawing.Point(6, 133)
        Me.lblisbn.Name = "lblisbn"
        Me.lblisbn.Size = New System.Drawing.Size(32, 13)
        Me.lblisbn.TabIndex = 2
        Me.lblisbn.Text = "ISBN"
        '
        'txtauteur
        '
        Me.txtauteur.Location = New System.Drawing.Point(31, 71)
        Me.txtauteur.Name = "txtauteur"
        Me.txtauteur.Size = New System.Drawing.Size(328, 20)
        Me.txtauteur.TabIndex = 9
        '
        'txtTitre
        '
        Me.txtTitre.Location = New System.Drawing.Point(31, 32)
        Me.txtTitre.Name = "txtTitre"
        Me.txtTitre.Size = New System.Drawing.Size(328, 20)
        Me.txtTitre.TabIndex = 10
        '
        'lbltitre
        '
        Me.lbltitre.AutoSize = True
        Me.lbltitre.Location = New System.Drawing.Point(6, 16)
        Me.lbltitre.Name = "lbltitre"
        Me.lbltitre.Size = New System.Drawing.Size(28, 13)
        Me.lbltitre.TabIndex = 5
        Me.lbltitre.Text = "Titre"
        '
        'lblauteur
        '
        Me.lblauteur.AutoSize = True
        Me.lblauteur.Location = New System.Drawing.Point(6, 55)
        Me.lblauteur.Name = "lblauteur"
        Me.lblauteur.Size = New System.Drawing.Size(38, 13)
        Me.lblauteur.TabIndex = 4
        Me.lblauteur.Text = "Auteur"
        '
        'lblanneepub
        '
        Me.lblanneepub.AutoSize = True
        Me.lblanneepub.Location = New System.Drawing.Point(3, 94)
        Me.lblanneepub.Name = "lblanneepub"
        Me.lblanneepub.Size = New System.Drawing.Size(107, 13)
        Me.lblanneepub.TabIndex = 3
        Me.lblanneepub.Text = "Annee de publication"
        '
        'grbliste
        '
        Me.grbliste.Controls.Add(Me.dgvliste)
        Me.grbliste.Controls.Add(Me.StatusStrip1)
        Me.grbliste.Location = New System.Drawing.Point(383, 120)
        Me.grbliste.Name = "grbliste"
        Me.grbliste.Size = New System.Drawing.Size(489, 343)
        Me.grbliste.TabIndex = 4
        Me.grbliste.TabStop = False
        Me.grbliste.Text = "liste des livres"
        '
        'dgvliste
        '
        Me.dgvliste.AllowUserToAddRows = False
        Me.dgvliste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvliste.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_livres, Me.Titre, Me.Auteur, Me.anneepublication, Me.ISBN, Me.genre, Me.quantite, Me.categorie, Me.idcategorie})
        Me.dgvliste.EnableHeadersVisualStyles = False
        Me.dgvliste.Location = New System.Drawing.Point(9, 19)
        Me.dgvliste.MultiSelect = False
        Me.dgvliste.Name = "dgvliste"
        Me.dgvliste.ReadOnly = True
        Me.dgvliste.RowHeadersVisible = False
        Me.dgvliste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvliste.Size = New System.Drawing.Size(477, 296)
        Me.dgvliste.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 318)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(483, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'grbbouton
        '
        Me.grbbouton.Controls.Add(Me.btnmodifier)
        Me.grbbouton.Controls.Add(Me.btnsupprimer)
        Me.grbbouton.Controls.Add(Me.btnajouter)
        Me.grbbouton.Location = New System.Drawing.Point(12, 70)
        Me.grbbouton.Name = "grbbouton"
        Me.grbbouton.Size = New System.Drawing.Size(365, 49)
        Me.grbbouton.TabIndex = 6
        Me.grbbouton.TabStop = False
        '
        'btnmodifier
        '
        Me.btnmodifier.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnmodifier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmodifier.Location = New System.Drawing.Point(141, 16)
        Me.btnmodifier.Name = "btnmodifier"
        Me.btnmodifier.Size = New System.Drawing.Size(75, 23)
        Me.btnmodifier.TabIndex = 0
        Me.btnmodifier.Text = "Modifier"
        Me.btnmodifier.UseVisualStyleBackColor = False
        '
        'btnsupprimer
        '
        Me.btnsupprimer.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnsupprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsupprimer.Location = New System.Drawing.Point(290, 16)
        Me.btnsupprimer.Name = "btnsupprimer"
        Me.btnsupprimer.Size = New System.Drawing.Size(75, 23)
        Me.btnsupprimer.TabIndex = 1
        Me.btnsupprimer.Text = "Supprimer"
        Me.btnsupprimer.UseVisualStyleBackColor = False
        '
        'btnajouter
        '
        Me.btnajouter.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnajouter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnajouter.Location = New System.Drawing.Point(6, 16)
        Me.btnajouter.Name = "btnajouter"
        Me.btnajouter.Size = New System.Drawing.Size(58, 23)
        Me.btnajouter.TabIndex = 2
        Me.btnajouter.Text = "Ajouter"
        Me.btnajouter.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(797, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'id_livres
        '
        Me.id_livres.HeaderText = "ID"
        Me.id_livres.Name = "id_livres"
        Me.id_livres.ReadOnly = True
        Me.id_livres.Width = 50
        '
        'Titre
        '
        Me.Titre.HeaderText = "Titre"
        Me.Titre.Name = "Titre"
        Me.Titre.ReadOnly = True
        Me.Titre.Width = 200
        '
        'Auteur
        '
        Me.Auteur.HeaderText = "Auteur"
        Me.Auteur.Name = "Auteur"
        Me.Auteur.ReadOnly = True
        Me.Auteur.Width = 150
        '
        'anneepublication
        '
        Me.anneepublication.HeaderText = "Annee"
        Me.anneepublication.Name = "anneepublication"
        Me.anneepublication.ReadOnly = True
        Me.anneepublication.Width = 60
        '
        'ISBN
        '
        Me.ISBN.HeaderText = "ISBN"
        Me.ISBN.Name = "ISBN"
        Me.ISBN.ReadOnly = True
        Me.ISBN.Width = 140
        '
        'genre
        '
        Me.genre.HeaderText = "Genre"
        Me.genre.Name = "genre"
        Me.genre.ReadOnly = True
        '
        'quantite
        '
        Me.quantite.HeaderText = "quantite"
        Me.quantite.Name = "quantite"
        Me.quantite.ReadOnly = True
        Me.quantite.Width = 50
        '
        'categorie
        '
        Me.categorie.HeaderText = "nom categorie"
        Me.categorie.Name = "categorie"
        Me.categorie.ReadOnly = True
        '
        'idcategorie
        '
        Me.idcategorie.HeaderText = "code categorie"
        Me.idcategorie.Name = "idcategorie"
        Me.idcategorie.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grbbouton)
        Me.Controls.Add(Me.grbliste)
        Me.Controls.Add(Me.grbinfo)
        Me.Controls.Add(Me.txtentete2)
        Me.Controls.Add(Me.grbrecherche)
        Me.Controls.Add(Me.txtentete)
        Me.Name = "Form1"
        Me.Text = "GESTION DE LA BIBLIOTHEQUE"
        Me.grbrecherche.ResumeLayout(False)
        Me.grbrecherche.PerformLayout()
        Me.grbinfo.ResumeLayout(False)
        Me.grbinfo.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        CType(Me.nudannee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudquantite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbliste.ResumeLayout(False)
        Me.grbliste.PerformLayout()
        CType(Me.dgvliste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grbbouton.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtentete As TextBox
    Friend WithEvents grbrecherche As GroupBox
    Friend WithEvents btnrechercher As Button
    Friend WithEvents txtrecherche As TextBox
    Friend WithEvents txtentete2 As TextBox
    Friend WithEvents grbinfo As GroupBox
    Friend WithEvents btnenregistrer As Button
    Friend WithEvents btnannuler As Button
    Friend WithEvents nudquantite As NumericUpDown
    Friend WithEvents cbbgenre As ComboBox
    Friend WithEvents lblquantite As Label
    Friend WithEvents txtisbn As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblisbn As Label
    Friend WithEvents txtauteur As TextBox
    Friend WithEvents txtTitre As TextBox
    Friend WithEvents lbltitre As Label
    Friend WithEvents lblauteur As Label
    Friend WithEvents lblanneepub As Label
    Friend WithEvents grbliste As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents grbbouton As GroupBox
    Friend WithEvents btnmodifier As Button
    Friend WithEvents btnsupprimer As Button
    Friend WithEvents btnajouter As Button
    Friend WithEvents nudannee As NumericUpDown
    Friend WithEvents dgvliste As DataGridView
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents tslblstatut As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbcategorie As ComboBox
    Friend WithEvents lblcategorie As Label
    Friend WithEvents id_livres As DataGridViewTextBoxColumn
    Friend WithEvents Titre As DataGridViewTextBoxColumn
    Friend WithEvents Auteur As DataGridViewTextBoxColumn
    Friend WithEvents anneepublication As DataGridViewTextBoxColumn
    Friend WithEvents ISBN As DataGridViewTextBoxColumn
    Friend WithEvents genre As DataGridViewTextBoxColumn
    Friend WithEvents quantite As DataGridViewTextBoxColumn
    Friend WithEvents categorie As DataGridViewTextBoxColumn
    Friend WithEvents idcategorie As DataGridViewTextBoxColumn
End Class
