using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private GameObject bulletspwaner;
    public float movespeed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButton(0))
        {
            bulletspwaner.SetActive(true);
            // physical mouse cursor moniter  ko kun thau ma xa vanera capture garxa (pixel ma calculate hunxa)
            Vector3 mousescreenpos = Input.mousePosition;


            // yesle chai mouse ko pixel position lai actual game map coordinate ma convert garxa
            Vector3 mouseworldpos = Camera.main.ScreenToWorldPoint(mousescreenpos);


            mouseworldpos.z = transform.position.z;


            // this pushes or allows the object to move toeard the crusor direction 

            transform.position = Vector3.MoveTowards(transform.position, mouseworldpos, movespeed * Time.deltaTime);
        }
        else
        {
            bulletspwaner.SetActive(false);
        }
        

    }
}
