using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUpdateMainUI : MonoBehaviour
{
    [Header("Quest Info")]
    [SerializeField] private TMP_Text questTitleText;
    [SerializeField] private TMP_Text questDescriptionText;
    [SerializeField] private TMP_Text questSummaryText;
    [SerializeField] private TMP_Text questPointText;

    public void UpdateQuestInfo(QuestProfile questProfile)
    {
        questTitleText.text = questProfile.QuestTitle;
        questDescriptionText.text = questProfile.QuestDescription;
        questSummaryText.text = "Cách thực hiện nhiệm vụ: "+questProfile.QuestSummary;
        questPointText.text = "Điểm nhận được: " + questProfile.QuestPoint.ToString();
    }
}
    