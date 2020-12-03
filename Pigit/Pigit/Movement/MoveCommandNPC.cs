using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.TileBuild;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Movement
{
    class MoveCommandNPC : AMovement
    {
        private bool righting = false;
        public MoveCommandNPC(IPlayerObject player, Level level) : base(player, level, 4, 2)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            base.CheckMovement(gameTime);

            player.Type = AnimatieTypes.Idle;

            player.Direction = !righting;

            //Human Run Sprite


            if (righting)
            {
                velocity.X -= walkingSpeed;
                player.Type = AnimatieTypes.Run;
                isGround = false;
                isSide = false;
            }
            else
            {
                velocity.X += walkingSpeed;
                player.Type = AnimatieTypes.Run;
                isGround = false;
                isSide = false;
            }

            double timer = gameTime.TotalGameTime.TotalSeconds;

            Debug.Print(timer.ToString());

            if (righting)
            {
                velocity.X = 1;
            }
            else
            {
                velocity.X = -1;
            }


            isGround = false;


            foreach (var tile in level.Tiles)
            {
                if (tile is ICollideTile)
                {
                    var temp = tile as ICollideTile;
                    Rectangle rectangle = player.Rectangle;

                    if (EndBlockCollision.isTouchingRight(velocity, temp, rectangle))
                    {
                        Debug.Print($"Left or Right player: {positie}  tile: {temp.Position}");
                        righting = true;
                        velocity.X = 0f;

                    }

                    if (EndBlockCollision.isTouchingLeft(velocity, temp, rectangle))
                    {
                        Debug.Print($"Left or Right player: {positie}  tile: {temp.Position}");
                        righting = false;
                        velocity.X = 0f;

                    }
                    if (EndBlockCollision.isTouchingTop(velocity, temp, rectangle) && !isGround)
                    {
                        Debug.Print($"Bottom player: {positie}  tile: {temp.Position}");
                        positie.Y = temp.Border.Y - (temp.Border.Height - 4);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                    if (EndBlockCollision.isTouchingBottom(velocity, temp, rectangle))
                    {
                        Debug.Print($"Top player: {positie}  tile: {temp.Position}");
                        velocity.Y = 0f;
                    }
                }

                if (tile is IPlatformTile)
                {
                    var temp = tile as IPlatformTile;
                    Rectangle rectangle = player.Rectangle;


                    //if (PlatformBlockCollision.isOnTopOf(rectangle, temp.Border) && velocity.Y > 0)
                    //{
                    //    velocity.Y = 0f;
                    //    isGround = true;
                    //}

                    if (PlatformBlockCollision.isOnTopOf(rectangle, temp.Border, velocity) && velocity.Y > 0)
                    {
                        Debug.Print($"inTopOf {player.Versnelling}");
                        positie.Y = temp.Border.Y - (temp.Border.Height - 5);
                        velocity.Y = 0f;
                        isGround = true;
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
                //if (player.Versnelling.Y < 0)
                //{
                //    player.Type = AnimatieTypes.Jump;
                //}
                //else if (player.Versnelling.Y > 0)
                //{
                //    player.Type = AnimatieTypes.Fall;
                //}
            }


            player.Positie = positie;
            player.Versnelling = velocity;
            player.Positie += player.Versnelling;

            player.Update(gameTime);
        }
    }
}
