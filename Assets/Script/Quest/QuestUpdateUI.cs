using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestUpdateUI : MonoBehaviour
{

    [Header("Quest Info")]
    [SerializeField] private TMP_Text questTitleText;
    [SerializeField] private TMP_Text questDescriptionText;

    public void UpdateQuestInfo(QuestProfile questProfile)
    {
        if (questTitleText == null)
        {
            questTitleText.text = null;
            questDescriptionText.text = null;
        }

        questTitleText.text = questProfile.QuestTitle;
        questDescriptionText.text = questProfile.QuestDescription;
    }

}
