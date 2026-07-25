using UnityEngine;
using System.Collections;

public class boss1script : MonoBehaviour
{
    private float movespeed = 8;
    private bool ismoving = true;
    private bool isattacking = true;
    [SerializeField] private Transform TargetA;
    [SerializeField] private Transform TargetB;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform firepoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float attacking_time = 3;
    private float attacking_rate = 0.2f;
    void Start()
    {
        StartCoroutine(boss());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator boss()
    {
        while (ismoving)
        {
            //move to point 1 
            yield return StartCoroutine(moveto(TargetA));

            //wait 3 second to fire 

            yield return StartCoroutine(attack());
            // move to point 2
            yield return StartCoroutine(moveto(TargetB));
            //wait 3 second to fire at point b 
            yield return StartCoroutine(attack());
        }
    }
    private IEnumerator moveto(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.05)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
            yield return null;
        }

    }
    private IEnumerator attack()
    {
        isattacking = true;
        float timer = 0;
        while (timer < attacking_time)
        {
            shoot();
            yield return new WaitForSeconds(attacking_rate);
            timer += attacking_rate;
        }
        isattacking = false;
    }
    private void shoot()
    {
        Instantiate(bulletprefab, firepoint.position, Quaternion.identity);
    }
}
