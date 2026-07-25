using UnityEngine;

public class boss1bulletscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float movespeed = 6;
    private Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void setdirection(Vector2 dir)
    {
        direction = dir;
    }
    void Update()
    {
        transform.Translate(direction * movespeed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
   
}
