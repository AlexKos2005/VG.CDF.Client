using System;
using VG.CDF.Client.Application.Enums;

namespace VG.CDF.Client.Application.Dto
{ 
   public class ParameterValueDto
    {
        public Guid ParameterValuesGroupId { get; set; }
        
        public int ParameterExternalId { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации в UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public string Value { get; set; } = String.Empty;

        public ParameterValueType ValueType { get; set; }
        
    }
}
