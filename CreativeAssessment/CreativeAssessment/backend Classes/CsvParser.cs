using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using CreativeAssessment.backend_Classes.Entities;
using CreativeAssessment.backendClasses.Entities;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace CreativeAssessment
{
    public class CsvParser
    {
        /// <summary>
        /// Parses the stream to student list.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <returns></returns>
        public List<CsvMappingResult<Student>> ParseStreamToStudentList(Stream fileStream)
        {
            var streamReader = new StreamReader(fileStream);
            var fileString = streamReader.ReadToEnd();

            var csvParserOptions = new CsvParserOptions(true, ',');
            var csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });

            var csvMapper = new CsvStudentMapping();
            var csvParser = new CsvParser<Student>(csvParserOptions, csvMapper);
            return csvParser.ReadFromString(csvReaderOptions, fileString).ToList();

        }

        /// <summary>
        /// Maps csv fields to Student object
        /// </summary>
        /// <seealso cref="CsvMapping{CreativeAssessment.Student}" />
        private class CsvStudentMapping : CsvMapping<Student>
        {
            public CsvStudentMapping() : base()
            {
                MapProperty(0, x => x.Name);
                MapProperty(1, x => x.Surname);
                //ID is empty at the moment but if we need to map in the future it's here
                // MapProperty(2, x => x.ID);
                MapProperty(3, x => x.MatriculationNumber, new Int32Converter());
                MapProperty(4, x => x.Email);
                MapProperty(5, x => x.LastDownloadedCsv, new Int32Converter());
                MapProperty(6, x => x.Marked, new BoolConverter("1", "0", StringComparison.InvariantCulture));
            }
        }



        /// <summary>
        /// Parses the stream to detailed feedback list.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <returns></returns>
        public List<CsvMappingResult<DetailedFeedback>> ParseStreamToDetailedFeedbackList(Stream fileStream)
        {
            var streamReader = new StreamReader(fileStream);
            var fileString = streamReader.ReadToEnd();

            var csvParserOptions = new CsvParserOptions(true, ',');
            var csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });

            var csvMapper = new CsvDetailedFeedbackMapping();
            var csvParser = new CsvParser<DetailedFeedback>(csvParserOptions, csvMapper);
            return csvParser.ReadFromString(csvReaderOptions, fileString).ToList();

        }

        /// <summary>
        /// Maps csv fields to DetailedFeedback object
        /// </summary>
        /// <seealso cref="CsvMapping{CreativeAssessment.DetailedFeedback}" />
        private class CsvDetailedFeedbackMapping : CsvMapping<DetailedFeedback>
        {
            public CsvDetailedFeedbackMapping() : base()
            {
                MapProperty(0, x => x.ID, new Int32Converter());
                MapProperty(1, x => x.Criterion);
                MapProperty(2, x => x.APlus);
                MapProperty(3, x => x.A);
                MapProperty(4, x => x.AMinus);
                MapProperty(5, x => x.BPlus);
                MapProperty(6, x => x.B);
                MapProperty(7, x => x.BMinus);
                MapProperty(8, x => x.CPlus);
                MapProperty(9, x => x.C);
                MapProperty(10, x => x.CMinus);
                MapProperty(11, x => x.DPlus);
                MapProperty(12, x => x.D);
                MapProperty(13, x => x.DMinus);
                MapProperty(14, x => x.E);
                MapProperty(15, x => x.F);
            }
        }
    }
}
