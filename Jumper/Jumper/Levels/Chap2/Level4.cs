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
    static class C2Level4
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(365, 403);
        public static float LevelTime = 60;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block2");

            tileManager.AddTile(block, new Vector2(340, 439), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(365, 439), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(390, 439), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(720, 287), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(745, 287), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(770, 287), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(795, 287), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(658, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(633, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(608, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(451, 408), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(511, 367), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(691, 409), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(586, 408), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(565, 317), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(271, 440), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(196, 425), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(87, 354), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(146, 390), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(34, 319), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(166, 301), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(232, 271), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(139, 233), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(230, 181), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(323, 173), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(403, 173), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(478, 152), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(541, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(610, 102), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            //breakableManager.SpawnBreakable(new Vector2(x, y));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            //spikeManager.SpawnSpike(new Vector2(x, y));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(300, 215), new Vector2(575, 215), 4);
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
            keyDoor.DoorPosition = new Vector2(365, 403);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(450, 215));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
