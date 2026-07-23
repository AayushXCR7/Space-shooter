using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    
    public float movespeed = 6f;
    private int point = 15;
    public float life = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life += logicmanager.instance.bonouslife;
        movespeed += logicmanager.instance.bonousspeed;
        if (life > 4)
        {
            life = 4;
        }
        if (movespeed > 7)
        {
            movespeed = 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * movespeed * Time.deltaTime);
        if (transform.position.y < -6)

        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;
           
            if (life == 0)
            {

                logicmanager.instance.updatescore(point);
                Destroy(gameObject);

        }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }



    }
    
}
