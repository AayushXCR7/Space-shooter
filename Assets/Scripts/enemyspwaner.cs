using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class enemyspwaner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    public float spwanrate = 2f;
    private bool couldspwan = true;
    private float minx = -8.5f;
    private float maxx = 9.4f;
    private float xposition;
    private Vector3 spwanposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spwaner());
    }

    // Update is called once per frame
   private  void Update()
    {
        xposition = Random.Range(minx, maxx);
        spwanposition = new Vector3(xposition, transform.position.y , 0f);
      
    }
    private IEnumerator spwaner ()
    {
        WaitForSeconds wait = new WaitForSeconds(spwanrate);
        while(couldspwan)
        {
            yield return wait;
            int random = Random.Range(0, enemies.Length);
            
            enemmiesspwan(random);

        }
    }
    public void enemmiesspwan(int random)
    {
        GameObject enemytospwan = enemies[random];
        Instantiate(enemytospwan, spwanposition, Quaternion.identity);
    }

}
