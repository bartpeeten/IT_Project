using KBVB.AR.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace KBVB.AR.Models
{
    public class CurrentChoosenPlayer : Player, ISubject
    {
        private List<IObserver> _observers;

        public CurrentChoosenPlayer()
        {
            _observers = new List<IObserver>();
        }

        public void NotifyObservers(int index)
        {
            foreach(IObserver ob in _observers)
            {
                Debug.WriteLine(index);
                ob.Update(index);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
