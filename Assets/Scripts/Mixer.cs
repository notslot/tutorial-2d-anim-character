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
  private MixerCategory[] categories = default;

  #endregion


  #region Properties

  private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

  #endregion


  #region MonoBehaviour

  private void Start ()
  {
    foreach ( MixerCategory category in categories )
      AddUISelector(category);
  }

  #endregion


  #region Methods

  private void AddUISelector (MixerCategory category)
  {
    string[] labels = LibraryAsset.GetCategoryLabelNames(category.name)
                                  .ToArray();

    // Create new item & add it to the sidebar
    MixerSelector item = Instantiate(selectorTemplate, transform);

    // Initialize the item with options
    item.Init(category, labels);
  }

  #endregion
}