using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace app.Models
{
    public abstract class UiElement : IMonogameElement
    {
        // Champs de la classe...
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 velocity;
        private float scale;
        private bool flipped;
        private float rotation;
        protected bool showHitbox;

        // Propriétés de la classe...
        public Vector2 Position { get => position; }
        protected Texture2D Texture { get => texture; }
        public Vector2 Velocity { get => velocity; }
        public float Scale { get => scale; }
        public bool Flipped { get => flipped; }
        public float Rotation { get => rotation; }
        public bool ShowHitbox { get => showHitbox; }


        // Constructeur de la classe...
        public UiElement(Vector2 position, Vector2 velocity, int sizePourcent = 100, bool flipped = false, float rotation = 0)
        {
            this.position = position;
            this.velocity = velocity;
            SetSize(sizePourcent);
            this.flipped = flipped;
            this.rotation = rotation;
            this.showHitbox = false;
        }

        // Méthodes de la classe...
        public virtual Rectangle Hitbox() { return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height); }

        protected void SetSize(int pourcent)
        {
            scale = pourcent / 100f;
        }

        protected void SetRotation(int degrees)
        {
            rotation = MathHelper.ToRadians(degrees);
        }

        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
