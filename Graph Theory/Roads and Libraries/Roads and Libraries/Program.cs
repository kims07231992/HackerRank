using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roads_and_Libraries
{
    // https://www.hackerrank.com/challenges/torque-and-development/problem
    class Program
    {
        static void Main(string[] args)
        {
            List<long> costs = new List<long>(); // to store cost of each query
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]); // number of cities
                int m = Convert.ToInt32(tokens_n[1]); // number of roads
                long x = Convert.ToInt64(tokens_n[2]); // cost of library
                long y = Convert.ToInt64(tokens_n[3]); // cost of road

                var hcl = SetHackerLand(n); // add n amounts of cities
                for (int a1 = 0; a1 < m; a1++)
                {
                    // connecting between two cities
                    string[] tokens_city_1 = Console.ReadLine().Split(' ');
                    int city_1 = Convert.ToInt32(tokens_city_1[0]); 
                    int city_2 = Convert.ToInt32(tokens_city_1[1]);

                    hcl.AddRoad(hcl._cites[city_1 - 1], hcl._cites[city_2 - 1]); // add cities as index number
                }
                hcl.DFS();
                long cost = n * x < (hcl.RoadCount * y) + (hcl.CityCount * x) 
                    ? n * x // city * library
                    : (hcl.RoadCount * y) + (hcl.CityCount * x); // city * library + road * disconnected cities
                costs.Add(cost);
            }
            foreach (long cost in costs)
            {
                Console.WriteLine(cost);
            }
        }

        private static HackerLand SetHackerLand(int n)
        {
            var hcl = new HackerLand();
            for (int i = 0; i < n; i++)
            {
                hcl.AddCity(new City());
            }
            return hcl;
        }

        internal class HackerLand
        {
            public List<City> _cites;

            public HackerLand()
            {

            }

            public List<City> Cities
            {
                get
                {
                    this._cites = this._cites ?? new List<City>();
                    return this._cites;
                }
            }
            public int RoadCount { get; private set; } // number of used roads
            public int CityCount { get; private set; } // number of disconnected cities

            public void AddCity(City newCity)
            {
                this.Cities.Add(newCity);
            }

            public void AddRoad(City cityA, City cityB)
            {
                cityA.AdjList.Add(cityB); // cityA -> cityB
                cityB.AdjList.Add(cityA); // cityA <- cityB
            }

            public void DFS()
            {
                foreach (var c in this.Cities)
                {
                    if (!c.VisitFlag)
                        this.CityCount++;
                    RecursiveDFS(c);
                }
            }

            private void RecursiveDFS(City city)
            {
                if (!city.VisitFlag)
                {
                    city.VisitFlag = true; // Visit
                }
                foreach (var adjC in city.AdjList)
                {
                    if (!adjC.VisitFlag)
                    {
                        this.RoadCount++;
                        RecursiveDFS(adjC);
                    }
                }
            }

            private void ResetFlag()
            {
                foreach (var c in this.Cities)
                {
                    c.VisitFlag = false;
                }
            }
        }

        internal class City
        {
            private List<City> _adjCities;

            public City()
            {
                this.VisitFlag = false;
            }

            public bool VisitFlag { get; set; }
            public List<City> AdjList
            {
                get
                {
                    this._adjCities = this._adjCities ?? new List<City>();
                    return this._adjCities;
                }
            }
        }
    }
}
