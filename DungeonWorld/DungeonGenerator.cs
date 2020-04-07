using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Utilities;

namespace DynamicDungeon.DungeonWorld
{
    class DungeonGenerator
    {
        private int[,] roomLayout = new int[50,32];
        private int maxRoom = 50;

        private Point startPoint = new Point(24,15);

        internal static WeightedRandom<long> random = new WeightedRandom<long>();

        private long seed = random.Get();

        public DungeonGenerator()
        {
            
        }

        public DungeonGenerator(long seed)
        {
            this.seed = seed;
        }

        
    }
}
