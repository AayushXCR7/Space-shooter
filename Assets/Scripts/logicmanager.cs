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
    [SerializeField] private GameObject[] boss;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bonousbullets;
    private float difficulty_rate = 0.5f;
    public float bonousspeed =0;
    public float bonouslife =0;
    public double bulletrate=0.05;
    private int Score ;
    private int trackingscore = 0;
    private int difficulty = 1;
    private int bosses;
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
        trackingscore += point;
        scoretext.text = Score.ToString();
        if (trackingscore > 100 && difficulty == 1)
        {
            difficulty = 2;
            increasing_difficulty();
        }
        if (trackingscore > 200 && difficulty == 2)
        {
            bonousbullets[0].SetActive(true);
            difficulty = 3;
            increasing_difficulty();
        }
        if (trackingscore > 300 && difficulty == 3)
        {
            difficulty = 4;
            increasing_difficulty();
        }
        if(trackingscore>400 && difficulty ==4)
        {
            difficulty = 5;
            increasing_difficulty();
        }
        if (trackingscore>500 && difficulty==5)
        {
            bosses++;
            difficulty = 1;
            trackingscore = 0;
            if (bosses == 1)
            {
                boss[0].SetActive(true);
                if (boss[0]!=null)
                {
                    for(int i =0; i<3; i++)
                    {
                        enemies[i].SetActive(false);
                    }
                }
                else
                {
                    for(int i=0; i<3; i++)
                    {
                        enemies[i].SetActive(true);
                    }
                }
            }

            }


        }
    private void increasing_difficulty()
    {
        spwaner.spwanrate -= difficulty_rate;
        bonouslife++;
        player.movespeed += 0.5f;
        bonousspeed++;
        bulletrate++;
    
    }
}
