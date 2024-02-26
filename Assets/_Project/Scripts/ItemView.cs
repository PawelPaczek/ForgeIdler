using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer itemSpriteRenderer;

    public void OnSpawn(Vector3 position,Transform parent,Sprite itemSprite)
    {
        gameObject.SetActive(true);
        gameObject.transform.parent = parent;
        transform.localPosition = position;
        itemSpriteRenderer.sprite = itemSprite;
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }
}
