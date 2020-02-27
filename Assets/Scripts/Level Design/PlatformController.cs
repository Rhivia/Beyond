using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    enum PlatformMovement
    {
        forward,
        up,
        down
    };

    [SerializeField] PlatformMovement platformMovement;
    public bool movementEnabled = true;
    public float speed = 15;

    Vector3 scaleVector = new Vector3(1, 1, 1);
    private int direction = 1;
    // Rigidbody rb;


    /*private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }*/

    private void FixedUpdate()
    {
        if (movementEnabled)
        {
            switch (platformMovement)
            {
                case PlatformMovement.up:
                    transform.Translate(Vector3.up * speed * direction * Time.deltaTime);
                    break;
                case PlatformMovement.forward:
                    transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);
                    break;
                case PlatformMovement.down:
                    transform.Translate(Vector3.down * speed * direction * Time.deltaTime);
                    break;
                default:
                    break;
            };
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }

        if (other.gameObject.CompareTag("PlatformCollider"))
        {
            direction *= -1;
            // troca de direção aqui
            // audio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
            other.transform.localScale = scaleVector;
        }
    }
}