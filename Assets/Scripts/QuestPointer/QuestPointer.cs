using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPointer : MonoBehaviour
{
    [System.Serializable]
    public class QuestPointerPair
    {
        public Image img;
        public Transform target;
    }

    public List<QuestPointerPair> questPointers;

    void Update()
    {
        foreach (var pair in questPointers)
        {
            UpdatePointerPosition(pair.img, pair.target);
        }

    }

    void UpdatePointerPosition(Image img, Transform target)
    {
        if (target == null) //if berry is picked up
        {
            img.gameObject.SetActive(false);
            return;
        }

        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY-200); //so it doesnt "crash" into the HUD

        //distance from targets screen pos
        float distanceToTarget = Vector2.Distance(pos, (Vector2)Camera.main.WorldToScreenPoint(target.position));

        // If pointer is close to target, hide
        if (distanceToTarget < 10f)  
        {
            img.gameObject.SetActive(false);
        }
        else
        {
            img.gameObject.SetActive(true); 
        }


        img.transform.position = pos;
    }
}