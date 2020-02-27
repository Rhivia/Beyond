using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FreezableHandler(Rigidbody rb);
public class Freezable : MonoBehaviour
{
    Rigidbody rb;
    Vector3 freezeSave;

    public bool isFrozen = false;
    public bool freeze;


    void Start()
    {
        PlayerController.ObjectFreezed += Freeze;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (freeze && !isFrozen)
        {
            isFrozen = true;

            // freezed.SetBool("objFreeze", true);
            // FindObjectOfType<AudioManager>().Play("SomCongela");
            // gameObject.GetComponent<PlatformController>().enabled = false;
                
        }
        else
        {
            isFrozen = false;

            // freezed.SetBool("objFreeze", false);
            // FindObjectOfType<AudioManager>().Play("SomCongela");
            // gameObject.GetComponent<PlatformController>().enabled = true;
        }
    }

    private void Freeze(Rigidbody rb)
    {
        Debug.Log("Enable");
        // freezeSave = rb.velocity;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
    }

    private void Unfreeze()
    {
        rb.velocity = freezeSave;
        rb.constraints = RigidbodyConstraints.None;
        // rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}