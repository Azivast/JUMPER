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
    static class C2Level6
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(593, 270);
        public static float LevelTime = 20;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block2");

            tileManager.AddTile(block, new Vector2(691, 398), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(641, 348), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(591, 298), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(541, 248), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(491, 198), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(441, 148), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(391, 98), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(341, 48), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(291, -2), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(321, 369), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(411, 291), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(732, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(588, 51), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(642, 192), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(180, 419), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(78, 240), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(201, 176), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(152, 268), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(261, 247), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(319, 193), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(264, 151), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 117), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(321, 77), new Rectangle(0, 0, 25, 25));
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
            enemyManager.SpawnEnemy(new Vector2(78, 215), new Vector2(250, 215), 3);
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
            keyDoor.DoorPosition = new Vector2(180, 383);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(702, 113));
            keyDoor.SpawnKey(new Vector2(315, 170));
            keyDoor.SpawnKey(new Vector2(170, 110));
            keyDoor.SpawnKey(new Vector2(700, 373));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
