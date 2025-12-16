using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace app.Models.Ui
{
    internal class ImageView : UiElement
    {
        private string textureReferance;

        public ImageView(string textRef, Vector2 position, int sizePourcent = 100, float rotation = 0) : base(position, Vector2.Zero, sizePourcent, false, rotation)
        {
            textureReferance = textRef;
        }

        public override void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(textureReferance);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            float i = 2f;
            Vector2 origin = new Vector2(Texture.Width / i, Texture.Height / i);
            spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                Rotation,
                origin,
                Scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}
