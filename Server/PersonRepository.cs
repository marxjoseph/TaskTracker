using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace Server
{
    public class PersonRepository
    {
        private readonly List<Person> _persons = new List<Person>();
        private readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "persondb.json");

        public PersonRepository()
        {
            // Read from the JSON file if it exists
            if (File.Exists(_jsonFilePath))
            {
                var jsonData = File.ReadAllText(_jsonFilePath);
                _persons = JsonSerializer.Deserialize<List<Person>>(jsonData) ?? new List<Person>();
            }
            else
            {
                // Add default persons if the file doesn't exist
                _persons.Add(new Person("Joseph", "Marques", new DateTime(2003, 2, 24)));
                _persons.Add(new Person("Victoria", "Moreira", new DateTime(2004, 4, 20)));
                SaveToFile(); // Save initial data to file
            }
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _persons;
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveToFile(); // Save changes to the file
        }

        private void SaveToFile()
        {
            // Convert the list to JSON and write it to the file
            var jsonData = JsonSerializer.Serialize(_persons, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, jsonData);
        }
    }
}
