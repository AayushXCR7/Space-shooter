using System;
using UnityEngine;

public class scrollingbg : MonoBehaviour
{
    public float speed;
    [SerializeField] private Renderer bgrenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgrenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
