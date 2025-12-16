using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Models.Agents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace app.Models.Views
{
    internal class GameScreen : MonogameWindow
    {
        private Santa santa;

        public GameScreen()
        {
            santa = new Santa(new Vector2(0, 0), Vector2.One);
        }

        public override void LoadContent(ContentManager content)
        {
            santa.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            santa.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            santa.Draw(spriteBatch, gameTime);
        }
    }
}
