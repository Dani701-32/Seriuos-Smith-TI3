using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public string ItemName = "New Item";
    public Sprite icon = null;
    public QuestGoalType goalType;
    public MaterialType materialType;
}
