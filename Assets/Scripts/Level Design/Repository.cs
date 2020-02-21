using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
/*
 *
    void MovePlayer()
    {
        // Horizontal
        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * playerSpeed;
            horizontalMovement += transform.position.x;

            transform.position = new Vector3(horizontalMovement, transform.position.y, transform.position.z);
        }

        // Depth
        if (Mathf.Abs(verticalMovement) > Mathf.Epsilon)
        {
            verticalMovement = verticalMovement * Time.deltaTime * playerSpeed;
            verticalMovement += transform.position.z;

            transform.position = new Vector3(transform.position.x, transform.position.y, verticalMovement);
        }
    }
 * 
 * 
 * 
 * 
 * 
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        // Controller por velocidade e força
        [SerializeField] float velMovimento = 5;
        float inputVertical;
        float inputHorizontal;
    
        // Character Controller
        private CharacterController controller;
        private float verticalVelocity;
        [SerializeField] float gravity;
        private float jumpForce = 10.0f;

        void Start()
        {
            controller = GetComponent<CharacterController>();

            inputVertical = Input.GetAxis("Vertical");
            inputHorizontal = Input.GetAxis("Horizontal");
        }

        void Update()
        {
            Vector3 moveVector = new Vector3(0, verticalVelocity, 0) * 5.0f;
            moveVector.x = Input.GetAxis("Horizontal") * 4.0f;
            moveVector.y = verticalVelocity;
            moveVector.z = Input.GetAxis("Vertical") * 4.0f;
            controller.Move(moveVector * Time.deltaTime);
        }

        public void SavePlayer()
        {
            SaveSystem.SavePlayer(this);
        }

        public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            // controller.transform.position.x = data.position[0];
        }
    }

 */
