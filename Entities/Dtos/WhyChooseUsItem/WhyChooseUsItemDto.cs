using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class WhyChooseUsItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Deleted {  get; set; }
        public string Header {  get; set; }
        public string PhotoUrl {  get; set; }
        public DateTime CreatedDate { get; set; }
        public int WhyChooseUsId { get; set; }
        public virtual WhyChooseUs WhyChooseUs { get; set; }
    }
}
