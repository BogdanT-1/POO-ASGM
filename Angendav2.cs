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
            List<Date_pers> perosoane = new List<Date_pers>();
            var temp = new Date_pers();
            temp = Liste.New_Persoana("Muntean", "Ion","MI@gmail.com", new DateTime(1955, 5, 17));
            perosoane.Add(temp);
            var temp1 = new Date_pers();
            temp1 = Liste.New_Persoana("Ion", "Ion", "II@gmail.com", new DateTime(1975, 3, 27));
            perosoane.Add(temp1);
            var temp2 = new Date_pers();
            temp2 = Liste.New_Persoana("Pop", "Andrei", "PA@gmail.com", new DateTime(1995, 10, 12));
            perosoane.Add(temp2);
            var temp3 = new Date_pers();
            temp3 = Liste.New_Persoana("Popa", "Rebeca", "PR@gmail.com", new DateTime(2003, 7, 2));
            perosoane.Add(temp3);

            List<Activity> activitati = new List<Activity>();
            var tempA = new Activity();
            tempA = Liste.New_Activity("sala", "gretutati-cardio", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(2));
            activitati.Add(tempA);
            var temp1A = new Activity();
            temp1A = Liste.New_Activity("fotbal", "cu colegii", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2));
            activitati.Add(temp1A);
            var temp2A = new Activity();
            temp2A = Liste.New_Activity("baschet", "cu preitenii", DateTime.Now.AddDays(5), DateTime.Now.AddDays(5).AddHours(3));
            activitati.Add(temp2A);
            var temp3A = new Activity();
            temp3A = Liste.New_Activity("inot", "cadio-polo", DateTime.Now.AddHours(12), DateTime.Now.AddHours(13));
            activitati.Add(temp3A);

            int i;
            Random rnd = new Random();
            foreach (var persoana in perosoane )
            {
                foreach(var activitate in activitati)
                {
                    
                    i=rnd.Next(10);
                    if(i%2==0)
                    persoana.ActivityPlus(activitate);
                }
                    
            }

            
            var pers_random = rnd.Next(perosoane.Count);
            var actv_random = rnd.Next(activitati.Count);
            string c = activitati[actv_random].ToString();

            List<Activity> ActivitatiPersonale = perosoane[pers_random].SearchActivity_Name(c);
            
            Console.WriteLine(perosoane[pers_random]+"are urmatoarele activitati:");
            ActivitatiPersonale.ForEach(Console.WriteLine);

            Console.WriteLine();
            perosoane[pers_random].SearchActivity_Interval(new DateTime(2020, 4, 27), new DateTime(2020, 4, 30));
            Liste.ActivityDelete(activitati[actv_random]);

            Console.ReadKey();
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
        public static Date_pers New_Persoana(string nume_, string prenume_, string email_, DateTime data_nasterii_)
        {
            Date_pers p = new Date_pers() { nume = nume_, prenume = prenume_, email = email_, data_nasterii = data_nasterii_ };
            Oameni.Add(p);
            return p;
        }
        public static Agenda New_Agenda(this Date_pers persoana)
        {
            Agenda agenda = new Agenda() { Activitati = new List<Activity>(), Persoana = persoana };
            persoana.Agenda = agenda;
            Agende.Add(agenda);           
            return agenda;
        }
        public static Activity New_Activity(string nume_, string descriere_, DateTime sdate, DateTime edate)
        {
            Activity activity = new Activity() { Nume = nume_, Descriere = descriere_, Inceput = sdate, Sfarsit = edate };
            activity.Participanti = new List<Date_pers>();

            Activitati.Add(activity);
            
            return activity;
        }
        
        public static Activity ActivityPlus (this Date_pers persona, Activity activity)
        {
            activity.Participanti.Add(persona);
            if (persona.Agenda == null) persona.New_Agenda();
            persona.Agenda.Activitati.Add(activity);
           
            return activity;
        }
        public static Activity ActivityMinus(this Date_pers persona, Activity activity)
        {
            if (persona.Agenda == null) return activity;
            persona.Agenda.Activitati.Remove(activity);
            
            return activity;
        }
        public static List<Activity> SearchActivity_Name(this Date_pers persona, string nume)
        {
            nume.ToLower().Trim();
            if (persona.Agenda == null) return new List<Activity>();
            List<Activity> Temp = persona.Agenda.Activitati.Where(a => a.Nume.ToLower().Contains(nume)).ToList();
            return Temp;
        }
        public static List<Activity> SearchActivity_Interval(this Date_pers persona, DateTime sdate, DateTime edate)
        {
            if (persona.Agenda == null) return new List<Activity>();
            List<Activity> Temp = persona.Agenda.Activitati.Where(a => a.Inceput >= sdate && a.Sfarsit <= edate).ToList();

            if (Temp.Count == 0)
            {
                Console.WriteLine("Nu s-a gasit activitate la ora respectiva");
                return Temp;
            }

            foreach (Activity activity in Temp)
                Console.WriteLine($"Exista activitatea: {activity.Date_Activitati()}la ora respectiva ");

            return Temp;
        }
        public static Activity ActivityDelete(Activity activity)
        {
            foreach (Date_pers person in activity.Participanti)
                person.ActivityMinus(activity);

            activity.Participanti.Clear();
            Activitati.Remove(activity);

            
            return activity;
        }

    }

}
