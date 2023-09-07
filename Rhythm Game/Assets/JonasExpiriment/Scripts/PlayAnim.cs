using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public GameObject anim;

    private void Start()
    {
        DotHit dotHit = FindObjectOfType<DotHit>();
        dotHit.OnCanHit += PlayAnimation;
    }

    private void PlayAnimation()
    {
        anim.GetComponent<Animator>().Play("dotfxnew");
        Debug.Log("anim played");
    }
}
