using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace MinigameRave
{
    public class Textures
    {
        private List<Texture2D> textureList;

        public Textures()
        {
            textureList = new List<Texture2D>();
        }

        public int loadTextures(String gameName, string[] textureName)
        {
            String fileName;
            Texture2D texture;
            

            foreach (string s in textureName)
            {
                /*try
                {*/
                fileName = "textures/" + gameName + "/" + s;
                texture = globals.contentManager.Load<Texture2D>(fileName);
                textureList.Add(texture);
                /* }
                 catch
                 {
                     return 1;
                 }*/

            }

            return 0;
        }

        public int loadTexture(String gameName, string textureName)
        {
            String fileName;
            Texture2D texture;

            fileName = "textures/" + gameName + "/" + textureName;
            texture = globals.contentManager.Load<Texture2D>(fileName);
            textureList.Add(texture);

            return 0;
        }

        public Texture2D getTexture(int textureNumber)
        {
            return textureList[textureNumber];
        }
    }

    
}
