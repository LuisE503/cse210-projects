using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; 

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToJson(string fileName)
    {
        string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, jsonString);
    }

    public void LoadFromJson(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
    }

    public void DisplayStatistics()
    {
        Console.WriteLine($"\nNumber of Entries: {_entries.Count}");
        if (_entries.Count > 0)
        {
            string earliestDate = _entries[0].Date;
            string latestDate = _entries[_entries.Count - 1].Date;
            Console.WriteLine($"Earliest Entry Date: {earliestDate}");
            Console.WriteLine($"Latest Entry Date: {latestDate}");
        }
        else
        {
            Console.WriteLine("No entries available to calculate statistics.");
        }
    }
}
