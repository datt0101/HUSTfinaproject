using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<QuestObject> questList;
    public List<QuestObject> currentQuestList;
    public QuestUpdateUI questUpdateUI;
    public QuestUpdateMainUI questUpdateMainUI;
    public GameObject questMenu;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        UpdateQuestAccepted();
    }

    public void ActiveQuestMenu()
    {
        questMenu.SetActive(true);
    }
    public void ExitQuestMenu()
    {
        questMenu.SetActive(false);
    }

    public void UpdateQuestAccepted() // update lai nhung nhiem vu da nhan
    {
        int l = questList.Count;
        for (int i = 0; i < l; i++)
        { 
            if (questList[i].questProfile.QuestProgress == QuestProgress.Accepted)
            {
                currentQuestList.Add(questList[i]);
                
            }
        }
        Debug.Log(l);
        if (currentQuestList.Count >0)
        {
            questUpdateUI.UpdateQuestInfo(currentQuestList[0].questProfile);
            questUpdateMainUI.UpdateQuestInfo(currentQuestList[0].questProfile);
        }
    }
    public void AcceptQuest(int questID)
    {
        int l = questList.Count;
        for (int i = 0; i < l; i++)
        {
            if (questList[i].questProfile.QuestID == questID && questList[i].questProfile.QuestProgress == QuestProgress.Available)
            {
                Debug.Log("AcceptQuest");
                currentQuestList.Add(questList[i]);
                questList[i].questProfile.QuestProgress = QuestProgress.Accepted;
                questUpdateUI.UpdateQuestInfo(currentQuestList[0].questProfile);
                questUpdateMainUI.UpdateQuestInfo(currentQuestList[0].questProfile);
            }
        }
    }
    public void GiveUpQuest(int questID)
    {
        // bo nv ra khoi danh sach hien tai
        int l = currentQuestList.Count;
        for (int i = 0; i < l; i++)
        {
            if (currentQuestList[i].questProfile.QuestID == questID && currentQuestList[i].questProfile.QuestProgress == QuestProgress.Accepted)
            {
                Debug.Log("GiveUpQuest");
                currentQuestList[i].questProfile.QuestProgress = QuestProgress.Available;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
        // tra nv ve danh sach cac nv
        l = questList.Count;
        for (int i = 0; i < l; i++)
        {
            if (questList[i].questProfile.QuestID == questID)
            {
                questList[i].questProfile.QuestProgress = QuestProgress.Available;
            }
        }
    }

    public void CompleteQuest(int questID)
    {
        int l = currentQuestList.Count;
        for (int i = 0; i < l; i++)
        {
            if (currentQuestList[i].questProfile.QuestID == questID && currentQuestList[i].questProfile.QuestProgress == QuestProgress.Accepted)
            {
                Debug.Log("CompleteQuest: " + i);
                currentQuestList[i].questProfile.QuestProgress = QuestProgress.Complete;
                currentQuestList[i].AddReward(currentQuestList[i].questProfile.QuestPoint);
                currentQuestList.Remove(currentQuestList[i]);
                break; 
                
            }
        }
        if (currentQuestList.Count > 0)
        {
            questUpdateUI.UpdateQuestInfo(currentQuestList[0].questProfile);
            questUpdateMainUI.UpdateQuestInfo(currentQuestList[0].questProfile);
        }
    }
}

