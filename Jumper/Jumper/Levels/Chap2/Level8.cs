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
    static class C2Level8
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(715, 220);
        public static float LevelTime = 40;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block2");

            tileManager.AddTile(block, new Vector2(759, 227), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(684, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(609, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(534, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(459, 227), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(384, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(309, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(234, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(159, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(84, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(9, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(9, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(26, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(101, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(176, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(251, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(326, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(401, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(476, 252), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(551, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(626, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(701, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(776, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(70, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(145, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(220, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(295, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(370, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(520, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(595, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(670, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(745, 293), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(59, 178), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(134, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(209, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(284, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(359, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(434, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(509, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(584, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(659, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(734, 175), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(44, 96), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(126, 56), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(88, 389), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(226, 448), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(657, 354), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(327, 377), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(448, 443), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(230, 116), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(467, 23), new Rectangle(0, 0, 25, 25));
            //tileManager.AddTile(block, new Vector2(768, 25), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(422, 113), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(620, 95), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(268, 14), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(554, 406), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(473, 443), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(684, 227));
            breakableManager.SpawnBreakable(new Vector2(384, 227));
            breakableManager.SpawnBreakable(new Vector2(551, 252));
            breakableManager.SpawnBreakable(new Vector2(134, 175));
            breakableManager.SpawnBreakable(new Vector2(44, 96));
            breakableManager.SpawnBreakable(new Vector2(88, 389));
            breakableManager.SpawnBreakable(new Vector2(768, 25));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            //spikeManager.SpawnSpike(new Vector2(x, y));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(0, 152), new Vector2(775, 152), 2);
            enemyManager.SpawnEnemy(new Vector2(0, 352), new Vector2(775, 352), 4);
            enemyManager.SpawnEnemy(new Vector2(26, 252), new Vector2(776, 252), 6);
            enemyManager.SpawnEnemy(new Vector2(84, 202), new Vector2(759, 202), 3);
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
            keyDoor.DoorPosition = new Vector2(460, 407);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(465, 210));
            keyDoor.SpawnKey(new Vector2(783, 210));
            keyDoor.SpawnKey(new Vector2(150, 265));
            keyDoor.SpawnKey(new Vector2(292, 130));
            keyDoor.SpawnKey(new Vector2(333, 360));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }
    }
}
