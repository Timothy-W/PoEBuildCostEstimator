﻿using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{
    /// <summary>
    /// Parses XElement for base type of item.
    /// </summary>
    /// <param name="element">XElement with item tag.</param>
    /// <returns>Base type of item as string.</returns>
    public class IsCorruptedParser : IntParser
    {
        public override int Parse(XElement element)
        {
            var eleSplitByLine = element.Value.Trim().Split("\n").Select(x => x.Trim()).ToArray();

            return eleSplitByLine.Any(x => x == "Corrupted") ? 1 : 0;
        }

    }
}
