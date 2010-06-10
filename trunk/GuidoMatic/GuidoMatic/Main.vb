Imports System.Threading
Imports MySql.Data.MySqlClient




Public Class Main


    Private ThreadCreatureReorder As Thread



    Private Sub lGuidsChanged_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lGuidsChanged.Click

    End Sub

    Private Sub bReorderCreature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bReorderCreature.Click

        Me.CreatureWorker.RunWorkerAsync()


    End Sub





    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Threading.Thread.CurrentThread.Name = "Main"

    End Sub


    Private Sub CreatureWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles CreatureWorker.DoWork

        Dim Command As New MySqlCommand
        Dim Adapter As New MySqlDataAdapter
        Dim Data As New DataTable
        Dim SqlQuery As String
        Dim first_empty_guid As Integer
        Dim last_used_guid As Integer
        Dim guid_to_reorder As Integer = 1
        Dim next_guid As Integer
        Dim FoundNextGuid As Boolean
        Const Max_Guid As Integer = 16777214
        Dim Rows As Integer
        Dim QueryResult1 As Integer
        Dim QueryResult2 As Integer

        Dim changedguids As Integer

        CancelReorderCreature = False

        'Consultamos cuantas filas tiene para posteriormente calcular el progreso
        SqlQuery = "SELECT COUNT(*) FROM creature"

        conn.ConnectionString = MysqlParams

        Try
            conn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Error Connecting to Database: " & myerror.Message)
        End Try

        Command.Connection = conn
        Command.CommandText = SqlQuery

        Rows = Command.ExecuteScalar

        Initialize_Counters(Rows)

        Do

            ' We check if guid is used or empty
            SqlQuery = "SELECT guid FROM creature WHERE guid=?guid_to_reorder"
            Command.CommandText = SqlQuery
            Command.Parameters.AddWithValue("?guid_to_reorder", guid_to_reorder)
            QueryResult1 = Command.ExecuteScalar
            Command.Parameters.Clear()


            If QueryResult1 = 0 Then
                first_empty_guid = guid_to_reorder
                next_guid = guid_to_reorder + 1
                QueryResult1 = Nothing
            Else
                last_used_guid = guid_to_reorder
                QueryResult1 = Nothing
                GoTo LoopEnd
            End If

            'In case an empty_guid is found we will iterate until the next used guid

            Do
                SqlQuery = "SELECT guid FROM creature WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                QueryResult2 = Command.ExecuteScalar
                Command.Parameters.Clear()


                If QueryResult2 = 0 Then
                    next_guid = next_guid + 1
                    FoundNextGuid = False
                    QueryResult2 = Nothing
                Else
                    FoundNextGuid = True
                    QueryResult2 = Nothing
                End If

            Loop Until FoundNextGuid Or next_guid = Max_Guid
            ' next_guid now contains the guid to replace for the first_empty_guid

            If FoundNextGuid Then
                SqlQuery = "UPDATE creature SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()

                SqlQuery = "UPDATE creature_addon SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_formations SET leaderGUID = ?first_empty_guid WHERE leaderGUID = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_formations SET memberGUID = ?first_empty_guid WHERE memberGUID = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_linked_respawn SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_linked_respawn SET linkedGuid = ?first_empty_guid WHERE linkedGuid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_respawn SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", next_guid)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                Increment_ChangedGuids(1)



            End If

LoopEnd:

            Progress_Update(changedguids)
            guid_to_reorder = guid_to_reorder + 1


        Loop Until (guid_to_reorder = Max_Guid) Or CancelReorderCreature


    End Sub

    Private Delegate Sub Progress_UpdateInvoker(ByVal guid_progress As Integer)

    Private Sub Progress_Update(ByVal guid_progress As Integer)

        Dim Progress As Integer
        If Me.ProgressCreatureGuids.InvokeRequired Then
            Me.ProgressCreatureGuids.Invoke(New Progress_UpdateInvoker(AddressOf Progress_Update), guid_progress)
        Else
            Progress = 100 * guid_progress / 16777214
            Me.ProgressCreatureGuids.Increment(Progress)
        End If
    End Sub

    Private Delegate Sub Initialize_CountersInvoker(ByVal rowsvalue As Integer)

    Private Sub Initialize_Counters(ByVal rowsvalue As Integer)
        If Me.lSpawnsValue.InvokeRequired Then
            Me.lSpawnsValue.Invoke(New Initialize_CountersInvoker(AddressOf Initialize_Counters), rowsvalue)
        Else
            Me.lSpawnsValue.Text = rowsvalue.ToString
            Me.lChangedGuidsValue.Text = "0"
        End If
    End Sub

    Private Delegate Sub Increment_ChangedGuidsInvoker(ByVal increment As Integer)

    Dim total As Integer = 0

    Private Sub Increment_ChangedGuids(ByVal increment As Integer)



        If Me.lChangedGuidsValue.InvokeRequired Then
            Me.lChangedGuidsValue.Invoke(New Progress_UpdateInvoker(AddressOf Progress_Update), increment)
        Else
            total = total + increment
            Me.lChangedGuidsValue.Text = total.ToString
        End If

    End Sub
End Class