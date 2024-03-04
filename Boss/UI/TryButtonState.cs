using UnityEngine;
using UnityEngine.SceneManagement;

interface IPointerState
{
    void Pointer_Enter();
    void Pointer_Exit();
    void Pointer_Down();
    void Pointer_Up();
    void Pointer_Click();
}

public class TryButtonState : MonoBehaviour, IPointerState
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

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        IsChangeObject.EnterBoss = true;
        SceneManager.LoadScene("Play");
    }

    public void Pointer_Enter() { }

    public void Pointer_Exit() { }
}
