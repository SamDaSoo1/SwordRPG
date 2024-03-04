using UnityEngine;

public class EnhanceCompleteButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] GameObject EnhanceCompleteButton;
    Animator animator;
    RectTransform rt;
    Vector3 ScaleSave;

    private void Start()
    {
        animator = EnhanceCompleteButton.GetComponent<Animator>();
        rt = EnhanceCompleteButton.GetComponent<RectTransform>();
        ScaleSave = rt.localScale;
    }

    public void Pointer_Down()
    {
        animator.SetTrigger("Pressed");
    }

    public void Pointer_Up()
    {
        animator.SetTrigger("Normal");
    }

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        rt.localScale = ScaleSave;
    }

    public void Pointer_Enter() { }
    public void Pointer_Exit() { }
}
