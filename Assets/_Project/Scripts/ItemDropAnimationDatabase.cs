using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDropAnimationDatabase", menuName = "ScriptableObjects/ItemDropAnimationDatabase")]
public class ItemDropAnimationDatabase : ScriptableObject
{

    [SerializeField] private List<ItemDropAnimationData> itemDropAnimationData;

    public List<Vector3> GetWaypoints(int waypointIndex)
    {
        if (waypointIndex >= 0 && waypointIndex < itemDropAnimationData.Count)
        {
            return itemDropAnimationData[waypointIndex].waypoints;
        }
        else
        {
            Debug.LogWarning("Invalid waypoint index.");
            return new List<Vector3>();
        }
    }

    public List<Vector3> GetScale(int waypointIndex)
    {
        if (waypointIndex >= 0 && waypointIndex < itemDropAnimationData.Count)
        {
            return itemDropAnimationData[waypointIndex].scale;
        }
        else
        {
            Debug.LogWarning("Invalid waypoint index.");
            return new List<Vector3>();
        }
    }
}
[Serializable]
public struct ItemDropAnimationData
{
    public List<Vector3> waypoints;
    public List<Vector3> scale;
}