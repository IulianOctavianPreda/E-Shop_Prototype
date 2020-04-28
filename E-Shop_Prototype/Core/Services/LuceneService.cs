using System;
using System.Collections.Generic;
using System.Linq;
using Core.Database;
using Core.DTOs;
using Core.Models;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Search;

namespace Core.Services
{
    public class LuceneService : ILuceneService
    {
        private IndexWriter _writer;
        // Ensures index backwards compatibility
        private const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private const string IndexLocation = "./Assets/Specifications/Index";

        public LuceneService()
        {
            CreateIndex();
            //AddSpecificationToIndex();
        }

        public void CreateIndex()
        {
            var dir = FSDirectory.Open(IndexLocation);
            //create an analyzer to process the text
            var analyzer = new StandardAnalyzer(AppLuceneVersion);
            //create an index writer
            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            _writer = new IndexWriter(dir, indexConfig);
        }

        public void AddToIndex(Guid id, string name, string data)
        {
            var source = new
            {
                Id = id.ToString(),
                Name = name,
                Data = data
            };
            var doc = new Document
            {
                // StringField indexes but doesn't tokenize
                new StringField("id",source.Id,Field.Store.YES),
                new TextField("name",source.Name,Field.Store.YES),
                new TextField("data",source.Data,Field.Store.YES),
            };

            _writer.AddDocument(doc);
            _writer.Flush(triggerMerge: false, applyAllDeletes: false);
        }

        //public void AddSpecificationToIndex()
        //{
        //    var files = System.IO.Directory.GetFiles("./Assets/Specifications", "*.pdf");
        //    foreach (var file in files)
        //    {
        //        var name = file.Split('\\').Last().Split('.').First();
        //        AddToIndex(name, PdfReaderService.ExtractTextFromPdf(file));
        //    }
        //}

        public void AddSpecificationToIndex(List<Product> products)
        {
            foreach (var product in products)
            {
                AddToIndex(product.Id,product.Name, PdfReaderService.ExtractTextFromPdf(product.SpecificationFilePath));
            }
        }

        public IEnumerable<LuceneDto> Search(string search, int take = 20)
        {
            var lucene = new List<LuceneDto>();
            if (string.IsNullOrEmpty(search))
            {
                return lucene;
            }

            var phrase = new MultiPhraseQuery();
            foreach (var x in search.Split(' '))
            {
                phrase.Add(new Term("data", x));
            }

            var searcher = new IndexSearcher(_writer.GetReader(applyAllDeletes: true));
            var hits = searcher.Search(phrase, take).ScoreDocs;
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                lucene.Add(
                    new LuceneDto
                    {
                        Score = hit.Score,
                        IdInternal = foundDoc.Get("id"),
                        Name = foundDoc.Get("name"),
                        Data = foundDoc.Get("data")
                    }
                );

            }
            return lucene;
        }
    }
}
