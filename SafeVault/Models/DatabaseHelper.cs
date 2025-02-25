public void RegisterUser(string username, string email)
{
    using (var connection = new SqlConnection(connectionString))
    {
        string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";
        SqlCommand command = new SqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@Username", username);
        command.Parameters.AddWithValue("@Email", email);
        
        connection.Open();
        command.ExecuteNonQuery();
    }
}
