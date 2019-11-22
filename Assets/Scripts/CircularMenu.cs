using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CircularMenu : MonoBehaviour
{

    public List<MenuButton> buttons = new List<MenuButton>();
    private Vector2 mousePosition; 
    private Vector2 fromVector2M = new Vector2(0.5f, 1.0f);
    private Vector2 centerCircle = new Vector2(0.5f, 0.5f);
    private Vector2 toVector2M; 

    public int menuItems;
    public int curMenuItem; 
    private int oldMenuItem;  
    // Start is called before the first frame update
    void Start()
    {
        menuItems = buttons.Count;        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentMenuItem();
        if(Input.GetButtonDown("Fire1")) {
            ButtonAction();
        }
    }

    public void GetCurrentMenuItem() {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        toVector2M = new Vector2(mousePosition.x/Screen.width, mousePosition.y/Screen.height);

        float angle = (Mathf.Atan2(fromVector2M.y-centerCircle.y, fromVector2M.x-centerCircle.x) - Mathf.Atan2(toVector2M.y-centerCircle.y, toVector2M.x-centerCircle.x)) * Mathf.Rad2Deg;

        if(angle < 0) {
        } angle += 360;

        curMenuItem = (int)(angle / (360 / menuItems));

        if(curMenuItem != oldMenuItem) {
            buttons[oldMenuItem].sceneImage.color = buttons[oldMenuItem].normalColor;
            oldMenuItem = curMenuItem;
            buttons[curMenuItem].sceneImage.color = buttons[oldMenuItem].highlitedColor;
        }
    }

    public void ButtonAction() {
        buttons[curMenuItem].sceneImage.color = buttons[curMenuItem].pressedColor;

        if(curMenuItem == 0) {
            print("You have pressed the first button");
        }
    }
}

[System.Serializable] 
public class MenuButton {
    public string name; 
    public Image sceneImage; 
    public Color normalColor = Color.white; 
    public Color highlitedColor = Color.grey; 
    public Color pressedColor = Color.gray; 
}
