using System;
using Main;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopUI : Singleton<ShopUI>
    {
        public Shop Shop;
        public OfferUI[] OfferUis;


        public void Load(Shop shop)
        {
            Shop = shop;
            GetComponent<Image>().raycastTarget = true;
            GetComponent<Toggle>().isOn = true;
            for (var i = 0; i < OfferUis.Length; i++)
            {
                OfferUis[i].gameObject.SetActive(true);
                OfferUis[i].Offer = shop.Save.Offers[i];
            }
        }

        public void Close()
        {
            GetComponent<Image>().raycastTarget = false;
            foreach (var ui in OfferUis)
            {
                ui.gameObject.SetActive(false);
            }

            GetComponent<Toggle>().isOn = false;
            Destroy(Shop.gameObject);
        }
    }
}