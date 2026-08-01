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
    [SerializeField] private buletspwaner bulletspwaner2;
    [SerializeField] private GameObject boss;
    [SerializeField] public GameObject[] enemies;
    
    private float difficulty_rate = 0.5f;
    public float bonousspeed =0;
    public float bonouslife =0;
    public float bulletrate=0;

    public int trackingscore = 0;
    private int difficulty = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static logicmanager instance;
    [SerializeField] private TMP_Text scoretext;
    public int Score;
    [SerializeField]private TMP_Text HIGHscore;
    [SerializeField] private TMP_Text Finalscore;
    

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

            difficulty = 3;
            increasing_difficulty();
        }
        if (trackingscore > 300 && difficulty == 3)
        {
            difficulty = 4;
            increasing_difficulty();
        }
        if (trackingscore > 400 && difficulty == 4)
        {
            difficulty = 5;
            increasing_difficulty();
        }
        if (trackingscore > 500 && difficulty == 5 && boss.activeSelf == false)
        {


            difficulty = 1;
            trackingscore = 0;


            boss.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                enemies[i].SetActive(false);
            }

        }
    }
    







    private void increasing_difficulty()
    {
        spwaner.spwanrate -= difficulty_rate;
        bonouslife++;
        player.movespeed += 0.5f;
        bonousspeed++;
        bulletspwaner.spwanrate -= 0.05f;
        bulletspwaner2.spwanrate -= 0.05f;
    }
    public void highscore()
    {
        if(PlayerPrefs.HasKey("SavedHighScore"))
        {
            if(Score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", Score);
        }
        PlayerPrefs.Save();

        Finalscore.text = Score.ToString();
        HIGHscore.text = PlayerPrefs.GetInt("SavedHighScore").ToString();


    }
}
