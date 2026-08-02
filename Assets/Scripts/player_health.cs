using UnityEngine;

public class player_health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] heart;
    private int i = -1;
    [SerializeField] private GameObject gameover;
    public int Player_health = 3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Boss_bullet"))
            {
            Player_health--;
            heart[Player_health].SetActive(false);
            if(Player_health == 0 )
            {

                logicmanager.instance.highscore();
                gameover.SetActive(true);
                Time.timeScale = 0;

            }
            Destroy(collision.gameObject);
        }
    }
}
