using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

    public bool Pause;

    void Update()
    {

        if (Pause == true)
        {
            Pause = false;
        }

        else
        {
            Pause = true;
        }
    }
      

    public void OnPauseButtonClicked()
    {
        Pause = true;
    }

}