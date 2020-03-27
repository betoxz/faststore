using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
