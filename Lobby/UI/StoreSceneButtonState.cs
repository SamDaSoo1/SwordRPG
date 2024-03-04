using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoreSceneButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] Image animator;

    public void Pointer_Enter()
    {
        SoundManager.instance.PlaySFX(eSound.ButtonMouseOver);
    }

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        SceneManager.LoadScene("Store");
    }

    public void Pointer_Exit() { }

    public void Pointer_Down() { }

    public void Pointer_Up() { }
}
