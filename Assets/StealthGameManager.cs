using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class StealthGameManager : MonoBehaviour
{
    public GameObject target;
    public float viewingFieldDistance = 7;
    public float viewingFieldAngle = 30;
    public float hearingThreshold = 7f;
    Animator animator;
    private float timer = 0f;
    private float restInterval = 20f;

    private EventInstance playerFootsteps;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        // not sure 
        //playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);
        //playerFootsteps.start();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.DrawRay(transform.position,
            transform.forward * viewingFieldDistance, Color.blue);
        transform.Rotate(0, 1f, 0);

        if (IsInSight() || IsHeard())
        {
            animator.SetBool("visible", true);
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.guardNoticing, this.transform.position);
        }
        else
        {
            animator.SetBool("visible", false);
        }
        if (IsRest())
        {
            animator.SetBool("resting", true);
            //playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
        else
        {
            animator.SetBool("resting", false);
            //PLAYBACK_STATE playbackState;
            //playerFootsteps.getPlaybackState(out playbackState);
            //if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            //{
            //    playerFootsteps.start();
            //}
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

    public bool IsHeard()
    {
        float hearingDistance=Vector3.Distance(transform.position, target.transform.position);
        return (hearingDistance < hearingThreshold);
    }

}
