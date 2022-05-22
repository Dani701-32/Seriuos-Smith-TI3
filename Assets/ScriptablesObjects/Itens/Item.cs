using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public string ItemName = "New Item";
    public Sprite icon = null;

    public virtual void UseItem()   // Script feito para usar o item, tanto pra usar dentro da forja ou fora.
    {
        // Usar o item para craftar algo
        Debug.Log("Usando" + name);
    }
    

    public enum ItemType
    {
        Madeira , Ferro 
    }
}
