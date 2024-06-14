using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableThingUI : MonoBehaviour
{
    public bool isHave = false;

    public void Update()
    {
        Collect();
    }
    public void Collect()
    {
        if (isHave)
        {
            gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1f,1f, 1f, 0.1f);
        }
    }
}
