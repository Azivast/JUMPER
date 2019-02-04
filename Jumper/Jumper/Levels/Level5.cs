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
    static class Level5
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(775, 380);
        public static float LevelTime = 60;

        public static TileManager tileManager;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");
            Texture2D block9x1 = Content.Load<Texture2D>(@"Sprites/Block 9x1");
            Texture2D block1x6 = Content.Load<Texture2D>(@"Sprites/Block 1x6");

            // Right up
            tileManager.AddTile(block1x6, new Vector2(775, 205), new Rectangle(0, 0, 25, 150));
            tileManager.AddTile(block, new Vector2(775, 180), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 155), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 130), new Rectangle(0, 0, 25, 25));

            // Right lower
            tileManager.AddTile(block, new Vector2(650, 180), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 180), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 180), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 180), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 180), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 180), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 180), new Rectangle(0, 0, 25, 25));

            // Right lower-up-down
            tileManager.AddTile(block, new Vector2(625, 130), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 155), new Rectangle(0, 0, 25, 25));

            // Right upper
            tileManager.AddTile(block9x1, new Vector2(575, 105), new Rectangle(0, 0, 225, 25));
            tileManager.AddTile(block, new Vector2(550, 105), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 105), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 105), new Rectangle(0, 0, 25, 25));

            // Mid right square
            tileManager.AddTile(block1x6, new Vector2(625, 255), new Rectangle(0, 0, 25, 150));
            tileManager.AddTile(block, new Vector2(600, 255), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 255), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 255), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 255), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block1x6, new Vector2(500, 255), new Rectangle(0, 0, 25, 150));

            // Lower
            tileManager.AddTile(block9x1, new Vector2(575, 405), new Rectangle(0, 0, 225, 25));
            tileManager.AddTile(block9x1, new Vector2(350, 405), new Rectangle(0, 0, 225, 25));
            tileManager.AddTile(block, new Vector2(325, 405), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 405), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 405), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 405), new Rectangle(0, 0, 25, 25));

            // Mid left
            tileManager.AddTile(block1x6, new Vector2(250, 130), new Rectangle(0, 0, 25, 150));
            // Mid mid
            tileManager.AddTile(block, new Vector2(275, 255), new Rectangle(0, 0, 25, 25));
            // Mid mid down
            tileManager.AddTile(block1x6, new Vector2(300, 205), new Rectangle(0, 0, 25, 150));
            // Mid right
            tileManager.AddTile(block, new Vector2(325, 205), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 205), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 205), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 205), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 205), new Rectangle(0, 0, 25, 25));

            // Left platforms
            tileManager.AddTile(block, new Vector2(375, 355), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 305), new Rectangle(0, 0, 25, 25));

            // Left down
            tileManager.AddTile(block, new Vector2(250, 380), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 355), new Rectangle(0, 0, 25, 25));


            // Left lower
            tileManager.AddTile(block, new Vector2(250, 330), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 330), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 330), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 330), new Rectangle(0, 0, 25, 25));

            // Left lower-upper
            tileManager.AddTile(block1x6, new Vector2(75, 205), new Rectangle(0, 0, 25, 150));
            tileManager.AddTile(block1x6, new Vector2(75, 80), new Rectangle(0, 0, 25, 150));

            // Left upper
            tileManager.AddTile(block9x1, new Vector2(75, 55), new Rectangle(0, 0, 225, 25));

        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(650, 355));
            breakableManager.SpawnBreakable(new Vector2(750, 305));
            breakableManager.SpawnBreakable(new Vector2(650, 255));
            breakableManager.SpawnBreakable(new Vector2(750, 205));

            breakableManager.SpawnBreakable(new Vector2(275, 155));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            spikeManager.SpawnSpike(new Vector2(275, 230));

            spikeManager.SpawnSpike(new Vector2(150, 330));
            spikeManager.SpawnSpike(new Vector2(125, 330));
            spikeManager.SpawnSpike(new Vector2(100, 330));

            spikeManager.SpawnSpike(new Vector2(225, 230));
            spikeManager.SpawnSpike(new Vector2(200, 230));
            spikeManager.SpawnSpike(new Vector2(175, 230));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(275, 380), new Vector2(475, 380), 4);
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
            keyDoor.DoorPosition = new Vector2(600, 144);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(657, 160));
            keyDoor.SpawnKey(new Vector2(475, 380));
            keyDoor.SpawnKey(new Vector2(175, 105));
            
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
