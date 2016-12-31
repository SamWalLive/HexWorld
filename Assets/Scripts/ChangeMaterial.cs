using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{

    public Dropdown dropdown;
    public Material[] materials;

    private Material currentMaterial;
    private int materialInt = 0;

    void Start ()
    {
        currentMaterial = materials[materialInt];
    }

    void Update ()
    {

        if (Input.GetButton("Mouse Primary"))
        {
            MouseClick(currentMaterial);
        }
    }

    public void ValueChangeCheck ()
    {
        if(dropdown.value != materialInt)
        {
            materialInt = dropdown.value;
            currentMaterial = materials[dropdown.value];
        }
    }

    void MouseClick (Material mat)
    {

        int mask = 1 << 8;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            hit.transform.gameObject.GetComponent<Renderer>().material = mat;
        }

    }

}
