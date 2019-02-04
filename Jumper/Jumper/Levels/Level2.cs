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
    static class Level2
    {
        // Position of player
        public static Vector2 PlayerPosition = new Vector2(25, 175);
        public static float LevelTime = 60;

        public static TileManager tileManager;
        public static TypeText TutorialText;

        // Load all tiles for level
        public static void LoadContent(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            tileManager = new TileManager();

            // Load textures for level
            Texture2D block = Content.Load<Texture2D>(@"Sprites/Block");

            // Top
            tileManager.AddTile(block, new Vector2(0, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(25, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 202), new Rectangle(0, 0, 25, 25));

            tileManager.AddTile(block, new Vector2(750, 202), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(775, 202), new Rectangle(0, 0, 25, 25));

            // Left down
            tileManager.AddTile(block, new Vector2(625, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(625, 277), new Rectangle(0, 0, 25, 25));

            // Right down
            tileManager.AddTile(block, new Vector2(750, 227), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 252), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 302), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 327), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(750, 352), new Rectangle(0, 0, 25, 25));

            // Mid
            tileManager.AddTile(block, new Vector2(50, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(200, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(225, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(250, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(275, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(300, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(325, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(350, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(375, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(400, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(425, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(450, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(475, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(500, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(525, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(550, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(575, 277), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(600, 277), new Rectangle(0, 0, 25, 25));

            // Lower
            tileManager.AddTile(block, new Vector2(50, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(75, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(100, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(125, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(150, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(175, 352), new Rectangle(0, 0, 25, 25));

            tileManager.AddTile(block, new Vector2(625, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(650, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(675, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(700, 352), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(725, 352), new Rectangle(0, 0, 25, 25));

            // Lower Left
            tileManager.AddTile(block, new Vector2(50, 327), new Rectangle(0, 0, 25, 25));
            tileManager.AddTile(block, new Vector2(50, 302), new Rectangle(0, 0, 25, 25));
        }

        // Spawn all breakables for level
        public static void SpawnBreakables(BreakableManager breakableManager)
        {
            breakableManager.SpawnBreakable(new Vector2(125, 277));
            breakableManager.SpawnBreakable(new Vector2(125, 302));
            breakableManager.SpawnBreakable(new Vector2(125, 327));
            breakableManager.SpawnBreakable(new Vector2(150, 277));
            breakableManager.SpawnBreakable(new Vector2(150, 302));
            breakableManager.SpawnBreakable(new Vector2(150, 327));

            breakableManager.SpawnBreakable(new Vector2(650, 202));
            breakableManager.SpawnBreakable(new Vector2(675, 202));
            breakableManager.SpawnBreakable(new Vector2(700, 202));
            breakableManager.SpawnBreakable(new Vector2(725, 202));

            breakableManager.SpawnBreakable(new Vector2(200, 352));
            breakableManager.SpawnBreakable(new Vector2(225, 352));
            breakableManager.SpawnBreakable(new Vector2(250, 352));
            breakableManager.SpawnBreakable(new Vector2(275, 352));
            breakableManager.SpawnBreakable(new Vector2(300, 352));
            breakableManager.SpawnBreakable(new Vector2(325, 352));
            breakableManager.SpawnBreakable(new Vector2(350, 352));
            breakableManager.SpawnBreakable(new Vector2(375, 352));
            breakableManager.SpawnBreakable(new Vector2(400, 352));
            breakableManager.SpawnBreakable(new Vector2(425, 352));
            breakableManager.SpawnBreakable(new Vector2(450, 352));
            breakableManager.SpawnBreakable(new Vector2(475, 352));
            breakableManager.SpawnBreakable(new Vector2(500, 352));
            breakableManager.SpawnBreakable(new Vector2(525, 352));
            breakableManager.SpawnBreakable(new Vector2(500, 352));
            breakableManager.SpawnBreakable(new Vector2(525, 352));
            breakableManager.SpawnBreakable(new Vector2(550, 352));
            breakableManager.SpawnBreakable(new Vector2(575, 352));
            breakableManager.SpawnBreakable(new Vector2(600, 352));
        }

        // Spawn all spikes for level
        public static void SpawnSpikes(SpikeManager spikeManager)
        {
            spikeManager.SpawnSpike(new Vector2(100, 427));
            spikeManager.SpawnSpike(new Vector2(125, 427));
            spikeManager.SpawnSpike(new Vector2(150, 427));
            spikeManager.SpawnSpike(new Vector2(175, 427));
            spikeManager.SpawnSpike(new Vector2(200, 427));
            spikeManager.SpawnSpike(new Vector2(225, 427));
            spikeManager.SpawnSpike(new Vector2(250, 427));
            spikeManager.SpawnSpike(new Vector2(275, 427));
            spikeManager.SpawnSpike(new Vector2(300, 427));
            spikeManager.SpawnSpike(new Vector2(325, 427));
            spikeManager.SpawnSpike(new Vector2(350, 427));
            spikeManager.SpawnSpike(new Vector2(375, 427));
            spikeManager.SpawnSpike(new Vector2(400, 427));
            spikeManager.SpawnSpike(new Vector2(425, 427));
            spikeManager.SpawnSpike(new Vector2(450, 427));
            spikeManager.SpawnSpike(new Vector2(475, 427));
            spikeManager.SpawnSpike(new Vector2(500, 427));
            spikeManager.SpawnSpike(new Vector2(525, 427));
            spikeManager.SpawnSpike(new Vector2(500, 427));
            spikeManager.SpawnSpike(new Vector2(525, 427));
            spikeManager.SpawnSpike(new Vector2(550, 427));
            spikeManager.SpawnSpike(new Vector2(575, 427));
            spikeManager.SpawnSpike(new Vector2(600, 427));
            spikeManager.SpawnSpike(new Vector2(625, 427));
            spikeManager.SpawnSpike(new Vector2(650, 427));
            spikeManager.SpawnSpike(new Vector2(675, 427));
        }

        // Spawn all enemies for level
        public static void SpawnEnemies(EnemyManager enemyManager)
        {
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
            keyDoor.DoorPosition = new Vector2(75, 316);

            // Spawn keys
            keyDoor.SpawnKey(new Vector2(780, 177));
        }

        // Spawn hearts for level
        public static void SpawnHearts(HeartManager heartManager)
        {
        }

        // Setup the tutorial text
        public static void SetupText(SpriteFont font)
        {
            TutorialText = new TypeText("Look! Some of these blocks are damaged. If you make contact\n" +
                                        "they will disappear for a short amount of time.\n" +
                                        "Also, avoid those spikes, they look deadly.\n" +
                                        "From here on out: Good Luck!", 2, new Vector2(50, 40), font);
        }
    }
}
