class PersonaDAO
{
    List<Persona> repository;

    public PersonaDAO()
    {
        repository = new List<Persona>();
    }

    public void LeggiDB(List<Persona> personas)
    {
        if (personas != null)
            repository = personas;
    }

    public void Inserisci(Persona p, PersonaDAODB personaDAODB)
    {
        if(repository.Count > 0)
            p.Id = repository.Last().Id + 1;
        else p.Id = 1;
        personaDAODB.ApriConnessione();
        personaDAODB.Inserimento(p);
        repository.Add(p);
    }

    public void Modifica(Persona persona, int id, PersonaDAODB personaDAODB)
    {
        int pos = -1;
        for (int i = 0; i < repository.Count; i++)
        {
            if (repository[i].Id == id)
            {
                pos = i;
                break;
            }
        }
        personaDAODB.Modifica(persona);
        repository[pos] = persona;
    }

    public void Rimuovi(int id, PersonaDAODB personaDAODB)
    {
        int pos = -1;
        for (int i = 0; i < repository.Count; i++)
        {
            if (repository[i].Id == id)
            {
                pos = i;
                break;
            }
        }
        personaDAODB.Rimuovi(id);
        repository.RemoveAt(pos);
    }

    public List<Persona> GetPersone()
    {
        return repository;
    }
}
