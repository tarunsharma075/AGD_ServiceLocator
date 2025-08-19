using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour,IDragHandler,IEndDragHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform monkeyTransform;
        private Vector3 origionalPosition;
        private Vector3 anchoredPosition;

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            monkeyTransform = GetComponent<RectTransform>();
            origionalPosition = monkeyTransform.localPosition;
            anchoredPosition = monkeyTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            monkeyTransform.anchoredPosition += eventData.delta;
            owner.MonkeyDraggedAt(monkeyTransform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ResetMonkey();
            owner.MonkeyDroppedAt(eventData.position);
        }

        private void ResetMonkey()
        {
            monkeyTransform.position = origionalPosition;
            monkeyTransform.anchoredPosition = anchoredPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
        }

        
    }
}