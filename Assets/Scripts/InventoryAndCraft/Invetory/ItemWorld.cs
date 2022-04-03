using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpwanItemWorld(Vector3 position, Item item)
    {
        Transform t_item = item.GetTransform();
        Transform transform = Instantiate(t_item, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
    public static ItemWorld DropItem(Vector3 droPosition, Item item)
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1.2f, 1.2f), 1f, Random.Range(-1.2f, 1.2f));
        ItemWorld itemWorld = SpwanItemWorld((droPosition + randomDirection * 5f), item);
        itemWorld.GetComponent<Rigidbody>().AddForce(randomDirection * 5f, ForceMode.Impulse);
        return itemWorld;

    }
    private Item item;

    public void SetItem(Item item) { this.item = item; } //Recebe o item a ser criado

    public Item GetItem() { return this.item; } //Pega o item e manda para outro script


    public void DestroySelf() { Destroy(gameObject); }// autoexplicativo
}
