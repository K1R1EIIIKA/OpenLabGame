using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    private static Transform player;
    private static AudioSource wind;
    [SerializeField] private float speed;
    [SerializeField] private float volumeOutside;
    private float volumeInside;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        wind = GameObject.FindGameObjectWithTag("Wind").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(transform.position.y - player.position.y <= 0)
        {
            wind.volume = volumeOutside;
            volumeInside = volumeOutside;
        }
        else
        {
            volumeInside -= (transform.position.y-player.position.y)*speed;
            wind.volume = volumeInside;
        }
    }

}
