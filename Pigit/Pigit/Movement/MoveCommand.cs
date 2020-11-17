using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Map;
using Pigit.Objects;
using Pigit.TileBuild;
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
        private Level level;
        private bool hitTile;

        public MoveCommand(IPlayerObject player, SpriteBatch _spriteBatch, Level level)
        {
            this.level = level;
            keyboard = new KeyBoardReader();
            this.player = player;
            this._spriteBatch = _spriteBatch;
            hasJumped = true;
            hitTile = false;
        }

        /*
         * TODO
         * fall sprite implementeren
         */
        public void CheckMovement(GameTime gameTime)
        {
            Vector2 positie = Vector2.Zero;
            keyboard.ReadInput();
            player.Direction = keyboard.Direction;

            if (keyboard.Move)
            {
                //Human Run Sprite
                player.Type = AnimatieTypes.Run;

                if (keyboard.Direction)
                {
                    positie = new Vector2(-1, 0);
                }
                else
                {
                    positie = new Vector2(1, 0);
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

                player.Versnelling = new Vector2(0f, -5f);
                hasJumped = true;
                player.Type = AnimatieTypes.Jump;
                positie = new Vector2(0, -10f);
            }

            //Hit another object
            foreach (var collideTile in level.Tiles)
            {
                if (collideTile is ICollideTile)
                {
                    ICollideTile temp = collideTile as ICollideTile;

                    if (player.Border.isOnTopOf(temp.Border))
                    {
                        hitTile = true;
                        break;
                    }
                    else
                    {
                        hitTile = false;
                    }
                }
            }

            if (hitTile)
            {
                player.Versnelling = new Vector2(0f, 0f);
                hasJumped = false;
            }
            else
            {
                float i = 1f;
                player.Versnelling += new Vector2(0f, 0.20f * i);
                if (player.Versnelling.Y <= 0)
                {
                    player.Type = AnimatieTypes.Jump;
                }
                else
                {
                    player.Type = AnimatieTypes.Fall;
                }
            }

            player.Update(gameTime, positie);
        }
    }
}
