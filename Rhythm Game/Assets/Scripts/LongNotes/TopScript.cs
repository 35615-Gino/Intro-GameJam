using UnityEngine;

public class TopScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LongNote"))
        {
            LongNoteScript longNoteScript = collision.GetComponent<LongNoteScript>();
            if (longNoteScript != null)
            {
                longNoteScript.canBeReleased = true;
            }
        }
    }
}