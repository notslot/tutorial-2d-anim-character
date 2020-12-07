using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;

public class Replacer : MonoBehaviour
{
  #region Inspector

  [SerializeField]
  private SpriteLibrary spriteLibrary = default;

  [SerializeField]
  private SpriteResolver targetResolver = default;

  [SerializeField]
  private string targetCategory = default;

  #endregion


  #region Properties

  private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

  #endregion


  #region Methods

  public void SelectRandom ()
  {
    string[] labels =
      LibraryAsset.GetCategoryLabelNames(targetCategory).ToArray();
    int index = Random.Range(0, labels.Length);
    string label = labels[index];

    targetResolver.SetCategoryAndLabel(targetCategory, label);
  }

  public void InjectCustom (Sprite customSprite)
  {
    // Duplicate bones and poses
    string referenceLabel = targetResolver.GetLabel();
    Sprite referenceHead =
      spriteLibrary.GetSprite(targetCategory, referenceLabel);
    SpriteBone[] bones = referenceHead.GetBones();
    NativeArray<Matrix4x4> poses = referenceHead.GetBindPoses();
    customSprite.SetBones(bones);
    customSprite.SetBindPoses(poses);

    // Inject new sprite
    const string customLabel = "customHead";
    spriteLibrary.AddOverride(customSprite, targetCategory, customLabel);
    targetResolver.SetCategoryAndLabel(targetCategory, customLabel);
  }

  #endregion
}