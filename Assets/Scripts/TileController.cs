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

    private int groundMaterialInt;
    private GameObject childGroundSprite;
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
        childGroundSprite.AddComponent<SpriteRenderer>();
        childGroundSprite.layer = layer;
        childGroundSprite.transform.rotation = Quaternion.Euler(0f, 0f, rotations[Random.Range(0, rotations.Length)]);
        groundMaterialInt = Random.Range(0, mainController.groundSprites.GetLength(0));
        groundMaterial = mainController.spriteNames[groundMaterialInt];
        childGroundSprite.GetComponent<SpriteRenderer>().sprite = mainController.groundSprites[groundMaterialInt, Random.Range(0, mainController.groundSprites.GetLength(1))];
    }

	void Start ()
    {
        mainController = FindObjectOfType<WorldController>();
        SetPosition();
        GenerateGround();
	}
	
}
