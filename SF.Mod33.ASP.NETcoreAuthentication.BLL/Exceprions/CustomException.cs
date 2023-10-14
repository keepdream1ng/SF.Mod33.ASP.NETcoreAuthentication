using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod33.ASP.NETcoreAuthentication.BLL;

public class CustomException : Exception
{
    public CustomException(string message): base(message)
    {
    }
}
