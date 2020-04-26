using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp107
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Date_pers
    {
        public string nume;
        public string prenume;
        public string email; 
        public DateTime data_nasterii;
        public Agenda Agenda;
        public string Date()
        {
            return $"{nume}-{prenume}-{email}-{data_nasterii}";
        }
    }
    public class Activity
    {
        public string Nume;
        public string Descriere;
        public DateTime Inceput;
        public DateTime Sfarsit;
        public List<Date_pers> Participanti;
        public string Date_Activitati()
        {
            return $"{Nume}, {Descriere}, {Inceput.ToString()}, {Sfarsit.ToString()}";
        }
    }
    public class Agenda
    {
        public List<Activity> Activitati;
        public Date_pers Persoana;
    }

    static class Liste
    {
        public static List<Date_pers> Oameni = new List<Date_pers>();
        public static List<Agenda> Agende = new List<Agenda>();
        public static List<Activity> Activitati = new List<Activity>();
        public static Date_pers Persoana(string nume_, string prenume_, string email_, DateTime data_nasterii_)
        {
            Date_pers p = new Date_pers() { nume = nume_, prenume = prenume_, email = email_, data_nasterii = data_nasterii_ };
            Oameni.Add(p);
            return p;
        }
        public static Agenda CreateAgenda(this Date_pers persoana)
        {
            Agenda agenda = new Agenda() { Activitati = new List<Activity>(), Persoana = persoana };
            persoana.Agenda = agenda;
            Agende.Add(agenda);           
            return agenda;
        }
        public static Activity CreateActivity(string nume_, string descriere_, DateTime sdate, DateTime edate)
        {
            Activity activity = new Activity() { Nume = nume_, Descriere = descriere_, Inceput = sdate, Sfarsit = edate };
            activity.Participanti = new List<Date_pers>();

            Activitati.Add(activity);
            
            return activity;
        }
        public static Activity CreateActivity(this Date_pers persona, string Nume_, string Descriere_, DateTime sdate, DateTime edate)
        {
            Activity activity = new Activity() { Nume = Nume_, Descriere = Descriere_, Inceput = sdate, Sfarsit = edate };
            activity.Participanti = new List<Date_pers>() { persona };

            if (persona.Agenda == null) persona.CreateAgenda();
            persona.Agenda.Activitati.Add(activity);
            Activitati.Add(activity);
           
            return activity;
        }
        public static Activity ActivityPlus (this Date_pers persona, Activity activity)
        {
            activity.Participanti.Add(persona);
            if (persona.Agenda == null) persona.CreateAgenda();
            persona.Agenda.Activitati.Add(activity);
           
            return activity;
        }
        public static Activity ActivityMinus(this Date_pers persona, Activity activity)
        {
            if (persona.Agenda == null) return activity;
            persona.Agenda.Activitati.Remove(activity);
            
            return activity;
        }

    }

}
