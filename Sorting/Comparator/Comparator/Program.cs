using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparator
{
    internal class Program
    {
        private static void Main(string[] args)
        {

        }

        private struct Player
        {
            public int score;
            public string name;
        }

        private class PlayerScoreDescendNameAscendComparer : IComparer<Player>
        {
            public int Compare(Player x, Player y)
            {
                if (x.score > y.score)
                {
                    return 1;
                }
                else if (x.score < y.score)
                {
                    return -1;
                }
                else // Same score case
                {
                    // Compare char
                    int length = x.name.Length > y.name.Length // Pick shorter one to avoid OutOfRangeException
                        ? y.name.Length
                        : x.name.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (x.name[i] > y.name[i])
                        {
                            return -1;
                        }

                        else if (x.name[i] < y.name[i])
                        {
                            return 1;
                        }
                        else // Same char case
                        {
                            continue;
                        }
                    }
                    // Same char until length case, length ascend
                    return x.name.Length > y.name.Length ? -1 : 1;
                }
            }
        }
    }
}
