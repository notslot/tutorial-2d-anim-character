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

  public void Init (MixerCategory category, string[] labels)
  {
    // Set title
    titleLabel.text = category.displayTitle;

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
      category.resolver.SetCategoryAndLabel(category.name, label);
    }); 
  }

  #endregion
}