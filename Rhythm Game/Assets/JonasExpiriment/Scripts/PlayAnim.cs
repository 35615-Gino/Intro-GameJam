using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public GameObject anim;
    public DotHit dotHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dotHit.canHit)
        {
            
        }
    }
}
