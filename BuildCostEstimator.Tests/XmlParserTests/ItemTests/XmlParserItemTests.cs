﻿using BuildCostEstimator.BuildFileProcessor.Parsers;
using BuildCostEstimator.Tests.XmlParser.ItemTests;
using Xunit;

namespace BuildCostEstimator.Tests.XmlParserTests.ItemTests
{
    public class XmlParserItemTests
    {

        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnNameFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            NameParser parser = new NameParser();
            string expected = testCase.Item.Name;

            // Act
            string actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnBaseTypeFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            BaseTypeParser parser = new BaseTypeParser();
            string expected = testCase.Item.BaseType;

            // Act
            string actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnRarityFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            RarityParser parser = new RarityParser();
            string expected = testCase.Item.Rarity;

            // Act
            string actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnSocketsFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            SocketsParser parser = new SocketsParser();
            string expected = testCase.Item.Sockets;

            // Act
            string actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnInfluencesFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            InfluencesParser parser = new InfluencesParser();
            string expected = testCase.Item.Influences;

            // Act
            string actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnPobItemIdFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            PobItemIdParser parser = new PobItemIdParser();
            int expected = testCase.Item.PobItemId;

            // Act
            int actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnItemLevelFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            ItemLevelParser parser = new ItemLevelParser();
            int expected = testCase.Item.ItemLevel;

            // Act
            int actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(XmlParserItemTestData))]
        public void Parse_ShouldReturnLevelReqFromItemXml(ItemXmlHelper testCase)
        {
            // Arrange
            LevelReqParser parser = new LevelReqParser();
            int expected = testCase.Item.LevelReq;

            // Act
            int actual = parser.Parse(testCase.Xml);

            // Assert
            Assert.Equal(expected, actual);
        }


    }
}
