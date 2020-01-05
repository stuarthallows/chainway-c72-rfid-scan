using System;
using System.Collections.Generic;
using System.Text;

namespace C72Scan.Services
{
    public interface IRfidService
    {
        bool StopInventory();

        bool Init();

        bool Free();
    }
}
