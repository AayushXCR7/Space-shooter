using UnityEngine;

public class bullet : MonoBehaviour
{
    public float movespeed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movespeed += logicmanager.instance.bonousspeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * movespeed * Time.deltaTime);
        if(transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
