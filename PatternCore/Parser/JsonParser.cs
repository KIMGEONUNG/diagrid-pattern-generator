using Pattern.Core.System.DiagridSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pattern.Core.Parser
{
    public class JsonParser
    {
        public string ToJson(DiagridUnit unit)
        {
            return  JsonConvert.SerializeObject(unit);
        }
    }
}
