using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class HealthTipItemCreateDto
    {
        public string Text { get; set; }
        public int HealthTipId {  get; set; }
       
    }
}
