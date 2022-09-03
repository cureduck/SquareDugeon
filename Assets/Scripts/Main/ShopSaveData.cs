using UnityEngine;

namespace Main
{
    public struct ShopSaveData : IMapSaveData
    {
        public Offer[] Offers;
        
        public Vector2 coord;
        public Vector2 Coord => coord;
    }
}