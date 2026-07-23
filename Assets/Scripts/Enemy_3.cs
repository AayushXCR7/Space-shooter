using System.Drawing;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    
    public float movespeed = 7f;
    private int point = 20;
    
    public float life = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life += logicmanager.instance.bonouslife;
        movespeed += logicmanager.instance.bonousspeed;
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
            
            if (life==0)
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
;


    }
   
}
