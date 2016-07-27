using System;
using System.Collections.Generic;
using System.Linq;

public class Song
{
    private string artist;
    private string name;
    private int[] length = new int[2];

    public Song(string artist, string name, int[] length)
    {
        this.Artist = artist;
        this.Name = name;
        this.Length = length;
    }

    public string Artist
    {
        get
        {
            return this.artist;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid song.");
            }
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }

            this.artist = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid song.");
            }
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }

            this.name = value;
        }
    }

    public int[] Length
    {
        get
        {
            return this.length;
        }
        private set
        {
            if (value.Length == 0 || value.Length == 1)
            {
                throw new ArgumentException("Invalid song length.");
            }
            if (value[0] < 0 || value[0] > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            if (value[1] < 0 || value[1] > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }

            this.length = value;
        }
    }
}

public class OnlineRadioDatabase
{
    public static void Main()
    {
        int numberOfSongsToBeAdded = int.Parse(Console.ReadLine());
        List<Song> playlist = new List<Song>();

        for (int i = 0; i < numberOfSongsToBeAdded; i++)
        {
            string[] data = Console.ReadLine().Split(';');
            string artist = data[0];
            string name = data[1];
            string duration = data[2];
            int[] length = new[] { 0, 0 };

            try
            {
                length = duration.Split(':').Select(int.Parse).ToArray();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid song length.");
                continue;
            }

            try
            {
                Song currentSong = new Song(artist, name, length);
                playlist.Add(currentSong);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                continue;
            }

            Console.WriteLine("Song added.");
        }

        Console.WriteLine("Songs added: " + playlist.Count);

        int minutes = playlist.Sum(s => s.Length[0]);
        int seconds = playlist.Sum(s => s.Length[1]);

        long totalSeconds = minutes * 60 + seconds;

        int hours = (int)totalSeconds / 3600;
        totalSeconds -= hours * 3600;
        minutes = (int)totalSeconds / 60;
        totalSeconds -= minutes * 60;
        seconds = (int)totalSeconds;

        Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
    }
}