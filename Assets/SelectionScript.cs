using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    public static int selected = 2;
    [SerializeField] private int thisSelected = 0;

    void Update()
    {
        // on space press, cycle through selected = 0, 1, 2
        if (Input.GetKeyDown("space") && thisSelected == 0)
        {
            selected = (selected + 1) % 3;
        }
        
        // if selected, show this object's Image
        if (selected == thisSelected)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
        else
        {
            GetComponent<UnityEngine.UI.Image>().enabled = false;
        }

        if (Input.GetKeyDown("x") && selected == thisSelected)
        {
            transform.parent.GetComponent<LevelRedirect>().Click();
        }
    }
}
