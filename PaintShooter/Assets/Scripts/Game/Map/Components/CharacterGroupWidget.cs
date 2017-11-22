using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Map.Components
{
    public enum CharacterSide
    {
        Up,
        Down,
        Left,
        Right
    }

    public class CharacterGroupWidget : BaseMonoBehaviour
    {
        [SerializeField]
        private List<Animator> _animators;

        private Dictionary<CharacterSide, int> _sides = new Dictionary<CharacterSide, int>();

        protected override void Awake()
        {
            base.Awake();
            
            _sides.Add(CharacterSide.Down, Animator.StringToHash("Down"));
            _sides.Add(CharacterSide.Up, Animator.StringToHash("Up"));
            _sides.Add(CharacterSide.Left, Animator.StringToHash("Left"));
            _sides.Add(CharacterSide.Right, Animator.StringToHash("Right"));
        }
        
        public void SetSide(CharacterSide side)
        {
            for (int i = 0; i < _animators.Count; i++)
            {
                _animators[i].SetTrigger(_sides[side]);
            }
        }
    }
}
