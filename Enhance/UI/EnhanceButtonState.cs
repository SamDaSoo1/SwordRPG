using UnityEngine;

public class EnhanceButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] Animator animator;

    public void Pointer_Down()
    {
        animator.SetTrigger("Pressed");
    }

    public void Pointer_Up()
    {
        animator.SetTrigger("Normal");
    }

    public void Pointer_Enter() { }
    public void Pointer_Exit() { }
    public void Pointer_Click() { }
}
