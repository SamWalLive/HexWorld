using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {

    public int team;
    public Sprite[] teamSprites;
    public SpriteRenderer teamColour;

    private PlayerController playerControl;

    public void setTeam (int inp)
    {
        teamColour.sprite = teamSprites[inp];
    }

    void Start ()
    {
        playerControl = FindObjectOfType<PlayerController>();
        team = playerControl.teamColour;
        setTeam(team);
	}
	
	void Update ()
    {
	
	}
}
