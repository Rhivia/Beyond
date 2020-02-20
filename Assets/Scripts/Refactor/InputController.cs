using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool btnSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && !btnSelected)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            btnSelected = true;
        }
    }

    private void OnDisable()
    {
        btnSelected = false;
    }
}
