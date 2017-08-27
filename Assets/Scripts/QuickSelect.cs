using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSelect : MonoBehaviour
{
    public Vector2 mousePos; //where our mouse is on screen
    public string direction; //use this to debug
    public bool showQuickMenu; //is the menu open
    public float scrH; //size of screen's height
    public float scrW; //size of screen's width
    public Inventory inventory;//location of our items
    public Item selectedItem;//item we are interacting with
    public Item equippedItem;// item we equippped
    public GUISkin qsSkin;
    public GUIStyle qsStyle;
    public bool equipAK47;
    public bool equipMossberg;
    public bool equipRuger;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            scrH = Screen.height / 9;
            scrW = Screen.width / 16;
            showQuickMenu = !showQuickMenu;
        }
        if(showQuickMenu)
        {
            mousePos = Input.mousePosition;

            #region Mouse Input
            #region Up Direction
            if (-mousePos.y + Screen.height >= scrH * 0 && -mousePos.y + Screen.height <= scrH * 3.5f)
            {
                if(mousePos.x >= scrW* 5.5f && mousePos.x <= scrW * 10.5f)
                {
                    direction = "Up";
                    //Debug.Log(direction);
                }
            }
            #endregion
            #region Down Direction
            if (-mousePos.y + Screen.height >= scrH * 5.5f && -mousePos.y + Screen.height <= scrH * 9)
            {
                if(mousePos.x >= scrW * 5.5f && mousePos.x <= scrW * 10.5f)
                {
                    direction = "Down";
                    //Debug.Log(direction);
                }
            }
            #endregion
            #region Right Direction
            if (mousePos.y >= scrH * 3.5f && mousePos.y <= scrH * 5.5f)
            {
                if (mousePos.x >= scrW * 10.5f && mousePos.x <= scrW * 16f)
                {
                    direction = "Right";
                    //Debug.Log(direction);
                }
            }
            #endregion
            #region Left Direction
            if (mousePos.y >= scrH * 3.5f && mousePos.y <= scrH * 5.5f)
            {
                if (mousePos.x >= scrW * 0 && mousePos.x <= scrW * 5.5f)
                {
                    direction = "Left";
                    //Debug.Log(direction);
                }
            }
            #endregion
            #region Upper Right Direction
            if (- mousePos.y + Screen.height >= scrH * 0 && - mousePos.y + Screen.height <= scrH * 3.5f)
            {
                if (mousePos.x >= scrW * 10.5f && mousePos.x <= scrW * 16f)
                {
                    direction = "Upper Right";
                    //Debug.Log(direction);
                }
            }
            #endregion
            #region Upper Left Direction
            if (-mousePos.y + Screen.height >= scrH * 0 && -mousePos.y + Screen.height <= scrH * 3.5f)
            {
                if (mousePos.x >= scrW * 0 && mousePos.x <= scrW * 5.5f)
                {
                    direction = "Upper Left";
                    //Debug.Log(direction);
                }
            }
            #endregion
            #region Bottom Right Direction
            if (-mousePos.y + Screen.height >= scrH * 5.5f && -mousePos.y + Screen.height <= scrH * 9)
            {
                if (mousePos.x >= scrW * 10.5f && mousePos.x <= scrW * 16f)
                {
                    direction = "Bottom Right";
                    //Debug.Log(direction);
                }
            }
            #endregion
            #region Bottom Left Direction
            if (-mousePos.y + Screen.height >= scrH * 5.5f && -mousePos.y + Screen.height <= scrH * 9)
            {
                if (mousePos.x >= scrW * 0 && mousePos.x <= scrW * 5.5f)
                {
                    direction = "Bottom Left";
                   // Debug.Log(direction);
                }
            }
            #endregion
            #region Center
            if (-mousePos.y + Screen.height >= scrH * 3.5f && -mousePos.y + Screen.height <= scrH * 5.5f)
            {
                if (mousePos.x >= scrW * 5.5f && mousePos.x <= scrW * 10.5f)
                {
                    direction = "Center";
                    // Debug.Log(direction);
                }
            }
            #endregion
            #region Selection
            if(Input.GetMouseButtonDown(0))
            {
                if(direction != "")
                {
                    if(direction == "Up")
                    {
                        Debug.Log(inventory.inv[0].Name);
                        selectedItem = inventory.inv[0];
                        equippedItem = inventory.inv[0];
                    }
                    if (direction == "Upper Right")
                    {
                        Debug.Log(inventory.inv[1].Name);
                        selectedItem = inventory.inv[1];
                        equippedItem = inventory.inv[1];
                    }
                    if (direction == "Right")
                    {
                        Debug.Log(inventory.inv[2].Name);
                        selectedItem = inventory.inv[2];
                        equippedItem = inventory.inv[2];
                    }
                    if (direction == "Bottom Right")
                    {
                        selectedItem = null;
                    }
                    if (direction == "Down")
                    {
                        selectedItem = null;
                    }
                    if (direction == "Bottom Left")
                    {
                        selectedItem = null;
                    }
                    if (direction == "Left")
                    {
                        selectedItem = null;
                    }

                    if (direction == "Upper Left")
                    {
                        selectedItem = null;
                    }
                }
            }
            #endregion
            #endregion
        }
    }
    void OnGUI()
    {
        // Shows equipped item's icon and information when the quick select menu is hidden
        if(!showQuickMenu)
        {
            GUI.Box(new Rect(scrW * 0, scrH * 7, scrW * 4, scrH * 2), "");
            GUI.DrawTexture(new Rect(scrW * 0, scrH * 7, scrW * 4, scrH * 2), equippedItem.Icon);
            GUI.Label(new Rect(scrW * 4.5f, scrH * 7, scrW * 2, scrH * 2), "Name: " + equippedItem.Name + "\n" + "Clip Size: " + equippedItem.Clipsize.ToString(), qsStyle);

        }

        GUI.skin = qsSkin;

        if (showQuickMenu)
        {
            //DeadZone
            GUI.Box(new Rect(scrW * 5.5f, scrH * 3.5f, scrW * 5, scrH * 2), "");
            if (selectedItem != null)
            {
                GUI.Label(new Rect(scrW * 5.5f, scrH * 3.5f, scrW * 5, scrH * 2), "Name: " + selectedItem.Name + "\n" + "Clip Size: " + selectedItem.Clipsize.ToString(),qsStyle);
            }
            //Up
            GUI.Box(new Rect(scrW * 5.5f, scrH * 0, scrW * 5, scrH * 3.5f), "");
            GUI.DrawTexture(new Rect(scrW * 5.5f, scrH * 0, scrW * 5, scrH * 3.5f), inventory.inv[0].Icon);
            //Down
            GUI.Box(new Rect(scrW * 5.5f, scrH * 5.5f, scrW * 5, scrH * 3.5f), "");
            //Right
            GUI.Box(new Rect(scrW * 10.5f, scrH * 3.5f, scrW * 5.5f, scrH * 2), "");
            GUI.DrawTexture(new Rect(scrW * 10.5f, scrH * 3.5f, scrW * 5.5f, scrH * 2), inventory.inv[2].Icon);
            //Left
            GUI.Box(new Rect(scrW * 0, scrH * 3.5f, scrW * 5.5f, scrH * 2), "");
            //Upper Right
            GUI.Box(new Rect(scrW * 10.5f, scrH * 0, scrW * 5.5f, scrH * 3.5f), "");
            GUI.DrawTexture(new Rect(scrW * 10.5f, scrH * 0, scrW * 5.5f, scrH * 3.5f), inventory.inv[1].Icon);
            //Upper Left
            GUI.Box(new Rect(scrW * 0, scrH * 0, scrW * 5.5f, scrH * 3.5f), "");
            //Bottom Right
            GUI.Box(new Rect(scrW * 10.5f, scrH * 5.5f, scrW * 5.5f, scrH * 3.5f), "");
            //Bottom Left
            GUI.Box(new Rect(scrW * 0, scrH * 5.5f, scrW * 5.5f, scrH * 3.5f), "");
        }
    }
}
