using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Services
{
    public interface IObserver
    {
        void Update(int index);
    }
}
