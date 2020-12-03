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

  [SerializeField]
  private Sprite customHead = default;

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

  public void InjectCustom ()
  {
    // Duplicate bones and poses
    string referenceLabel = targetResolver.GetLabel();
    Sprite referenceHead =
      spriteLibrary.GetSprite(targetCategory, referenceLabel);
    SpriteBone[] bones = referenceHead.GetBones();
    NativeArray<Matrix4x4> poses = referenceHead.GetBindPoses();
    customHead.SetBones(bones);
    customHead.SetBindPoses(poses);

    // Inject new sprite
    const string newLabel = "customHead";
    spriteLibrary.AddOverride(customHead, targetCategory, newLabel);
    targetResolver.SetCategoryAndLabel(targetCategory, newLabel);
  }

  #endregion
}