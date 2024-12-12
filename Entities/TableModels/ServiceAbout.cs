using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class ServiceAbout : BaseEntity
    {
        public ServiceAbout()
        {
            ServiceAboutItems = new HashSet<ServiceAboutItem>();
        }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string PhotoUrl {  get; set; }
        public virtual ICollection<ServiceAboutItem> ServiceAboutItems { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
