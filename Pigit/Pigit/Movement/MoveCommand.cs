using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement
{
    class MoveCommand
    {
        private IInputReader keyboard;
        private IPlayerObject player;
        SpriteBatch _spriteBatch;
        private bool hasJumped;

        public MoveCommand(IPlayerObject player, SpriteBatch _spriteBatch)
        {
            keyboard = new KeyBoardReader();
            this.player = player;
            this._spriteBatch = _spriteBatch;
            hasJumped = true;
        }

        /*
         * TODO
         * fall sprite implementeren
         */
        public void CheckMovement(GameTime gameTime)
        {
            keyboard.ReadInput();
            //if (keyboard.Attack)
            //{
            //    player.Type = AnimatieTypes.Attack;
            //    player.Update(gameTime, Vector2.Zero);
            //}
            //if (keyboard.Jump && !hasJumped)
            //{
            //    //Human jumps sprite

            //    player.Versnelling = new Vector2(0f, -5f);
            //    hasJumped = true;
            //    player.Type = AnimatieTypes.Jump;
            //    player.Update(gameTime, new Vector2(0f, -10f));
            //}

            //if (player.Positie.Y >= 400f)
            //{
            //    player.Versnelling = new Vector2(0f, 0f);
            //    hasJumped = false;
            //}
            //else
            //{
            //    float i = 1f;
            //    player.Versnelling += new Vector2(0f, 0.20f * i);
            //}

            //if (keyboard.Move)
            //{
            //    //Human Run Sprite
            //    player.Type = AnimatieTypes.Run;
            //    player.Update(gameTime, new Vector2(-1, 0));
            //}
            //else
            //{
            //    //Human Idle
            //    player.Type = AnimatieTypes.Idle;
            //    player.Update(gameTime, Vector2.Zero);
            //}
            player.Type = AnimatieTypes.Idle;
            player.Update(gameTime, Vector2.Zero);
        }
    }
}
