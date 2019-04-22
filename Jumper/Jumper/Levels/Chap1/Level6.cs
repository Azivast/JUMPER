using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    static class C1Level6
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(484, 3);
        public static float LevelTime = 30;

        public static TileManager tileManager;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");

            // Left line up
            tileManager.AddTile(block, new Vector2(73, 183), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, 158), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, 133), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, 108), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, 83), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, 58), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, 33), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, 8), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(73, -17), new Rectangle(0, 0, 25, 25));

            // Left floating blocks
            tileManager.AddTile(block, new Vector2(330, 183), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(281, 143), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(232, 133), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(179, 108), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(130, 83), new Rectangle(0, 0, 25, 25));

            // Mid line left
            tileManager.AddTile(block, new Vector2(-10, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(15, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(40, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(65, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(90, 208), new Rectangle(0, 0, 25, 25));

            // Right floating blocks
            tileManager.AddTile(block, new Vector2(621, 183), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(673, 158), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(722, 133), new Rectangle(0, 0, 25, 25));


            // Mid line right
            tileManager.AddTile(block, new Vector2(150, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 208), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 208), new Rectangle(0, 0, 25, 25));

            // Left down starting pos
            tileManager.AddTile(block, new Vector2(453, 0), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(453, 25), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(453, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(453, 75), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(453, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(453, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(453, 150), new Rectangle(0, 0, 25, 25));

            // Mid upper starting pos
            tileManager.AddTile(block, new Vector2(478, 37), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(503, 37), new Rectangle(0, 0, 25, 25));
            // Mid lower starting pos
            tileManager.AddTile(block, new Vector2(503, 109), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(528, 109), new Rectangle(0, 0, 25, 25));

            // Right down starting pos
            tileManager.AddTile(block, new Vector2(553, 0), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(553, 25), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(553, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(553, 75), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(553, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(553, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(553, 150), new Rectangle(0, 0, 25, 25));

            // Left line down
            tileManager.AddTile(block, new Vector2(-10, 233), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(-10, 258), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(-10, 283), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(-10, 308), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(-10, 333), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(-10, 358), new Rectangle(0, 0, 25, 25));

            tileManager.AddTile(block, new Vector2(15, 358), new Rectangle(0, 0, 25, 25));

            // Mid line down
            tileManager.AddTile(block, new Vector2(365, 358), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(390, 358), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(390, 333), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(390, 308), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(390, 283), new Rectangle(0, 0, 25, 25));

            // Lower floating blocks
            tileManager.AddTile(block, new Vector2(118, 283), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(201, 283), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(263, 283), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(326, 283), new Rectangle(0, 0, 25, 25));

            // Lower Line
            tileManager.AddTile(block, new Vector2(415, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(415, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(440, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(465, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(490, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(515, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(540, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(565, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(590, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(615, 283), new Rectangle(0, 0, 25, 25));

            // Lower line Right up
            tileManager.AddTile(block, new Vector2(615, 258), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(615, 233), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(528, 37));
            breakableManager.SpawnBreakable(new Vector2(478, 109));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            spikeManager.SpawnSpike(new Vector2(40, 358));
            spikeManager.SpawnSpike(new Vector2(65, 358));
            spikeManager.SpawnSpike(new Vector2(90, 358));
            spikeManager.SpawnSpike(new Vector2(115, 358));
            spikeManager.SpawnSpike(new Vector2(140, 358));
            spikeManager.SpawnSpike(new Vector2(165, 358));
            spikeManager.SpawnSpike(new Vector2(190, 358));
            spikeManager.SpawnSpike(new Vector2(215, 358));
            spikeManager.SpawnSpike(new Vector2(240, 358));
            spikeManager.SpawnSpike(new Vector2(265, 358));
            spikeManager.SpawnSpike(new Vector2(290, 358));
            spikeManager.SpawnSpike(new Vector2(315, 358));
            spikeManager.SpawnSpike(new Vector2(340, 358));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(150, 183), new Vector2(305, 183), 3);
            enemyManager.SpawnEnemy(new Vector2(440, 263), new Vector2(590, 263), 2);
        }

        // Position player
        public static void PositionPlayer(PlayerManager player)
        {
            player.Position = PlayerPosition;
        }

        // Position door and spawn keys
        public static void SpawnDoorAndKeys(KeyDoor keyDoor)
        {
            // Position door
            keyDoor.DoorPosition = new Vector2(365, 322);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(110, 44));
            keyDoor.SpawnKey(new Vector2(780, 103));
            keyDoor.SpawnKey(new Vector2(585, 253));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }

    }
}
