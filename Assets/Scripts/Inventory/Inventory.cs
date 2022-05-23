using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    [SerializeField] private PlayerHolderQuest playerHolder;
    public static Inventory instance;

    void Awake()
    {
        playerHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHolderQuest>();
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    //delegate servem pra podoer chamar mais de uma função com uma variavel so.
    public delegate void OnItemChanged(); // pra poder saber quando o inventario mudou ou nao na UI

    public OnItemChanged onItemChangedCallBack;

    public List<Item> items = new List<Item>();

    public int space = 20;
    public bool Add(Item item) // Adiciona um novo item ao inventario
    {
        if (items.Count >= space)
        {
            Debug.Log("Inventario Cheio");
            return false;
        }

        items.Add(item);
        CheckQuest(item);


        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke(); // quando tem alguma modificação na UI chama essa função pra redefinir a UI
        }
        return true;
    }
    private void CheckQuest(Item item)
    {
        if (!playerHolder.HasQuest()) return; //Quando n tiver quest retorna; 
        playerHolder.AdvanceQuest(item);
    }

    public void CheckQuest()
    {
        foreach (Item item in items)
        {
            playerHolder.AdvanceQuest(item);
        }
    }

    public void Remove(Item item) // Remove um item do inventario
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke(); // quando tem alguma modificação na UI chama essa função pra redefinir a UI
        }
    }

    public void Remove(MaterialType type, int amout, QuestGoalType typeGoal)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].materialType == type && amout > 0 && items[i].goalType == typeGoal)
            {
                items.Remove(items[i]);
                amout--;

                if (amout == 0) break;
            }
        }
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke(); // quando tem alguma modificação na UI chama essa função pra redefinir a UI
        }
    }
}
