﻿using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl {  get; set; }
        public bool IsHomePage { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
