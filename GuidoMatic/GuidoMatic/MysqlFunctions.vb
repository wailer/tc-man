Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading

Module MysqlFunctions

    Public conn As MySqlConnection
    Public MysqlParams As String
    Public CancelReorderCreature As Boolean



    Public Sub Creature_Reorder()

        Dim Command As New MySqlCommand
        Dim Adapter As New MySqlDataAdapter
        Dim Data As New DataTable
        Dim SqlQuery As String
        Dim first_empty_guid As Integer
        Dim last_used_guid As Integer
        Dim next_empty_guid As Integer = 1
        Dim next_guid As Integer
        Dim FoundNextGuid As Boolean
        Const Max_Guid As Integer = 16777214
        Dim Rows As Integer
        Dim QueryResult1 As Integer
        Dim QueryResult2 As Integer
        Dim Progress As Integer
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
        Main.lSpawnsValue.Text = Rows.ToString
        Main.lChangedGuidsValue.Text = "0"


        Do

            ' We check if guid is used or empty
            SqlQuery = "SELECT guid FROM creature WHERE guid=?next_empty_guid"
            Command.CommandText = SqlQuery
            Command.Parameters.AddWithValue("?next_empty_guid", next_empty_guid)
            QueryResult1 = Command.ExecuteScalar
            Command.Parameters.Clear()


            If QueryResult1 = 0 Then
                first_empty_guid = next_empty_guid
                next_guid = next_empty_guid + 1
                QueryResult1 = Nothing
            Else
                last_used_guid = next_empty_guid
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
                changedguids = changedguids + 1
                Main.lChangedGuidsValue.Text = changedguids.ToString
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
                Main.lGuidsChanged.Text = changedguids
                Main.Refresh()

            End If

LoopEnd:


            Progress = 100 * next_empty_guid / 16777214
            Main.ProgressCreatureGuids.Increment(Progress)
            next_empty_guid = next_empty_guid + 1

            conn.Close()
            conn.Dispose()
            conn.Open()

            Main.Refresh()
            Main.Update()

        Loop Until (next_empty_guid = Max_Guid) Or CancelReorderCreature



    End Sub



End Module
