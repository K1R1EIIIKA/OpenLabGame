using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassManifestation : MonoBehaviour
{
    private Transform Player;

    [SerializeField] private float speedOfManifestation;

    [SerializeField] private float requiredDistance;

    private float currentDistance;
    private float alfa;

    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Manifestation();
    }
    private void Manifestation()
    {
        currentDistance = Mathf.Abs(Player.position.x - transform.position.x);
        
        if(currentDistance < requiredDistance)
        {
            alfa = currentDistance * speedOfManifestation;
            sprite.color = new Color(1f,1f, 1f, 1-alfa);
        }
    }
}
