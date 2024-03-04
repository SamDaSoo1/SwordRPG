using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossSceneButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] Image animator;

    public void Pointer_Enter()
    {
        SoundManager.instance.PlaySFX(eSound.ButtonMouseOver);
    }

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        SceneManager.LoadScene("Boss");
    }

    public void Pointer_Exit() { }

    public void Pointer_Down() { }

    public void Pointer_Up() { }
}
