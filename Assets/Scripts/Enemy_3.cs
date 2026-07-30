using System.Drawing;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    private Animator animator;
    public float movespeed = 7f;
    private int point = 20;
    
    public float life = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        life += logicmanager.instance.bonouslife;
        movespeed += logicmanager.instance.bonousspeed;
        if(life > 6)
        {
            life = 6;
        }
        if(movespeed>10)
        {
            movespeed = 10;
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
            
            if (life==0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                enabled = false;
                animator.Play("blast3");
                Destroy(gameObject, 0.7f);
                logicmanager.instance.updatescore(point);
                

            }
            else
            {
                animator.Play("Enemy3");
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
