using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestNPC : MonoBehaviour
{
    [SerializeField] private List<QuestProfile> NpcQuestList;

    //private bool isCollision = false;
    [SerializeField] private TypeQuestNPC typeQuestNPC;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("touch NPC");
            TakeObligatoryQuest();
            TakeRandomQuest();

        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {
    //        Debug.Log("dont touch NPC");
    //        isCollision = false;
    //    }
    //}
    public void TakeObligatoryQuest()
    {
        if (typeQuestNPC == TypeQuestNPC.obligatory)
        {
            int l = NpcQuestList.Count;
            for(int i =0; i<l;i++)
            QuestManager.instance.AcceptQuest(NpcQuestList[i].QuestID);
        }
    }
    public void TakeRandomQuest()
    {
        Debug.Log("Out");
        if (typeQuestNPC == TypeQuestNPC.random)
        {
            Debug.Log("in");
            int l = NpcQuestList.Count;
            int randomNum = Random.Range(0, l-1);
            Debug.Log(randomNum);
            QuestManager.instance.AcceptQuest(NpcQuestList[randomNum].QuestID);
        }
    }
    public void TakeChooseQuest()
    {
       
    }
}
enum TypeQuestNPC
{
    random,
    choose,
    obligatory
}


