using UnityEngine;

public abstract class PickUp : MonoBehaviour
{   
    [SerializeField] float rotationSpeed = 100f;
    const string playerString = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(playerString))
        {
            Debug.Log("PickUPss");
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();

    
}
