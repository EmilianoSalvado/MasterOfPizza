using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] LayerMask _interactablesLM;
    RaycastHit _hit;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out _hit, 999f, _interactablesLM))
            { Debug.Log("nuh-uh"); return; }

            _hit.collider.GetComponent<Interactable>().Interact();
        }
    }
}
