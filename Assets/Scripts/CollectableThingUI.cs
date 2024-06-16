using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableThingUI : MonoBehaviour
{
    public int isHave;
    public int cost = 1;
    [SerializeField] private TextMeshProUGUI countThing;
    [SerializeField] private Color notHaveColor;
    [SerializeField] private Color haveColor;

    public void Update()
    {
        Collect();
    }

    public void Collect()
    {
        if (isHave <= 0)
        {
            gameObject.GetComponent<Image>().color = notHaveColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = haveColor;
            if (countThing)
                countThing.text = isHave.ToString();
        }
    }
}