using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    
    public static Inventory instance;

    void Awake()
    {
        if(instance!= null)
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
    public bool Add (Item item) // Adiciona um novo item ao inventario
    {
        if(items.Count >= space)
        {
            Debug.Log("Inventario Cheio");
            return false;
        }

        items.Add(item);

        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke(); // quando tem alguma modificação na UI chama essa função pra redefinir a UI
        }
        return true;
    }

    public void Remove (Item item) // Remove um item do inventario
    {
        items.Remove(item);

        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke(); // quando tem alguma modificação na UI chama essa função pra redefinir a UI
        }
    }
}
