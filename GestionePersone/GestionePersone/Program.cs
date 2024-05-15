//TEAM 1: Lopindo Giuseppe, Donnarumma Giovanni, Martino Giuseppe, Cioffi Raffaele, Di Somma Giovanni;
//TEAM 2: D'Esposito Luigi, Cuomo Andrea, Ruggiero Francesco Pio, Verde Giovanni, Tramparulo Vincenzo;
//TEAM 3: Esposito Simone, Carrano Francesco Paolo, Ferrero Giuseppe, Russo Adriano;
//TEAM 4: Caprio Salvatore, Coscarelli Graziano, Langelotti Giuseppe;
// Richiesta lavorativa : Classe con il main, classe dao, classe model, classe view tutte vuote,
// Implementare inserimento e visualizzazione elenco, creare le entità con tutte le proprietà,
// creare tutti i metodi leggi stringhe e leggi intero, creare il menu principale con
// tutte le voci gia assegnate. Nel main aggiungere uno switch che in base alla scelta del menu
// si avvia il programma. Creare la maschera di inserimento nella view e
// creare il metodo di visualizzazione in formato elenco, nel dao creare il repository private,
// creare il metodo inserisci per addare le entità, metodo get persone per
// prendere il contenuto della repository.
// TEMPO STIMATO : Entro pausa pranzo

class Program
{
    static void Main(string[] args)
    {
        PersonaDAODB personaDAODB = new PersonaDAODB();
        Impaginazione impaginazione = new Impaginazione();
        View view = new View();
        personaDAODB.ApriConnessione();
        view.LeggiDB(personaDAODB);
        int choice = 0;
        bool exit = false;
        Persona p;
        

        do
        {
            view.MenuPrincipale();
            choice = view.LeggiIntero("Scegli:");

            switch (choice)
            {
                case 1:
                    p = new Persona();
                    view.InserisciPersona(p, personaDAODB);
                    view.Pausa();
                    break;
                case 2:
                    view.MenuModifica(personaDAODB);
                    view.Pausa();
                    break;
                case 3:
                    view.MenuRimuovi(personaDAODB);
                    view.Pausa();
                    break;
                case 4:
                    view.MenuTrova();
                    view.Pausa();
                    break;
                case 5:
                    view.VisualizzaPersone();
                    view.Pausa();
                    break;
                case 6:
                    view.VisualizzaSchedaPersone(impaginazione);
                    view.Pausa();
                    break;
                case 7:
                    exit = true;
                    personaDAODB.ChiudiConnessione();
                    break;
                default:
                    Console.WriteLine("Scegliere un valore tra 1 e 7.");
                    view.Pausa();
                    break;
            }
            Console.Clear();
        } while (!exit);
    }
}