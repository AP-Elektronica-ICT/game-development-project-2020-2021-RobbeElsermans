using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.SpriteBuild.Enums;
using Pigit.TileBuild;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Movement
{
    class MoveCommandHero : AMovement
    {
        private double timer;
        private bool isSetTimer = false;

        public MoveCommandHero(IPlayerObject player, Level level) : base(player, level)
        {

        }

        public override void CheckMovement(GameTime gameTime)
        {
            base.CheckMovement(gameTime);

            bool attack = false;
            player.IsAttacking = false;
            keyboard.ReadInput();
            player.Direction = keyboard.Direction;

            if (keyboard.Move)
            {
                isGround = false;
                isSide = false;

                if (keyboard.Direction)
                {
                    velocity.X -= walkingSpeed;
                }
                else
                {
                    velocity.X += walkingSpeed;
                }
            }
            else
            {
                
            }

            if (keyboard.Attack)
            {
                player.IsAttacking = true;
                attack = true;
            }

            //BRON jump werkend krijgen: https://www.youtube.com/watch?v=ZLxIShw-7ac&list=PL667AC2BF84D85779&index=25&t=5s 
            if (keyboard.Jump && !hasJumped)
            {
                velocity.Y = -jumpHeight;
                hasJumped = true;
                isGround = false;
            }

            foreach (var tile in level.Tiles)
            {
                if (tile is ICollideTile)
                {
                    var temp = tile as ICollideTile;
                    Rectangle rectangle = player.Rectangle;


                    if ((EndBlockCollision.isTouchingLeft(velocity, temp, rectangle) || EndBlockCollision.isTouchingRight(velocity, temp, rectangle)) && !isSide)
                    {
                        velocity.X = 0f;
                        isSide = true;
                    }
                    if (EndBlockCollision.isTouchingTop(velocity, temp, rectangle) && !isGround)
                    {
                        positie.Y = temp.Border.Y - (temp.Border.Height + 13);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                    if (EndBlockCollision.isTouchingBottom(velocity, temp, rectangle))
                    {
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
                        positie.Y = temp.Border.Y - (temp.Border.Height + 13);
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
                //if (player.Velocity.Y < 0)
                //{
                //    player.Type = AnimatieTypes.Jump;
                //}
                //else if (player.Velocity.Y > 0)
                //{
                //    player.Type = AnimatieTypes.Fall;
                //}
            }

            //Attack an enemy
            if (!isSetTimer)
            {
                timer = gameTime.TotalGameTime.TotalSeconds;
                isSetTimer = true;
            }

            foreach (var enemy in level.Enemys)
            {
                if (NPCCollision.isTouchingNPC(player.Rectangle, enemy.Rectangle) && attack)
                {
                    var tempEnemy = enemy as IPlayerObject;
                    if (gameTime.TotalGameTime.TotalSeconds - timer > 0.5)
                    {
                        isSetTimer = false;
                        tempEnemy.Hearts -= player.AttackDamage;
                        if (!tempEnemy.IsHit)
                        {
                            tempEnemy.IsHit = true;
                        }
                        //Debug.Print($"{tempEnemy.Hearts}");
                    }
                }
            }

            player.Positie = positie;
            player.Velocity = velocity;
            //player.Positie += player.Versnelling;

            player.Update(gameTime);
        }
    }
}
