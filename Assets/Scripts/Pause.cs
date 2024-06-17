using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            isActive = !isActive;
        }
        PausePanel.SetActive(isActive);
        if(isActive)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SetActive()
    {
        isActive=!isActive;
    }
}
