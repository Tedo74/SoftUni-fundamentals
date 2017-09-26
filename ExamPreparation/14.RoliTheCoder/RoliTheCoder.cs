using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.RoliTheCoder
{
    class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public List<string> Participants { get; set; }

        public Event(int id, string name)
        {
            this.EventId = id;
            this.Name = name;
            this.Participants = new List<string>();
        }
    }

    class RoliTheCoder
    {
        public static void Main()
        {
            Dictionary<int, Event> allEvents = new Dictionary<int, Event>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Time for Code")
                {
                    break;
                }
                string[] eventInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (eventInput.Length < 2)
                {
                    continue;
                }
                int eventNumber = -1;
                if (int.TryParse(eventInput[0], out eventNumber)
                    && eventInput[1][0] == '#')
                {
                    string eventName = eventInput[1].Trim('#');
                    Event e;
                    if (allEvents.ContainsKey(eventNumber))
                    {
                        e = allEvents[eventNumber];
                        if (e.Name != eventName || eventInput.Length <= 2)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        e = new Event(eventNumber, eventName);
                    }
                    string[] participants = eventInput.Skip(2).ToArray();
                    if (!participants.All(p => p.StartsWith("@")))
                    {
                        continue;
                    }
                    foreach (var participant in participants)
                    {
                        if (!e.Participants.Contains(participant))
                        {
                            e.Participants.Add(participant);
                        }
                    }
                    allEvents[eventNumber] = e;
                }
            }
            var orderedEvents = allEvents.OrderByDescending(e => e.Value.Participants.Count).ThenBy(e => e.Value.Name);
            foreach (var ev in orderedEvents)
            {
                Console.WriteLine($"{ev.Value.Name} - {ev.Value.Participants.Count}");
                if (ev.Value.Participants.Any())
                {
                    var ordered = ev.Value.Participants.OrderBy(e => e).ToList();
                    foreach (var participant in ordered)
                    {
                        Console.WriteLine(participant);
                    }
                }
            }
        }
    }
}
