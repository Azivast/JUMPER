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
    static class Level7
    {
        // Position of player
        public static Vector2 PlayerPoisition = new Vector2(10, 360);
        public static float LevelTime = 60;

        public static TileManager tileManager;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");

            tileManager.AddTile(block, new Vector2(0, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(25, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 391), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(692, 366), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(717, 366), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(742, 366), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(767, 366), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(792, 366), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(727, 341), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(752, 341), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(777, 341), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 286), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 191), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 166), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 191), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 216), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 261), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 236), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 211), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 186), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 141), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 116), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 91), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 66), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 41), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 16), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 92), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 92), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 92), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(25, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(0, 42), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 67), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 92), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 117), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 142), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 167), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 192), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 192), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(25, 192), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(0, 192), new Rectangle(0, 0, 25, 25));

            tileManager.AddTile(block, new Vector2(775, 153), new Rectangle(0, 0, 25, 25));

            tileManager.AddTile(block, new Vector2(109, 366), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 366), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(512, 366), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(342, 261));
            breakableManager.SpawnBreakable(new Vector2(255, 235));
            breakableManager.SpawnBreakable(new Vector2(207, 261));
            breakableManager.SpawnBreakable(new Vector2(195, 204));

            breakableManager.SpawnBreakable(new Vector2(560, 153));
            breakableManager.SpawnBreakable(new Vector2(634, 153));
            breakableManager.SpawnBreakable(new Vector2(707, 153));

            breakableManager.SpawnBreakable(new Vector2(674, 309));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            spikeManager.SpawnSpike(new Vector2(775, 191));
            spikeManager.SpawnSpike(new Vector2(750, 191));
            spikeManager.SpawnSpike(new Vector2(725, 191));
            spikeManager.SpawnSpike(new Vector2(700, 191));
            spikeManager.SpawnSpike(new Vector2(675, 191));
            spikeManager.SpawnSpike(new Vector2(650, 191));
            spikeManager.SpawnSpike(new Vector2(625, 191));
            spikeManager.SpawnSpike(new Vector2(600, 191));
            spikeManager.SpawnSpike(new Vector2(575, 191));
            spikeManager.SpawnSpike(new Vector2(550, 191));
            spikeManager.SpawnSpike(new Vector2(525, 191));

            spikeManager.SpawnSpike(new Vector2(125, 261));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
            enemyManager.SpawnEnemy(new Vector2(134, 366), new Vector2(275, 366), 3);
            enemyManager.SpawnEnemy(new Vector2(325, 366), new Vector2(487, 366), 3);
            enemyManager.SpawnEnemy(new Vector2(537, 366), new Vector2(667, 366), 3);
        }

        // Position player
        public static void PositionPlayer(PlayerManager player)
        {
            player.Poisition = PlayerPoisition;
        }

        // Position door and spawn keys
        public static void SpawnDoorAndKeys(KeyDoor keyDoor)
        {
            // Position door
            keyDoor.DoorPosition = new Vector2(774, 305);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(779, 128));
            keyDoor.SpawnKey(new Vector2(137, 202));
            keyDoor.SpawnKey(new Vector2(410, 338));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
            //heartManager.SpawnHeart(new Vector2(x, y));
        }

    }
}
