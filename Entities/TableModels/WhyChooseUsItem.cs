using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class WhyChooseUsItem : BaseEntity
    {
        public string Title {  get; set; }
        public string Description {  get; set; }
        public int WhyChooseUsId {  get; set; }
        public virtual WhyChooseUs WhyChooseUs { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
