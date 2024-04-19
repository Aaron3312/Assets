using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
//get player position from drover.cs
    

    //this thing position should be the same as the car
    void Update()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-150);

    }
}
