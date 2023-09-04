
using UnityEngine;
using UnityEngine.InputSystem;

public class DragBehaviour : MonoBehaviour
{
    private PlayerInput playerInput;

    [SerializeField] private GameObject player;
     
    private InputAction downEvent;
    private InputAction positionEvent;

    

    private Camera mainCamera;
    private Vector3 initialTouchPosition;
    private Vector3 initialObjectPosition;
    private bool isDragging = false;
    

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        downEvent = playerInput.actions["TouchPress"];
        positionEvent = playerInput.actions["TouchPosition"];
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        downEvent.started += OnTouchStart;
        downEvent.canceled += OnTouchEnd;

    }

    private void OnDisable()
    {
        downEvent.started -= OnTouchStart;
        downEvent.canceled -= OnTouchEnd;
    }
    

    private void OnTouchStart(InputAction.CallbackContext context)
    {
        if (isDragging) return;

        initialTouchPosition = positionEvent.ReadValue<Vector2>();
        initialObjectPosition = player.transform.position;
        isDragging = true;
    }

    private void OnTouchEnd(InputAction.CallbackContext context)
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(positionEvent.ReadValue<Vector2>());
            Vector3 touchDelta = touchPosition - mainCamera.ScreenToWorldPoint(initialTouchPosition);
            player.transform.position = new Vector3(initialObjectPosition.x + touchDelta.x, player.transform.position.y,
                player.transform.position.z);
        }
    }
}


