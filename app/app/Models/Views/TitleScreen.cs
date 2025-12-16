using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Models.Controls;
using app.Models.Ui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace app.Models.Views
{
    public class TitleScreen : MonogameWindow
    {
        private ImageView logo;
        private Button btnPlay;

        public TitleScreen()
        {
            logo = new ImageView("logo", new Vector2(Game1.ScreenDimensions.Width / 2, Game1.ScreenDimensions.Height * 2 / 5), 80);
            btnPlay = new Button(
                normalForm: new Rectangle(0, 170, 160, 83),
                clickedForm: new Rectangle(160, 0, 160, 83),
                new Action(() =>
                {
                    Game1.activeScene = new GameScreen();
                }), new Vector2(Game1.ScreenDimensions.Width / 2, Game1.ScreenDimensions.Height * 2 / 3)
                );
        }

        public override void LoadContent(ContentManager content)
        {
            logo.LoadContent(content);
            btnPlay.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            btnPlay.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            logo.Draw(spriteBatch, gameTime);
            btnPlay.Draw(spriteBatch, gameTime);
        }
    }
}
