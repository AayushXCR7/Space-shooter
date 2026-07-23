using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class logicmanager : MonoBehaviour
{
    [SerializeField] private enemyspwaner spwaner;
    
    [SerializeField] private Playermovement player;
    
    [SerializeField] private buletspwaner bulletspwaner;
    private float difficulty_rate = 0.5f;
    public float bonousspeed =0;
    public float bonouslife =0;
    private int Score ;
    private int difficulty = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static logicmanager instance;
    [SerializeField] private TMP_Text scoretext;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updatescore(int point)
    {
        Score += point;
        scoretext.text = Score.ToString();
        if (Score > 100 && difficulty == 1)
        {
            difficulty = 2;
            increasing_difficulty();
        }
        if (Score > 200 && difficulty == 2)
        {
            difficulty = 3;
            increasing_difficulty();
        }
        if (Score > 300 && difficulty == 3)
        {
            difficulty = 4;
            increasing_difficulty();
        }
        

    }
    private void increasing_difficulty()
    {
        spwaner.spwanrate -= difficulty_rate;
        bonouslife++;
        player.movespeed += 0.5f;
        bonousspeed++;
        bulletspwaner.spwanrate -= 0.05f;
    }
}
