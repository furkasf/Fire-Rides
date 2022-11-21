using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IBallGrapple
    {
        public GrappleController Controller { get; set; }
    }
}
