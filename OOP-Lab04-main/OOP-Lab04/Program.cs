using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Task01
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Team team1 = new Team("BigTrio", 8, new System.DateTime(2023, 5, 10));
            Team team2 = new Team("BigTrio", 8, new System.DateTime(2023, 5, 10));
            Console.WriteLine($"1) Рівність даних: {team1 == team2},Хеш-код команди 1:{team1.GetHashCode()}, Хеш-код команди 2: {team2.GetHashCode()}");
            try
            {
                Team2 team3 = new Team2("ErrorTeam", -1);
                Console.WriteLine("Блок try відпрацював");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"2) Помилка: {ex.Message}");
            }
            FootballPlayer player1 = new FootballPlayer();
            DateTime dateStart;
            Statistics match;
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
                player1.AddGames(match);
            }
            Person person1 = new Person("Nazar","Cago",DateTime.Now);
            Person person2 = new Person();
            player1.AddMembers(person1, person2);
            Console.WriteLine($"3) player1.PlayedGames:");
            foreach (var i in player1.PlayedGames)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"player1.TeamMembers:");
            foreach (var i in player1.TeamMembers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"4) {player1.team}");
            FootballPlayer player2 = (FootballPlayer)player1.DeepCopy();
            player2.Name = "Oleg";
            Console.WriteLine($"5) Player1 = {player1.ToShortString()}");
            Console.WriteLine($"Player2 = {player2.ToShortString()}");
            Console.WriteLine("7) Зіграно за останні 2 роки: ");
            foreach (Statistics i in player1.PlayedGames) 
            {
                if (i.date.Year >= 2021)
                {

                Console.WriteLine(i); 
                }
            }
        }
        interface INameAndCopy
        {
            string Name { get; set; }
            object DeepCopy();
        }
        class Person
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string surname;
            public string Surname
            {
                get { return surname; }
                set { surname = value; }
            }
            private System.DateTime date;
            public System.DateTime Date
            {
                get { return date; }
                set { date = value; }
            }
            public int DateYear
            {
                get { return date.Year; }
                set { date = new System.DateTime(value); }
            }
            public Person(string Name, string Surname, System.DateTime Date)
            {
                this.name = Name;
                this.surname = Surname;
                this.date = Date;
            }
            public Person()
            {
                this.name = "Oleksandr";
                this.surname = "Stetsiuk";
                this.date = new System.DateTime(2000, 1, 1);
            }
            public override string ToString()
            {
                return $"І'мя: {Name}, Прізвище: {Surname}, Дата народження: {date}";
            }
            public virtual string ToShortString()
            {
                return $"І'мя: {Name}, Прізвище: {Surname}";
            }
            public override bool Equals(object? obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                Person other = (Person)obj;
                return (this.Name == other.Name) && (this.Surname == other.Surname) && (this.Date == other.Date);
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Surname, Date);
            }
            public static bool operator ==(Person person1, Person person2)
            {
                if (person1 is null || person2 is null)
                {
                    return false;
                }

                return (person1.Name == person2.Name) && (person1.Surname == person2.Surname) && (person1.Date == person2.Date); ;
            }
            public static bool operator !=(Person person1, Person person2)
            {
                return !(person1 == person2);
            }
            public virtual object DeepCopy()
            {
                Person person = new Person(this.Name, this.Surname, this.Date);
                return person;
            }
        }
        class Team : INameAndCopy
        {
            public string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public double budget;
            public System.DateTime date;
            public virtual object DeepCopy()
            {
                Team team = new Team(this.name, this.budget, this.date);
                return team;
            }
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
            /*        public override string ToString()
                    {
                        return $"Команда: {this.name}, Бюджет: {this.budget}, Початок сезону: {this.date}";
                    }*/
            public override bool Equals(object? obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                Team other = (Team)obj;
                return (this.Name == other.Name) && (this.budget == other.budget) && (this.date == other.date);
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Name, budget, date);
            }
            public static bool operator ==(Team team1, Team team2)
            {
                if (team1 is null || team2 is null)
                {
                    return false;
                }

                return (team1.Name == team2.Name) && (team1.budget == team2.budget) && (team1.date == team2.date); ;
            }
            public static bool operator !=(Team team1, Team team2)
            {
                return !(team1 == team2);
            }
            public virtual string ToString()
            {
                return $"Команда: {Name}, Бюджет: {budget}, Початок сезону: {date}";
            }
        }

        class Team2 : INameAndCopy
        {
            protected string teamName;
            protected int teamRegistrationNumber;
            public string Name
            {
                get { return teamName; }
                set { teamName = value; }
            }
            protected int TeamRegistrationNumber
            {
                get { return teamRegistrationNumber; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "Номер реєстрації повинен бути більше 0.");
                    }
                    teamRegistrationNumber = value;
                }
            }
            public Team2(string teamName, int teamRegistrationNumber)
            {
                this.teamName = teamName;
                this.TeamRegistrationNumber = teamRegistrationNumber;
            }
            public Team2()
            {
                this.teamName = "BigTrio";
                this.teamRegistrationNumber = 8;
            }
            public virtual object DeepCopy()
            {
                Team2 team = new Team2(this.teamName, this.teamRegistrationNumber);
                return team;
            }
            public override string ToString()
            {
                return $"Ім'я команди: {teamName}, Номер: {teamRegistrationNumber}";
            }
        }
        class FootballPlayer : Team2, INameAndCopy
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private int registrationNumber;
            private string nationality;
            private System.Collections.ArrayList teamMembers = new System.Collections.ArrayList();
            public System.Collections.ArrayList TeamMembers
            {
                get { return teamMembers; }
                set { teamMembers = value; }
            }
            private System.Collections.ArrayList playedGames = new System.Collections.ArrayList();
            public System.Collections.ArrayList PlayedGames
            {
                get { return playedGames; }
                set { teamMembers = value; }
            }
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
            public Team2 team
            {
                get
                {
                    Team2 team = new Team2(this.teamName, this.teamRegistrationNumber);
                    return team;
                }
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
            public void AddGames(params Statistics[] matches)
            {
                foreach (Statistics i in matches)
                {
                    PlayedGames.Add(i);
                }
            }
            public void AddMembers(params Person[] persons)
            {
                foreach (Person i in persons)
                {
                    TeamMembers.Add(i);
                }
            }

            public FootballPlayer(string Name, string Nationality, int RegistrationNumber, TimeFrame Time, Statistics[] QuantityPlayedGame, string teamName, int teamRegistrationNumber) : base(teamName, teamRegistrationNumber)
            {
                this.Name = Name;
                this.registrationNumber = RegistrationNumber;
                this.nationality = Nationality;
                this.Time = Time;
                this.QuantityPlayedGame = QuantityPlayedGame;
            }
            public FootballPlayer(string Name, string Nationality, int RegistrationNumber, TimeFrame Time, Statistics QuantityPlayedGame, string teamName, int teamRegistrationNumber) : base(teamName, teamRegistrationNumber)
            {
                this.Name = Name;
                this.registrationNumber = RegistrationNumber;
                this.nationality = Nationality;
                this.Time = Time;
                this.QuantityPlayedGame = new Statistics[] { QuantityPlayedGame };
            }
            public FootballPlayer() : base()
            {
                this.name = "Stetsiuk O.O.";
                this.registrationNumber = 5;
                this.nationality = "Ukrainian";
                this.Time = null;
                this.QuantityPlayedGame = null;
            }
            public override string ToString()
            {
                return $"І'мя: {this.name}, Громадянство: {this.nationality}, Номер реєстрації: {this.registrationNumber}, Тривалість сезону: {this.Time}, Остання зіграна гра {this.QuantityPlayedGame[0]}";
            }
            public string ToShortString()
            {
                return $"І'мя: {this.name}, Громадянство: {this.nationality}, Номер реєстрації: {this.registrationNumber}, Тривалість сезону: {this.Time}";
            }
            public override object DeepCopy()
            {
                FootballPlayer footballPlayer = new FootballPlayer(this.name, this.nationality, this.registrationNumber, this.time, this.quantityPlayedGame, this.teamName, this.teamRegistrationNumber);
                return footballPlayer;
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
}