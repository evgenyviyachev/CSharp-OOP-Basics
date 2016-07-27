using System;
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public Trainer(string name)
    {
        this.name = name;
        this.numberOfBadges = 0;
        this.pokemons = new List<Pokemon>();
    }

    public string name;
    public int numberOfBadges;
    public List<Pokemon> pokemons;
    public int counter;
}

public class Pokemon
{
    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public string name;
    public string element;
    public int health;
}

public class PokemonTrainer
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Trainer> trainers = new List<Trainer>();
        int counter = 0;

        while (input != "Tournament")
        {
            counter++;
            string[] info = input.Trim().Split();
            string trainerName = info[0];
            string pokemonName = info[1];
            string pokemonElement = info[2];
            int pokemonHealth = int.Parse(info[3]);
                        
            if (!trainers.Any(t => t.name == trainerName))
            {
                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                currentTrainer.pokemons.Add(currentPokemon);
                currentTrainer.counter = counter;
                trainers.Add(currentTrainer);
            }
            else
            {
                Trainer currentTrainer = trainers.FirstOrDefault(t => t.name == trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                currentTrainer.pokemons.Add(currentPokemon);
            }

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "End")
        {
            string currentElement = input;

            foreach (var trainer in trainers)
            {
                if (trainer.pokemons.Any(p => p.element == currentElement))
                {
                    trainer.numberOfBadges++;
                }
                else
                {
                    for (int i = trainer.pokemons.Count - 1; i >= 0; i--)
                    {
                        trainer.pokemons[i].health -= 10;
                        if (trainer.pokemons[i].health <= 0)
                        {
                            trainer.pokemons.RemoveAt(i);
                        }
                    }
                }
            }

            input = Console.ReadLine();
        }
        
        var trainersSorted = trainers
            .OrderByDescending(t => t.numberOfBadges)
            .ThenBy(t => t.counter)
            .ToList();

        foreach (var trainer in trainersSorted)
        {
            Console.WriteLine($"{trainer.name} {trainer.numberOfBadges} {trainer.pokemons.Count}");
        }
    }
}