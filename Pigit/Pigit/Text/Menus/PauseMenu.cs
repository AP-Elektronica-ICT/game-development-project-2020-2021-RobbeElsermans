using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Global.Enums;
using Pigit.Input.Interfaces;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Text.Menus
{
    class PauseMenu : AShowMenu
    {
        public PauseMenu(Dictionary<TextTypes, SpriteFont> spriteFonts, IInputMenu inputMenu, Vector2 position, List<string> text) : base(spriteFonts, inputMenu, position, text)
        {

        }
        public override void EnterLoop(GameTime gameTime)
        {
            if (cursor.CursorIndex == 0)
            {
                //Resume
                Game1.currGameState = GameLoop.Play;
                cursor.ResetCursor();
            }
            if (cursor.CursorIndex == 1)
            {
                //Help
                cursor.ResetCursor();
            }
            if (cursor.CursorIndex == 2)
            {
                //Exit to menu
                Game1.currGameState = GameLoop.Menu;
                cursor.ResetCursor();
            }
        }

        //public override void EscapeLoop(GameTime gameTime)
        //{

        //}
    }
}
