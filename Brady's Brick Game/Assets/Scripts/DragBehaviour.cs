using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragBehaviour : MonoBehaviour
{
    [SerializeField] 
    private InputAction downEvent;

    [SerializeField] 
    private float DragSpeed = .1f;

    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        downEvent.Enable();
        downEvent.performed += downPressed;
        
    }

    private void OnDisable()
    {
        downEvent.performed -= downPressed;
        downEvent.Disable();
    }

    private void downPressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }

    private IEnumerator DragUpdate(GameObject pressedObject)
    {
        float initialDistance = Vector3.Distance(pressedObject.transform.position, mainCamera.transform.position);
        while (downEvent.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            pressedObject.transform.position = Vector3.SmoothDamp(pressedObject.transform.position,
                ray.GetPoint(initialDistance), ref velocity, DragSpeed);
            yield return null;
        }

    }
}


