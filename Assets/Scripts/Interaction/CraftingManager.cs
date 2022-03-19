using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingManager : MonoBehaviour
{
    private Item currentItem; // Item atual
    public Image customCursor; // GameObject que fica no mouse

    public Slot[] craftingSlots; // array que armazena todos os itens craftaveis

    public List<Item> itemList; //Lista para ser preenchida com os itens
    public string [] recipes; // array de string com os nomes das receitas
    public Item[] recipesResults; // resultado das receitas (obs: deve colocar no inspector a mesma ordem das receitas)
    public Slot resultsSlots; 

    void Update()
    {
        if(Input.GetMouseButtonUp(0)) // checa se soltou o item
        {
            if(currentItem != null) // checa se vc esta dando drag no objeto
            {
                customCursor.gameObject.SetActive(false); // desativa o cursor 
                Slot nearestSlot = null; // Essa variavel serve para verificar onde foi deixado o item, o slot mais perto no caso.
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in craftingSlots)
                {
                    float distance = Vector2.Distance(Input.mousePosition,slot.transform.position); // checa  se a distancia do objeto e menor que distancia mais perto
                    if(distance < shortestDistance) 
                    {
                        shortestDistance = distance; // transforma a menor distancia na distancia atual
                        nearestSlot = slot; // transforma o slot mais perto no slot atual
                    }
                }
                nearestSlot.gameObject.SetActive(true); // ativa o slot mais perto
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite; // transforma a imagem no sprite colocado por cima
                nearestSlot.item = currentItem; // seta o slot mais perto no item atual
                itemList[nearestSlot.index] = currentItem; // preenche a lista de item pra rastrear oque cada slot contem oque

                currentItem = null;
                CheckForCompleteRecipes();
            }
        }
    }
    public void CheckForCompleteRecipes()
    {
        resultsSlots.gameObject.SetActive(false); // desativa o ResultSlot que fica o resultado das coisas
        resultsSlots.item = null;

        string currentRecipesString =  "";
        foreach(Item item in itemList) // foreach dedicado a criar a string da receita e detectar qual receita e qual exemplo : woodwoodwoodwood = club
        {
            if(item != null)
            {
                currentRecipesString += item.itemName; 
            }
            else
            {
                currentRecipesString += "null";
            }

            for(int i = 0; i < recipes.Length; i++) // for dedicado pra verificar se a receita que foi feita e igual a uma receita "valida"
            {
                if(recipes[i] == currentRecipesString) // criou a receita
                {
                    resultsSlots.gameObject.SetActive(true);
                    resultsSlots.GetComponent<Image>().sprite = recipesResults[i].GetComponent<Image>().sprite;
                    resultsSlots.item = recipesResults[i];
                }
            }
        }
    }
    public void OnClickedSlot(Slot slot) // retira qualquer item que esta no craft simplesmente clicando nele
    {
        slot.item = null; // seta aquele slot pra Null
        itemList[slot.index] = null; // retira o item da lista
        slot.gameObject.SetActive(false); // desativa a Imagem
        CheckForCompleteRecipes(); // checa dnv se tem alguma receita completa
    }
    public void OnMouseDownItem(Item item) // Drag-In-Drop System
    {
        if(currentItem == null) // verifica se nao esta dando drag-in-drop
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }
    }
}
