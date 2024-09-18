using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaytipusMovement : MonoBehaviour
{
    private static PlaytipusMovement instance;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] public Color bodyColor;
    [SerializeField] public MeshRenderer meshRenderer;
    private float moveSpeed = 5;
    private float rotateSpeed = 50;
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
        transform.Translate(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(transform.up * Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        bool ImWalking = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;
        animator.SetBool("IsWalking", ImWalking);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hitResult;
            bool hit = Physics.Raycast(transform.position, transform.forward, out hitResult, 3f);
            if (hit && hitResult.rigidbody != null)
            {
                if (repelents <= 0)
                {
                    hitResult.rigidbody.AddForce(transform.forward * punchingForce);
                    if (hitResult.rigidbody.GetComponent<HealthBarPig>() != null)
                    {
                        hitResult.rigidbody.GetComponent<HealthBarPig>().GetHit();
                    }
                }
                else
                {
                    repelents -= 0;
                    Destroy(hitResult.rigidbody.gameObject);
                }
            }
        }

        MarkWeakestPig();
    }

    private void MarkWeakestPig()
    {
        float minHealth = 500;
        HealthBarPig weakestPig = null;

        HealthBarPig[] pigs = GameObject.FindObjectsByType<HealthBarPig>(FindObjectsSortMode.None);
        foreach (HealthBarPig pig in pigs)
        {
            if (pig.GetHealth() <= minHealth)
            {
                weakestPig = pig;
                minHealth = pig.GetHealth();
            }
        }

        foreach (HealthBarPig pig in pigs)
        {
            pig.ToggleMarker(pig == weakestPig);
        }
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
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
