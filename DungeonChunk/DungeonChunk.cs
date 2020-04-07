using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonBase;
using DynamicDungeon.DungeonWorld;
using InfinityCore.API.Chunks;
using Terraria.World.Generation;

namespace DynamicDungeon.DungeonChunk
{
    class DungeonChunk : ModChunk
    {
        private BaseRoom dungeonRoom;

        public override bool CanExist => SubworldLibrary.SLWorld.currentSubworld is DungeonWorld.DungeonSubworld;

        public override bool ImpactWorldGen => true;

        public void SetRoomType(BaseRoom roomType)
        {
            this.dungeonRoom = roomType;
        }

        public override void Update()
        {
            
        }

        public override void Generate(GenerationProgress progress = null)
        {
            progress.Message = "Currently generating dungeon room";
            if (dungeonRoom != null)
            {
                
                dungeonRoom.Generate();
            }
        }
    }
}
