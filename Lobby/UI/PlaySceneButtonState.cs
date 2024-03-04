using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] Animator animator;

    public void Pointer_Enter()
    {
        SoundManager.instance.PlaySFX(eSound.PlayButtonMouseOver);
    }

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);

        IsChangeObject.EnterBoss = false;
        SceneManager.LoadScene("Play");
    }

    public void Pointer_Exit() { }
    public void Pointer_Down() { }
    public void Pointer_Up() { }
}
