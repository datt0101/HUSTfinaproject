using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfile : ScriptableObject
{
    [SerializeField] private int playerID; 
    [SerializeField] private string playerLevel; // Cap do cua nguoi choi
    [SerializeField] private string playerName;
    [SerializeField] private int playerStrength, playerIntelligence, playerSocial, playerKnowledge;// chi so 

    public int PlayerID { get => playerID; set => playerID = value; }
    public string PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public string PlayerName { get => playerName; set => playerName = value; }
    public int PlayerStrength { get => playerStrength; set => playerStrength = value; }
    public int PlayerIntelligence { get => playerIntelligence; set => playerIntelligence = value; }
    public int PlayerSocial { get => playerSocial; set => playerSocial = value; }
    public int PlayerKnowledge { get => playerKnowledge; set => playerKnowledge = value; }

    
    public void AddStrength(int value)
    {
        Debug.Log("Add Strength");
        playerStrength += value;
    }
    public void AddIntelligence(int value)
    {
        Debug.Log("Add Intelligence");
        playerIntelligence += value;
    }
    public void AddSocial(int value)
    {
        Debug.Log("Add Social");
        playerSocial += value;
    }
    public void AddKnowledge(int value)
    {
        Debug.Log("Add Knowledge");
        playerKnowledge += value;
    }
}

