using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Context
{
    public interface IContext
    {
        void ExecuteQuery(string query);
    }
}
