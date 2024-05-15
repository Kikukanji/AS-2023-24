class View
{
    PersonaDAO personaDAO;

    public View()
    {
        personaDAO = new PersonaDAO();
    }

    public void LeggiDB(PersonaDAODB personaDAODB)
    {
        personaDAO.LeggiDB(personaDAODB.Lettura());
    }

    public string LeggiStringa(string mess)
    {
        Console.Write(mess);
        return Console.ReadLine();
    }

    public string LeggiStringaSesso(string mess)
    {
        Console.Write(mess);
        string str = Console.ReadLine();

        while (str.ToLower() != "maschio" && str.ToLower() != "femmina" && str.ToLower() != "altro" && !String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(str))
        {
            Console.WriteLine("ERRORE: inserire un valore valido (maschio - femmina - altro).");
            Console.Write(mess);
            str = Console.ReadLine();
        }
        return str;
    }

    public string LeggiStringaPrima(string mess, bool isSesso)
    {
        string str;
        if (isSesso)
            str = LeggiStringaSesso(mess);
        else
            str = LeggiStringa(mess);
        while (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
        {

            if (isSesso)
            {
                Console.WriteLine("ERRORE: inserire un valore valido (maschio - femmina - altro).");
                str = LeggiStringaSesso(mess);
            }
            else
            {
                Console.WriteLine("ERRORE: inserire un valore valido");
                str = LeggiStringa(mess);
            }
        }
        return str;
    }

    public int LeggiIntero(string mess)
    {
        Console.Write(mess);
        int n;
        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("ERRORE: inserire un numero intero.");
            Console.Write(mess);
        }
        return n;
    }

    public DateTime LeggiData(string mess)
    {
        Console.Write(mess);
        DateTime data;
        while (!DateTime.TryParse(Console.ReadLine(), out data))
        {
            Console.WriteLine("ERRORE: inserire una formato di data valido(gg/mm/aaaa).");
            Console.Write(mess);
        }
        return data;
    }

    public void Pausa()
    {
        Console.WriteLine("Premi per continuare.");
        Console.ReadKey();
    }

    public void MenuPrincipale()
    {
        Console.Clear();
        Console.WriteLine("<--- Menu Principale --->");
        Console.WriteLine("1) Inserisci");
        Console.WriteLine("2) Modifica");
        Console.WriteLine("3) Cancella");
        Console.WriteLine("4) Trova");
        Console.WriteLine("5) Stampa elenco persone");
        Console.WriteLine("6) Visualizza scheda persona");
        Console.WriteLine("7) Esci");
    }

    public void MenuModifica(PersonaDAODB personaDAODB)
    {
        if (personaDAO.GetPersone().Count > 0)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("<--- Menu Modifica --->");
                Console.WriteLine("1) Cerca per Id");
                Console.WriteLine("2) Cerca per nome e cognome");
                Console.WriteLine("3) Torna indietro");
                choice = LeggiIntero("Scegli:");
                switch (choice)
                {
                    case 1:
                        Modifica(TrovaId(), personaDAODB);
                        Pausa();
                        break;
                    case 2:
                        Modifica(TrovaNomeCognome(), personaDAODB);
                        Pausa();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            } while (choice != 3);
        }
        else
            Console.WriteLine("ERRORE: non sono presenti persone nell'elenco.");
    }

    public void MenuTrova()
    {
        if (personaDAO.GetPersone().Count > 0)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("<--- Menu Trova --->");
                Console.WriteLine("1) Cerca per Id");
                Console.WriteLine("2) Cerca per nome e cognome");
                Console.WriteLine("3) Torna indietro");
                choice = LeggiIntero("Scegli:");
                switch (choice)
                {
                    case 1:
                        TrovaId();
                        break;
                    case 2:
                        TrovaNomeCognome();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            } while (choice != 3);
        }
        else
            Console.WriteLine("ERRORE: non sono presenti persone nell'elenco.");
    }

    public void MenuRimuovi(PersonaDAODB personaDAODB)
    {
        if (personaDAO.GetPersone().Count > 0)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("<--- Menu Elimina --->");
                Console.WriteLine("1) Cerca per Id");
                Console.WriteLine("2) Torna indietro");
                choice = LeggiIntero("Scegli:");
                switch (choice)
                {
                    case 1:
                        Rimuovi(TrovaId(), personaDAODB);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            } while (choice != 2);
        }
        else
            Console.WriteLine("ERRORE: non sono presenti persone nell'elenco.");
    }

    public void Rimuovi(int id, PersonaDAODB personaDAODB)
    {
        string choice;
        if (id != -1)
        {
            choice = LeggiStringa("Vuoi rimuovere: (y/n)");
            while (choice != "y" && choice != "n")
            {
                Console.WriteLine("ERRORE: inserire un valore valido (y/n)");
                choice = LeggiStringa("Vuoi rimuovere: (y/n)");
            }
            if (choice == "y")
            {
                personaDAO.Rimuovi(id, personaDAODB);
                Console.WriteLine("Persona rimossa con successo!");
                Pausa();
            }
        }
    }

    public void InserisciPersona(Persona p, PersonaDAODB personaDAODB)
    {
        p.Nome = LeggiStringaPrima("Nome:", false);
        p.Cognome = LeggiStringaPrima("Cognome:", false);
        p.LuogoNascita = LeggiStringaPrima("Luogo di nascita:", false);
        p.DataNascita = LeggiData("Data di nascita:");
        p.Sesso = LeggiStringaPrima("Sesso (maschio - femmina - altro):", true);
        p.CF = LeggiStringaPrima("Codice fiscale:", false);
        personaDAO.Inserisci(p, personaDAODB);
        Console.WriteLine("Persona aggiunta con successo!");
    }

    public int TrovaId()
    {
        int id, found = -1, pos = -1;
        List<Persona> repository = personaDAO.GetPersone();
        id = LeggiIntero("Inserisci id:");
        for (int i = 0; i < repository.Count; i++)
        {
            if (repository[i].Id == id)
            {
                found = id;
                pos = i;
                break;
            }
        }
        if (found == -1)
        {
            Console.WriteLine("ERRORE: non è presente un utente con questo id.");
        }
        else VisualizzaSchedaPersone(pos);
        return found;
    }

    public int TrovaNomeCognome()
    {
        List<int> found = new List<int>();
        string nome, cognome;
        List<Persona> repository = personaDAO.GetPersone();
        nome = LeggiStringa("Inserisci nome:");
        cognome = LeggiStringa("Inserisci cognome:");
        for (int i = 0; i < repository.Count; i++)
        {
            if (repository[i].Nome == nome && repository[i].Cognome == cognome)
            {
                found.Add(i);
            }
        }
        if (found.Count == 0)
        {
            Console.WriteLine("ERRORE: non esistono utenti con questo nome e cognome");
            return -1;
        }
        else
        {
            if (found.Count == 1)
            {
                int id = found[0];
                VisualizzaSchedaPersone(id);
                return id;
            }
            else
            {
                VisualizzaPersone(found);
                return TrovaId();
            }
        }
        return -1;
    }

    public void Modifica(int found, PersonaDAODB personaDAODB)
    {
        if (found != -1)
        {
            Persona persona = new Persona();
            int pos = -1;
            for(int i = 0; i < personaDAO.GetPersone().Count; i++)
            {
                if (personaDAO.GetPersone()[i].Id == found)
                {
                    pos = i;
                    break;
                }
            }
            persona = personaDAO.GetPersone()[pos];
            string var = LeggiStringa($"[{persona.Nome}] Nome:");
            if (!String.IsNullOrEmpty(var) && !String.IsNullOrWhiteSpace(var))
                persona.Nome = var;
            var = LeggiStringa($"[{persona.Cognome}] Cognome:");
            if (!String.IsNullOrEmpty(var) && !String.IsNullOrWhiteSpace(var))
                persona.Cognome = var;
            var = LeggiStringaSesso($"[{persona.Sesso}] Sesso:");
            if (!String.IsNullOrEmpty(var) && !String.IsNullOrWhiteSpace(var))
                persona.Sesso = var;
            var = LeggiStringa($"[{persona.LuogoNascita}] Luogo di nascita:");
            if (!String.IsNullOrEmpty(var) && !String.IsNullOrWhiteSpace(var))
                persona.LuogoNascita = var;
            DateTime vardata;
            bool ok = false;
            while (!ok)
            {
                var = LeggiStringa($"[{persona.DataNascita.Day}/{persona.DataNascita.Month}/{persona.DataNascita.Year}] Data di nascita:");

                if (!String.IsNullOrEmpty(var) && !String.IsNullOrWhiteSpace(var))
                {
                    if (!DateTime.TryParse(var, out vardata))
                    {
                        Console.WriteLine("ERRORE: inserire una formato di data valido(gg/mm/aaaa).");
                        ok = false;
                    }
                    else
                    {
                        ok = true;
                        persona.DataNascita = vardata;
                    }
                }
                else
                    ok = true;
            }
            var = LeggiStringa($"[{persona.CF}] Codice fiscale:");
            if (!String.IsNullOrEmpty(var) && !String.IsNullOrWhiteSpace(var))
                persona.CF = var;
            personaDAO.Modifica(persona, found, personaDAODB);
        }
    }

    public void VisualizzaPersone()
    {
        List<Persona> repository = personaDAO.GetPersone();
        if (repository.Count > 0)
        {
            Console.WriteLine($"ID\tNome\t\tCognome");

            for (int i = 0; i < repository.Count; i++)
            {
                Console.WriteLine($"[{repository[i].Id}]\t{repository[i].Nome}\t\t{repository[i].Cognome}");
            }
        }
        else
            Console.WriteLine("ERRORE: non sono presenti persone nell'elenco.");
    }

    public void VisualizzaPersone(List<int> ids)
    {
        List<Persona> repository = personaDAO.GetPersone();
        if (repository.Count > 0)
        {
            Console.WriteLine($"ID\tNome\t\tCognome");
            for (int i = 0; i < ids.Count; i++)
            {
                Console.WriteLine($"[{repository[ids[i]].Id}]\t{repository[ids[i]].Nome}\t\t{repository[ids[i]].Cognome}");
            }
        }
        else
            Console.WriteLine("ERRORE: non sono presenti persone nell'elenco.");
    }

    public void VisualizzaSchedaPersone(Impaginazione impaginazione)
    {
        List<Persona> repository = personaDAO.GetPersone();
        if (repository.Count > 0)
        {
            int choice;
            Console.Clear();
            double tmp = Convert.ToDouble(repository.Count) / Convert.ToDouble(impaginazione.LungezzaPagina);
            int ultimaPagina = Convert.ToInt32(Math.Ceiling(tmp));
            int offset = (impaginazione.PaginaCorrente - 1) * impaginazione.LungezzaPagina;
            for (int i = offset; i < offset + impaginazione.LungezzaPagina; i++)
            {
                if (i < repository.Count)
                {
                    Console.WriteLine($"<--- Scheda N°{i + 1} --->\n");
                    Console.WriteLine($"Id: {repository[i].Id}");
                    Console.WriteLine($"Nome: {repository[i].Nome}");
                    Console.WriteLine($"Cognome: {repository[i].Cognome}");
                    Console.WriteLine($"Sesso: {repository[i].Sesso}");
                    Console.WriteLine($"Luogo di nascita: {repository[i].LuogoNascita}");
                    Console.WriteLine($"Data di nascita: {repository[i].DataNascita.Day}/{repository[i].DataNascita.Month}/{repository[i].DataNascita.Year}");
                    Console.WriteLine($"Codice fiscale: {repository[i].CF}\n");
                }
                else
                    Console.WriteLine("");
            }
            choice = LeggiIntero("1) Prima pagina 2) Pagina precendente 3) Pagina successiva 4) Ultima pagina 5)Esci\n");
            switch (choice)
            {
                case 1:
                    impaginazione.PaginaCorrente = 1;
                    VisualizzaSchedaPersone(impaginazione);
                    break;
                case 2:
                    if (impaginazione.PaginaCorrente != 1)
                    {
                        impaginazione.PaginaCorrente--;
                        VisualizzaSchedaPersone(impaginazione);
                    }
                    else
                        VisualizzaSchedaPersone(impaginazione);
                    break;
                case 3:
                    if (impaginazione.PaginaCorrente != ultimaPagina)
                    {
                        impaginazione.PaginaCorrente++;
                        VisualizzaSchedaPersone(impaginazione);
                    }
                    else
                        VisualizzaSchedaPersone(impaginazione);
                    break;
                case 4:
                    impaginazione.PaginaCorrente = ultimaPagina;
                    VisualizzaSchedaPersone(impaginazione);
                    break;
                case 5:
                    break;
                default:
                    VisualizzaSchedaPersone(impaginazione);
                    break;
            }
        }
        else
            Console.WriteLine("ERRORE: non sono presenti persone nell'elenco.");
    }

    public void VisualizzaSchedaPersone(int id)
    {
        List<Persona> repository = personaDAO.GetPersone();
        Console.WriteLine($"Id: {repository[id].Id}");
        Console.WriteLine($"Nome: {repository[id].Nome}");
        Console.WriteLine($"Cognome: {repository[id].Cognome}");
        Console.WriteLine($"Sesso: {repository[id].Sesso}");
        Console.WriteLine($"Luogo di nascita: {repository[id].LuogoNascita}");
        Console.WriteLine($"Data di nascita: {repository[id].DataNascita.Day}/{repository[id].DataNascita.Month}/{repository[id].DataNascita.Year}");
        Console.WriteLine($"Codice fiscale: {repository[id].CF}");
        Pausa();
    }
}