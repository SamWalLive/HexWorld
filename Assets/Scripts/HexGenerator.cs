using UnityEngine;

public class HexGenerator : MonoBehaviour {

    public Vector2 size;
    public GameObject hex;

    bool ErrorCheck()
    {
        bool error = false;
        if (size.x % 2 == 0)
        {
            Debug.Log("X input cannot be even");
            error = true;
        }
        if (size.y % 2 == 0)
        {
            Debug.Log("Y input cannot be even");
            error = true;
        }
        if (size.x < 1)
        {
            Debug.Log("X input must be greater than 0");
            error = true;
        }
        if (size.y < 1)
        {
            Debug.Log("Y input must be greater than 0");
            error = true;
        }
        return error;
    }

    void Awake()
    {
        if (ErrorCheck())
        {
        }
        else
        {
            Generate();
        }

    }

    void Generate()
    {
        float x, y;
        for (x = -size.x; x <= size.x; x++)
        {
            for(y = -size.y; y <= size.y; y++)
            {
                if (ValidCoordinates(x, y))
                {
                    GenerateHex(x, y);
                }
            }
        }
        foreach (Hex obj in GetComponentsInChildren<Hex>())
        {
            obj.FillNeighbours();
        }
    }

    void GenerateHex(float x, float y)
    {
        Vector2 position = new Vector2(x * 1.5f, y * Mathf.Sqrt(3f) * 0.5f);
        GameObject clone = (GameObject)Instantiate(hex, position, hex.transform.rotation, transform);
        Hex cloneHex = clone.GetComponent<Hex>();
        cloneHex.position.x = x;
        cloneHex.position.y = y;
        cloneHex.FillNeighbourPositions();
        cloneHex.name = "Hex(" + x.ToString() + "," + y.ToString() + ")";
    }

    bool ValidCoordinates(float x, float y)
    {
        if (x < 0)
            x *= -1;
        if (y < 0)
            y *= -1;

        if (x % 2 == 0)
        {
            if (y % 2 == 1)
            {
                return false;
            }
        }
        
        if (x % 2 == 1)
        {
            if(y % 2 == 0)
            {
                return false;
            }
        }

        if (y < size.y)
        {
            return true;
        }

        return false;
    }

}
