using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicinhome : MonoBehaviour
{
    [SerializeField] private AudioSource InsideMusic;
    [SerializeField] private AudioSource OutsideMusic;
    [SerializeField] private AudioSource Wind;
    public bool inside;

    private void Start()
    {
        inside = false;
    }

    public void ChangeMusic()
    {
        if (inside)
        {
            OutsideMusic.Stop();
            Wind.Stop();
            InsideMusic.Play();
        }
        else
        {
            InsideMusic.Stop();
            OutsideMusic.Play();
            Wind.Play();
        }
    }
}
