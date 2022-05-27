using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lodis
{
    [CreateAssetMenu(menuName = "Event")]
    public class Event : ScriptableObject
    {
        private List<IListener> _listeners = new List<IListener>();


        [SerializeField]
        private object[] _args = new object[4];

        public static Event CreateInstance(object[] args)
        {
            Event newEvent = CreateInstance<Event>();

            newEvent._args = args;

            return newEvent;
        }

        public void AddListener(IListener newListener)
        {
            _listeners.Add(newListener);
        }

        public void Raise(GameObject sender, object[] args = null)
        {
            foreach(IListener listener in _listeners)
            {
                listener.Invoke(sender, args);
            }
        }

        public void Raise(object[] args = null)
        {
            foreach (IListener listener in _listeners)
            {
                listener.Invoke(null, args);
            }
        }
    }
}
