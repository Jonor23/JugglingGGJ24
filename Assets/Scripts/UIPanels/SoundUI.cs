using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI : MonoBehaviour
{

    [SerializeField]
    private AK.Wwise.Event sound = null;
    [SerializeField]
    private AK.Wwise.Event sound2 = null;
    [SerializeField]
    private AK.Wwise.Switch mySwitch;

    private void Start()
    {
        sound2.Post(this.gameObject);
    }

    public void click()
    {
        Debug.Log("test");
        sound.Post(this.gameObject);
    }

    public void swap()
    {
        Debug.Log("test");
        mySwitch.SetValue(this.gameObject);
    }
}
