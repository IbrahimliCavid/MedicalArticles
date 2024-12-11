using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class Language : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
