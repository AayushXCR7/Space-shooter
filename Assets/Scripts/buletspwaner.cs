using Unity.VisualScripting;
using UnityEngine;

public class buletspwaner : MonoBehaviour
{
    [SerializeField] private GameObject bulletprefab;
    public double spwanrate = 0.5f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spwanrate -= logicmanager.instance.bulletrate;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<spwanrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            bulletspwan();
            timer = 0;

        }
    }
    public void bulletspwan()
    {
        Instantiate(bulletprefab, transform.position, Quaternion.identity);
    }
}
