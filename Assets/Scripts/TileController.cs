using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public WorldController mainController;
    public int layer;
    public float spriteSize;
    public Vector2 coordinates;
    public string groundMaterial;
    public int tileSelectionPriority;
    public GameObject[] buildings;
    public GameObject[] farms;

    private int groundMaterialInt;
    private GameObject childGroundSprite;
    private GameObject childGroundCover;
    private float[] rotations = { 0f, 90f, 180f, -90f };

    void SetPosition ()
    {
        transform.position = new Vector3(coordinates.x , coordinates.y) * spriteSize;
    }

    void GenerateGround ()
    {
        childGroundSprite = new GameObject("Ground Sprite");
        childGroundSprite.transform.parent = transform;
        childGroundSprite.transform.localPosition = Vector3.zero;
        childGroundSprite.layer = layer;
        childGroundSprite.transform.rotation = Quaternion.Euler(0f, 0f, rotations[Random.Range(0, rotations.Length)]);
        SpriteRenderer spr = childGroundSprite.AddComponent<SpriteRenderer>();
        groundMaterialInt = Random.Range(0, mainController.groundSprites.GetLength(0));
        groundMaterial = mainController.spriteNames[groundMaterialInt];
        spr.sprite = mainController.groundSprites[groundMaterialInt, Random.Range(0, mainController.groundSprites.GetLength(1))];
        Selection sel = childGroundSprite.AddComponent<Selection>();
        sel.priority = tileSelectionPriority;
        sel.type = "Ground";
        BoxCollider2D col = childGroundSprite.AddComponent<BoxCollider2D>();
        col.size = new Vector2(spriteSize, spriteSize);
        col.isTrigger = true;

    }

	void Start ()
    {
        mainController = FindObjectOfType<WorldController>();
        SetPosition();
        GenerateGround();
        GenerateGroundCover();
	}

    void GenerateGroundCover ()
    {

        switch (groundMaterialInt)
        {
            case 0:
                if (Random.Range(0, 2) == 0)
                {
                    GenerateDirtCover();
                }
                break;
            case 1:
                if (Random.Range(0, 2) == 0)
                {
                    GenerateGrassCover();
                }
                break;
            case 2:
                if (Random.Range(0, 2) == 0)
                {
                    GenerateStoneCover();
                }
                break;
            case 3:
                if (Random.Range(0, 2) == 0)
                {
                    GenerateSandCover();
                }
                break;
            case 4:
                if (Random.Range(0, 2) == 0)
                {
                    GenerateIceCover();
                }
                break;
            case 5:
                if (Random.Range(0, 2) == 0)
                {
                    GenerateWaterCover();
                }
                break;
        }
        if (childGroundCover)
        {
            childGroundCover.transform.parent = transform;
            childGroundCover.transform.localPosition = Vector3.zero;
            childGroundCover.layer = layer;
            childGroundCover.name = "Ground Cover: " + childGroundCover.name;
        }
    }

    public void AddGroundCover (GameObject inp)
    {
        childGroundCover = Instantiate(inp);
        childGroundCover.name = inp.name;
        childGroundCover.transform.parent = transform;
        childGroundCover.transform.localPosition = Vector3.zero;
        childGroundCover.layer = layer;
        childGroundCover.name = "Ground Cover: " + childGroundCover.name;
    }

    void GenerateDirtCover ()
    {
        int r = Random.Range(0, buildings.Length);
        childGroundCover = Instantiate(buildings[r]);
        childGroundCover.name = buildings[r].name;
    }

    void GenerateGrassCover ()
    {
        List<GameObject> lst = new List<GameObject>();
        lst.AddRange(buildings);
        lst.AddRange(farms);
        GameObject[] ary = lst.ToArray();
        int r = Random.Range(0, ary.Length);
        childGroundCover = Instantiate(ary[r]);
        childGroundCover.name = ary[r].name;
    }

    void GenerateStoneCover ()
    {
        int r = Random.Range(0, buildings.Length);
        childGroundCover = Instantiate(buildings[r]);
        childGroundCover.name = buildings[r].name;
    }

    void GenerateSandCover ()
    {

    }

    void GenerateIceCover ()
    {

    }

    void GenerateWaterCover ()
    {

    }
	
}
