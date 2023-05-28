using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthGameManager : MonoBehaviour
{
    public GameObject target;
    public float viewingFieldDistance = 7;
    public float viewingFieldAngle = 30;
    Animator animator;
    private float timer = 0f;
    private float restInterval = 20f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.DrawRay(transform.position,
            transform.forward * viewingFieldDistance, Color.blue);
        transform.Rotate(0, 1f, 0);

        if (IsInSight())
        {
            animator.SetBool("visible", true);
        }
        else
        {
            animator.SetBool("visible", false);
        }

        if(IsRest())
        {

        }
    }

public bool IsRest()
    {
        if (timer >= restInterval)
        {
            timer = 0f;
            return true;
        }

        return false;
    }


    public bool IsInSight()
    {
        //1. Distance
        float distance = Vector3.Distance(
            transform.position,
            target.transform.position);
        if (distance > viewingFieldDistance)
        {
            return false;
        }

        //2. Angle
        Vector3 distanceVector =
            target.transform.position - transform.position;
        distanceVector.y = 0;
        float angle = Vector3.Angle(
            transform.forward,
            distanceVector);
        if (angle > viewingFieldAngle / 2)
        {
            return false;
        }        
        //3. Obstacles 
        
        RaycastHit hit;
        if (Physics.Raycast(
            transform.position,
              distanceVector.normalized,
              out hit,
              distance))
        {            
            return (hit.collider.gameObject == target);
        }        
        return false;
    }

}
