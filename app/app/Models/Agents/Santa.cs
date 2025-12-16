using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace app.Models.Agents
{
    internal class Santa : AnimatedElement, IMonogameElement
    {
        public Santa(Vector2 position, Vector2 velocity, int sizePourcent = 100, bool flipped = false, float rotation = 0) : base(position, velocity, sizePourcent, flipped, rotation)
        {
            animationName = "die";
        }

        public override void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>("santa");

            // Animations
            List<Rectangle> l = new List<Rectangle>();
            l.AddRange(Animation.GenerateAnimation(355, 555, 8655, 45, 590, 0, 5));
            l.AddRange(Animation.GenerateAnimation(555, 555, 230, 32, 420, 0, 9));
            animations["die"] = new Animation(l, 400, 0, false);
        }

        public override void Update(GameTime gameTime)
        {
            CurrentAnimationObject.Update(gameTime);
        }
    }
}
