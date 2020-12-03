using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixerSelector : MonoBehaviour
{
  #region Inspector

  [SerializeField]
  private Text titleLabel;

  [SerializeField]
  private Dropdown dropdown;

  #endregion


  #region Methods

  public void Init (MixerOption option, string[] labels)
  {
    // Set title
    titleLabel.text = option.displayTitle;

    // Populate dropdown
    List<Dropdown.OptionData> spriteLabels = new List<Dropdown.OptionData>();
    foreach ( string label in labels )
    {
      Dropdown.OptionData data = new Dropdown.OptionData(label);
      spriteLabels.Add(data);
    }

    dropdown.options = spriteLabels;

    // Handle change
    dropdown.onValueChanged.AddListener(optionIndex =>
    {
      string label = labels[optionIndex];
      option.resolver.SetCategoryAndLabel(option.category, label);
    });
  }

  #endregion
}