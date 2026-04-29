using System;
using System.Collections.Generic;
using System.Text;

namespace Ettevõtte_töötajate_haldussüsteem
{
    public interface ITootaja
    {
       public void TeeTood();
       public void EsitaAruanne();
        public double KalkuleeriPalk();
    }
}
