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
    static class C2Level5
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(602, 30);
        public static float LevelTime = 30;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block2");

            tileManager.AddTile(block, new Vector2(602, 66), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(636, 104), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(666, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(702, 176), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(784, 139), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(585, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(569, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(554, 388), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(402, 387), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(229, 387), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(132, 387), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(317, 345), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(481, 426), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(86, 387), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(86, 362), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(71, 337), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(71, 312), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(57, 287), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(57, 262), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(42, 237), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(42, 212), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(28, 187), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(28, 162), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(15, 137), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(15, 112), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(135, 112), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(247, 112), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(354, 112), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(469, 112), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(512, 112), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(512, 87), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(512, 62), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(512, 37), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(512, 12), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(512, -13), new Rectangle(0, 0, 25, 25));
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
            enemyManager.SpawnEnemy(new Vector2(15, 87), new Vector2(512, 87), 4);
            enemyManager.SpawnEnemy(new Vector2(115, 187), new Vector2(512, 187), 10);
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
            keyDoor.DoorPosition = new Vector2(697, 373);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(777, 113));
            keyDoor.SpawnKey(new Vector2(252, 88));
            keyDoor.SpawnKey(new Vector2(73, 247));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
