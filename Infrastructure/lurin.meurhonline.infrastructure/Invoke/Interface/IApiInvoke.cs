using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

namespace lurin.meurhonline.infrastructure.invoke.interfaces
{
    public interface IApiInvoke
    {
        T PostReturn<T>(int colaboradorId);
    }
}