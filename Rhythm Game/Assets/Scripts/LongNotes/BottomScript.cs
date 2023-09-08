using UnityEngine;

public class BottomScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LongNote"))
        {
            LongNoteScript longNoteScript = collision.GetComponent<LongNoteScript>();
            if (longNoteScript != null)
            {
                longNoteScript.canBePressed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LongNote"))
        {
            LongNoteScript longNoteScript = collision.GetComponent<LongNoteScript>();
            if (longNoteScript != null)
            {
                longNoteScript.canBePressed = false;
            }
        }
    }
}