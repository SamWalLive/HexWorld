using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideUI : MonoBehaviour
{
    public GameObject uiTile;

    public float spriteSize;
    public float scaleSize;

    void Start ()
    {
        float nSize = spriteSize * scaleSize;
        float n2Size = nSize * 2f;

        int repeats = Mathf.CeilToInt((Screen.height - (int)n2Size) / n2Size);
        Debug.Log(repeats.ToString());
        for (int i = 0; i <= repeats; i++)
        {
            GameObject crnt = Instantiate(uiTile);
            crnt.transform.parent = transform;
            crnt.transform.localPosition = Vector3.zero;
            crnt.transform.localRotation = Quaternion.identity;
        }

    }

}
