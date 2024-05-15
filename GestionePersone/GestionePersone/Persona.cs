public class Persona
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Sesso { get; set; }
    public string LuogoNascita { get; set; }
    public DateTime DataNascita { get; set; }
    public string CF { get; set; }

    public Persona() { }

    public Persona(string nome, string cognome, string sesso, string luogoNascita, DateTime dataNascita, string Cf)
    {
        Nome = nome;
        Cognome = cognome;
        Sesso = sesso;
        LuogoNascita = luogoNascita;
        DataNascita = dataNascita;
        CF = Cf;
    }
}
