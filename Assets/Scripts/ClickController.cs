using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ClickController : MonoBehaviour {

    public int clickableLayer;
    public Dropdown drop;
    public Selection currentSelection;

    private Selection[] currentSelections;
    private Selection seconderySelect;

	void Update ()
    {
	    if(Input.GetButtonUp("Mouse Primary"))
        {
            GetSelection();
            if (currentSelections != null && currentSelections.Length > 0)
            {
                ChooseCurrentSelection();
                SelectionOptions();
            }
        }
        else
        {
            if(Input.GetButtonUp("Mouse Secondery"))
            {
                int mask = 1 << clickableLayer;

                List<Selection> crnt = new List<Selection>();

                RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, mask);

                if (hits != null || hits.Length > 0)
                {
                    foreach (RaycastHit2D hit in hits)
                    {
                        Selection select = hit.transform.GetComponentInChildren<Selection>();
                        if (select)
                        {
                            crnt.Add(select);
                        }

                    }
                    crnt.ToArray();

                    int max = int.MaxValue;
                    foreach (Selection select in crnt)
                    {
                        if (select.priority < max)
                        {
                            seconderySelect = select;
                            max = seconderySelect.priority;
                        }
                    }
                    if (seconderySelect.transform.parent.GetComponent<BuildingController>())
                    {
                        Destroy(seconderySelect.transform.parent.gameObject);
                    }

                }
            }
        }
        

	}

    void GetSelection ()
    {
        int mask = 1 << clickableLayer;

        List<Selection> crnt = new List<Selection>();

        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, mask);

        if (hits == null || hits.Length == 0)
        {
            currentSelections = null;
        }
        else
        {
            foreach (RaycastHit2D hit in hits)
            {
                Selection select = hit.transform.GetComponentInChildren<Selection>();
                if (select)
                {
                    crnt.Add(select);
                }
                
            }
            currentSelections = crnt.ToArray();
        }
        
    }

    void ChooseCurrentSelection ()
    {
        
        int max = int.MaxValue;
        foreach (Selection select in currentSelections)
        {
            if (select.priority < max)
            {
                currentSelection = select;
                max = currentSelection.priority;
            }
        }
    }

    void SelectionOptions ()
    {
        if (currentSelection.transform.parent.GetComponent<BuildingController>())
            currentSelection.transform.parent.GetComponent<BuildingController>().setTeam(Random.Range(0, currentSelection.GetComponentInParent<BuildingController>().teamSprites.Length));
        else
        {
            if (currentSelection.transform.parent.GetComponent<TileController>() && !currentSelection.transform.parent.GetComponentInChildren<BuildingController>())
                currentSelection.transform.parent.GetComponent<TileController>().AddGroundCover(currentSelection.GetComponentInParent<TileController>().buildings[drop.value]);
        }
    }

}
