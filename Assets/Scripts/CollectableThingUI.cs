using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableThingUI : MonoBehaviour
{
    public int isHave = 0;
    [SerializeField] private TextMeshProUGUI countThing;
    [SerializeField] private Color notHaveColor;
    [SerializeField] private Color haveColor;

    public void Update()
    {
        Collect();
        countThing.text = isHave.ToString();
    }
    public void Collect()
    {
        if (isHave == 0)
        {
            gameObject.GetComponent<Image>().color = notHaveColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = haveColor;
        }
    }
}
