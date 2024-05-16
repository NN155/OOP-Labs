using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task01
{
    class Program
    {
        static void Main()
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Початок програми");
            System.DateTime dateStart = new DateTime(2020, 5, 12);
            System.DateTime dateEnd = DateTime.Now;
            TimeFrame Time = new TimeFrame(dateStart, dateEnd);
            Statistics match = new Statistics(42, dateStart);
            FootballPlayer player = new FootballPlayer("Sasha", "Ukrainian", 5, Time, match);
            Random random = new Random();
            int randomNumber, randomYear, randomMounth, randomDay;
            for (int i = 0; i < 10; i++)
            {
                randomNumber = random.Next(1, 10000);
                randomYear = random.Next(2018, 2024);
                randomMounth = random.Next(1, 13);
                randomDay = random.Next(1, 28);
                dateStart = new DateTime(randomYear, randomMounth, randomDay);
                match = new Statistics(randomNumber, dateStart);
                player.AddMatch(match);
            }
            Console.WriteLine(player);
            Console.ReadLine();
        }
    }
    class Team
    {
        public string name;
        public double budget;
        public System.DateTime date;
        public Team(string Name, double Budget, DateTime Date)
        {
            this.name = Name;
            this.budget = Budget;
            this.date = Date;
        }
        public Team()
        {
            this.name = "Team1";
            this.budget = 5000;
            this.date = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Команда: {this.name}, Бюджет: {this.budget}, Початок сезону: {this.date}";
        }
    }
    class FootballPlayer
    {
        private string name;
        private string nationality;
        private int registrationNumber;
        private TimeFrame? time;
        private Statistics[]? quantityPlayedGame;
        public TimeFrame? Time
        {
            get
            {
                if (time == null) { return null; }
                if (time.dateEnd == null)
                {
                    time.Bool = true;
                    return time;
                }
                time.Bool = false;
                return time;
            }
            set { time = value; }
        }

        public Statistics[]? QuantityPlayedGame
        {
            get
            {
                if (this.quantityPlayedGame == null)
                {
                    return null;
                }
                Statistics? needMatch = null;
                Statistics? match;
                for (int i = 0; i < this.quantityPlayedGame.Length; i++)
                {

                    match = this.quantityPlayedGame[i];
                    if (needMatch == null || needMatch.date < match.date)
                    {
                        needMatch = match;
                    }
                }
                Statistics[] temp = new Statistics[1];
                temp[0] = needMatch;
                return temp;
            }
            set { this.quantityPlayedGame = value; }
        }
        public void AddMatch(params Statistics[] matches)
        {
            List<Statistics> temp = new List<Statistics>();
            if (this.QuantityPlayedGame != null)
            {
                foreach (var i in this.QuantityPlayedGame)
                {
                    temp.Add(i);
                }
            }
            foreach (var i in matches)
            {
                temp.Add(i);
            }
            this.QuantityPlayedGame = new Statistics[temp.Count];

            for (int i = 0; i < temp.Count; i++)
            {
                this.quantityPlayedGame[i] = temp[i];
            }

        }


        public FootballPlayer(string Name, string Nationality, int RegistrationNumber, TimeFrame Time, Statistics QuantityPlayedGame)
        {
            this.name = Name;
            this.nationality = Nationality;
            this.registrationNumber = RegistrationNumber;
            this.Time = Time;
            this.QuantityPlayedGame = new Statistics[] { QuantityPlayedGame };
        }
        public FootballPlayer()
        {
            this.name = "Stetsiuk O.O.";
            this.nationality = "Ukrainian";
            this.registrationNumber = 5;
            this.Time = null;
            this.QuantityPlayedGame = null;
        }
        public override string ToString()
        {
            return $"І'мя: {this.name}, Громадянство: {this.nationality}, Номер реєстрації: {this.registrationNumber}, Тривалість сезону: {this.Time}, Остання зіграна гра {this.QuantityPlayedGame[0]}";
        }
    }
    class Statistics
    {
        public int id;
        public System.DateTime date;
        public Statistics(int Id, System.DateTime Date)
        {
            this.id = Id;
            this.date = Date;
        }
        public override string ToString()
        {
            return $"Id: {this.id}, Time: {this.date}";
        }
    }
    class TimeFrame
    {
        public bool Bool;
        public System.DateTime dateStart;
        public System.DateTime? dateEnd;
        public TimeFrame(DateTime dateStart, DateTime dateEnd)
        {
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
        }
        public TimeFrame(DateTime dateStart)
        {
            this.dateStart = dateStart;
            this.dateEnd = null;
        }
        public override string ToString()
        {
            if (this.Bool)
            {
                return $"DateStart = {this.dateStart}";
            }
            return $"DateStart = {this.dateStart}, DateEnd = {this.dateEnd}";
        }
    }
}