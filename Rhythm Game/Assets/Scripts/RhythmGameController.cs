using UnityEngine;

public class RhythmGameController : MonoBehaviour
{
    public CircleCollider2D point1Collider;
    public CircleCollider2D point2Collider;
    private bool scriptActive = true;
    private bool firstTriggerActivated = false;


    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the triggering object is the one that should activate the triggers
        //if (other.CompareTag("ActivationObject"))
        {
            if (!firstTriggerActivated)
            {
                point1Collider.isTrigger = true;
                Debug.Log("Point 1: Trigger activated");
                firstTriggerActivated = true;
            }
            else if (!point2Collider.isTrigger)
            {
                point2Collider.isTrigger = true;
                Debug.Log("Point 2: Trigger activated");
                scriptActive = false; // Deactivate the script after passing Point 2
                Debug.Log("Script deactivated after passing Point 2");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptActive) return; // Exit the Update loop if the script is no longer active

        // Your other game logic here
    }
}
