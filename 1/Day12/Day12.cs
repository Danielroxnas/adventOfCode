using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Day12
    {
        public List<int> _groupMembers = new List<int>() { 0 };
        private Dictionary<int, int[]> _input = new Dictionary<int, int[]>();
        private List<List<int>> _groupOfGroups = new List<List<int>>();

        public void Part1()
        {
            _input = File.ReadAllLines("Day12/Day12.txt")
                .Select(x => x.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(x => int.Parse(x[0]), x => x[1].Split(',').Select(y => int.Parse(y.Trim())).ToArray());

            GetNext(0);
            var result = _groupMembers.Count;
        }


        public void Part2()
        {
            _input = File.ReadAllLines("Day12/Day12.txt")
                .Select(x => x.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(x => int.Parse(x[0]), x => x[1].Split(',').Select(y => int.Parse(y.Trim())).ToArray());

            for (int i = 0; i < _input.Count; i++)
            {
                AddToGroup(i);
            }
            var result = _groupOfGroups.Count;
        }

        public void AddToGroup(int value)
        {
            var values = _input.Where(x => x.Key == value).First();

            foreach (var item in values.Value)
            {
                if (_groupOfGroups.Any(x => x.Contains(values.Key)))
                {
                    if (!_groupOfGroups.Any(x => x.Contains(item)))
                    {
                        _groupOfGroups.Where(x => x.Contains(values.Key)).First().Add(item);
                        AddToGroup(item);
                    }

                }
                else
                {
                    _groupOfGroups.Add(new List<int> { values.Key, item });
                    AddToGroup(item);
                }
            }
        }


        public void GetNext(int value)
        {

            var values = _input.Where(x => x.Key == value).First().Value;

            foreach (var item in values)
            {
                if (!_groupMembers.Contains(item))
                {
                    _groupMembers.Add(item);
                    GetNext(item);
                }
            }
        }
    }
}

