using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.TileBuild;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Movement
{
    class MoveCommand
    {
        private IInputReader keyboard;
        private IPlayerObject player;
        private Level level;

        bool isGround = false;
        bool isSide = false;

        private bool hasJumped;

        public MoveCommand(IPlayerObject player,Level level)
        {
            keyboard = new KeyBoardReader();
            this.player = player;
            this.level = level;
            hasJumped = true;
            isGround = false;
            isSide = false;
        }

        /*
         * TODO
         * fall sprite implementeren
         */
        public void CheckMovement(GameTime gameTime)
        {
            Vector2 positie = new Vector2(player.Positie.X, player.Positie.Y);
            Vector2 velocity = new Vector2(0f, player.Versnelling.Y);

            keyboard.ReadInput();
            player.Direction = keyboard.Direction;

            if (keyboard.Move)
            {
                //Human Run Sprite
                player.Type = AnimatieTypes.Run;
                isGround = false;
                isSide = false;

                if (keyboard.Direction)
                {
                    velocity.X -= 1f;
                }
                else
                {
                    velocity.X += 1f;
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
                isGround = false;
            }


            foreach (var tile in level.Tiles)
            {
                if (tile is ICollideTile)
                {
                    var temp = tile as ICollideTile;
                    Rectangle rectangle = player.Rectangle;


                    if ((EndBlockCollision.isTouchingLeft(velocity, temp, rectangle)|| EndBlockCollision.isTouchingRight(velocity, temp, rectangle)) && !isSide)
                    {
                        Debug.Print($"Left or Right player: {player.Positie.X}:{player.Positie.Y}  tile: {temp.Position.X}:{tile.Position.Y}");
                        velocity.X = 0f;
                        isSide = true;
                    }
                    if (EndBlockCollision.isTouchingTop(velocity, temp, rectangle) && !isGround)
                    {
                        Debug.Print($"Bottom or Top player: {player.Positie.X}:{player.Positie.Y}  tile: {temp.Position.X}:{tile.Position.Y}");
                        positie.Y = temp.Border.Y - (temp.Border.Height+13);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                    if (EndBlockCollision.isTouchingBottom(velocity, temp, rectangle))
                    {
                        velocity.Y = 0f;
                    }
                }
            }


            //Hit another object
            if (isGround)
            {
                velocity.Y = 0f;
                hasJumped = false;
            }
            else
            {
                float i = 1f;
                velocity.Y += 0.20f * i;
                if (player.Versnelling.Y < 0)
                {
                    player.Type = AnimatieTypes.Jump;
                }
                else if (player.Versnelling.Y > 0)
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
