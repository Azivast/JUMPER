using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jumper
{
    class TileManager
    {
        // List of all tiles
        public List<Sprite> Tiles = new List<Sprite>();

        public void AddTile(Texture2D texture, Vector2 position, Rectangle initialFrame)
        {
            Sprite tile = new Sprite(position, texture, initialFrame);
            Tiles.Add(tile);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite tile in Tiles)
            {
                tile.Draw(spriteBatch);
            }

        }
       
    }
}
