using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {

    public int team;
    public Sprite[] teamSprites;
    public SpriteRenderer teamColour;

    public void setTeam (int inp)
    {
        teamColour.sprite = teamSprites[inp];
    }

    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
}
