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

        if (IsTouchingFloor() && Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(Vector3.up * jumpingForce);
        }

    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position - Vector3.up * 0.45f, 0.3f, transform.up, out hit, 1f);
        Debug.LogError(result);
        return result;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position - Vector3.up * 0.45f, 0.3f);
    }

    public void IncreaseRepelentAmount()
    {
        repelents += 1;
    }
}
