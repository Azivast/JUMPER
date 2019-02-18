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
    static class C1Level8
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(750, 5);
        public static float LevelTime = 60;

        public static TileManager tileManager;

        // Texture for spikes
        private static Texture2D Spike;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");
            Spike = Content.Load<Texture2D>(@"Sprites/Spike Inverted");

            tileManager.AddTile(block, new Vector2(784, 0), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(784, 25), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(784, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(784, 75), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(784, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(709, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(709, 25), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(709, 0), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(684, 0), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(659, 0), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(634, 0), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(684, 25), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(684, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(659, 25), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(709, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(784, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(684, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(659, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(634, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(609, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(609, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(584, 75), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(584, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(584, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(559, 75), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(559, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(559, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(534, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(509, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(484, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(459, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(434, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(409, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(384, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(359, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(334, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(309, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(284, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(259, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(559, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 200), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(734, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(234, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(209, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(184, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(159, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(109, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(84, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(59, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(34, 125), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(34, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(34, 75), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(34, 50), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(59, 75), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(59, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(84, 100), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 150), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 175), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 200), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 225), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 250), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 275), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 300), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 325), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(134, 350), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(-1, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(24, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(49, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(74, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(99, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(124, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(149, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(174, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(199, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(224, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(249, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(274, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(299, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(324, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(349, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(374, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(399, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(424, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(449, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(474, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(499, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(524, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(549, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(574, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(599, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(624, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(649, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(674, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(699, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(724, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(749, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(774, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(799, 436), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 200), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 225), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 225), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 200), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 200), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(759, 125), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(387, 381));
            breakableManager.SpawnBreakable(new Vector2(337, 331));
            breakableManager.SpawnBreakable(new Vector2(274, 320));
            breakableManager.SpawnBreakable(new Vector2(221, 294));
            breakableManager.SpawnBreakable(new Vector2(159, 257));
            breakableManager.SpawnBreakable(new Vector2(263, 207));

            breakableManager.SpawnBreakable(new Vector2(437, 331));
            breakableManager.SpawnBreakable(new Vector2(500, 320));
            breakableManager.SpawnBreakable(new Vector2(553, 294));
            breakableManager.SpawnBreakable(new Vector2(615, 257));
            breakableManager.SpawnBreakable(new Vector2(511, 207));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            spikeManager.SpawnSpike(new Vector2(150, 70));
            spikeManager.SpawnSpike(new Vector2(175, 70));
            spikeManager.SpawnSpike(new Vector2(200, 70));
            spikeManager.SpawnSpike(new Vector2(225, 70));
            spikeManager.SpawnSpike(new Vector2(250, 70));
            spikeManager.SpawnSpike(new Vector2(275, 70));
            spikeManager.SpawnSpike(new Vector2(300, 70));
            spikeManager.SpawnSpike(new Vector2(325, 70));
            spikeManager.SpawnSpike(new Vector2(350, 70));
            spikeManager.SpawnSpike(new Vector2(375, 70));
            spikeManager.SpawnSpike(new Vector2(400, 70));
            spikeManager.SpawnSpike(new Vector2(425, 70));
            spikeManager.SpawnSpike(new Vector2(450, 70));

            // Change spike texture to inverted one
            foreach (Sprite spike in spikeManager.Spikes)
            {
                spike.Texture = Spike;
            }

            spikeManager.SpawnSpike(new Vector2(0, 220));
            spikeManager.SpawnSpike(new Vector2(25, 220));

            spikeManager.SpawnSpike(new Vector2(109, 298));
            spikeManager.SpawnSpike(new Vector2(84, 298));
            spikeManager.SpawnSpike(new Vector2(59, 298));

            spikeManager.SpawnSpike(new Vector2(0, 349));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(110, 99), new Vector2(534, 99), 3);
            enemyManager.SpawnEnemy(new Vector2(0, 411), new Vector2(775, 411), 3);
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
            keyDoor.DoorPosition = new Vector2(388, 164);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(38, 307));
            keyDoor.SpawnKey(new Vector2(542, 108));
            keyDoor.SpawnKey(new Vector2(229, 270));
            keyDoor.SpawnKey(new Vector2(560, 270));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            heartManager.SpawnHeart(new Vector2(57, 419));
        }

    }
}