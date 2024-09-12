using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaytipusMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float moveSpeed = 5;
    private float punchingForce = 1000;
    private float jumpingForce = 600;
    private int repelents = 0;
    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hitResult;
            bool hit = Physics.Raycast(transform.position, transform.forward, out hitResult, 3f);
            if (hit)
            {
                if (repelents <= 0)
                {
                    hitResult.rigidbody.AddForce(transform.forward * punchingForce);
                }
                else
                {
                    repelents -= 0;
                    Destroy(hitResult.rigidbody.gameObject);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && IsTouchingFloor() == true)
        {
            rb.AddForce(Vector3.up * jumpingForce);
        }

    }

    private bool IsTouchingFloor()
    {
        Vector3 position = transform.position + Vector3.down * 0.5f;
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.5f, -transform.up, out hit, 1f);
    }

    public void IncreaseRepelentAmount()
    {
        repelents += 1;
    }
}
