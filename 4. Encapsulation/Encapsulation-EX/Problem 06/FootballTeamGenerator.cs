using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();        
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public int GetRating()
    {
        if (this.players.Count == 0)
        {
            return 0;
        }
        return (int)Math.Round(this.players.Average(p => p.AverageStat));
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string nameOfPlayer)
    {
        bool hasPlayer = this.players.Any(p => p.Name == nameOfPlayer);
        if (hasPlayer)
        {
            this.players.RemoveAll(p => p.Name == nameOfPlayer);
        }
        else
        {
            throw new ArgumentException($"Player {nameOfPlayer} is not in {this.name} team.");
        }
    }
}

public class Player
{
    private string name;
    private int[] stats;
    private double averageStat;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Stats = new[] { endurance, sprint, dribble, passing, shooting };
        this.averageStat = this.Stats.Average();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public int[] Stats
    {
        get
        {
            return this.stats;
        }
        private set
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] > 100 || value[i] < 0)
                {
                    string stat = string.Empty;
                    switch (i)
                    {
                        case 0:
                            stat = "Endurance";
                            break;
                        case 1:
                            stat = "Sprint";
                            break;
                        case 2:
                            stat = "Dribble";
                            break;
                        case 3:
                            stat = "Passing";
                            break;
                        case 4:
                            stat = "Shooting";
                            break;
                        default:
                            break;
                    }
                    throw new ArgumentException($"{stat} should be between 0 and 100.");
                }
            }

            this.stats = value;
        }
    }

    public double AverageStat
    {
        get
        {
            return this.averageStat;
        }
    }
}

public class FootballTeamGenerator
{
    public static void Main()
    {
        List<Team> teams = new List<Team>();
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] data = input.Split(';');

            if (data[0] == "Team")
            {
                try
                {
                    teams.Add(new Team(data[1]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            else if (data[0] == "Add")
            {
                if (!teams.Any(t => t.Name == data[1]))
                {
                    Console.WriteLine($"Team {data[1]} does not exist.");
                }
                else
                {
                    Team currentTeam = teams.First(t => t.Name == data[1]);
                    try
                    {
                        Player currentPlayer = new Player(data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                        currentTeam.AddPlayer(currentPlayer);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                }
            }
            else if (data[0] == "Remove")
            {
                if (!teams.Any(t => t.Name == data[1]))
                {
                    Console.WriteLine($"Team {data[1]} does not exist.");
                }
                else
                {
                    Team currentTeam = teams.First(t => t.Name == data[1]);
                    try
                    {
                        currentTeam.RemovePlayer(data[2]);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else if (data[0] == "Rating")
            {
                if (!teams.Any(t => t.Name == data[1]))
                {
                    Console.WriteLine($"Team {data[1]} does not exist.");
                }
                else
                {
                    Team currentTeam = teams.First(t => t.Name == data[1]);
                    Console.WriteLine($"{currentTeam.Name} - {currentTeam.GetRating()}");
                }
            }

            input = Console.ReadLine();
        }
    }
}