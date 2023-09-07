using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public string dotFXTag = "DotFX"; // Specify the tag here in the Inspector.

    public void PlayDotFXAnimation()
    {
        GameObject[] dotFXObjects = GameObject.FindGameObjectsWithTag(dotFXTag);

        // Ensure at least one object with the specified tag exists
        if (dotFXObjects.Length > 0)
        {
            foreach (GameObject dotFXObject in dotFXObjects)
            {
                Animation anim = dotFXObject.GetComponent<Animation>();

                // Play the animation by its name
                if (anim != null)
                {
                    anim.Play("DotFXAnimation");
                }
            }
        }
        else
        {
            Debug.LogWarning("No objects with tag '" + dotFXTag + "' found.");
        }
    }
}
