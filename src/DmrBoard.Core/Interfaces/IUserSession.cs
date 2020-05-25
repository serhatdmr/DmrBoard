using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Core.Interfaces
{
    public interface IUserSession
    {
        string Name { get; }
        string UserId { get; }
        bool IsAuthenticated();
    }
}
