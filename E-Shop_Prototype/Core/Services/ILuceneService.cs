using System.Collections.Generic;
using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface ILuceneService
    {
        IEnumerable<LuceneDto> Search(string search, int take = 20);
        void AddSpecificationToIndex(List<Product> products);
    }
}