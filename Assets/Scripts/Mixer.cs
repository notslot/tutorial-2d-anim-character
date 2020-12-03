using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Mixer : MonoBehaviour
{
  #region Inspector

  [SerializeField]
  private SpriteLibrary spriteLibrary = default;

  [SerializeField]
  private MixerSelector selectorTemplate = default;

  [SerializeField]
  private MixerOption[] options = default;

  #endregion


  #region Properties

  private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

  #endregion


  #region MonoBehaviour

  private void Start ()
  {
    foreach ( MixerOption option in options )
      AddItem(option);
  }

  #endregion


  #region Methods

  private void AddItem (MixerOption option)
  {
    string[] labels =
      LibraryAsset.GetCategoryLabelNames(option.category).ToArray();

    // Create new item & add it to the sidebar
    MixerSelector item = Instantiate(selectorTemplate, transform);
    
    // Initialize the item with options
    item.Init(option, labels);
  }

  #endregion
}