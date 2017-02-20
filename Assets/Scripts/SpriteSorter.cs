using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class SpriteSorter : MonoBehaviour {

    public SpriteRenderer[] sprites;
    public string liveLayer;

	void Start ()
    {

        List<SpriteRenderer> spriteList = new List<SpriteRenderer>();

        foreach(SpriteRenderer rend in GetComponentsInChildren<SpriteRenderer>())
        {
            if (rend.sortingLayerName == liveLayer)
                spriteList.Add(rend);
        }
        sprites = spriteList.ToArray();
	}
	
	void Update ()
    {
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * 100) * -1;
        }
        
	}
}
