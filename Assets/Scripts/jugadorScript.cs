using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorScript : MonoBehaviour
{
    public Transform weaponPos;
    public GameObject bulletPrefab;
    
    
    public float fuerza;

    private bool groundedPlayer;
    private CharacterController controller;
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Joystick1Button0) )
        {
            var bullet = Instantiate(bulletPrefab, weaponPos.position, Quaternion.identity);
            var rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(weaponPos.transform.forward * fuerza, ForceMode.Impulse);
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);


        // Changes the height position of the player..

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        //controller.Move(playerVelocity * Time.deltaTime);
    }
    
}
