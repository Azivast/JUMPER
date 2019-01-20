using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumper
{
    static class InputManager
    {
        // Static Accessable states for the keyboard. As well as their previous states
        public static KeyboardState KBState;
        public static KeyboardState PrevKBState;

        // Function to check if a key has just been pressed down, and was previously up
        public static bool IsTapped(Keys key)
        {
            return KBState.IsKeyDown(key) && PrevKBState.IsKeyUp(key);
        }

        // Update
        public static void Update(GameTime gameTime)
        {
            // Update keyboard states
            PrevKBState = KBState;
            KBState = Keyboard.GetState();
        }
    }
}
