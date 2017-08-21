using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler
{
    public static Item CreateAndSplitItem(string ItemId)
    {
        string[] items = ItemId.Split('|');

        Item temp = new Item();
        int id = System.Convert.ToInt32(items[0]);
        string name = items[1];
        int clipsize = System.Convert.ToInt32(items[2]);
        float damage = float.Parse(items[3]);
        float firerate = float.Parse(items[4]);
        float weaponrange = float.Parse(items[5]);
        int weight = System.Convert.ToInt32(items[6]);
        string ammotype = items[7];
        string iconname = items[8];
        string modelname = items[9];

        temp.ID = id;
        temp.Name = name;
        temp.Clipsize = clipsize;
        temp.Damage = damage;
        temp.Firerate = firerate;
        temp.Weaponrange = weaponrange;
        temp.Weight = weight;
        temp.Ammotype = ammotype;
        temp.Icon = Resources.Load("Icons/" + iconname) as Texture2D;
        temp.Modelname = modelname;

        return temp;
    } 
}
