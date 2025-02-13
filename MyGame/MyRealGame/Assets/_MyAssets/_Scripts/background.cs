using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    [SerializeField] float scrollspeed;
    private SpriteRenderer sr;
    private Material mr;
    private Vector2 offset;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        offset = sr.material.mainTextureOffset;
    }

    private void Update()
    {
        offset.x += scrollspeed * Time.deltaTime;
        sr.material.mainTextureOffset = offset;
    }
}