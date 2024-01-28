using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI : MonoBehaviour
{

    [SerializeField]
    private AK.Wwise.Event sound = null;

    public void click()
    {
        sound.Post(this.gameObject);
    }
}
