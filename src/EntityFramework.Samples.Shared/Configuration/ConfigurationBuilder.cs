using Conditions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntityFramework.Samples.Shared.Configuration
{
    public class ConfigurationBuilder
    {
        private string _fileName = "appsettings.json";
        private string _filePath;
        public ConfigurationBuilder FileName(string fileName)
        {
            _fileName = fileName;
            return this;
        }

        public ConfigurationBuilder FilePath(string filePath)
        {
            _filePath = filePath;
            return this;
        }

        public IConfiguration Build()
        {
            Validate();
            IConfigurationBuilder builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(_filePath, _fileName));
            return builder.Build();
        }

        private void Validate()
        {
            Condition.Requires(_fileName, "fileName")
            .IsNotNullOrWhiteSpace("FileName must be specified.")
            .EndsWith(".json", "Configuration file must be .json format");

            Condition.Requires(_filePath, "filePath")
            .IsNotNullOrWhiteSpace("FilePath must be specified.");
        }
    }
}
