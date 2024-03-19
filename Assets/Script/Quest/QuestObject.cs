using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public QuestProfile questProfile;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collision QuestObject");
            QuestManager.instance.CompleteQuest(questProfile.QuestID);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {
    //        Debug.Log("Collision QuestObject");
    //        QuestManager.instance.CompleteQuest(questProfile.QuestID);
    //    }
    //}

    public bool AddReward(int itemValue)
    {
        if (questProfile == null)
        {
            Debug.Log("questProfile is Null !!!");
            return false;
        }
        switch(questProfile.QuestReward)
        {
            case QuestReward.Intelligence:
                PlayerManager.instance.playerProfile.AddIntelligence(itemValue);
                return true; 

            case QuestReward.Social:
                PlayerManager.instance.playerProfile.AddSocial(itemValue);
                return true;

            case QuestReward.Strength:
                PlayerManager.instance.playerProfile.AddStrength(itemValue);
                return true;

            case QuestReward.Knowledge:
                PlayerManager.instance.playerProfile.AddKnowledge(itemValue);
                return true;

            default:
                return false;
        }
    }



}


