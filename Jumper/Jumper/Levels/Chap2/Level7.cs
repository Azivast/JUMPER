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
    static class C2Level7
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(590, 15);
        public static float LevelTime = 60;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block2");

            tileManager.AddTile(block, new Vector2(587, 63), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(562, 63), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(496, 102), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(373, 102), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(246, 102), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(184, 150), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(309, 150), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(438, 150), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(184, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(309, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(438, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(184, 312), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(184, 424), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(308, 424), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(438, 424), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(309, 312), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(438, 312), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(126, 371), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(248, 371), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(374, 371), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(497, 371), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(43, 371), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 278), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 253), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 228), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 203), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 178), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 153), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 128), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 103), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(114, 103), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, 78), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(562, 371), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(587, 371), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 63), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 38), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 13), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 88), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 138), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 163), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 188), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 213), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 238), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 263), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 288), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 313), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 338), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 363), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 388), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, -12), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 413), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 438), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(612, 463), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(89, -2), new Rectangle(0, 0, 25, 25));
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
            keyDoor.DoorPosition = new Vector2(587, 335);

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
