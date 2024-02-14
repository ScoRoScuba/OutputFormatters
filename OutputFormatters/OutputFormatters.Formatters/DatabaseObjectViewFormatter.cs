﻿using OutputFormatters.Model;
using System.Text;

namespace OutputFormatters.Formatters
{
    public class DatabaseObjectViewFormatter
    {
        public string Format(View view)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"View: {view.Name}");

            foreach (var dependency in view.Dependencies)
            {
                stringBuilder.Append($"{Environment.NewLine}\tTable: {dependency.Name}");
            }

            return stringBuilder.ToString();
        }
    }
}