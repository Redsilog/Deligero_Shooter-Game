using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{  
    public GameObject bulletPreFab;
    public Transform bulletSpawnPoint;
    public Rigidbody2D rigidBody;
    public Animator anim;
    private Vector2 movementInput;
    public float bulletSpeed;
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rigidbody = Bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = transform.up * bulletSpeed;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}