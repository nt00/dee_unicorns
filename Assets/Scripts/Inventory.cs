using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public string[] items;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadItemData());
    }

    IEnumerator LoadItemData()
    {
        WWW itemsURL = new WWW("localhost/unicorns_dee/ItemData.php");
        yield return itemsURL;
        string itemData = itemsURL.text;
        items = itemData.Split(';');
    }
}
