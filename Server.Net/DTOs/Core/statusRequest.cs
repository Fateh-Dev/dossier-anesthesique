using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Net.DTOs.Core
{
    public class StatusRrequest
    {
        public Item Details { get; set; }
        public Guid[] Liste { get; set; }
    }

    public class Item
    {
        public string Status { get; set; }
        public string Profile { get; set; }
        public int TimingProgramme { get; set; }
        public Guid? IdUnite { get; set; }
        public Guid? IdStructure { get; set; }
        public Guid? IdTypeAeronef { get; set; }
        public string DisplayUnite { get; set; }
        public string Observation { get; set; }
    }

    public class Candidate
    {
        public int Id { get; set; }
        public string Wilaya { get; set; }
    }

    public class Center
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public List<string> Wilayas { get; set; } = new List<string>();
    }

    public class Wilaya
    {
        public string Name { get; set; }
        public int CenterId { get; set; }
    }

    public class CandidateDistributor
    {
        private readonly List<Center> _centers;
        private readonly List<Candidate> _candidates;

        public CandidateDistributor(List<Center> centers, List<Candidate> candidates)
        {
            _centers = centers;
            _candidates = candidates;
        }

        public Dictionary<int, List<Candidate>> DistributeCandidates()
        {
            // Create a mapping of wilayas to centers
            var wilayaToCenter = new Dictionary<string, Center>();
            foreach (var center in _centers)
            {
                foreach (var wilaya in center.Wilayas)
                {
                    if (!wilayaToCenter.ContainsKey(wilaya))
                    {
                        wilayaToCenter[wilaya] = center;
                    }
                    else
                    {
                        throw new Exception($"Wilaya {wilaya} is assigned to multiple centers.");
                    }
                }
            }

            // Initialize center allocations
            var centerAllocations = _centers.ToDictionary(
                center => center.Id,
                center => new List<Candidate>()
            );

            // Allocate candidates to their respective centers
            foreach (var candidate in _candidates)
            {
                if (wilayaToCenter.TryGetValue(candidate.Wilaya, out var center))
                {
                    if (centerAllocations[center.Id].Count < center.Capacity)
                    {
                        centerAllocations[center.Id].Add(candidate);
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Warning: Center {center.Id} has reached its capacity. Candidate {candidate.Id} cannot be allocated."
                        );
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"Warning: No center found for wilaya {candidate.Wilaya}. Candidate {candidate.Id} cannot be allocated."
                    );
                }
            }

            return centerAllocations;
        }
    }
}
