using Core;
using System;
using UnityEngine;

namespace Game.Map
{
    public class InteractionHandler : BaseMonoBehaviour
    {
        public event Action OnClick;

        public void OnMouseUpAsButton()
        {
            if(OnClick != null)
            {
                OnClick();
            }
        }
        
    }
}
