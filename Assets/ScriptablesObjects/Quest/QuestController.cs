using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests" , menuName = "New Quests")]
public class QuestCoontroller : ScriptableObject
{
    
    public float money = 0f;
    public Quest[] quest; // caso precisar de mais pedidos substituir isso por um Array
}
