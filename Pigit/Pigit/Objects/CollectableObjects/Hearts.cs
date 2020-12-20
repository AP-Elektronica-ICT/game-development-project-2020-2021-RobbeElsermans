using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Movement;
using Pigit.Objects.Enums;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.CollectableObjects
{
    class Hearts : ICollectableObject
    {
        public int Value { get; }
        public bool IsTaken { get; set; }
        public bool IsCollected { get; set; }
        public CollectableTypes Size { get; }
        public Rectangle Rectangle { get; set; }
        public SpriteDefine CurrentSprite { get; }
        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }
        public MoveTypes MovementType { get; set; }

        public Hearts(Dictionary<AnimatieTypes, SpriteDefine> sprites, Vector2 positie, MoveTypes movement)
        {
            this.MovementType = movement;
            this.Sprites = sprites;
            this.Positie = positie;
        }

        public void Update(GameTime gameTime) 
        {

        }
        public void Draw(SpriteBatch _spriteBatch) 
        { 

        }
    }
}
