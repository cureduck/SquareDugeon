using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    [ExecuteAlways]
    public class SpriteManager : Singleton<SpriteManager>
    {
        public Dictionary<string, Sprite> Sprites;
        
        private void Start()
        {
            var t = Resources.LoadAll<Sprite>("Sprites");
            Sprites = new Dictionary<string, Sprite>();
            foreach (var sprite in t)
            {
                Sprites.Add(sprite.name, sprite);
            }
        }
    }
}