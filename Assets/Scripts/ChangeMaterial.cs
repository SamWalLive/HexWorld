using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{

    public Dropdown dropdown;
    public Sprite[] sprites;

    private Sprite currentSprite;
    private int spriteInt = 0;

    void Start ()
    {
        currentSprite = sprites[spriteInt];
    }

    void Update ()
    {

        if (Input.GetButton("Mouse Primary"))
        {
            MouseClick(currentSprite);
        }
    }

    public void ValueChangeCheck ()
    {
        if(dropdown.value != spriteInt)
        {
            spriteInt = dropdown.value;
            currentSprite = sprites[dropdown.value];
        }
    }

    void MouseClick (Sprite spr)
    {

        int mask = 1 << 8;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, mask);
        if (hit)
        {
            if (hit)
            {
                hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = spr;
            }
        }
        
    }

}
