using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    public interface IOperations
    {
        void Add();
        void Delete();
        void Update();
        void List();
        void Search();
    }
}