Imports MySql.Data.MySqlClient
Public Class Form1
    Private cnx As MySqlConnection

    Private idLivreSelectionne As Integer = -1
    Private changer As Boolean = False
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        ouvrirconnexion()
        extrairedonnees()
    End Sub
    Private Sub ouvrirconnexion()
        Dim chaine As String
        chaine = "server=localhost; database=bibliotheque_db; userId=root; password=; sslmode=none"
        cnx = New MySqlConnection(chaine)
        Try
            cnx.Open()
            tslblstatut.ForeColor = Color.Green
            statut("connexion reussie")
        Catch ex As MySqlException
            tslblstatut.ForeColor = Color.Red
            statut("warning: verifier que votre serveur a demarreer et que la base de donnee existe")
        Catch ex As Exception
            tslblstatut.ForeColor = Color.Red
            statut("echec de connexion")

        End Try

    End Sub
    Public Sub extrairedonnees()
        Dim cmd = New MySqlCommand("select * from livres natural join categorie order by titre", cnx)
        Dim dr As MySqlDataReader = cmd.ExecuteReader()
        dgvliste.Rows.Clear()
        While dr.Read()
            Dim code = dr.GetValue(1)
            Dim titre = dr.GetValue(2)
            Dim auteur = dr.GetValue(3)
            Dim annee = dr.GetValue(4)
            Dim genre = dr.GetValue(5)
            Dim isbn = dr.GetValue(6)
            Dim quantite = dr.GetValue(7)
            Dim categorie = dr.GetValue(9)
            Dim idcat = dr.GetValue(0)
            dgvliste.Rows.Add({code, titre, auteur, annee, isbn, genre, quantite, categorie, idcat})
        End While
        dr.Close()
    End Sub
    Private Function validersaisie() As Boolean
        'verifie le contenu des champs du formulaire
        If String.IsNullOrWhiteSpace(txtTitre.Text) Then
            tslblstatut.ForeColor = Color.Red
            statut("veuiller saisir le titre du livre ")
            txtTitre.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtauteur.Text) Then
            tslblstatut.ForeColor = Color.Red
            statut("veuiller saisir le nom de l auteur ")
            txtauteur.Focus()
            Return False
        End If
        If nudannee.Value < 1400 OrElse nudannee.Value > Year(Now) Then
            tslblstatut.ForeColor = Color.Red
            statut("l'annee doit etre comprise entre 1400 et" & Year(Now) & ".")
            nudannee.Focus()
            Return False
        End If
        If cbbgenre.SelectedIndex = -1 OrElse cmbcategorie.SelectedIndex = -1 Then
            tslblstatut.ForeColor = Color.Red
            statut("veuiller selectionner un genre et une categorie")
            cbbgenre.Focus()
        End If
        Return True
    End Function
    Private Sub statut(message As String)
        tslblstatut.Text = message
    End Sub
    Private Sub nettoyerchamps()
        txtauteur.Clear()
        txtTitre.Clear()
        txtisbn.Clear()
        cbbgenre.SelectedIndex = -1
        cbbgenre.ResetText()
        cmbcategorie.ResetText()
        cmbcategorie.SelectedIndex = -1
        nudannee.ResetText()
        nudquantite.ResetText()
    End Sub
    Sub enconsultation(ok As Boolean)
        grbbouton.Enabled = ok
        grbinfo.Enabled = Not (ok)
        grbrecherche.Enabled = ok
        grbliste.Enabled = ok

    End Sub
    Public Sub ajouter()
        'insert les donnees du champ dans la base de donnees
        Try
            Dim cmd = New MySqlCommand("insert into livres(titre, auteur, anneepublication,genre, ISBN, quantite) values(@titre,@auteur,@annee,@genre,@isbn,@quantite)", cnx)
            cmd.Parameters.AddWithValue("@titre", txtTitre.Text.Trim())
            cmd.Parameters.AddWithValue("@auteur", txtauteur.Text.Trim())
            cmd.Parameters.AddWithValue("@annee", nudannee.Value)
            cmd.Parameters.AddWithValue("@quantite", nudquantite.Value)
            cmd.Parameters.AddWithValue("@genre", cbbgenre.SelectedItem.ToString())
            If String.IsNullOrWhiteSpace(txtisbn.Text) Then
                cmd.Parameters.AddWithValue("@isbn", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@isbn", txtisbn.Text.Trim())
            End If
            Dim nbligne As Integer = cmd.ExecuteNonQuery()
            If nbligne > 0 Then
                statut("livre ajouter avec succes")
            Else
                statut("Erreur: aucun livre n'a ete enregistrer")
            End If
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show(" Erreur MySQL (" & ex.Number & ") : " & ex.Message, " Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnannuler_Click(sender As Object, e As EventArgs) Handles btnannuler.Click
        nettoyerchamps()
        enconsultation(True)

    End Sub

    Private Sub btnenregistrer_Click(sender As Object, e As EventArgs) Handles btnenregistrer.Click
        If Not validersaisie() Then
            Return
        End If
        If changer Then
            modifier()
        Else
            ajouter()
        End If
        extrairedonnees()
        nettoyerchamps()
        enconsultation(True)

    End Sub

    Private Sub nudannee_ValueChanged(sender As Object, e As EventArgs) Handles nudannee.ValueChanged
        nudannee.Maximum = Year(Now)
    End Sub

    Private Sub dgvliste_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvliste.CellContentClick
        If dgvliste.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvliste.SelectedRows(0)
            grbinfo.Enabled = True
            idLivreSelectionne = Convert.ToInt32(row.Cells("id_livres").Value)
            txtTitre.Text = row.Cells("Titre").Value.ToString()
            txtauteur.Text = row.Cells("Auteur").Value.ToString()
            nudannee.Value = Convert.ToInt32(row.Cells("AnneePublication").Value)
            cbbgenre.Text = row.Cells("Genre").Value.ToString()
            cmbcategorie.Text = row.Cells("categorie").Value.ToString()
            If row.Cells("ISBN").Value IsNot DBNull.Value Then
                txtisbn.Text = row.Cells("ISBN").Value.ToString()
            Else
                txtisbn.Clear()
            End If
            btnajouter.Enabled = False
            btnmodifier.Enabled = True
            btnsupprimer.Enabled = True
            tslblstatut.ForeColor = Color.Red
            statut("livre selectionner:" & txtTitre.Text)
        End If
    End Sub

    Private Sub btnmodifier_Click(sender As Object, e As EventArgs) Handles btnmodifier.Click
        grbinfo.Enabled = True
        If idLivreSelectionne = -1 Then
            MessageBox.Show(" Veuillez selectionner un livre a modifier .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim resultat As DialogResult = MessageBox.Show("voulez-vous vraiment modifier ce livre ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resultat = DialogResult.No Then

            Return
        ElseIf resultat = DialogResult.Yes
            changer = True
        End If
    End Sub
    Private Sub modifier()
        Try
            Dim cmd = New MySqlCommand("update livres set titre=@titre, auteur=@auteur, anneepublication=@genre,
ISBN=@isbn, quantite=@quantite where idlivre= @idlivre", cnx)
            cmd.Parameters.AddWithValue("@IdLivre", idLivreSelectionne)
            cmd.Parameters.AddWithValue("@Titre", txtTitre.Text.Trim())
            cmd.Parameters.AddWithValue("@Auteur", txtauteur.Text.Trim())
            cmd.Parameters.AddWithValue("@Annee", nudannee.Value)
            cmd.Parameters.AddWithValue("@quantite", nudquantite.Value)
            cmd.Parameters.AddWithValue("@Genre", cbbgenre.SelectedItem.ToString())
            If String.IsNullOrWhiteSpace(txtisbn.Text) Then
                cmd.Parameters.AddWithValue("@ISBN", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@ISBN", txtisbn.Text.Trim())
                Dim nbLignes As Integer = cmd.ExecuteNonQuery()
                If nbLignes > 0 Then

                    statut("livre modifier avec succes")
                Else
                    statut("erreur lors de la modification de ce livre")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnajouter_Click(sender As Object, e As EventArgs) Handles btnajouter.Click
        nettoyerchamps()
        enconsultation(False)
    End Sub

    Private Sub btnrechercher_Click(sender As Object, e As EventArgs) Handles btnrechercher.Click
        If txtrecherche.Text = "" Then
            MessageBox.Show("veuiller ernseigner le nom de l'auteur ou le titre du livre")
            txtrecherche.Focus()
            Return
        End If
        Dim cmd = New MySqlCommand("select * from livre natural join categorie where titre like @rechercher or auteur like @recherche order by titre", cnx)
        cmd.Parameters.AddWithValue("@recherche", "%" & txtrecherche.Text & "%")

        Dim dr As MySqlDataReader = cmd.ExecuteReader()
        dgvliste.Rows.Clear()
        If Not dr.HasRows Then
            MessageBox.Show("Aucun resultat trouve")
        Else
            While dr.Read()
                Dim code = dr.GetValue(1)
                Dim titre = dr.GetValue(2)
                Dim auteur = dr.GetValue(3)
                Dim annee = dr.GetValue(4)
                Dim genre = dr.GetValue(5)
                Dim isbn = dr.GetValue(6)
                Dim quantite = dr.GetValue(7)
                Dim categorie = dr.GetValue(9)
                Dim idcat = dr.GetValue(0)
                dgvliste.Rows.Add({code, titre, auteur, annee, isbn, genre, quantite, categorie, idcat})
            End While
        End If
        dr.Close()
    End Sub

    Private Sub btnsupprimer_Click(sender As Object, e As EventArgs) Handles btnsupprimer.Click
        If idLivreSelectionne = -1 Then
            MessageBox.Show("Veuillez selectionner un livre a supprimer .", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)            Return
        End If
        Dim resultat As DialogResult = MessageBox.Show("Voulez-vous vraiment supprimer le livre : " & txtTitre.Text & "  Cette action est irreversible .", " Confirmation de suppression ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)        If resultat = DialogResult.No Then
            Return
        End If        Try
            Dim cmd = New MySqlCommand(" DELETE FROM Livres WHERE IdLivre = @IdLivre", cnx)
            cmd.Parameters.AddWithValue("@IdLivre", idLivreSelectionne)
            Dim nbLignes As Integer = cmd.ExecuteNonQuery()
            If nbLignes > 0 Then
                MessageBox.Show("Livre supprime avec succes!", " Succes ", MessageBoxButtons.OK, MessageBoxIcon.Information)                extrairedonnees()                nettoyerchamps()                statut("livre supprimer avec succes")
            Else                MessageBox.Show(" Erreur lors de la suppression .", " Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show("Impossible de supprimer ce livre car il est reference ailleurs .", " Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(" Erreur MySQL : " & ex.Message, " Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(" Erreur : " & ex.Message, " Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
