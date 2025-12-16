using System;
using app.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace app.Models.Views
{
    public abstract class MonogameWindow : IMonogameElement
    {
        protected double ratio;

        public double Ratio { get => ratio; }

        public abstract void LoadContent(ContentManager content);

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public abstract void Update(GameTime gameTime);
    }
}
