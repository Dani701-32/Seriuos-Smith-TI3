using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePaph;
    private DataBaseObject dataBase;
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable()
    {
        //Funiona apenas no editor da Unity
#if UNITY_EDITOR
        dataBase = (DataBaseObject)AssetDatabase.LoadAssetAtPath("Assets/Objects/Resources/Database.asset", typeof(DataBaseObject)); //Encontra o local onde o arquivo está sendo salvo
//Funciona Apenas na Build
#else
        dataBase = Resources.Load<DataBaseObject>("Database"); 
#endif
    }
    public void AddItem(ItemObject item, int amount)
    {
        foreach (InventorySlot slot in Container)
        {
            if (slot.item == item)
            {
                slot.AddAmout(amount);
                return;
            }

        }
        Container.Add(new InventorySlot(dataBase.GetId[item], item, amount));
    }
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true); //Converte esse objeto para um arquivo JSON
        BinaryFormatter binaryFormatter = new BinaryFormatter(); // Cria um formatador para Binario
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePaph)); //Define a roda para qual oarquivo sempre será salvo
        binaryFormatter.Serialize(file, saveData);// Converte o arquivo File com a informação savedata para Binario
        file.Close();//Fecha o arquivo
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePaph)))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter(); //Cria um conversos binario
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePaph), FileMode.Open); //Abre o arquivo no local desginado
            JsonUtility.FromJsonOverwrite(binaryFormatter.Deserialize(file).ToString(), this); //Converte o arquivo de um Json para esse arquivo normal
            file.Close();
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
            Container[i].item = dataBase.GetItem[Container[i].ID];

    }
    public void OnBeforeSerialize()
    {

    }

}
[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;
    public InventorySlot(int ID, ItemObject item, int amount)
    {
        this.ID = ID;
        this.item = item;
        this.amount = amount;
    }

    public void AddAmout(int value)
    {
        amount += value;
    }
}