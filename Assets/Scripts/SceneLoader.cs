using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  #region MonoBehaviour

  void Update ()
  {
    if ( Input.GetKeyDown(KeyCode.Alpha1) )
    {
      SceneManager.LoadScene("3a – Swapper");
    }
    else if ( Input.GetKeyDown(KeyCode.Alpha2) )
    {
      SceneManager.LoadScene("3b – Skinner");
    }
    else if ( Input.GetKeyDown(KeyCode.Alpha3) )
    {
      SceneManager.LoadScene("3c – Mixer");
    }
  }

  #endregion
}