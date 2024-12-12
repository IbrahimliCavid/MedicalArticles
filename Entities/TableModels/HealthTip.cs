using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class HealthTip : BaseEntity
    {
        public HealthTip()
        {
            HealthTipItems = new HashSet<HealthTipItem>();
        }
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public string Header {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string SubTitle {  get; set; }
        public string PhotoUrl {  get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public ICollection<HealthTipItem> HealthTipItems { get; set; }
    }
}
