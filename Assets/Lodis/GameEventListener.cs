using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Lodis
{
    delegate void Actions();
    public class GameEventListener:MonoBehaviour,IListener
    {
        [SerializeField]
        private UnityEvent<object,object,object,object> _actions;
        [SerializeField]
        private Event _event;
        [SerializeField]
        private GameObject _intendedSender;

        // Use this for initialization
        void Start()
        {
            _event.AddListener(this);
        }

        public void Invoke(Object Sender, object[] args)
        {
            if(_intendedSender == null)
            {
                _actions.Invoke(args[0], args[1], args[2], args[3]);
                return;
            }
            else if(_intendedSender == Sender)
            {
                _actions.Invoke(args[0], args[1], args[2], args[3]);
                return;
            }
        }
    }
}
