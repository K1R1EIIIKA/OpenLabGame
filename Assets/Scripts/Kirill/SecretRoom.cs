using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening; // Подключаем DOTween

public class SecretRoom : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private Tilemap _tilesToOpen;
    [SerializeField] private float _openTileMapDuration = 1.5f;
    [SerializeField] private float _fadeDuration = 0.5f;

    private void Start()
    {
        FadeTilemap(1f, 0, _tilesToOpen);
        FadeTilemap(1f, 0, _tilesToOpen);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FadeTilemap(0.4f, _fadeDuration, _tileMap);

            FadeTilemap(0, _openTileMapDuration, _tilesToOpen);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FadeTilemap(1f, _fadeDuration, _tileMap);
        }
    }

    private void FadeTilemap(float targetAlpha, float duration, Tilemap tileMap)
    {
        Color currentColor = tileMap.color;
        Color targetColor = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);

        DOTween.To(() => tileMap.color, x => tileMap.color = x, targetColor, duration);
    }
}