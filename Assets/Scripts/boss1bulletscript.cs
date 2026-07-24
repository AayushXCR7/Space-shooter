using UnityEngine;

public class boss1bulletscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float movespeed = 8;
    void Start()
    {
        
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
}
