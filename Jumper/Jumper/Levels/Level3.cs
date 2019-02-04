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
    static class Level3
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(675, 80);
        public static float LevelTime = 60;

        public static TileManager tileManager;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");

            // Upper Right
            tileManager.AddTile(block, new Vector2(775, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 113), new Rectangle(0, 0, 25, 25));

            // Upper Right Down
            tileManager.AddTile(block, new Vector2(625, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 163), new Rectangle(0, 0, 25, 25));

            // Upper Right Lower
            tileManager.AddTile(block, new Vector2(600, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 163), new Rectangle(0, 0, 25, 25));

            // Floating platforms
            tileManager.AddTile(block, new Vector2(425, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 163), new Rectangle(0, 0, 25, 25));

            // Upper Left Lower
            tileManager.AddTile(block, new Vector2(250, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 163), new Rectangle(0, 0, 25, 25));

            // Upper Left Down
            tileManager.AddTile(block, new Vector2(175, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 138), new Rectangle(0, 0, 25, 25));

            // Upper Left
            tileManager.AddTile(block, new Vector2(175, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 113), new Rectangle(0, 0, 25, 25));

            // // Upper Left Down Down
            tileManager.AddTile(block, new Vector2(250, 188), new Rectangle(0, 0, 25, 25));

            // Mid
            tileManager.AddTile(block, new Vector2(250, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 213), new Rectangle(0, 0, 25, 25));

            // Mid Down
            tileManager.AddTile(block, new Vector2(450, 238), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 263), new Rectangle(0, 0, 25, 25));

            // Lower Mid  
            tileManager.AddTile(block, new Vector2(475, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 263), new Rectangle(0, 0, 25, 25));

            // Lower Mid Down
            tileManager.AddTile(block, new Vector2(525, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 313), new Rectangle(0, 0, 25, 25));

            // Lower Right
            tileManager.AddTile(block, new Vector2(525, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 338), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            //breakableManager.SpawnBreakable(new Vector2(x, y));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            spikeManager.SpawnSpike(new Vector2(50, 113));
            spikeManager.SpawnSpike(new Vector2(25, 113));
            spikeManager.SpawnSpike(new Vector2(0, 113));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(275, 188), new Vector2(450, 188), 2);
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
            keyDoor.DoorPosition = new Vector2(775, 302);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(775, 90));
            keyDoor.SpawnKey(new Vector2(80, 90));
            keyDoor.SpawnKey(new Vector2(525, 238));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
