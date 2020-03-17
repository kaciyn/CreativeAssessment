﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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
            var csvParser = new CsvParser<Student>(csvParserOptions,csvMapper);
            return csvParser.ReadFromString(csvReaderOptions,fileString).ToList();

        }

        /// <summary>
        /// Maps csv fields to Student object
        /// </summary>
        /// <seealso cref="TinyCsvParser.Mapping.CsvMapping{CreativeAssessment.Student}" />
        private class CsvStudentMapping : CsvMapping<Student>
        {
            public CsvStudentMapping() :base()
            {
                MapProperty(0, x => x.Name);
                MapProperty(1, x => x.Surname);
                //ID is empty at the moment but if we need to map in the future it's here
                // MapProperty(2, x => x.ID);
                MapProperty(3, x => x.MatriculationNumber,new Int32Converter());
                MapProperty(4, x => x.Email);
                MapProperty(5, x => x.LastDownloadedCsv, new Int32Converter());
                MapProperty(6, x => x.Marked, new BoolConverter("1","0",StringComparison.InvariantCulture));
            }
        }

    }
}
