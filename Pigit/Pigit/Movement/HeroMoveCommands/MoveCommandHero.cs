using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.Objects.Interfaces;
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
        IInputReader inputs;

        public MoveCommandHero(IPlayerObject player, Level level, IInputReader input) : base(player, level)
        {
            inputs = input;
        }

        public override void CheckMovement(GameTime gameTime)
        {
            RecastPositions();

            bool attack = false;
            player.IsAttacking = false;
            inputs.ReadInput();
            player.Direction = inputs.Direction;

            if (inputs.Move)
            {
                isGround = false;

                if (inputs.Direction)
                {
                    velocity.X -= walkingSpeed;
                }
                else
                {
                    velocity.X += walkingSpeed;
                }
            }

            if (inputs.Attack)
            {
                player.IsAttacking = true;
                attack = true;
            }

            //BRON jump werkend krijgen: https://www.youtube.com/watch?v=ZLxIShw-7ac&list=PL667AC2BF84D85779&index=25&t=5s 
            if (inputs.Jump && !hasJumped)
            {
                velocity.Y = -jumpHeight;
                hasJumped = true;
                isGround = false;
            }

            CheckCollide(-13, -13);

            CheckGravity();

            if (attack)
            {
                player.Attack.Attack(level.CurrEnemys, player, gameTime);
            }

            player.Positie = positie;
            player.Velocity = velocity;

            player.Update(gameTime);
        }
    }
}
