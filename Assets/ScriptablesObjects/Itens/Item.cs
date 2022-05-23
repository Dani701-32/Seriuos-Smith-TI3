using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public string ItemName = "New Item";
    public Sprite icon = null;
    public QuestGoalType goalType;
    public MaterialType materialType;
    public States statesTypes;
    public TrabState trabState; 
    public int minBatidas;
    public int limiteBatidas;

    public float temperatura = 25; //em graus
    public float temperaturaQuente;
    public float temperaturaQueimado;

    void FixedUpdate()
    {
        /*if(statesTypes == States.Quente&& temperatura > 25) // quando estiver fora da fornalha ela esfriar
        {
            temperatura  = temperatura -1 * Time.fixedDeltaTime;
        }
        */
    }
}
