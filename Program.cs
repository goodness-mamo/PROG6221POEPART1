using System;
using System.IO;
using System.Media;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Title = "Cybersecurity Awareness Bot";

        PlayVoiceGreeting();
        ShowAsciiArt();
        StartChat();
    }

    // 1. Voice Greeting
    static void PlayVoiceGreeting()
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.PlaySync();
        }
        catch
        {
            Console.WriteLine("⚠️ Could not play audio. Make sure greeting.wav exists.");
        }
    }

    // 2. ASCII Image
    static void ShowAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine(@"
   ____            _                  _____           _   
  / ___| _   _ ___| |_ ___ _ __ ___  | ____|_ __   __| |  
 | |    | | | / __| __/ _ \ '_ ` _ \ |  _| | '_ \ / _` |  
 | |___ | |_| \__ \ ||  __/ | | | | || |___| | | | (_| |  
  \____| \__, |___/\__\___|_| |_| |_||_____|_| |_|\__,_|  
         |___/                                            
   CYBERSECURITY AWARENESS BOT
");

        Console.ResetColor();
    }

    // 3. Chat interaction
    static void StartChat()
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            name = "User";
        }

        Console.ForegroundColor = ConsoleColor.Green;
        TypeText($"\nHello {name}! Welcome to the Cybersecurity Awareness Bot.\n");
        Console.ResetColor();

        while (true)
        {
            Console.Write("\nAsk me something (or type 'exit'): ");
            string input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
                continue;
            }

            if (input == "exit")
            {
                Console.WriteLine("Goodbye! Stay safe online 👋");
                break;
            }

            Respond(input);
        }
    }

    // 4. Response system
    static void Respond(string input)
    {
        if (input.Contains("how are you"))
        {
            Console.WriteLine("I'm just a bot, but I'm running securely 😄");
        }
        else if (input.Contains("purpose"))
        {
            Console.WriteLine("I help you stay safe online by giving cybersecurity tips.");
        }
        else if (input.Contains("password"))
        {
            Console.WriteLine("Use strong passwords with letters, numbers, and symbols. Never reuse passwords!");
        }
        else if (input.Contains("phishing"))
        {
            Console.WriteLine("Be careful of suspicious emails. Never click unknown links.");
        }
        else if (input.Contains("safe browsing"))
        {
            Console.WriteLine("Always check for HTTPS and avoid unsafe websites.");
        }
        else
        {
            Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
        }
    }

    // 6. Typing effect
    static void TypeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
    }
}