using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Map;
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
        private Level level;

        private bool hasJumped;

        public MoveCommand(IPlayerObject player,Level level)
        {
            keyboard = new KeyBoardReader();
            this.player = player;
            this.level = level;
            hasJumped = true;
        }

        /*
         * TODO
         * fall sprite implementeren
         */
        public void CheckMovement(GameTime gameTime)
        {
            Vector2 positie = new Vector2(player.Positie.X, player.Positie.Y);
            Vector2 velocity = new Vector2(player.Versnelling.X, player.Versnelling.Y);

            keyboard.ReadInput();
            player.Direction = keyboard.Direction;

            if (keyboard.Move)
            {
                //Human Run Sprite
                player.Type = AnimatieTypes.Run;

                if (keyboard.Direction)
                {
                    positie.X -= 1f;
                }
                else
                {
                    positie.X += 1f;
                }
            }
            else
            {
                //Human Idle
                player.Type = AnimatieTypes.Idle;
            }

            if (keyboard.Attack)
            {
                player.Type = AnimatieTypes.Attack;
            }


            //BRON jump werkend krijgen: https://www.youtube.com/watch?v=ZLxIShw-7ac&list=PL667AC2BF84D85779&index=25&t=5s 
            if (keyboard.Jump && !hasJumped)
            {
                //Human jumps sprite

                velocity.Y = -5f;
                hasJumped = true;
                player.Type = AnimatieTypes.Jump;
                positie.Y -= 10f;
            }

            //Hit another object
            if (player.Positie.Y >= 400f)
            {
                velocity.Y = 0f;
                hasJumped = false;
            }
            else
            {
                float i = 1f;
                velocity.Y += 0.20f * i;
                if (player.Versnelling.Y <=0)
                {
                    player.Type = AnimatieTypes.Jump;
                }
                else
                {
                    player.Type = AnimatieTypes.Fall;
                }
            }

            player.Positie = positie;
            player.Versnelling = velocity;
            player.Positie += player.Versnelling;

            player.Update(gameTime);
        }
    }
}
