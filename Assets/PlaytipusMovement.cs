using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaytipusMovement : MonoBehaviour
{
    private static PlaytipusMovement instance;

    [SerializeField] private Rigidbody rb;
    private float moveSpeed = 5;
    private float punchingForce = 1000;
    private float jumpingForce = 600;
    private int repelents = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static PlaytipusMovement GetInstance()
    {
        return instance;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hitResult;
            bool hit = Physics.Raycast(transform.position, transform.forward, out hitResult, 3f);
            if (hit && hitResult.rigidbody != null)
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
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.75f, -transform.up, out hit, 1f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.75f);
    }

    public void IncreaseRepelentAmount()
    {
        repelents += 1;
    }
}
