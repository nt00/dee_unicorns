using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public string[] items;
    public List<Item> inv = new List<Item>();

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(LoadItemData());
        for (int i = 0; i < items.Length - 1; i++)
        {
            inv.Add(ItemHandler.CreateAndSplitItem(items[i]));
            //Debug.Log(inv[i].Name);
        }
    }

    IEnumerator LoadItemData()
    {
        WWW itemsURL = new WWW("localhost/unicorns_dee/ItemData.php");
        yield return itemsURL;
        string itemData = itemsURL.text;
        items = itemData.Split(';');
    }

}
