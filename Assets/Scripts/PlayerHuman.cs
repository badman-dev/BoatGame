using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;

    float mouseSensitivity = 600f;

    float maxInteractDistance = 10f;

    public float throwStrength = 8;

    public PlayerInventory inventory;

    GameObject heldObject;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotation.x += -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxInteractDistance))
            {
                if (heldObject != null)
                {
                    if (hit.collider.transform.gameObject.GetComponent<InventorySlot>())
                    {
                        heldObject.GetComponent<InventoryItem>().Putdown();
                        inventory.InventoryAdd(heldObject, hit.collider.transform.gameObject.GetComponent<InventorySlot>());
                        heldObject.GetComponent<Collider>().enabled = true;
                        heldObject = null;
                    }

                    //throw code
                    else if (hit.transform.gameObject.tag != "Player" && heldObject.GetComponent<InventoryItem>().throwable)
                    {
                        ThrowItem(heldObject);
                    }
                }
                else if (hit.collider.transform.gameObject.GetComponent<InventoryItem>())
                {
                    inventory.InventoryRemove(hit.collider.transform.gameObject);

                    heldObject = hit.collider.transform.gameObject;
                    heldObject.GetComponent<InventoryItem>().Pickup();

                    heldObject.transform.parent = transform;
                    heldObject.transform.localPosition = new Vector3(0, -0.3f, 0.6f);

                    Destroy(heldObject.GetComponent<Rigidbody>());

                    heldObject.GetComponent<Collider>().enabled = false;

                }
            }
            else if (heldObject != null)
            {
                ThrowItem(heldObject);
            }
        }
    }

    void LateUpdate()
    {
        transform.localRotation = Quaternion.Euler(rotation);
    }

    void ThrowItem(GameObject item)
    {
        item.transform.parent = null;

        Rigidbody rb = item.AddComponent<Rigidbody>() as Rigidbody;

        Vector3 cameraDir = GetComponentInChildren<Camera>().transform.forward;
        Debug.Log(cameraDir);
        rb.AddForce(cameraDir * throwStrength * 100);

        heldObject.GetComponent<Collider>().enabled = true;

        heldObject = null;
    }
}
