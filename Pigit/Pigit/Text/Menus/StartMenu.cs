﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Global.Enums;
using Pigit.Input.Interfaces;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using System.Collections.Generic;

namespace Pigit.Text.Menus
{
    class StartMenu : AShowMenu
    {
        public StartMenu(Dictionary<TextTypes, SpriteFont> spriteFonts, IInputMenu inputMenu, Vector2 position, List<string> text): base(spriteFonts, inputMenu, position, text)
        {}
        public override void EnterLoop(GameTime gameTime)
        {
            switch (cursor.CursorIndex)
            {
                case 0:
                    //play
                    Game1.currGameState = GameLoop.Play;

                    cursor.ResetCursor();
                    break;
                case 1:
                    //Exit
                    Game1.currGameState = GameLoop.Exit;

                    cursor.ResetCursor();
                    break;
                default:
                    break;
            }
        }
    }
}
