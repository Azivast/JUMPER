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
    static class Level4
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(20, 35);
        public static float LevelTime = 60;

        public static TileManager tileManager;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");

            // Top left
            tileManager.AddTile(block, new Vector2(0, 88), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(25, 88), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 88), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 88), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 88), new Rectangle(0, 0, 25, 25));

            // Top left down
            tileManager.AddTile(block, new Vector2(100, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 138), new Rectangle(0, 0, 25, 25));

            // Top center
            tileManager.AddTile(block, new Vector2(75, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 163), new Rectangle(0, 0, 25, 25));

            tileManager.AddTile(block, new Vector2(575, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 113), new Rectangle(0, 0, 25, 25));


            tileManager.AddTile(block, new Vector2(725, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 138), new Rectangle(0, 0, 25, 25));

            // Top Right
            tileManager.AddTile(block, new Vector2(725, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 163), new Rectangle(0, 0, 25, 25));

            // Mid line right
            tileManager.AddTile(block, new Vector2(525, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 238), new Rectangle(0, 0, 25, 25));

            // Mid line down right
            tileManager.AddTile(block, new Vector2(525, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 313), new Rectangle(0, 0, 25, 25));

            // Mid line platforms
            tileManager.AddTile(block, new Vector2(450, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 263), new Rectangle(0, 0, 25, 25));

            tileManager.AddTile(block, new Vector2(350, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 263), new Rectangle(0, 0, 25, 25));

            // Mid line left
            tileManager.AddTile(block, new Vector2(250, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 263), new Rectangle(0, 0, 25, 25));

            // Mid line down left
            tileManager.AddTile(block, new Vector2(250, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 313), new Rectangle(0, 0, 25, 25));

            // Lower line
            tileManager.AddTile(block, new Vector2(50, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 338), new Rectangle(0, 0, 25, 25));

            // Lower Left down
            tileManager.AddTile(block, new Vector2(50, 188), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 238), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 313), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(700, 163));
            breakableManager.SpawnBreakable(new Vector2(675, 163));
            breakableManager.SpawnBreakable(new Vector2(650, 163));
            breakableManager.SpawnBreakable(new Vector2(625, 163));

            breakableManager.SpawnBreakable(new Vector2(75, 263));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            spikeManager.SpawnSpike(new Vector2(500, 313));
            spikeManager.SpawnSpike(new Vector2(475, 313));
            spikeManager.SpawnSpike(new Vector2(450, 313));
            spikeManager.SpawnSpike(new Vector2(425, 313));
            spikeManager.SpawnSpike(new Vector2(400, 313));
            spikeManager.SpawnSpike(new Vector2(375, 313));
            spikeManager.SpawnSpike(new Vector2(350, 313));
            spikeManager.SpawnSpike(new Vector2(325, 313));
            spikeManager.SpawnSpike(new Vector2(300, 313));
            spikeManager.SpawnSpike(new Vector2(275, 313));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(125, 138), new Vector2(550, 138), 4);
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
            keyDoor.DoorPosition = new Vector2(225, 302);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(350, 120));
            keyDoor.SpawnKey(new Vector2(395, 235));
            keyDoor.SpawnKey(new Vector2(85, 230));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }

    }
}
