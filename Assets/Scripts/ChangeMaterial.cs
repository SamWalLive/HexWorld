using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Material[] materials = new Material[3];

    void Update()
    {

        if (Input.GetButton("Mouse Primary"))
        {
            MouseClick(materials[0]);
        }
        else if (Input.GetButton("Mouse Secondery"))
        {
            MouseClick(materials[1]);
        }
        else if (Input.GetButton("Mouse Wheel"))
        {
            MouseClick(materials[2]);
        }

    }

    void MouseClick(Material mat)
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
