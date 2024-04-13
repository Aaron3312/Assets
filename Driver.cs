using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float SteerSpeed = 200.1f;
    [SerializeField] float moveSpeed = 25.1f;
    [SerializeField] float slowSpeed = 10.1f;
    [SerializeField] float boostSpeed = 32.1f;
    float normalSpeed = 25.1f;
    // Start is called before the first frame update
    void Start()
    {

    }
      void OnCollisionEnter2D(Collision2D other){
        Debug.Log("relenting speed");
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Boost"){
            Debug.Log("Boosting speed");
            moveSpeed = boostSpeed;
        }
        /*if (other.tag == "Road"){
            Debug.Log("normal speed");
            moveSpeed = normalSpeed;
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        float steer = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;
        //float move1 = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //necesito controlarl el move con los gatillos del control de xbox como hago eso?
        float move = Input.GetAxis("Fire1") * moveSpeed * Time.deltaTime;
        float move2 = Input.GetAxis("Fire2") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steer);
        transform.Translate(0, move, 0);
        transform.Translate(0, -move2, 0);
        //transform.Translate(0, move1, 0);


    }
}
