using UnityEngine;

public class BugRepelent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlaytipusMovement playtipus = other.gameObject.GetComponent<PlaytipusMovement>();
        if (playtipus != null)
        {
            playtipus.IncreaseRepelentAmount();
            Destroy(gameObject);
        }
    }
}
