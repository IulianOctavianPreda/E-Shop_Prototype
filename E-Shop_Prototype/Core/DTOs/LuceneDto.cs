using System;

namespace Core.DTOs
{
    public class LuceneDto
    {
        public string IdInternal { get ; set; }
        public Guid Id => Guid.Parse(IdInternal);
        public float Score { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
    }
}