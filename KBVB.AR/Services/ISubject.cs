using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Services
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers(int index);
    }
}
