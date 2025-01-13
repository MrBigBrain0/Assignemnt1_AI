using UnityEngine;


[RequireComponent(typeof(Animator))]
public class CompactorController : MonoBehaviour
{
    private Animator animator;
    private readonly int isOnAnimHash = Animator.StringToHash("IsOn");

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TurnOn()
    {
        animator.SetBool(isOnAnimHash, true);
    }

    public void TurnOff()
    {
        animator.SetBool(isOnAnimHash, false);
    }
}
