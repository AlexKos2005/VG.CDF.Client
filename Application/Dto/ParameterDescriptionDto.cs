
using System;

namespace VG.CDF.Client.Application.Dto
{
    public class ParameterDescriptionDto : EntityBaseDto
    {
        public string Description { get; set; }

        public Guid LanguageId { get; set; }

        public Guid ParameterId { get; set; }

    }
}
