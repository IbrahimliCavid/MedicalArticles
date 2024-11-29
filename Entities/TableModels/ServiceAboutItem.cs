using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class ServiceAboutItem : BaseEntity
    {
        public string Text {  get; set; }
        public int ServiceAboutId {  get; set; }
        public ServiceAbout ServiceAbout { get; set; }
    }
}
