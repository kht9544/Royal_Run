using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;

    [SerializeField]float moveSpeed = 5f;
    [SerializeField]float xClamp = 3f;
    [SerializeField]float zClamp = 2f;

    void Awake()
    {
       rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        Debug.Log(movement);
    }

    void HandleMovement()
    {
        Vector3 currentPoisition = rb.position;
        Vector3 moveDirction = new Vector3(movement.x, 0, movement.y);
        Vector3 newPoisition = currentPoisition + moveDirction * moveSpeed * Time.fixedDeltaTime;

        newPoisition.x = Mathf.Clamp(newPoisition.x, -xClamp, xClamp);
        newPoisition.z = Mathf.Clamp(newPoisition.z, -zClamp, zClamp);

        rb.MovePosition(newPoisition);
    }

}
