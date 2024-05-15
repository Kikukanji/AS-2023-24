using MySql.Data.MySqlClient;

class PersonaDAODB
{
    public string ConnString { get; set; }
    public MySqlConnection Conn { get; set; }
    public PersonaDAODB()
    {
        ConnString = "Server=localhost; Database=dbpersone; User id=root; Password=;";
        ApriConnessione();
    }
    public bool ApriConnessione()
    {
        Conn = new MySqlConnection(ConnString);
        try
        {
            Conn.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }
    public bool ChiudiConnessione()
    {
        try
        {
            Conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public void Inserimento(Persona persona)
    {
        try
        {
            string query = "Insert into persone (nome, cognome, sesso, luogonascita, datanascita, cf)" +
                "values(@nome, @cognome,@sesso, @luogonascita, @datanascita, @cf)";
            using (MySqlCommand cmd = new MySqlCommand(query, Conn))
            {
                cmd.Parameters.AddWithValue("@nome", persona.Nome);
                cmd.Parameters.AddWithValue("@cognome", persona.Cognome);
                cmd.Parameters.AddWithValue("@sesso", persona.Sesso);
                cmd.Parameters.AddWithValue("@luogonascita", persona.LuogoNascita);
                cmd.Parameters.AddWithValue("@datanascita", persona.DataNascita);
                cmd.Parameters.AddWithValue("@cf", persona.CF);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public List<Persona> Lettura()
    {
        try
        {
            string query = "SELECT * from persone;";
            MySqlCommand cmd = new MySqlCommand(query, Conn);
            List<Persona> repository = new List<Persona>();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    repository.Add(new Persona());
                    repository.Last().Id = Convert.ToInt32(reader["id"]);
                    repository.Last().Nome = Convert.ToString(reader["nome"]);
                    repository.Last().Cognome = Convert.ToString(reader["cognome"]);
                    repository.Last().Sesso = Convert.ToString(reader["sesso"]);
                    repository.Last().LuogoNascita = Convert.ToString(reader["luogonascita"]);
                    repository.Last().DataNascita = Convert.ToDateTime(reader["datanascita"]);
                    repository.Last().CF = Convert.ToString(reader["cf"]);
                }
            }
            return repository;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public void Modifica(Persona persona)
    {
        try
        {
            string query = "Update persone set nome = @nome, cognome = @cognome, sesso = @sesso, luogonascita = @luogonascita," +
                "datanascita = @datanascita, cf = @cf where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(query, Conn))
            {
                cmd.Parameters.AddWithValue("@nome", persona.Nome);
                cmd.Parameters.AddWithValue("@cognome", persona.Cognome);
                cmd.Parameters.AddWithValue("@sesso", persona.Sesso);
                cmd.Parameters.AddWithValue("@luogonascita", persona.LuogoNascita);
                cmd.Parameters.AddWithValue("@datanascita", persona.DataNascita);
                cmd.Parameters.AddWithValue("@cf", persona.CF);
                cmd.Parameters.AddWithValue("@id", persona.Id);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Rimuovi(int id)
    {
        try
        {
            string query = $"delete from persone where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(query, Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}