using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    
        public class Usuario
        {
            public Guid ID { get; set; }

            public string Nome { get; set; }

            public string Login { get; set; }

            public string Senha { get; set; }
        }
    
}
