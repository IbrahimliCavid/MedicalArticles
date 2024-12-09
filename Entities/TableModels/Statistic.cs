using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class Statistic : BaseEntity
    {
        public string Name { get; set; }    
        public string Icon { get; set; }
        public int Count {  get; set; }
    }
}
