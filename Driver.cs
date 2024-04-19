using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using Alteruna;

public class Driver : MonoBehaviour
{
    private Camera cam; // Camera variable to hold a reference to our camera
    private Alteruna.Avatar _avatar;
    public GameObject deathCamera;

    [SerializeField] float SteerSpeed = 200.1f;
    [SerializeField] float moveSpeed = 25.1f;
    [SerializeField] float slowSpeed = 10.1f;
    [SerializeField] float boostSpeed = 32.1f;
    [SerializeField] private InputActionReference moveActionToUse;
    float normalSpeed = 25.1f;
    [SerializeField] public Text Turbo;
    // Start is called before the first frame update
    void Start()
    {
        deathCamera.SetActive(false);

        _avatar = GetComponent<Alteruna.Avatar>();
        if (!_avatar.IsMe)
            return;
        {
            Debug.LogError("No Avatar component found on this object");
        }
        cam = Camera.main; // Assign the main camera
        Turbo.text = "TURBO OFF";
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("relenting speed");
        moveSpeed = slowSpeed;
        Turbo.text = "TURBO OFF";
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("Boosting speed");
            moveSpeed = boostSpeed;
            Turbo.text = "TURBO ON";

        }

        /*if (other.tag == "Road"){
            Debug.Log("normal speed");
            moveSpeed = normalSpeed;
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (!_avatar.IsMe)
            return;

        float steer = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;
        float move1 = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steer1 = moveActionToUse.action.ReadValue<Vector2>().x * SteerSpeed * Time.deltaTime;
        float moveY = moveActionToUse.action.ReadValue<Vector2>().y * moveSpeed * Time.deltaTime;




        //float move = Input.GetAxis("Fire1") * moveSpeed * Time.deltaTime;
        //float move2 = Input.GetAxis("Fire2") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steer);
        //transform.Translate(0, move, 0);
        //transform.Translate(0, -move2, 0);
        transform.Translate(0, move1, 0);
        transform.Translate(0, moveY, 0);
        transform.Rotate(0, 0, -steer1);




    }
}


