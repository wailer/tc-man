Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading

Module MysqlFunctions

    Public conn As MySqlConnection

    Public MysqlParams As String
    Public CancelReorderCreature As Boolean

    Public Sub Duplicate_creature()

        Dim DupcreatureCommand As New MySqlCommand
        Dim DupcreatureAdapter As New MySqlDataAdapter
        Dim DupcreatureData As New DataTable
        Dim diSqlQuery As String
        Dim MaxID As Integer


        diSqlQuery = "Select MAX(entry) from creature_template"


        Try
            conn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Error Connecting to Database: " & myerror.Message)
        End Try

        DupcreatureCommand.Connection = conn
        DupcreatureCommand.CommandText = diSqlQuery

        MaxID = DupcreatureCommand.ExecuteScalar







        ' Creamos tabla temporal para copiar el registro que vamos a duplicar
        diSqlQuery = "CREATE TEMPORARY TABLE creature_temp ENGINE=MEMORY SELECT * FROM creature_template where entry=?tcreatureIDOrigen"
        DupcreatureCommand.CommandText = diSqlQuery
        DupcreatureCommand.Parameters.AddWithValue("?tcreatureIDOrigen", Main.tcreatureIdOrigen.Text)
        QueryResult1 = DupcreatureCommand.ExecuteNonQuery
        DupcreatureCommand.Parameters.Clear()

        ' Cambiamos la key unica del registro copiado ( La nueva ID )
        diSqlQuery = "UPDATE creature_temp SET entry=?tNuevaID"
        DupcreatureCommand.CommandText = diSqlQuery
        DupcreatureCommand.Parameters.AddWithValue("?tNuevaID", Main.tcreatureNuevaID.Text)
        QueryResult1 = DupcreatureCommand.ExecuteNonQuery
        DupcreatureCommand.Parameters.Clear()

        ' Modificamos nombre si se ha indicado

        If Main.tcreatureNombreNuevo.TextLength <> 0 Then
            diSqlQuery = "UPDATE creature_temp SET name=?tNuevoNombre"
            DupcreatureCommand.CommandText = diSqlQuery
            DupcreatureCommand.Parameters.AddWithValue("?tNuevoNombre", Main.tcreatureNombreNuevo.Text)
            QueryResult1 = DupcreatureCommand.ExecuteNonQuery
            DupcreatureCommand.Parameters.Clear()
        End If

        ' Modificamos la displayID si se ha indicado

        If Main.tcreatureDisplayNuevo.TextLength <> 0 Then
            diSqlQuery = "UPDATE creature_temp SET modelid1=?tNuevaDisplay"
            DupcreatureCommand.CommandText = diSqlQuery
            DupcreatureCommand.Parameters.AddWithValue("?tNuevaDisplay", Main.tcreatureDisplayNuevo.Text)
            QueryResult1 = DupcreatureCommand.ExecuteNonQuery
            DupcreatureCommand.Parameters.Clear()
        End If

        ' Insertamos la nueva entrada en la tabla original

        diSqlQuery = "INSERT INTO creature_template SELECT * FROM creature_temp"
        DupcreatureCommand.CommandText = diSqlQuery
        QueryResult1 = DupcreatureCommand.ExecuteNonQuery
        DupcreatureCommand.Parameters.Clear()

        ' Borramos la tabla temporal
        diSqlQuery = "DROP TABLE creature_temp"
        DupcreatureCommand.CommandText = diSqlQuery
        QueryResult1 = DupcreatureCommand.ExecuteNonQuery
        DupcreatureCommand.Parameters.Clear()

        conn.Close()






    End Sub


    Public Sub Duplicate_Item()

        Dim DupItemCommand As New MySqlCommand
        Dim DupItemAdapter As New MySqlDataAdapter
        Dim DupItemData As New DataTable
        Dim diSqlQuery As String
        Dim MaxID As Integer


        diSqlQuery = "Select MAX(entry) from item_template"


        Try
            conn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Error Connecting to Database: " & myerror.Message)
        End Try

        DupItemCommand.Connection = conn
        DupItemCommand.CommandText = diSqlQuery

        MaxID = DupItemCommand.ExecuteScalar



        ' Creamos tabla temporal para copiar el registro que vamos a duplicar
        diSqlQuery = "CREATE TEMPORARY TABLE item_temp ENGINE=MEMORY SELECT * FROM item_template where entry=?tItemIDOrigen"
        DupItemCommand.CommandText = diSqlQuery
        DupItemCommand.Parameters.AddWithValue("?tItemIDOrigen", Main.tItemIDOriginal.Text)
        Try
            QueryResult1 = DupItemCommand.ExecuteNonQuery
        Catch ex As Exception
            MessageBox.Show("Error MySQL: " & ex.Message)
        End Try

        DupItemCommand.Parameters.Clear()

        ' Cambiamos la key unica del registro copiado ( La nueva ID )
        diSqlQuery = "UPDATE item_temp SET entry=?tNuevaID"
        DupItemCommand.CommandText = diSqlQuery
        DupItemCommand.Parameters.AddWithValue("?tNuevaID", Main.tItemIDnuevo.Text)
        QueryResult1 = DupItemCommand.ExecuteNonQuery
        DupItemCommand.Parameters.Clear()

        ' Modificamos nombre si se ha indicado

        If Main.tItemNuevoNombre.TextLength <> 0 Then
            diSqlQuery = "UPDATE item_temp SET name=?tNuevoNombre"
            DupItemCommand.CommandText = diSqlQuery
            DupItemCommand.Parameters.AddWithValue("?tNuevoNombre", Main.tItemNuevoNombre.Text)
            QueryResult1 = DupItemCommand.ExecuteNonQuery
            DupItemCommand.Parameters.Clear()
        End If

        ' Modificamos la displayID si se ha indicado

        If Main.tItemNuevoDisplay.TextLength <> 0 Then
            diSqlQuery = "UPDATE item_temp SET displayid=?tNuevaDisplay"
            DupItemCommand.CommandText = diSqlQuery
            DupItemCommand.Parameters.AddWithValue("?tNuevaDisplay", Main.tItemNuevoDisplay.Text)
            QueryResult1 = DupItemCommand.ExecuteNonQuery
            DupItemCommand.Parameters.Clear()
        End If

        ' Insertamos la nueva entrada en la tabla original

        diSqlQuery = "INSERT INTO item_template SELECT * FROM item_temp"
        DupItemCommand.CommandText = diSqlQuery
        QueryResult1 = DupItemCommand.ExecuteNonQuery
        DupItemCommand.Parameters.Clear()

        ' Borramos la tabla temporal
        diSqlQuery = "DROP TABLE item_temp"
        DupItemCommand.CommandText = diSqlQuery
        QueryResult1 = DupItemCommand.ExecuteNonQuery
        DupItemCommand.Parameters.Clear()

        conn.Close()






    End Sub

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
