using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Global.Enums;
using Pigit.Input.Interfaces;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using System.Collections.Generic;

namespace Pigit.Text.Menus
{
    class EndingGameMenu : AShowMenu
    {
        public EndingGameMenu(Dictionary<TextTypes, SpriteFont> spriteFonts, IInputMenu inputMenu, Vector2 position, List<string> text) : base(spriteFonts, inputMenu, position, text)
        {

        }
        public override void EnterLoop(GameTime gameTime)
        {
            if (cursor.CursorIndex == 0)
            {
                //Exit to menu
                Game1.currGameState = GameLoop.Menu;
                cursor.ResetCursor();
            }
            if (cursor.CursorIndex == 1)
            {
                //Exit game
                Game1.currGameState = GameLoop.Exit;
                cursor.ResetCursor();
            }
        }
    }
}
