using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    [Header("Prefabs dos Objetos")]
    public Transform woodPrefab;
    public Transform steelPrefab;

    [Header("Sprites dos Objetos")]
    public Sprite swordSprite;
    public Sprite hammerSprite;
    public Sprite spearSprite;
    public Sprite woodSprite;
    public Sprite steelSprite;

}
