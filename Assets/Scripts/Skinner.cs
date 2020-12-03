using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Skinner : MonoBehaviour
{
  #region Inspector

  [SerializeField]
  private SpriteLibrary spriteLibrary = default;

  #endregion


  #region Methods

  public void Replace (SpriteLibraryAsset collection)
  {
    spriteLibrary.spriteLibraryAsset = collection;
  }

  #endregion
}