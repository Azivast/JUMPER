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
    static class C2Level3
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(395, 20);
        public static float LevelTime = 60;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block2");

            tileManager.AddTile(block, new Vector2(350, 5), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(340, 31), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(332, 58), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(320, 87), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(311, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(303, 142), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(296, 169), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(285, 196), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(278, 221), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(431, 6), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(438, 34), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(446, 60), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(455, 87), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(464, 114), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(470, 139), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(478, 164), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(485, 192), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(496, 217), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(356, 294), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(437, 271), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(296, 364), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(185, 359), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(149, 321), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(103, 284), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(56, 246), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(153, 215), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(429, 358), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(479, 341), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(540, 382), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(587, 342), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(371, 377), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(248, 328), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(652, 319), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(703, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(752, 259), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(777, 259), new Rectangle(0, 0, 25, 25));

        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(56, 246));
            breakableManager.SpawnBreakable(new Vector2(153, 215));
            breakableManager.SpawnBreakable(new Vector2(429, 358));
            breakableManager.SpawnBreakable(new Vector2(587, 342));
            breakableManager.SpawnBreakable(new Vector2(371, 377));
            breakableManager.SpawnBreakable(new Vector2(703, 277));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            //spikeManager.SpawnSpike(new Vector2(x, y));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(190, 330), new Vector2(595, 330), 4);
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
            keyDoor.DoorPosition = new Vector2(775, 223);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(164, 170));
            keyDoor.SpawnKey(new Vector2(395, 300));
            keyDoor.SpawnKey(new Vector2(444, 220));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
