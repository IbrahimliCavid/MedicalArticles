using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class HealthTipItem : BaseEntity
    {
        public string Text {  get; set; }
        public int HealthTipId {  get; set; }

        public virtual HealthTip HealthTip { get; set; }
    }
}
