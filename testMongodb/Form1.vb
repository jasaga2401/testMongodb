Imports MongoDB.Driver
Imports MongoDB.Bson

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' MongoDB connection string
        Dim connectionString As String = "mongodb+srv://jasaga:igywFraEIYcgiMZG@cluster0.sd0fg.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"

        ' Create a MongoClient
        Dim client As New MongoClient(connectionString)

        ' Access the database
        Dim database As IMongoDatabase = client.GetDatabase("dbcustomer")

        ' Access the collection
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("users")

        ' Define a filter to search for "title" = "Post Title1"
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of String)("forename", "Kenny")

        ' Execute the query
        Dim documents As List(Of BsonDocument) = collection.Find(filter).ToList()

        ' Output the results
        Console.WriteLine("Matching Documents:")
        For Each document In documents
            Console.WriteLine(document.ToJson())
        Next

    End Sub

End Class
