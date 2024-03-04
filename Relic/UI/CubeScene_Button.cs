using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeScene_Button : MonoBehaviour, IPointerState
{
    [SerializeField] Animator animator;
    [SerializeField] Confirm_Acquisition ca;

    public bool IsLock {  get; set; }

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

        if (IsLock) { return; }

        if (!ca.Notification_text()) 
        {
            SceneManager.LoadScene("Cube");
        }
    }

    public void Pointer_Enter() { }
    public void Pointer_Exit() { }
}
