using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace app.Models.Controls
{
    public class Button : UiElement, IMonogameElement
    {
        // Champs de la classe...
        private Action actionToDo;
        private bool clicked;
        private Rectangle normalForm;
        private Rectangle clickedForm;

        public Rectangle NormalForm { get => normalForm; }
        public Rectangle ClickedForm { get => clickedForm; }
        public bool Clicked { get => clicked; }

        // Constructeur de la classe...
        public Button(Rectangle normalForm, Rectangle clickedForm, Action toDo, Vector2 position) : this(normalForm, clickedForm, toDo, position, 85, false, 0) { }
        public Button(Rectangle normalForm, Rectangle clickedForm, Action toDo, Vector2 position, int sizePourcent = 100, bool flipped = false, float rotation = 0) : base(position, Vector2.Zero, sizePourcent, flipped, rotation)
        {
            this.actionToDo = toDo;
            clicked = false;
            this.normalForm = normalForm;
            this.clickedForm = clickedForm;
            // showHitbox = true;
        }

        // Méthodes de la classe...
        public override Rectangle Hitbox()
        {
            float i = 2f;
            Rectangle form = !clicked ? normalForm : clickedForm;
            Vector2 origin = new Vector2(form.Width / i, form.Height / i);
            return new Rectangle(
                (int)(Position.X - origin.X),
                (int)(Position.Y - origin.Y),
                (int)(form.Width * Scale),
                (int)(form.Height * Scale)
            );
        }

        public override void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>("buttons");
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Draw
            float i = 2f;
            Rectangle form = !clicked ? normalForm : clickedForm;
            Vector2 origin = new Vector2(form.Width / i, form.Height / i);
            SpriteEffects effects = this.Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(Texture, Position, form, Color.White, Rotation, origin, this.Scale, effects, 0f);

            // Afficher la hitbox
            if (ShowHitbox)
            {
                int thickness = 2;
                var color = Color.Red;
                var rect = Hitbox();

                // Tracer les 4 côtés
                spriteBatch.Draw(Game1.WhitePixel, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color); // Haut
                spriteBatch.Draw(Game1.WhitePixel, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color); // Gauche
                spriteBatch.Draw(Game1.WhitePixel, new Rectangle(rect.X + rect.Width - thickness, rect.Y, thickness, rect.Height), color); // Droite
                spriteBatch.Draw(Game1.WhitePixel, new Rectangle(rect.X, rect.Y + rect.Height - thickness, rect.Width, thickness), color); // Bas
            }
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Rectangle boutonRect = Hitbox();

            if (boutonRect.Contains(mouseState.Position))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    clicked = true;
                else if (mouseState.LeftButton == ButtonState.Released && clicked)
                {
                    // Le bouton est cliqué
                    actionToDo?.Invoke();
                    clicked = false;
                }
            }
            else
                clicked = false;
        }
    }
}
