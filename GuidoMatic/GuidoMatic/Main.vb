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
        Const Max_Guid As Integer = 16777214
        Dim last_used_guid As Integer
        Dim next_empty_guid As Integer = 1
        Dim guid_to_reorder As Integer = Max_Guid
        Dim FoundNextGuid As Boolean
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
            SqlQuery = "SELECT guid FROM creature WHERE guid=?next_empty_guid"
            Command.CommandText = SqlQuery
            Command.Parameters.AddWithValue("?next_empty_guid", next_empty_guid)
            QueryResult1 = Command.ExecuteScalar
            Command.Parameters.Clear()


            If QueryResult1 = 0 Then
                first_empty_guid = next_empty_guid
                QueryResult1 = Nothing
            Else
                last_used_guid = next_empty_guid
                QueryResult1 = Nothing
                GoTo LoopEnd
            End If

            'In case an empty_guid is found we will select highest guid and reassign it to an empty lower one.

            Do
                SqlQuery = "SELECT MAX(guid) FROM creature"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?guid_to_reorder", guid_to_reorder)
                QueryResult2 = Command.ExecuteScalar
                Command.Parameters.Clear()


                If QueryResult2 < first_empty_guid Then
                    GoTo Loopend
                    FoundNextGuid = False
                    QueryResult2 = Nothing
                Else
                    FoundNextGuid = True
                    guid_to_reorder = QueryResult2
                    QueryResult2 = Nothing
                End If

            Loop Until FoundNextGuid Or guid_to_reorder < next_empty_guid
            ' next_guid now contains the guid to replace for the first_empty_guid

            If FoundNextGuid Then
                SqlQuery = "UPDATE creature SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", guid_to_reorder)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()

                SqlQuery = "UPDATE creature_addon SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", guid_to_reorder)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_formations SET leaderGUID = ?first_empty_guid WHERE leaderGUID = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", guid_to_reorder)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_formations SET memberGUID = ?first_empty_guid WHERE memberGUID = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", guid_to_reorder)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_linked_respawn SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", guid_to_reorder)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_linked_respawn SET linkedGuid = ?first_empty_guid WHERE linkedGuid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", guid_to_reorder)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                SqlQuery = "UPDATE creature_respawn SET guid = ?first_empty_guid WHERE guid = ?next_guid"
                Command.CommandText = SqlQuery
                Command.Parameters.AddWithValue("?first_empty_guid", first_empty_guid)
                Command.Parameters.AddWithValue("?next_guid", guid_to_reorder)
                Command.ExecuteNonQuery()
                Command.Parameters.Clear()
                Increment_ChangedGuids(1)



            End If

LoopEnd:

            Progress_Update(changedguids)
            next_empty_guid = next_empty_guid + 1



        Loop Until (next_empty_guid = Max_Guid) Or CancelReorderCreature
        MsgBox("Process completed")

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
            Me.lChangedGuidsValue.Text = total

        End If

    End Sub

 
End Class