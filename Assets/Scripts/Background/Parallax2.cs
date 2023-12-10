using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float parallaxStrength = 0.1f;
    [SerializeField] bool disableVeticalParallax;
    Vector3 targetPreviousPosition;
    public GameObject cam;
    
    void Start()
    {
        if(!followingTarget) 
            followingTarget = cam.transform;
        
        targetPreviousPosition = followingTarget.position;
    }

    void Update()
    {
        var delta = followingTarget.position - targetPreviousPosition;

        if(disableVeticalParallax) {delta.y = 0;}

        targetPreviousPosition = followingTarget.position;

        transform.position += delta * parallaxStrength;
    }
}
